// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using BiglandsEngine.Core.Shaders.Ast;

namespace BiglandsEngine.Core.Shaders.Ast.BiglandsEngine
{
    public partial class SemanticType : TypeBase, IDeclaration, IScopeContainer, IGenericStringArgument
    {
        #region Constructors and Destructors
        /// <summary>
        ///   Initializes a new instance of the <see cref = "SemanticType" /> class.
        /// </summary>
        public SemanticType() : base("Semantic")
        {
        }

        #endregion
    }
}
