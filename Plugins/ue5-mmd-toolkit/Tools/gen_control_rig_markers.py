"""
Generate ControlRigFKMarkers.inl from a Control Rig hierarchy dump.

Input : control_rig_hierarchy_dump.json  (produced by dump_control_rig_hierarchy.py;
        element [0] = Miku, the canonical reference)
Output: Source/AMAP5_Importer/Private/ControlRigFKMarkers.inl

The .inl is a brace-init list of FPmxMarker (see Rig.cpp). One row per hierarchy
element (controls + nulls), ordered parent-before-child so Rig.cpp can resolve
parents in a single forward pass.

Body / limb / finger / IK controls carry a BoneAlias and are placed at that bone
at generation time (model-adaptive). Face-panel elements carry an explicit
parent-local offset taken from the reference.
"""
import json
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
PLUGIN = os.path.dirname(HERE)
DUMP = sys.argv[1] if len(sys.argv) > 1 else next(
    (p for p in (
        os.path.join(HERE, "control_rig_hierarchy_dump.json"),
        os.path.join(os.environ.get("TEMP", "."), "control_rig_hierarchy_dump.json"),
    ) if os.path.exists(p)),
    os.path.join(HERE, "control_rig_hierarchy_dump.json"))
OUT = os.path.join(PLUGIN, "Source", "AMAP5_Importer", "Private", "ControlRigFKMarkers.inl")
BONE_MAP_JSON = os.path.join(HERE, "control_bone_map.json")
PINDEFAULTS_INL = os.path.join(PLUGIN, "Source", "AMAP5_Importer", "Private", "ControlRigFKPinDefaults.inl")

# controls whose shape scale tracks model size (== dist(上半身,首) / divisor)
MODEL_SCALED = {
    "CTRL_Spine": 8.0, "CTRL_Chest": 8.0, "CTRL_Neck": 8.0,
    "CTRL_LegIK_L": 16.0, "CTRL_LegIK_R": 16.0,
}


def enum_tail(s):
    # "<RigControlType.EULER_TRANSFORM: 9>" -> "EULER_TRANSFORM"
    if isinstance(s, str) and s.startswith("<") and ":" in s:
        return s.split(".", 1)[1].split(":")[0].strip()
    return s or ""


def load_control_bone_map():
    """CTRL_* -> PMX bone name (first alias)."""
    return json.load(open(BONE_MAP_JSON, encoding="utf-8"))


def load_face_curve_names():
    """slider index -> MMD morph/curve name, from ControlRigFKPinDefaults.inl."""
    import re
    m = {}
    for line in open(PINDEFAULTS_INL, encoding="utf-8"):
        mm = re.search(r'MMD_Face_Forward_SetCurve_(\d+)\.Curve"\),\s*TEXT\("([^"]+)"\)', line)
        if mm:
            m[int(mm.group(1))] = mm.group(2)
    return m


def c_arr(vals, n):
    vals = list(vals) + [0.0] * n
    return "{ " + ", ".join("%.6f" % float(v) for v in vals[:n]) + " }"


def c_str(s):
    return 'TEXT("%s")' % s.replace("\\", "\\\\").replace('"', '\\"')


