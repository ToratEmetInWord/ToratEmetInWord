using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lucene.Net.Store.Lock;
using System.Web.UI.WebControls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows;
using ToratEmet.Models;

namespace ToratEmet.Controls
{
    public class DictionaryWindowWrapper : Window
    {
        public AramaicDictionaryControl dictionaryControl;
        public DictionaryWindowWrapper()
        {
            dictionaryControl = new AramaicDictionaryControl();
            Content = dictionaryControl;

            Width = 425;
            Height = 270;
            FlowDirection = FlowDirection.RightToLeft;
            this.Left = 100;
            Title = "מילון ארמי עברי - וראשי תיבות";

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            PreviewKeyDown += AramaicDictionaryWindow_PreviewKeyDown;
        }

        private void AramaicDictionaryWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) { Close(); }
        }

        public void SetOwner()
        {
            WordWindowOwner.SetOwner(this, dictionaryControl);
        }
    }
}
