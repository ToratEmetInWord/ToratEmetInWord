using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using תורת_אמת_בוורד_3._1._3.Models;


namespace תורת_אמת_בוורד_3._1._1.Controls
{
    public class SearchControlWindow:Window
    {
        public SearchControl searchControl;
        public SearchControlWindow()
        {
            IntializeSearchControl();

            Width = 330;
            Height = 450;
            FlowDirection = FlowDirection.RightToLeft;
            this.Left = Math.Max(Properties.Settings.Default.SearchWindowLeft, 200);

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            PreviewKeyDown +=SearchControlWindow_PreviewKeyDown;
            LocationChanged +=SearchControlWindow_LocationChanged;
            Closing += SearchControlWindow_Closing;
        }

        private void SearchControlWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) { Close(); }
        }

        private void SearchControlWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Collapsed;
        }

        private void SearchControlWindow_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SearchWindowLeft = this.Left;
            Properties.Settings.Default.Save();
        }

        public void SetOwner()
        {
            IntializeSearchControl();
            WordWIndowOwner.SetOwner(this, searchControl);
        }

        public void IntializeSearchControl()
        {
            if (StaticGlobals.searchControl == null) { StaticGlobals.searchControl = new SearchControl(); }
            if (StaticGlobals.searchControl.Parent is TabItem tab)
            {
                tab.Content = null;
                TabControl tabParent = tab.Parent as TabControl;
                int tabIndex = tabParent.SelectedIndex;
                tabParent.Items.Remove(tab);
                if (tabIndex > 0)
                {
                    tabParent.SelectedIndex = tabIndex - 1;
                }
                else
                {
                    tabParent.SelectedIndex = 0;
                }
            }
            Content = StaticGlobals.searchControl;
        }
    }
}
