using Avalonia;

namespace FinTrack;

internal class Program
{
    public static void Main(string[] args) =>
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()   // Detecta automaticamente Windows/Linux/Mac
            .LogToTrace();         // Logging para debug
}