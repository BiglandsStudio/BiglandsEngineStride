// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Sean Boettger <sean@whypenguins.com>
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;

using BiglandsEngine.Core;
using BiglandsEngine.Core.Collections;
using BiglandsEngine.Core.Diagnostics;
using BiglandsEngine.Core.Mathematics;
using BiglandsEngine.Engine;
using BiglandsEngine.Shaders;
using BiglandsEngine.Graphics;
using BiglandsEngine.Rendering.Lights;
using BiglandsEngine.Rendering.Voxels;
using BiglandsEngine.Core.Extensions;
using BiglandsEngine.Rendering;

namespace BiglandsEngine.Rendering.Voxels
{
    public interface IVoxelizationMethod
    {
        void Reset();
        void CollectVoxelizationPasses(VoxelizationPassList passList, IVoxelStorer storer, Matrix view, Vector3 resolution, VoxelAttribute attr, VoxelizationStage stage, bool output, bool shadows);
        void Render(VoxelStorageContext storageContext, RenderDrawContext drawContext, RenderView view);

        bool RequireGeometryShader();
        int GeometryShaderOutputCount();

        ShaderSource GetVoxelizationShader();
        bool CanShareRenderStage(IVoxelizationMethod method);
    }
}