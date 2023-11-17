using Microsoft.Maui.Graphics;
using Microsoft.UI.Xaml.Controls;
using WinColor = Windows.UI.Color;

namespace MauiWindowsTitlebar.Platforms.Windows
{
    public class TitleContainer : Microsoft.UI.Xaml.Controls.Grid
    {
        static TitleContainer? titleGrid = null;
        static Color? titlebarColor = null;
        static string? currentTitle = null;
        public TitleContainer() 
        {
            titleGrid = this;
            this.Loaded += TitleContainer_Loaded;
        }

        private void TitleContainer_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            SetTitlebarColor(titlebarColor);
            SetTitle(currentTitle);
        }

        public static void SetTitlebarColor(Microsoft.Maui.Graphics.Color? color)
        {
            if (color != null)
            {
                titlebarColor = color;
                if (titleGrid != null)
                {
                    titleGrid.Background = new Microsoft.UI.Xaml.Media.SolidColorBrush(ToWindowsColor(titlebarColor));
                }
            }
        }

        public static void SetTitle(string? title)
        {
            currentTitle = title;
            if (titleGrid != null && title != null)
            {
                var titleBlock = titleGrid.FindName("AppTitle") as TextBlock;
                if (titleBlock != null)
                {
                    titleBlock.Text = title;
                }
            }
        }

        public static WinColor ToWindowsColor(Microsoft.Maui.Graphics.Color color)
        {
            var a = (byte)(color.Alpha * 255);
            var r = (byte)(color.Red * 255);
            var g = (byte)(color.Green * 255);
            var b = (byte)(color.Blue * 255);
            return WinColor.FromArgb(a, r, g, b);
        }
    }
}
