using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace MyTestOne.Converters
{
    public class ShapeTypeToVisibilityConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (value is Models.ShapeType currentType && parameter is string expectedType)
            {
                return currentType.ToString() == expectedType;
            }
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo? culture)
        {
            throw new NotImplementedException();
        }
    }
}