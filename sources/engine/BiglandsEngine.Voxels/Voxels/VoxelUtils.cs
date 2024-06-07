// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Sean Boettger <sean@whypenguins.com>
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;
using BiglandsEngine.Core.Mathematics;
using BiglandsEngine.Graphics;

namespace BiglandsEngine.Rendering.Voxels
{
    static class VoxelUtils
    {
        public static bool DisposeBufferBySpecs(BiglandsEngine.Graphics.Buffer buf, int count)
        {
            if (buf == null || buf.ElementCount != count)
            {
                if (buf != null)
                    buf.Dispose();

                return true;
            }
            return false;
        }

        public static bool TextureDimensionsEqual(Texture tex, Vector3 dim)
        {
            return (tex.Width == dim.X &&
                    tex.Height == dim.Y &&
                    tex.Depth == dim.Z);
        }
        public static bool DisposeTextureBySpecs(BiglandsEngine.Graphics.Texture tex, Vector3 dim, BiglandsEngine.Graphics.PixelFormat pixelFormat)
        {
            if (tex == null || !TextureDimensionsEqual(tex, dim) || tex.Format != pixelFormat)
            {
                if (tex != null)
                    tex.Dispose();

                return true;
            }
            return false;
        }
        public static bool DisposeTextureBySpecs(BiglandsEngine.Graphics.Texture tex, Vector3 dim, BiglandsEngine.Graphics.PixelFormat pixelFormat, MultisampleCount samples)
        {
            if (tex == null || !TextureDimensionsEqual(tex, dim) || tex.Format != pixelFormat || tex.MultisampleCount != samples)
            {
                if (tex != null)
                    tex.Dispose();

                return true;
            }
            return false;
        }
    }
}
