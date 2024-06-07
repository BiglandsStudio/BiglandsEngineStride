// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BiglandsEngine.Graphics;

namespace BiglandsEngine.TextureConverter.Requests
{
    /// <summary>
    /// Request to export a texture to a BiglandsEngine <see cref="Image"/> instance.
    /// </summary>
    internal class ExportToBiglandsEngineRequest : IRequest
    {

        public override RequestType Type { get { return RequestType.ExportToBiglandsEngine; } }

        /// <summary>
        /// The BiglandsEngine <see cref="Image"/> which will contains the exported texture.
        /// </summary>
        public Image XkImage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportToBiglandsEngineRequest"/> class.
        /// </summary>
        public ExportToBiglandsEngineRequest()
        {
        }
    }
}
