# Third-Party Notices

This file lists third-party software and source-code components identified in the provided AMAP5 source package.

| Library | License | URL |
|---|---|---|
| PMXImporter | MIT License | https://github.com/HaJH/PmxImporter |
| UE-MMD-Camera-Importer | MIT License | https://github.com/noname0310/UE-MMD-Camera-Importer |
| Bullet Physics SDK | zlib License | https://github.com/bulletphysics/bullet3 |

## PMXImporter

Project: PMXImporter for Unreal Engine  
Upstream: https://github.com/HaJH/PmxImporter  
Copyright: Copyright (c) 2025 Jeonghyeon Ha  
License: MIT License

Portions of the AMAP5 PMX importer/runtime code contain copyright notices for Jeonghyeon Ha and are derived from or based on PMXImporter.

MIT License

Copyright (c) 2025 Jeonghyeon Ha

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

## UE-MMD-Camera-Importer

Project: UE-MMD-Camera-Importer  
Upstream: https://github.com/noname0310/UE-MMD-Camera-Importer  
Copyright: Copyright (c) 2023 noname0310  
License: MIT License

The `MMDCameraImporter` module is based on the UE-MMD-Camera-Importer project.

MIT License

Copyright (c) 2023 noname0310

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

## Bullet Physics

Project: Bullet Physics SDK  
Upstream: https://github.com/bulletphysics/bullet3  
Website: https://bulletphysics.org  
License: zlib License

`PmxPhysics_Runtime.Build.cs` references Bullet source headers and the `BulletDynamics`, `BulletCollision`, and `LinearMath` libraries under `ThirdParty/BulletPhysicsEngineLibrary`. The referenced `ThirdParty` directory is not present in the provided archive, but the build integration explicitly depends on these Bullet libraries.

The files in the Bullet repository are licensed under the zlib license, except for files specifically marked otherwise in excluded/third-party areas of the upstream repository.

Bullet Continuous Collision Detection and Physics Library

This software is provided 'as-is', without any express or implied warranty.
In no event will the authors be held liable for any damages arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it freely,
subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
3. This notice may not be removed or altered from any source distribution.

## External platform and optional integrations

The provided source also references Unreal Engine modules and optional integrations such as MetaHuman and VRM4U. These components are external dependencies and are not included in the provided archive. Their applicable licenses and terms are therefore not reproduced in this file.
