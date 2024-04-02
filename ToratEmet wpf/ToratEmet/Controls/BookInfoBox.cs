using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using ToratEmet.Models;

namespace ToratEmet.Controls
{
    public class BookInfoBox:Window
    {
        private TextBox textBox;
        public BookInfoBox(string message)
        {
            Width = 450;
            Height = 200;
            FlowDirection = FlowDirection.RightToLeft;
            ShowInTaskbar = false;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            WordWindowOwner.SetOwner(this, null);

            textBox = new TextBox
            {
                TextWrapping = TextWrapping.WrapWithOverflow,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                IsReadOnly = true,
                Margin = new Thickness(10),
                Text = Regex.Replace(message, "<.*?>", ""),
            };
            Content = textBox;
        }
    }
}
