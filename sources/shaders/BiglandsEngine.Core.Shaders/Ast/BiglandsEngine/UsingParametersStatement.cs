// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Collections.Generic;

using BiglandsEngine.Core.Shaders.Ast;

namespace BiglandsEngine.Core.Shaders.Ast.BiglandsEngine
{
    /// <summary>
    /// A using params statement.
    /// </summary>
    public partial class UsingParametersStatement : Statement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public Expression Name { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public BlockStatement Body { get; set; }

        #region Public Methods

        /// <inheritdoc />
        public override IEnumerable<Node> Childrens()
        {
            ChildrenList.Clear();
            ChildrenList.Add(Name);
            ChildrenList.Add(Body);
            return ChildrenList;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("using params {0}{1}",  Name, Body != null ? " {...}" : string.Empty);
        }

        #endregion
    }
}
