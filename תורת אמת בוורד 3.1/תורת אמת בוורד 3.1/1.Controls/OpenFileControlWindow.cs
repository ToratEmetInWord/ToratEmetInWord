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
    public class OpenFileControlWindow:Window
    {
        public OpenFileControl openFileControl;
        public OpenFileControlWindow() 
        {
            openFileControl = new OpenFileControl();
            Content = openFileControl;
            LocationChanged += OpenFileControlWindow_LocationChanged;
            Closing += OpenFileControlWindow_Closing;

            Width = 315;
            Height = 400;
            FlowDirection = FlowDirection.RightToLeft;
            this.Left = Math.Max(Properties.Settings.Default.OpenFileWindowLeft, 100);

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        public void SetOwner()
        {
            WordWIndowOwner.SetOwner(this, openFileControl);
        }

        private void OpenFileControlWindow_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OpenFileWindowLeft = this.Left;
            Properties.Settings.Default.Save();
        }

        private void OpenFileControlWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Collapsed;
        }
    }
}
