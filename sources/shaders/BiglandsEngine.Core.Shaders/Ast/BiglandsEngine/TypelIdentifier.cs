// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using BiglandsEngine.Core.Shaders.Ast;

namespace BiglandsEngine.Core.Shaders.Ast.BiglandsEngine
{
    public partial class TypeIdentifier : Identifier
    {
        public TypeIdentifier()
        {
        }

        public TypeIdentifier(TypeBase type)
            : base(type.ToString())
        {
            Type = type;
        }

        public TypeBase Type { get; set; }
    }
}
