// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Windows.Markup;
using BiglandsEngine.Core.Annotations;

namespace BiglandsEngine.Core.Presentation.MarkupExtensions
{
    [MarkupExtensionReturnType(typeof(int))]
    public sealed class MaxIntExtension : MarkupExtension
    {
        [NotNull]
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return int.MaxValue;
        }
    }
}
