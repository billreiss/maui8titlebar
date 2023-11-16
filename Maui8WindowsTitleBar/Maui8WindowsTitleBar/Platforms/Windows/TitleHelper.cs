using Microsoft.UI.Xaml;
using WinColor = Windows.UI.Color;

namespace Maui8WindowsTitleBar.Platforms.Windows
{
    public static class TitleHelper
    {
        static Microsoft.UI.Xaml.Controls.Grid? titleGrid = null;
        static Color? titlebarColor = null;
        public static bool GetIsTitleGrid(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsTitleGridProperty);
        }

        public static void SetIsTitleGrid(DependencyObject obj, bool value)
        {
            obj.SetValue(IsTitleGridProperty, value);
        }

        // Using a DependencyProperty as the backing store for TitleColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTitleGridProperty =
            DependencyProperty.RegisterAttached("IsTitleGrid", typeof(bool), typeof(TitleHelper), new PropertyMetadata(false, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Microsoft.UI.Xaml.Controls.Grid)
            {
                if ((bool)e.NewValue == true)
                {
                    titleGrid = d as Microsoft.UI.Xaml.Controls.Grid;
                    SetTitlebarColor(titlebarColor);
                }
            }
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
