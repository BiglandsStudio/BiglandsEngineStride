// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BiglandsEngine.Core.Extensions;

namespace BiglandsEngine.Core.Presentation.ValueConverters
{
    public class Take : OneWayValueConverter<Take>
    {
        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return value;

            var count = ConverterHelper.TryConvertToInt32(parameter, culture);
            return count.HasValue ? value.ToEnumerable<object>().Take(count.Value) : value;
        }
    }
}
