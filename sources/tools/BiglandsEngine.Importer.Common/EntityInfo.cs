// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.Collections.Generic;
using BiglandsEngine.Assets.Materials;

namespace BiglandsEngine.Importer.Common
{
    public class EntityInfo
    {
        public List<string> TextureDependencies;
        public Dictionary<string, MaterialAsset> Materials;
        public List<string> AnimationNodes;
        public List<MeshParameters> Models;
        public List<NodeInfo> Nodes;
    }
}
