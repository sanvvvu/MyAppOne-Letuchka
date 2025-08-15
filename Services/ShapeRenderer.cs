using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Controls.Shapes;
using MyTestOne.Models;
using MyTestOne.Converters;

namespace MyTestOne.Services;

public static class ShapeRenderer
{
    public static Control RenderShape(ShapeSettings settings, ShapeType type)
    {
        return type switch
        {
            ShapeType.Rectangle => RenderRectangle((RectangleSettings)settings),
            ShapeType.Circle => RenderCircle((CircleSettings)settings),
            _ => new TextBlock { Text = "Unknown shape" }
        };
    }

    private static Control RenderRectangle(RectangleSettings settings)
    {
        var textBlock = new TextBlock
        {
            FontSize = 24,
            FontWeight = FontWeight.Bold,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
            TextAlignment = Avalonia.Media.TextAlignment.Center,
            Padding = new Thickness(20)
        };
        
        textBlock[!TextBlock.TextProperty] = new Binding(nameof(settings.Text)) { Source = settings };
        textBlock[!TextBlock.ForegroundProperty] = new Binding(nameof(settings.TextColor)) { Source = settings, Converter = ColorToBrushConverter.Instance };

        var border = new Border
        {
            CornerRadius = new CornerRadius(8),
            BoxShadow = new BoxShadows(
                new BoxShadow { Blur = 10, OffsetX = 5, OffsetY = 5, Color = Color.FromArgb(100, 0, 0, 0) }
            ),
            Child = textBlock
        };

        border[!Border.WidthProperty] = new Binding(nameof(settings.Width)) { Source = settings };
        border[!Border.HeightProperty] = new Binding(nameof(settings.Height)) { Source = settings };
        border[!Border.BackgroundProperty] = new Binding(nameof(settings.ShapeColor)) { Source = settings, Converter = ColorToBrushConverter.Instance };
        border[!Visual.RenderTransformProperty] = new Binding(nameof(settings.Rotation)) { Source = settings, Converter = RotationTransformConverter.Instance };

        return border;
    }

    private static Control RenderCircle(CircleSettings settings)
    {
        var ellipse = new Ellipse
        {
            Width = 180,
            Height = 180,
        };

        ellipse[!Shape.FillProperty] = new Binding(nameof(settings.ShapeColor)) { Source = settings, Converter = ColorToBrushConverter.Instance };
        
        var scaleTransform = new ScaleTransform();
        scaleTransform[!ScaleTransform.ScaleXProperty] = new Binding(nameof(settings.ScaleX)) { Source = settings };
        scaleTransform[!ScaleTransform.ScaleYProperty] = new Binding(nameof(settings.ScaleY)) { Source = settings };
        ellipse.RenderTransform = scaleTransform;

        var textBlock = new TextBlock
        {
            FontSize = 24,
            FontWeight = FontWeight.Bold,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
        };
        
        textBlock[!TextBlock.TextProperty] = new Binding(nameof(settings.Text)) { Source = settings };
        textBlock[!TextBlock.ForegroundProperty] = new Binding(nameof(settings.TextColor)) { Source = settings, Converter = ColorToBrushConverter.Instance };

        var grid = new Grid();
        grid.Children.Add(ellipse);
        grid.Children.Add(textBlock);

        return grid;
    }
}
