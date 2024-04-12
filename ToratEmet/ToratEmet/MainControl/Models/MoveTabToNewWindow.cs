using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using ToratEmet.Controls;
using ToratEmet.Models;

namespace ToratEmet.Models
{
    public static class MoveTabToNewWindow
    {
        public static void Execute(TabItem tabItem, double width)
        {
            var tabContent = tabItem.Content;
            tabItem.Content= null;

            TabControl sourceTabControl = tabItem.Parent as TabControl;
            int sourceTabIndex = sourceTabControl.SelectedIndex;
            sourceTabControl.Items.Remove(tabItem);

            TabControlX tabControlX = new TabControlX();
            tabControlX.tabControl.Items.Add(tabItem);

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            TabsWindow window = new TabsWindow
            {
                FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                Content = tabControlX,
                FlowDirection = FlowDirection.RightToLeft,
                Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
                Width = width,
            };

            tabControlX.tabControl.SelectedIndex = 0;

            WordWindowOwner.SetOwner(window, null);
            window.Show();

            tabItem.Content = tabContent;
            if (sourceTabControl.Items.Count == 1)
            {
                sourceTabControl.SelectedIndex = 0;
            }
            else if (sourceTabControl.Items.Count > 1)
            {
                sourceTabControl.SelectedIndex = sourceTabIndex - 1;
            }
            
        }
    }

    public class TabsWindow : Window 
    {
        public TabsWindow() 
        {
            Closing +=TabsWindow_Closing;
        }

        private void TabsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Content is TabControlX tabControlX)
            {
                tabControlX.DisposeWebViews();
            }
        }
    }
}
