using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Enmiteer;

public partial class ServerIcon : UserControl
{
    public ServerIcon()
    {
        InitializeComponent();
    }
    
    

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        
        App.OnHotReload += () =>
        {
            this.Find<Border>("border").Background =
                Theme.HexToBrush(App.CurrentTheme.semanticColors.BACKGROUND_SECONDARY[App.LightTheme ? 0 : 1]);
        };
    }
}