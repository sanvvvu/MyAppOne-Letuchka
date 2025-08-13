using Avalonia.Media;
using System.ComponentModel;

namespace MyTestOne.Models;

public class ShapeSettings : INotifyPropertyChanged
{
    private Color _shapeColor = Color.FromRgb(74, 134, 232);
    public Color ShapeColor
    {
        get => _shapeColor;
        set
        {
            _shapeColor = value;
            OnPropertyChanged(nameof(ShapeColor));
        }
    }

    private string _text = "Shape Editor";
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }

    private Color _textColor = Colors.White;
    public Color TextColor
    {
        get => _textColor;
        set
        {
            _textColor = value;
            OnPropertyChanged(nameof(TextColor));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
