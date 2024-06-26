// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

namespace BiglandsEngine.Core.Presentation.Themes
{
    public enum ThemeType
    {
        // Dark themes
        [Display("Expression Dark (Default)")]
        ExpressionDark,
        [Display("Dark Steel")]
        DarkSteel,
        [Display("Divided")]
        Divided,

        // Light themes
        [Display("Light Steel Blue (Experimental)")]
        LightSteelBlue,
    }

    public static class ThemeTypeExtensions
    {
        public static IconThemeSelector.ThemeBase GetThemeBase(this ThemeType themeType)
        {
            switch (themeType)
            {
                case ThemeType.ExpressionDark:
                case ThemeType.DarkSteel:
                case ThemeType.Divided:
                default:
                    return IconThemeSelector.ThemeBase.Dark;


                case ThemeType.LightSteelBlue:
                    return IconThemeSelector.ThemeBase.Light;
            }
        }
    }
}
