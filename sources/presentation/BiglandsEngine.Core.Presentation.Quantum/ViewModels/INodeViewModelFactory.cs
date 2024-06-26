// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using BiglandsEngine.Core.Annotations;
using BiglandsEngine.Core.Presentation.Quantum.Presenters;

namespace BiglandsEngine.Core.Presentation.Quantum.ViewModels
{
    public interface INodeViewModelFactory
    {
        [NotNull]
        NodeViewModel CreateGraph([NotNull] GraphViewModel owner, [NotNull] Type rootType, [NotNull] IEnumerable<INodePresenter> rootNodes);

        void GenerateChildren([NotNull] GraphViewModel owner, NodeViewModel parent, [NotNull] List<INodePresenter> nodePresenters);
    }
}
