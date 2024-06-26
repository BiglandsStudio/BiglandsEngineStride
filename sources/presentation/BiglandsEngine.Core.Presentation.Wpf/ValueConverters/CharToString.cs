// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Globalization;
using BiglandsEngine.Core.Annotations;

namespace BiglandsEngine.Core.Presentation.ValueConverters
{
    /// <summary>
    /// This converter will convert a <see cref="char"/> value to a string containing only this char.
    /// </summary>
    public class CharToString : ValueConverterBase<CharToString>
    {
        /// <inheritdoc/>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is char ? value.ToString() : string.Empty;
        }

        /// <inheritdoc/>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            if (!string.IsNullOrEmpty(str))
                return str[0];

            return targetType == typeof(char) ? (object)default(char) : null;
        }
    }
}
