// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.Windows.Media;
using BiglandsEngine.Core.Presentation.Drawing;

namespace BiglandsEngine.Core.Presentation.Themes
{
    public struct IconTheme
    {
        public IconTheme(string name, Color backgroundColor)
        {
            Name = name;
            BackgroundColor = backgroundColor;
        }

        public string Name { get; }

        public Color BackgroundColor { get; }

        public double BackgroundLuminosity => BackgroundColor.ToHslColor().Luminosity;

    }
}
