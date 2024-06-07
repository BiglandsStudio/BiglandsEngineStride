// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Collections.Generic;

namespace BiglandsEngine.Core.Shaders.Ast
{
    public interface IAttributes
    {
        List<AttributeBase> Attributes { get; set; }
    }
}
