using System;
using Avalonia;
using System.IO;

namespace MyTestOne;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            // Создаем лог-файл
            File.WriteAllText("startup.log", "Запуск приложения...");
            
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }
        catch (Exception ex)
        {
            // Записываем критическую ошибку
            File.WriteAllText("critical_error.log", $"КРИТИЧЕСКАЯ ОШИБКА:\n{ex}");
        }
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace(); // Включаем подробное логирование
}
