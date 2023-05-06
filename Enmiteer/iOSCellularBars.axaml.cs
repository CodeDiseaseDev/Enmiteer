using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Enmiteer;

public partial class iOSCellularBars : UserControl
{
    public iOSCellularBars()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}