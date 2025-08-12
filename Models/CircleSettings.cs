using Avalonia.Media;
using System.ComponentModel;

namespace MyTestOne.Models;

public class CircleSettings : ShapeSettings
{
    private double _scaleX = 1.0;
    public double ScaleX
    {
        get => _scaleX;
        set
        {
            _scaleX = value;
            OnPropertyChanged(nameof(ScaleX));
        }
    }

    private double _scaleY = 1.0;
    public double ScaleY
    {
        get => _scaleY;
        set
        {
            _scaleY = value;
            OnPropertyChanged(nameof(ScaleY));
        }
    }
}