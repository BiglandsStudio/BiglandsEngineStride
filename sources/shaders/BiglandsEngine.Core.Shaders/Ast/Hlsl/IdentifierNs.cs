// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;

namespace BiglandsEngine.Core.Shaders.Ast.Hlsl
{
    /// <summary>
    /// A C++ identifier with namespaces "::" separator
    /// </summary>
    public partial class IdentifierNs : CompositeIdentifier
    {
        /// <inheritdoc/>
        public override string Separator
        {
            get
            {
                return "::";
            }
        }
    }
}
