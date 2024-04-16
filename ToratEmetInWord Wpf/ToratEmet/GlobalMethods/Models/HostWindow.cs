using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using ToratEmet.Models;

namespace ToratEmet.Controls
{
    public class HostWindow:Window
    {
        public HostWindow()
        {
            FlowDirection = FlowDirection.RightToLeft;
            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            PreviewKeyDown += HostWindow_PreviewKeyDown;
            WordWindowOwner.SetOwner(this, Content as UserControl);
            Closing += HostWindow_Closing;
        }

        private void HostWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Content is AramaicDictionaryControl aramaicDictionary)
            {
                aramaicDictionary.ResultsWebView.Dispose();
            }
        }

        private void HostWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) { Close(); }
        }
    }
}