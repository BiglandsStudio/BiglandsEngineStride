// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using BiglandsEngine.Core.Presentation.Extensions;

namespace BiglandsEngine.Core.Presentation.Behaviors
{
    public class ChangeCursorOnSliderThumbBehavior : DeferredBehaviorBase<Slider>
    {
        protected override void OnAttachedAndLoaded()
        {
            var thumb = AssociatedObject.FindVisualChildOfType<Thumb>();
            if (thumb != null)
                thumb.Cursor = Cursors.SizeWE;

            base.OnAttachedAndLoaded();
        }
    }
}
