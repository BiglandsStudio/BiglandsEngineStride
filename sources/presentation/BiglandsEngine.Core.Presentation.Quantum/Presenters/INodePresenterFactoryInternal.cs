// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using BiglandsEngine.Core.Annotations;
using BiglandsEngine.Core.Quantum;

namespace BiglandsEngine.Core.Presentation.Quantum.Presenters
{
    public interface INodePresenterFactoryInternal : INodePresenterFactory
    {
        IReadOnlyCollection<INodePresenterCommand> AvailableCommands { get; }

        void CreateChildren([NotNull] IInitializingNodePresenter parentPresenter, IObjectNode objectNode, [CanBeNull] IPropertyProviderViewModel propertyProvider);
    }
}
