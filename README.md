# ue5-mmd-toolkit (AMAP5 V2)
[![Unreal Engine](https://img.shields.io/badge/Unreal%20Engine-5.8.x-0E1128?logo=unrealengine)](https://www.unrealengine.com/)
[![License](https://img.shields.io/github/license/AMAP-N/ue5-mmd-toolkit)](https://github.com/AMAP-N/ue5-mmd-toolkit/blob/main/LICENSE)
[![Platform](https://img.shields.io/badge/platform-Windows%20x64-blue)](#)
[![Release](https://img.shields.io/github/v/release/AMAP-N/ue5-mmd-toolkit)](https://github.com/AMAP-N/ue5-mmd-toolkit/releases)

Unreal Engine 5でMMD形式データを扱うためのWindowsプラグインです。

![ue5-mmd-toolkit](docs/images/thumbnail2.png)
model: Sour暄 / [rendered demo](https://youtu.be/5gckcH_7DNo)

## 対応環境

- Epic Games Launcher版 Unreal Engine 5.8.x
- Windows 10 (22H2) / Windows 11, 64-bit

バイナリ配布のため、以下は利用できません。

- UE ≤ 5.7 / UE 5.9+
- GitHubからソースビルドしたエンジン、スタジオ独自ビルドなどランチャー版以外のエンジン

## 主な機能

- PMXモデルのインポート
- SDEF含むスキニング処理
- PMX IK、付与親、物理演算の対応
- VMDモーションおよびVMDカメラのインポート
- PMX向けの `UE Toon` / `UE Standard` マテリアル
- PMX用IK Rig / FK Control Rig の生成
- Post Process Animation Blueprint の生成（VRM4U 導入時のみ）
- VRM4Uマテリアルとの任意連携

## インストール

1. Unreal Editorを終了します。
2. このリポジトリの `Plugins/ue5-mmd-toolkit` フォルダを、使用するUnreal Engineプロジェクトの `Plugins` フォルダへコピーします。
3. 最終的な配置が次の構成になることを確認します。

```text
YourProject/
└─ Plugins/
   └─ ue5-mmd-toolkit/
      ├─ Binaries/
      ├─ Config/
      ├─ Content/
      ├─ Resources/
      ├─ Tools/
      └─ ue5-mmd-toolkit.uplugin
```

4. プロジェクトをランチャー版の Unreal Engine 5.8.x で開きます。
5. 必要に応じて「編集」>「プラグイン」から `ue5-mmd-toolkit` を有効にし、Editorを再起動します。

## 必須プラグイン

次のUnreal Engine標準プラグインを使用します。`ue5-mmd-toolkit` を有効にすると自動で有効化されます。

- Control Rig
- IK Rig
- Compute Framework
- Deformer Graph

手動で無効化されている場合は有効化し、Editorを再起動してください。

## 任意連携（VRM4U）

VRM4U は必須ではありません。`UE Toon` / `UE Standard`、PMXインポート、SDEF などの基本機能は VRM4U に依存しません。

VRM4U を同じ `Plugins` フォルダへ入れて有効化すると、次が使えます。

- `(VRM4U)` 表記の MToon 系マテリアル（マテリアルタイプの選択肢に追加されます）
- Post Process Animation Blueprint の生成（IK / 物理 / モーフのノード配線）

VRM4U が無い場合、`(VRM4U)` 表記のマテリアルタイプはインポート画面に表示されません。

## 基本的な使い方

PMXファイルをContent Browserへドラッグ＆ドロップし、表示されるインポート画面で設定を選択してインポートします。

マテリアルは次の用途を想定しています。

- `UE Toon`: MMDに近い見た目を目的とした、ue5-mmd-toolkit独自のマテリアル
- `UE Standard`: Unreal Engine標準のライティング環境へ移行しやすいマテリアル
- `(VRM4U)` 表記のマテリアル: VRM4Uが導入されている場合に使用する任意連携

---

## English

`ue5-mmd-toolkit` is a plugin for importing and using MikuMikuDance assets in Unreal Engine 5.

### Requirements

- **Epic Games Launcher build of Unreal Engine 5.8.x** (5.8.0 / 5.8.1 / 5.8.2, i.e. any 5.8 hotfix)
- Windows 10 (22H2) / Windows 11, 64-bit

This is a binary-only distribution with no source, so it does **not** work on UE 5.7 or earlier, UE 5.9 or later, or engines built from source.

### Install

Copy `Plugins/ue5-mmd-toolkit` into your project's `Plugins` directory, open the project with a Launcher build of UE 5.8.x, enable the plugin, and restart Unreal Editor. Control Rig, IK Rig, Compute Framework and Deformer Graph are enabled automatically.

Drop VRM4U into the same `Plugins` folder to unlock the optional MToon (VRM4U) material types and post-process AnimBP generation. Without VRM4U the `(VRM4U)` material types are hidden in the import dialog.
