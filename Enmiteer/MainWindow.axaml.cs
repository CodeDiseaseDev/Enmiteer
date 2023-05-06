using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Enmiteer;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        App.OnHotReload += () =>
        {
            var channelList =
                Theme.HexToBrush(App.CurrentTheme.semanticColors.BACKGROUND_MOBILE_SECONDARY[App.LightTheme ? 0 : 1]);
            
            //var chatBackground =
           //     Theme.HexToBrush(App.CurrentTheme.semanticColors.chat[App.LightTheme ? 0 : 1]);
            
            var mainBackground =
                Theme.HexToBrush(App.CurrentTheme.semanticColors.BACKGROUND_TERTIARY[App.LightTheme ? 0 : 1]);

            MainBackground.Background = mainBackground;
            ChannelList.Background = channelList;
            MessageList.Background = channelList;
        };
    }

    // public Brush BACKGROUND_MOBILE_PRIMARY
    // {
    //     set
    //     {
    //         ChannelList.Background = value;
    //         MessageList.Background = value;
    //     }
    // }

    public bool ChannelListOpen
    {
        // this is messy, not too proud of this one...
        
        get
        {
            var gridValue = ChannelListMessageListGrid.ColumnDefinitions[0].Width;
            return gridValue.Value == 1 && gridValue.IsStar;
        }
        set
        {
            ChannelListMessageListGrid.ColumnDefinitions[0].Width =
                value ? new GridLength(1,GridUnitType.Star) : new GridLength(0,GridUnitType.Pixel);
            
            ChannelListMessageListGrid.ColumnDefinitions[1].Width =
                value ? new GridLength(50,GridUnitType.Pixel) : new GridLength(1,GridUnitType.Star);
        }
    }

    private async void LoadThemeTest(object? sender, RoutedEventArgs e)
    {
        string theme = await App.Current.Clipboard.GetTextAsync();
        App.CurrentTheme = await Theme.LoadFromUrl(theme);
        App.HotReloadTheme();
    }

    private void MessagesAreaBurgerButton(object? sender, PointerPressedEventArgs e)
    {
        ChannelListOpen = !ChannelListOpen;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        App.LightTheme = !App.LightTheme;
        App.HotReloadTheme();
    }
}