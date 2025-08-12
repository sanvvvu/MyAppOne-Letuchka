using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Data; // Добавлено для AvaloniaPropertyChangedEventArgs
using MyTestOne.Models;
using MyTestOne.Services;

namespace MyTestOne.Views;

public partial class ShapeView : UserControl
{
    public ShapeView()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ShapeSettings> ShapeSettingsProperty =
        AvaloniaProperty.Register<ShapeView, ShapeSettings>(nameof(ShapeSettings));

    public static readonly StyledProperty<ShapeType> ShapeTypeProperty =
        AvaloniaProperty.Register<ShapeView, ShapeType>(nameof(ShapeType));

    public ShapeSettings ShapeSettings
    {
        get => GetValue(ShapeSettingsProperty);
        set => SetValue(ShapeSettingsProperty, value);
    }

    public ShapeType ShapeType
    {
        get => GetValue(ShapeTypeProperty);
        set => SetValue(ShapeTypeProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == ShapeSettingsProperty || change.Property == ShapeTypeProperty)
        {
            if (ShapeSettings != null)
            {
                Content = ShapeRenderer.RenderShape(ShapeSettings, ShapeType);
            }
        }
    }
}