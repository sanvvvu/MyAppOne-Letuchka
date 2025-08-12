using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
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
            RenderTransform = new RotateTransform(settings.Rotation),
            Child = new TextBlock
            {
                Text = settings.Text,
                Foreground = new SolidColorBrush(settings.TextColor),
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            }
        };
    }

    private static Control RenderCircle(CircleSettings settings)
    {
        var ellipse = new Ellipse
        {
            Width = 150,
            Height = 150,
            Fill = new SolidColorBrush(settings.ShapeColor),
            RenderTransform = new ScaleTransform(settings.ScaleX, settings.ScaleY)
        };

        var stackPanel = new StackPanel
        {
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
        };

        stackPanel.Children.Add(ellipse);
        stackPanel.Children.Add(new TextBlock
        {
            Text = settings.Text,
            Foreground = new SolidColorBrush(settings.TextColor),
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        });

        return stackPanel;
    }
}