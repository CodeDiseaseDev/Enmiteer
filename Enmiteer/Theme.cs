using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Media;
using Newtonsoft.Json;
using Brush = Avalonia.Media.Brush;
using Color = Avalonia.Media.Color;

namespace Enmiteer;

public class Author
{
    public string name { get; set; }
    public string id { get; set; }
}

public class Background
{
    public double? blur { get; set; }
    public string url { get; set; }
    public double? alpha { get; set; }
}

public class RawColors
{
    public string PRIMARY_DARK { get; set; }
    public string PRIMARY_100 { get; set; }
    public string PRIMARY_200 { get; set; }
    public string PRIMARY_300 { get; set; }
    public string PRIMARY_360 { get; set; }
    public string PRIMARY_400 { get; set; }
    public string PRIMARY_500 { get; set; }
    public string PRIMARY_600 { get; set; }
    public string PRIMARY_630 { get; set; }
    public string PRIMARY_660 { get; set; }
    public string PRIMARY_700 { get; set; }
    public string PRIMARY_800 { get; set; }
    public string BRAND_260 { get; set; }
    public string BRAND_360 { get; set; }
    public string BRAND_500 { get; set; }
    public string BRAND_560 { get; set; }
    public string BRAND_900 { get; set; }
    public string BRAND_NEW { get; set; }
    public string YELLOW_300 { get; set; }
    public string GREEN_360 { get; set; }
    public string DANGER { get; set; }
    public string RED_400 { get; set; }
}

public class Theme
{
    public string name { get; set; }
    public string description { get; set; }
    public List<Author> authors { get; set; } = new List<Author>();
    public int? spec { get; set; }
    public SemanticColors semanticColors { get; set; } = new SemanticColors();
    public RawColors rawColors { get; set; } = new RawColors();
    public Background background { get; set; } = new Background();
    public string color { get; set; }

    public static Brush HexToBrush(string hex)
    {
        hex = hex.Replace("#", "");
        string sr = hex.Substring(0, 2);
        string sg = hex.Substring(2, 2);
        string sb = hex.Substring(4, 2);
        
        byte r = (byte)Convert.ToInt32("0x"+sr, 16);
        byte g = (byte)Convert.ToInt32("0x"+sg, 16);
        byte b = (byte)Convert.ToInt32("0x"+sb, 16);
        
        return new SolidColorBrush(new Color(255, r, g, b));
    }

    public static async Task<Theme> LoadFromUrl(string url)
    {
        string str = await new HttpClient().GetStringAsync(new Uri(url));
        return JsonConvert.DeserializeObject<Theme>(str)!;
    }
}

public class SemanticColors
{
    public List<string> HEADER_PRIMARY { get; set; } = new List<string>();
    public List<string> HEADER_SECONDARY { get; set; } = new List<string>();
    public List<string> TEXT_NORMAL { get; set; } = new List<string>();
    public List<string> TEXT_MUTED { get; set; } = new List<string>();
    public List<string> INTERACTIVE_NORMAL { get; set; } = new List<string>();
    public List<string> INTERACTIVE_HOVER { get; set; } = new List<string>();
    public List<string> INTERACTIVE_ACTIVE { get; set; } = new List<string>();
    public List<string> INTERACTIVE_MUTED { get; set; } = new List<string>();
    public List<string> BACKGROUND_PRIMARY { get; set; } = new List<string>();
    public List<string> BACKGROUND_SECONDARY { get; set; } = new List<string>();
    public List<string> BACKGROUND_SECONDARY_ALT { get; set; } = new List<string>();
    public List<string> BACKGROUND_TERTIARY { get; set; } = new List<string>();
    public List<string> BACKGROUND_ACCENT { get; set; } = new List<string>();
    public List<string> BACKGROUND_FLOATING { get; set; } = new List<string>();
    public List<string> BACKGROUND_MOBILE_PRIMARY { get; set; } = new List<string>();
    public List<string> BACKGROUND_MOBILE_SECONDARY { get; set; } = new List<string>();
    public List<string> BACKGROUND_NESTED_FLOATING { get; set; } = new List<string>();
    public List<string> BACKGROUND_MESSAGE_HOVER { get; set; } = new List<string>();
    public List<string> BACKGROUND_MODIFIER_HOVER { get; set; } = new List<string>();
    public List<string> BACKGROUND_MODIFIER_ACTIVE { get; set; } = new List<string>();
    public List<string> BACKGROUND_MODIFIER_SELECTED { get; set; } = new List<string>();
    public List<string> BACKGROUND_MODIFIER_ACCENT { get; set; } = new List<string>();
    public List<string> SCROLLBAR_THIN_THUMB { get; set; } = new List<string>();
    public List<string> SCROLLBAR_THIN_TRACK { get; set; } = new List<string>();
    public List<string> SCROLLBAR_AUTO_THUMB { get; set; } = new List<string>();
    public List<string> SCROLLBAR_AUTO_TRACK { get; set; } = new List<string>();
    public List<string> CHANNEL_TEXT_AREA_PLACEHOLDER { get; set; } = new List<string>();
    public List<string> CHANNELTEXTAREA_BACKGROUND { get; set; } = new List<string>();
    public List<string> CHANNELS_DEFAULT { get; set; } = new List<string>();
    public List<string> TEXT_LINK { get; set; } = new List<string>();
    public List<string> KEYBOARD { get; set; } = new List<string>();
    public List<string> CHANNEL_ICON { get; set; } = new List<string>();
}

