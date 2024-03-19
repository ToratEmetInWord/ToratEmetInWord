using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using תורת_אמת_בוורד_3._1._3.Models;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    public class BookInfoBox:Window
    {
        private RichTextBox richTextBox;
        private Paragraph messageParagraph;
        UserControl userControl = new UserControl();
        public BookInfoBox(string message)
        {
            Width = 450;
            Height = 200;
            FlowDirection = FlowDirection.RightToLeft;
            ShowInTaskbar = false;
            ResizeMode = ResizeMode.NoResize;

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            
            richTextBox = new RichTextBox
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                IsReadOnly = true,
                Margin = new Thickness(10)
            };

            FlowDocument flowDocument = new FlowDocument();
            messageParagraph = new Paragraph();
            messageParagraph.Inlines.Add(new Run(Regex.Replace(message, "<.*?>", "")));
            flowDocument.Blocks.Add(messageParagraph);
            richTextBox.Document = flowDocument;

            userControl.Content = richTextBox;

            SetOwner();
        }

        public void SetOwner()
        {
            WordWIndowOwner.SetOwner(this, userControl);
        }
    }
}
