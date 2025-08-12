using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;

namespace MyTestOne;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        var builder = AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();

        // Установка иконки (новый способ)
        try
        {
            var icon = new WindowIcon("Assets/Letuchka.ico");
            builder.With(icon);
        }
        catch { /* Игнорируем ошибки */ }

        return builder;
    }
}