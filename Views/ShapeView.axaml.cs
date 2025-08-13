using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using MyTestOne.Models;
using MyTestOne.Services;

namespace MyTestOne.Views;

public class ShapeView : UserControl
{
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

    public ShapeView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == ShapeSettingsProperty || change.Property == ShapeTypeProperty)
        {
            UpdateContent();
        }
    }

    private void UpdateContent()
    {
        if (ShapeSettings != null)
        {
            Content = ShapeRenderer.RenderShape(ShapeSettings, ShapeType);
        }
        else
        {
            Content = null;
        }
    }
}
