# Third-Party Notices

ue5-mmd-toolkit uses the following third-party software.

| Software | Use in ue5-mmd-toolkit | License |
|---|---|---|
| [Avalonia 11.2.3](https://github.com/AvaloniaUI/Avalonia) | Import window UI | MIT |
| [SkiaSharp 2.88.9 / Skia](https://github.com/mono/SkiaSharp) | Avalonia rendering backend | MIT / BSD 3-Clause |
| [HarfBuzzSharp 7.3.0.3 / HarfBuzz](https://github.com/harfbuzz/harfbuzz) | Text shaping used by Avalonia | MIT / Old MIT |
| [ANGLE 2.1.22045](https://github.com/google/angle) | Translates Avalonia's graphics calls to Direct3D on Windows | BSD 3-Clause |
| [Microsoft .NET Runtime 9](https://github.com/dotnet/runtime) | Native AOT runtime for the import window | MIT |
| [Bullet Physics SDK](https://github.com/bulletphysics/bullet3) | PMX rigid-body and joint simulation | zlib |
| [FFmpeg 7.1.1, Gyan.dev essentials build](https://www.gyan.dev/ffmpeg/builds/) | Video and media conversion used by the MetaHuman workflow | GPL v3 |
| [VRM4U](https://github.com/ruyo/VRM4U) | Optional material and animation integration; not bundled | MIT |
| [UE-MMD-Camera-Importer](https://github.com/noname0310/UE-MMD-Camera-Importer) | Reference implementation for the VMD camera importer | MIT, Copyright (c) 2023 noname0310 |

The Avalonia UI distribution includes `libSkiaSharp.dll`, `libHarfBuzzSharp.dll`, and `av_libglesv2.dll`.

The bundled FFmpeg executables report `--enable-gpl --enable-version3` and are therefore distributed under GPL v3. Their complete build configuration can be displayed with `ffmpeg -version`.

Copyright notices and license terms are provided by each linked upstream project. FFmpeg source and license information for the bundled build are available from the linked Gyan.dev distribution page.
