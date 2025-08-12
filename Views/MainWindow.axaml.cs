using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes; // Добавлено
using Avalonia.Diagnostics; // Добавлено для AttachDevTools

namespace MyTestOne.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
#if DEBUG
    // Упрощенная версия без DevTools
    if (Design.IsDesignMode)
    {
        this.InitializeComponent();
    }
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}