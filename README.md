![ue5-mmd-toolkit](docs/images/ue5-mmd-toolkit.png)

[![Unreal Engine](https://img.shields.io/badge/Unreal%20Engine-5.8.x-0E1128?logo=unrealengine)](https://www.unrealengine.com/)
[![License](https://img.shields.io/github/license/AMAP-N/ue5-mmd-toolkit)](https://github.com/AMAP-N/ue5-mmd-toolkit/blob/main/LICENSE)
[![Platform](https://img.shields.io/badge/platform-Windows%20x64-blue)](#)
[![Release](https://img.shields.io/github/v/release/AMAP-N/ue5-mmd-toolkit)](https://github.com/AMAP-N/ue5-mmd-toolkit/releases)

[English](README.md)｜[日本語](README_ja.md)

## Overview
ue5-mmd-toolkit (AMAP5 V2) is a plugin for working with MMD-format PMX/VMD assets in Unreal Engine 5.

The PMX importer generates a Skeletal Mesh, Skeleton, Animation Blueprint, material instances, and more.
This plugin also serves as an extension toolset for bringing PMX assets into more advanced Unreal Engine workflows.
Unreal Engine is gaining attention as a real-time engine that's strong on both fronts — as a renderer for film/video work (with things like MCP support and MetaHuman Mocap) and as a graphics engine for games, including asset migration from DCC tools. This project aims to build out functionality that extends in both directions.

![ue5-mmd-toolkit](docs/images/thumbnail2.png)
model: Sour暄 / [rendered demo](https://youtu.be/5gckcH_7DNo)

> [!NOTE]
>- Because UE leans heavily toward being a renderer, export functionality is not a high implementation priority.
>- Detailed asset editing is better suited to a DCC tool, so this plugin is not intended to cover the entire pipeline by itself.
>- Material support is focused on semi-realistic to photo-realistic looks. (Toon/cel-shaded looks see little benefit from being rendered in UE, so they are not a focus.)


## Requirements
### System
- Unreal Engine 5.8.x, Launcher build
- Windows 11, 64-bit

The following are **not** supported:

- UE ≤ 5.7 / UE 5.9+
- Any engine other than a Launcher build — source-built engines from GitHub, studio-custom builds, etc.

### Plugins
- Required (ships with the engine; must be enabled)
  - IK Rig
  - Control Rig
  - Compute Framework
  - Deformer Graph
- Optional
  - VRM4U (bundled plugin; required only if you use the VRM4U material type)
  - MetaHuman / MetaHuman Animator (required only if you use MetaHuman Mocap)


## Highlights
*By "typical PMX/VMD import method" we mainly mean FBX conversion via a DCC tool.

| Feature | ue5-mmd-toolkit | How it differs from typical approaches |
|---|---|---|
| Vertex deformation | Preserved and auto-repaired via a GPU SDEF/QDEF blend through a Deformer Graph | UE has no native SDEF support, so FBX-conversion workflows usually lose SDEF data, breaking meshes that rely on SDEF vertices |
| Bone constraints | Append (parent-linked) rotation/translation, axis limits, and IK chains are solved live — without baking — by a dedicated AnimGraph node, "PMX Bone Solver" | Most methods only reproduce the look at the moment of baking; constraints don't follow motion swapped in afterward |
| Morphs | Vertex(V) / Bone(B) / Material(M) / Group(G) morphs are evaluated as morph curves by a dedicated AnimGraph node, "PMX Morph" (with cyclic-reference detection) | Group-morph weight distribution and bone-morph accumulation usually need to be implemented by hand |
| Rig generation | Generates an IK Rig plus a Control Rig with finger and facial controls, in one step | Normally you only get a bare skeleton; building the IK Rig / Control Rig is manual work |
| Physics | Rigid bodies and joints are interpreted through Bullet Physics and written directly into the Animation Blueprint's RigidBody node (rigid bodies can be clicked to select for in-editor debugging) | Jiggle physics for hair, skirts, etc. usually requires manually building a PhysicsAsset |
| Camera | Imported into Sequencer as camera actors/tracks, with a selectable camera-cut import type | Few importers handle camera motion. Ported and substantially reworked from noname0310's MmdCameraImporter, with focus-drift and other issues fixed |
| Mocap | Streamlines running MetaHuman Mocap; results can be reviewed via an SMPL model | Setting up mocap capture is normally a real hassle |


## Features
### Implemented
- PMX model import (generate a SkeletalMesh / Material type: UE Standard, UE Toon, etc. / white-texture fallback)
- Reproduces PMX bone constraints (append rotation/translation, axis limits, IK chains/links) — via the "PMX Bone Solver" AnimGraph node
- Physics (rigid body/joint) import (converted through Bullet Physics, written into the AnimBlueprint's RigidBody node, with in-editor debug display)
- Reproduces PMX morphs (vertex/bone/material/group) — via the "PMX Morph" AnimGraph node
- BDEF/SDEF/QDEF import and vertex-deformation computation
- IK Rig generation (full-body IK)
- Control Rig generation (FK controls, facial-morph control panel, etc.)
- VMD motion import (selectable frame rate)
- VMD camera import (adds camera actors/tracks to Sequencer, selectable camera-cut type)
- MetaHuman Animator markerless mocap integration (drop a video → runs body capture → outputs a Performance asset)
- External UI bridge, AMAP5.UI (Avalonia/.NET)

### Roadmap
- Control Rig (beta)
- IK Rig (beta)
- Retargeting MetaHuman Mocap results onto PMX


## Installation & Usage
1. Set up an Unreal Engine 5.8 (Win64) project.
2. In the Plugins window, confirm the following are enabled: IK Rig / Control Rig / Compute Framework / Deformer Graph.
3. (Optional) If you want to use VRM4U material types, place the bundled `Plugins/VRM4U` into your project's `Plugins` folder.
4. (Optional) If you want to use MetaHuman Mocap, enable the required plugins via `MetaHuman Animator Markerless Motion Capture (Check)`.
5. Place the `Plugins/ue5-mmd-toolkit` folder into your project's `Plugins` folder.
> [!TIP]
> With the optional pieces included, the final layout should look like this:
> ```text
> YourProject/                       (project root)
> ├─ YourProject.uproject
> └─ Plugins/
>   ├─ ue5-mmd-toolkit/            (this plugin)
>   │  └─ ue5-mmd-toolkit.uplugin  (keep this folder as-is under Plugins)
>   └─ VRM4U/                      (optional)
>      └─ VRM4U.uplugin            (keep this folder as-is under Plugins)
>```
6. Launch the project.
7. Drag and drop PMX/VMD files into the Content Browser to import them.
8. For additional imports, use the "ue5-mmd-toolkit" menu as needed.
9. For camera VMD, click the VMD icon in Sequencer to import.


## Disclaimer
This plugin is not affiliated with Epic Games, Unreal Engine, MikuMikuDance, or any other related company or organization.
The author accepts no responsibility for any damages resulting from use of this plugin, including but not limited to project/data corruption or rights issues related to imported models or motion data.

Verifying and complying with the copyright and usage terms of any PMX / VMD / video data you import is your own responsibility.
This software is provided "AS IS," without warranty of any kind, express or implied.


## License
MIT License

For third-party license information, see [THIRD_PARTY_NOTICES](LICENSES/THIRD_PARTY_NOTICES.md).


## Support & Contact
If you have questions or run into an issue, please open an Issue in this repository or contact the author directly.

AMAP-N [@Kapelz_](https://x.com/Kapelz_)
