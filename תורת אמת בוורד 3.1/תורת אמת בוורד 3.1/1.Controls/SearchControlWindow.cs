using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            searchControl = new SearchControl();
            Content = searchControl;
            LocationChanged +=SearchControlWindow_LocationChanged;
            Closing += SearchControlWindow_Closing;

            Width = 317;
            Height = 450;
            FlowDirection = FlowDirection.RightToLeft;
            this.Left = Math.Max(Properties.Settings.Default.SearchWindowLeft, 100);

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void SearchControlWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Collapsed;
        }

        private void SearchControlWindow_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SearchControlLeft = this.Left;
            Properties.Settings.Default.Save();
        }

        public void SetOwner()
        {
            WordWIndowOwner.SetOwner(this, searchControl);
        }
    }
}
