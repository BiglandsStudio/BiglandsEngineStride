// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Sean Boettger <sean@whypenguins.com>
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using BiglandsEngine.Shaders;

namespace BiglandsEngine.Rendering.Voxels
{
    public interface IVoxelStorageMethod
    {
        void Apply(ShaderMixinSource mixin);
        int PrepareLocalStorage(VoxelStorageContext context, IVoxelStorage storage, int channels, int layoutCount);
    }
}
