// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using BiglandsEngine.Core.Shaders.Ast;

namespace BiglandsEngine.Core.Shaders.Ast.BiglandsEngine
{
    public partial class LiteralIdentifier : Identifier
    {
        public LiteralIdentifier()
        {
        }

        public LiteralIdentifier(Literal valueName)
            : base(valueName.ToString())
        {
            Value = valueName;
        }


        public Literal Value { get; set; }
    }
}
