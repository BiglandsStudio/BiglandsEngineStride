// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.Collections.Generic;

namespace BiglandsEngine.Importer.Common
{
    public class MeshParameters
    {
        public string MaterialName;
        public string MeshName;
        public string NodeName;
        public HashSet<string> BoneNodes;
    }
}
