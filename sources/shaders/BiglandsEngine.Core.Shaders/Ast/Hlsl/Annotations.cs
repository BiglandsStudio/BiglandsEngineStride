// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using BiglandsEngine.Core.Shaders.Visitor;

namespace BiglandsEngine.Core.Shaders.Ast.Hlsl
{
    /// <summary>
    /// An Annotations.
    /// </summary>
    public partial class Annotations : PostAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Annotations"/> class.
        /// </summary>
        public Annotations()
        {
            Variables = new List<Variable>();
        }

        /// <summary>
        /// Gets or sets the variable.
        /// </summary>
        /// <value>
        /// The variable.
        /// </value>
        public List<Variable> Variables { get; set; }
    }
}
