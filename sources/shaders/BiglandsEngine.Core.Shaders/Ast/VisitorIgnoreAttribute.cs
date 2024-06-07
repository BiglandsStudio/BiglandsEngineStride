// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using BiglandsEngine.Core.Shaders.Visitor;

namespace BiglandsEngine.Core.Shaders.Ast
{
    /// <summary>
    /// Instruct a <see cref="ShaderVisitor"/> to ignore a field
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class VisitorIgnoreAttribute : Attribute
    {
    }
}
