// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Globalization;
using BiglandsEngine.Core.Presentation.Internal;

namespace BiglandsEngine.Core.Presentation.ValueConverters
{
    public class MatchType : OneWayValueConverter<MatchType>
    {
        /// <inheritdoc/>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            var result = ((Type)parameter).IsInstanceOfType(value);
            return result.Box();
        }
    }
}