def main():
    data = json.load(open(DUMP, encoding="utf-8"))
    miku = data[0]
    bone_map = load_control_bone_map()
    curve_names = load_face_curve_names()

    by_name = {}
    for c in miku["controls"]:
        by_name[c["name"]] = ("Control", c)
    for nll in miku["nulls"]:
        by_name[nll["name"]] = ("Null", nll)

    def gofs(name):
        kind, e = by_name[name]
        if kind == "Control":
            return e.get("offset_global") or e.get("global_initial")
        return e.get("global_initial")

    # topological order: parents first
    ordered = []
    seen = set()

    def visit(name):
        if name in seen or name not in by_name:
            return
        _, e = by_name[name]
        p = e.get("parent") or ""
        if p and p in by_name and p not in seen:
            visit(p)
        seen.add(name)
        ordered.append(name)

    for c in miku["controls"] + miku["nulls"]:
        visit(c["name"])

    rows = []
    for name in ordered:
        kind, e = by_name[name]
        parent = e.get("parent") or ""
        settings = e.get("settings", {}) if kind == "Control" else {}
        ctype = enum_tail(settings.get("control_type", "")) or "NULL"
        atype = enum_tail(settings.get("animation_type", "")) or "ANIMATION_CONTROL"
        shape = settings.get("shape_name", "Default") or "Default"
        color = settings.get("shape_color", [1, 1, 1, 1])
        shape_visible = 1 if settings.get("shape_visible", True) else 0
        prim = enum_tail(settings.get("primary_axis", "X")) or "X"

        sl = e.get("shape_local", {}) if kind == "Control" else {}
        s_loc = sl.get("loc", [0, 0, 0])
        s_quat = sl.get("quat", [0, 0, 0, 1])
        s_scale = sl.get("scale", [1, 1, 1])

        bone = bone_map.get(name, "")
        # parent-local offset: bone rows leave it zero (runtime places at bone);
        # non-bone rows take offset relative to parent from the reference.
        off_loc = [0.0, 0.0, 0.0]
        off_quat = [0.0, 0.0, 0.0, 1.0]
        off_scale = [1.0, 1.0, 1.0]
        if not bone:
            if kind == "Null":
                li = e.get("local_initial", {})
                off_loc = li.get("loc", [0, 0, 0])
                off_quat = li.get("quat", [0, 0, 0, 1])
                off_scale = li.get("scale", [1, 1, 1])
            else:
                # Face-panel controls: parent-local offset = child global - parent global.
                # Translation-only; every panel element in the reference rigs has an
                # identity offset rotation, so no rotation term is emitted. Revisit if
                # a future reference rotates the panel.
                g = gofs(name)
                gp = gofs(parent) if parent in by_name else None
                if g and gp:
                    off_loc = [g["loc"][i] - gp["loc"][i] for i in range(3)]
                elif g:
                    off_loc = list(g["loc"])

        model_scaled = MODEL_SCALED.get(name, 0.0)

        display = ""
        if name.startswith("CTRL_Face_") and ctype == "FLOAT":
            try:
                idx = int(name.rsplit("_", 1)[1])
                display = curve_names.get(idx, "")
            except ValueError:
                pass

        rows.append(
            "    { %s, %s, %s, EPmxMarkerKind::%s, EPmxMarkerCtrl::%s, EPmxMarkerAnim::%s,\n"
            "      %s, %d, EPmxMarkerAxis::%s, %s /*color rgba*/,\n"
            "      %s /*shape loc*/, %s /*shape quat xyzw*/, %s /*shape scale*/,\n"
            "      %s /*offset loc*/, %s /*offset quat xyzw*/, %s /*offset scale*/,\n"
            "      %s /*modelScaleDiv*/, %s /*displayName*/ }," % (
                c_str(name), c_str(parent), c_str(bone),
                "Null" if kind == "Null" else "Control",
                {"EULER_TRANSFORM": "EulerTransform", "ROTATOR": "Rotator",
                 "FLOAT": "Float", "NULL": "EulerTransform"}[ctype],
                {"ANIMATION_CONTROL": "Animation", "VISUAL_CUE": "VisualCue"}.get(atype, "Animation"),
                c_str(shape), shape_visible,
                {"X": "X", "Y": "Y", "Z": "Z"}.get(prim, "X"),
                c_arr(color, 4),
                c_arr(s_loc, 3), c_arr(s_quat, 4), c_arr(s_scale, 3),
                c_arr(off_loc, 3), c_arr(off_quat, 4), c_arr(off_scale, 3),
                "%.6f" % model_scaled,
                c_str(display) if display else "nullptr",
            )
        )

    header = (
        "// Generated by Tools/gen_control_rig_markers.py from CRMMD_* reference rigs.\n"
        "// %d elements (%d controls + %d nulls), parent-before-child order.\n"
        "// Columns: Name, Parent, BoneAlias, Kind, CtrlType, AnimType,\n"
        "//          ShapeName, ShapeVisible, PrimaryAxis, ShapeColor[4],\n"
        "//          ShapeLoc[3], ShapeQuat[4], ShapeScale[3],\n"
        "//          OffsetLoc[3], OffsetQuat[4], OffsetScale[3],\n"
        "//          ModelScaleDivisor (0 = use ShapeScale as-is), DisplayName (nullptr = use Name)\n"
        % (len(rows), len(miku["controls"]), len(miku["nulls"]))
    )
    with open(OUT, "w", encoding="utf-8") as fh:
        fh.write(header + "\n".join(rows) + "\n")
    print("wrote", OUT, "-", len(rows), "rows")


if __name__ == "__main__":
    main()
