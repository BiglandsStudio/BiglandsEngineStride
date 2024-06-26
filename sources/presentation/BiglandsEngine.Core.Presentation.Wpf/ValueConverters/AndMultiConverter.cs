// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using BiglandsEngine.Core.Annotations;
using BiglandsEngine.Core.Presentation.Internal;

namespace BiglandsEngine.Core.Presentation.ValueConverters
{
    public class AndMultiConverter : OneWayMultiValueConverter<AndMultiConverter>
    {
        [NotNull]
        public override object Convert([NotNull] object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                throw new InvalidOperationException("This multi converter must be invoked with at least two elements");

            var fallbackValue = parameter is bool && (bool)parameter;
            var result = values.All(x => x == DependencyProperty.UnsetValue ? fallbackValue : (bool)x);
            return result.Box();
        }
    }
}
