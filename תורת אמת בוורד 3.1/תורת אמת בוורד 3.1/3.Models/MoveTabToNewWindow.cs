using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using תורת_אמת_בוורד_3._1._1.Controls;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public static class MoveTabToNewWindow
    {
        public static void Execute(TabItem tabItem)
        {
            var tabContent = tabItem.Content;
            tabItem.Content= null;

            TabControl sourceTabControl = tabItem.Parent as TabControl;
            int sourceTabIndex = tabItem.TabIndex;
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
                Width = 350,
            };

            tabControlX.tabControl.SelectedIndex = 0;
            StaticGlobals.windowList.Add(window);

            window.Closing += (sender, e) =>
            {
                    StaticGlobals.windowList.Remove(window);

                if (tabItem.Content is BookViewer viewer) {viewer.Dispose(); }
            };

            WordWIndowOwner.SetOwner(window, null);
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
            if(Content is TabControlX tabControl)
            {
                tabControl.CloseAllTabs();
            }
        }
    }
}
