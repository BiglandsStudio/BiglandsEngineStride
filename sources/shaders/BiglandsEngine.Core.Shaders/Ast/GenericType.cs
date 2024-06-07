// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using BiglandsEngine.Core;

namespace BiglandsEngine.Core.Shaders.Ast
{
    /// <summary>
    /// Custom generic type.
    /// </summary>
    public partial class GenericType : GenericBaseType
    {
        public GenericType()
        {
        }

        public GenericType(string name, int parameterCount) : base(name, parameterCount)
        {
        }

        /// <inheritdoc/>
        [DataMember]
        public override List<Type> ParameterTypes { get; set; }

        /// <inheritdoc/>
        [DataMember]
        public override List<Node> Parameters { get; set; }
    }
}
