using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Enmiteer;

public partial class Channel : UserControl
{
    public Channel()
    {
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);

        App.OnHotReload += () =>
        {
            this.Find<TextBlock>("hashTag").Foreground =
                Theme.HexToBrush(App.CurrentTheme.semanticColors.CHANNEL_ICON[App.LightTheme ? 0 : 1]);
            
            this.Find<TextBlock>("channelName").Foreground =
                Theme.HexToBrush(App.CurrentTheme.semanticColors.INTERACTIVE_HOVER[App.LightTheme ? 0 : 1]);
        };
    }
}