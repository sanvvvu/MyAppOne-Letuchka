using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace MyTestOne.Converters;

public class ShapeTypeToVisibilityConverter : IValueConverter
{
    public object? Convert(object? value, Type? targetType, object? parameter, CultureInfo? culture)
    {
        try
        {
            if (value == null || parameter == null) 
                return false;

            var currentShape = value.ToString();
            var expectedShape = parameter.ToString();

            if (string.IsNullOrEmpty(currentShape)) 
                return false;

            return string.Equals(
                currentShape,
                expectedShape,
                StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    public object? ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo? culture)
    {
        throw new NotSupportedException("Обратное преобразование не поддерживается");
    }
}
