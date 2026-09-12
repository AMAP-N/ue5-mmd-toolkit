"""
Dump Control Rig hierarchy (control shape / settings / transforms) to JSON.

Run inside the Unreal Editor:
  Window > Output Log > (cmd dropdown) Python  ->  paste one line:
      exec(open(r"<path to this file>").read())
  or via Tools > Execute Python Script.

Edit RIG_PATHS below if the asset paths differ. Output JSON files are written
next to each asset ( <AssetName>_hierarchy.json ) and a combined file to
%TEMP%/control_rig_hierarchy_dump.json .
"""
import json
import os
import unreal

RIG_PATHS = [
    "/Game/test/model/2/Rig/CRMMD_YYB_Hatsune_Miku_NT_1_0ver",
    "/Game/test/model/SoueRin_260909/Rig/CRMMD_Black2",
    "/Game/test/model/YYB/Rig/CRMMD_YYB_Kagamine_Rin_Future",
]


def vec(v):
    return [float(v.x), float(v.y), float(v.z)]


def quat(q):
    return [float(q.x), float(q.y), float(q.z), float(q.w)]


def xform(t):
    return {
        "location": vec(t.translation),
        "rotation_quat": quat(t.rotation),
        "rotation_euler": vec(t.rotation.euler()),
        "scale": vec(t.scale3d),
    }


def linear_color(c):
    return [float(c.r), float(c.g), float(c.b), float(c.a)]


def dump_rig(path):
    blueprint = unreal.load_asset(path)
    if blueprint is None:
        unreal.log_warning("Could not load %s" % path)
        return None

    hierarchy = blueprint.get_hierarchy()  # URigHierarchy
    controller = blueprint.get_hierarchy_controller()

    out = {"asset": path, "controls": [], "bones": [], "nulls": [], "curves": []}

    for key in hierarchy.get_all_keys():
        etype = str(key.type)
        name = str(key.name)
        parent = hierarchy.get_first_parent(key)
        parent_name = str(parent.name) if parent and str(parent.name) != "None" else ""
        parent_type = str(parent.type) if parent and str(parent.name) != "None" else ""

        entry = {
            "name": name,
            "type": etype,
            "parent": parent_name,
            "parent_type": parent_type,
        }

        try:
            entry["global_transform"] = xform(
                hierarchy.get_global_transform(key, initial=True)
            )
            entry["local_transform"] = xform(
                hierarchy.get_local_transform(key, initial=True)
            )
        except Exception as exc:  # noqa
            entry["transform_error"] = str(exc)

        if "Control" in etype:
            try:
                s = hierarchy.get_control_settings(key)  # FRigControlSettings
                entry["control"] = {
                    "animation_type": str(s.animation_type),
                    "control_type": str(s.control_type),
                    "display_name": str(s.display_name),
                    "shape_name": str(s.shape_name),
                    "shape_visible": bool(s.shape_visible),
                    "shape_color": linear_color(s.shape_color),
                    "is_curve": bool(getattr(s, "is_curve", False)),
                    "draw_limits": bool(getattr(s, "draw_limits", False)),
                    "primary_axis": str(getattr(s, "primary_axis", "")),
                }
            except Exception as exc:  # noqa
                entry["control_settings_error"] = str(exc)

            try:
                entry["shape_transform"] = xform(
                    hierarchy.get_control_shape_transform(key, initial=True)
                )
            except Exception as exc:  # noqa
                try:
                    entry["shape_transform"] = xform(
                        hierarchy.get_control_shape_transform(key)
                    )
                except Exception as exc2:  # noqa
                    entry["shape_transform_error"] = "%s / %s" % (exc, exc2)

            try:
                entry["offset_transform"] = xform(
                    hierarchy.get_control_offset_transform(key, initial=True)
                )
            except Exception as exc:  # noqa
                entry["offset_transform_error"] = str(exc)

            out["controls"].append(entry)
        elif "Bone" in etype:
            out["bones"].append(entry)
        elif "Null" in etype:
            out["nulls"].append(entry)
        elif "Curve" in etype:
            out["curves"].append(entry)

    return out


def main():
    combined = []
    for path in RIG_PATHS:
        data = dump_rig(path)
        if data is None:
            continue
        combined.append(data)

        sys_path = unreal.SystemLibrary.get_system_path(unreal.load_asset(path))
        if sys_path:
            json_path = os.path.splitext(sys_path)[0] + "_hierarchy.json"
        else:
            json_path = os.path.join(
                unreal.Paths.project_saved_dir(),
                os.path.basename(path) + "_hierarchy.json",
            )
        with open(json_path, "w", encoding="utf-8") as fh:
            json.dump(data, fh, ensure_ascii=False, indent=2)
        unreal.log("Wrote %s (%d controls)" % (json_path, len(data["controls"])))

    tmp = os.path.join(
        os.environ.get("TEMP", unreal.Paths.project_saved_dir()),
        "control_rig_hierarchy_dump.json",
    )
    with open(tmp, "w", encoding="utf-8") as fh:
        json.dump(combined, fh, ensure_ascii=False, indent=2)
    unreal.log("Wrote combined dump: %s" % tmp)


main()
