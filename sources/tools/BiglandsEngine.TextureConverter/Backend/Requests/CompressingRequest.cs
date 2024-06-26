// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiglandsEngine.TextureConverter.Requests
{
    /// <summary>
    /// Request to compress a texture to a specified format
    /// </summary>
    internal class CompressingRequest : IRequest
    {
        public override RequestType Type { get { return RequestType.Compressing; } }


        /// <summary>
        /// The format.
        /// </summary>
        public BiglandsEngine.Graphics.PixelFormat Format { get; private set; }

        /// <summary>
        /// Gets the quality.
        /// </summary>
        /// <value>The quality.</value>
        public TextureQuality Quality { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressingRequest"/> class.
        /// </summary>
        /// <param name="format">The compression format.</param>
        public CompressingRequest(BiglandsEngine.Graphics.PixelFormat format, TextureQuality quality = TextureQuality.Fast)
        {
            this.Format = format;
            this.Quality = quality;
        }
    }
}
