using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Enmiteer;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    public delegate void ThemeHotReloadHandler();

    public static Theme CurrentTheme;
    public static event ThemeHotReloadHandler OnHotReload;
    public static bool LightTheme = false;

    public static void HotReloadTheme() => OnHotReload?.Invoke();
}