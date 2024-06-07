// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Sean Boettger <sean@whypenguins.com>
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;
using BiglandsEngine.Core;
using BiglandsEngine.Shaders;
using BiglandsEngine.Rendering.Materials;

namespace BiglandsEngine.Rendering.Voxels
{
    [DataContract(DefaultMemberMode = DataMemberMode.Default)]
    [Display("Float32")]
    public class VoxelFragmentPackFloat32 : IVoxelFragmentPacker
    {
        ShaderSource source = new ShaderClassSource("VoxelFragmentPackFloat32");
        public ShaderSource GetShader()
        {
            return source;
        }
        public int GetBits(int channels)
        {
            return channels * 32;
        }
    }
}
