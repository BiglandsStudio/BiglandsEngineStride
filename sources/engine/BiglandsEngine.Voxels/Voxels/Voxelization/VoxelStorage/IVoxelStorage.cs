// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Sean Boettger <sean@whypenguins.com>
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using BiglandsEngine.Graphics;
using BiglandsEngine.Shaders;

namespace BiglandsEngine.Rendering.Voxels
{
    public interface IVoxelStorage
    {
        void UpdateFromContext(VoxelStorageContext context);
        void CollectVoxelizationPasses(ProcessedVoxelVolume data, VoxelStorageContext storageContext);
        
        int RequestTempStorage(int count);
        void UpdateTexture(VoxelStorageContext context, ref IVoxelStorageTexture texture, BiglandsEngine.Graphics.PixelFormat pixelFormat, int layoutSize);
        void UpdateTempStorage(VoxelStorageContext context);
        void PostProcess(VoxelStorageContext context, RenderDrawContext drawContext, ProcessedVoxelVolume data);
    }
}
