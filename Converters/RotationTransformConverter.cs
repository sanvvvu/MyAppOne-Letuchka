using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace MyTestOne.Converters;

public class RotationTransformConverter : IValueConverter
{
    public static readonly RotationTransformConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double angle)
        {
            return new RotateTransform(angle);
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
