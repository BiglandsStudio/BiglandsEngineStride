// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Sean Boettger <sean@whypenguins.com>
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;
using BiglandsEngine.Core;
using BiglandsEngine.Shaders;
using BiglandsEngine.Rendering.Materials;
using BiglandsEngine.Core.Annotations;

namespace BiglandsEngine.Rendering.Voxels
{
    [DataContract(DefaultMemberMode = DataMemberMode.Default)]
    [Display("Filtered")]
    public class VoxelStorageMethodIndirect : IVoxelStorageMethod
    {
        [NotNull]
        public IVoxelFragmentPacker TempStorageFormat { get; set; } = new VoxelFragmentPackFloatR11G11B10();
        [NotNull]
        public IVoxelBufferWriter Filter { get; set; } = new VoxelBufferWriteMax();

        public void Apply(ShaderMixinSource mixin)
        {
            var writermixin = new ShaderMixinSource();
            writermixin.Mixins.Add((ShaderClassSource)TempStorageFormat.GetShader());
            writermixin.AddComposition("writer", Filter.GetShader());
            mixin.AddComposition("writer", writermixin);
        }

        public int PrepareLocalStorage(VoxelStorageContext context, IVoxelStorage storage, int channels, int layoutCount)
        {
            return storage.RequestTempStorage(TempStorageFormat.GetBits(channels) * layoutCount);
        }
    }
}
