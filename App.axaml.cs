using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MyTestOne.ViewModels;
using MyTestOne.Views;

namespace MyTestOne;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Создаем главное окно вручную
            var mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel();
            desktop.MainWindow = mainWindow;
            
            // Показываем окно
            mainWindow.Show();
        }
        
        base.OnFrameworkInitializationCompleted();
    }
}
