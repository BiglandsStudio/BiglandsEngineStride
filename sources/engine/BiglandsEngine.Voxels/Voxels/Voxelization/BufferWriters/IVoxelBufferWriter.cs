// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Sean Boettger <sean@whypenguins.com>
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;
using BiglandsEngine.Shaders;
using BiglandsEngine.Rendering.Materials;

namespace BiglandsEngine.Rendering.Voxels
{
    public interface IVoxelBufferWriter
    {
        ShaderSource GetShader();
    }
}
