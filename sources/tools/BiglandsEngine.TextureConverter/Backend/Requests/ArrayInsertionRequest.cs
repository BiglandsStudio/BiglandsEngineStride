// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;

namespace BiglandsEngine.TextureConverter.Requests
{
    /// <summary>
    /// Request to insert a specific texture in a texture array.
    /// </summary>
    class ArrayInsertionRequest : IRequest
    {
        public override RequestType Type { get { return RequestType.ArrayInsertion; } }

        /// <summary>
        /// The indice where to place the new texture.
        /// </summary>
        public int Indice { get; private set; }


        /// <summary>
        /// The new texture.
        /// </summary>
        public TexImage Texture { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayInsertionRequest"/> class.
        /// </summary>
        /// <param name="texture">The new texture.</param>
        /// <param name="name">The indice where to place the new texture.</param>
        public ArrayInsertionRequest(TexImage texture, int indice)
        {
            Texture = texture;
            Indice = indice;
        }
    }
}
