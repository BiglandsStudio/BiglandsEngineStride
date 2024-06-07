// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using BiglandsEngine.Core.Shaders.Ast;

namespace BiglandsEngine.Core.Shaders.Ast.BiglandsEngine
{
    /// <summary>
    /// A structure.
    /// </summary>
    public partial class VarType : TypeBase, IDeclaration, IScopeContainer
    {
        #region Constructors and Destructors
        /// <summary>
        ///   Initializes a new instance of the <see cref = "StructType" /> class.
        /// </summary>
        public VarType() : base("var")
        {
        }

        #endregion
    }
}
