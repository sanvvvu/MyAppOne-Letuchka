using Avalonia.Media;
using System.ComponentModel;

namespace MyTestOne.Models;

public class RectangleSettings : ShapeSettings
{
    private double _width = 200;
    public double Width
    {
        get => _width;
        set
        {
            _width = value;
            OnPropertyChanged(nameof(Width));
        }
    }

    private double _height = 150;
    public double Height
    {
        get => _height;
        set
        {
            _height = value;
            OnPropertyChanged(nameof(Height));
        }
    }

    private double _rotation;
    public double Rotation
    {
        get => _rotation;
        set
        {
            _rotation = value;
            OnPropertyChanged(nameof(Rotation));
        }
    }
}