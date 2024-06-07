// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Collections.Generic;
using BiglandsEngine.Core.Presentation.Dirtiables;

namespace BiglandsEngine.Core.Presentation.Tests.Dirtiables
{
    public class SimpleDirtiable : IDirtiable
    {
        public bool IsDirty { get; private set; }

        public IEnumerable<IDirtiable> Yield()
        {
            yield return this;
        }

        public void UpdateDirtiness(bool value)
        {
            IsDirty = value;
        }
    }
}
