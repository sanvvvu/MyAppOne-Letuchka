using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Controls.Shapes;
using MyTestOne.Models;

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
        return new Border
        {
            Width = settings.Width,
            Height = settings.Height,
            Background = new SolidColorBrush(settings.ShapeColor),
            CornerRadius = new CornerRadius(8),
            RenderTransform = new RotateTransform(settings.Rotation),
            BoxShadow = new BoxShadows(
                new BoxShadow { Blur = 10, OffsetX = 5, OffsetY = 5, Color = Color.FromArgb(100, 0, 0, 0) }
            ),
            Child = new TextBlock
            {
                Text = settings.Text,
                FontSize = 24,
                FontWeight = FontWeight.Bold,
                Foreground = new SolidColorBrush(settings.TextColor),
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                TextAlignment = Avalonia.Media.TextAlignment.Center,
                Padding = new Thickness(20)
            }
        };
    }

    private static Control RenderCircle(CircleSettings settings)
    {
        // Используем Border для создания тени
        var border = new Border
        {
            Width = 180,
            Height = 180,
            BoxShadow = new BoxShadows(
                new BoxShadow { Blur = 10, OffsetX = 5, OffsetY = 5, Color = Color.FromArgb(100, 0, 0, 0) }
            ),
            Child = new Ellipse
            {
                Width = 180,
                Height = 180,
                Fill = new SolidColorBrush(settings.ShapeColor),
                RenderTransform = new ScaleTransform(settings.ScaleX, settings.ScaleY)
            }
        };

        var textBlock = new TextBlock
        {
            Text = settings.Text,
            FontSize = 24,
            FontWeight = FontWeight.Bold,
            Foreground = new SolidColorBrush(settings.TextColor),
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            Margin = new Thickness(0, 20, 0, 0)
        };

        var stackPanel = new StackPanel
        {
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
        };

        stackPanel.Children.Add(border);
        stackPanel.Children.Add(textBlock);

        return stackPanel;
    }
}
