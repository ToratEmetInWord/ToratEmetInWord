using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lucene.Net.Store.Lock;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Collections.Specialized;
using תורת_אמת_בוורד_3._1._3.Models;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    public class SearchExplorerWindow : Window
    {
        public SearchExplorerControl searchExplorerControl;
        public SearchExplorerWindow()
        {
            searchExplorerControl = new SearchExplorerControl();
            Content = searchExplorerControl;
            Closing += SearchControlWindow_Closing;

            Width = 316;
            Height = 450;
            FlowDirection = FlowDirection.RightToLeft;
            this.Left = Math.Max(Properties.Settings.Default.SearchWindowLeft, 100);

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            KeyDown +=SearchExplorerWindow_KeyDown;
            LocationChanged +=SearchExplorerWindow_LocationChanged;
        }

        private void SearchExplorerWindow_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SearchWindowLeft = this.Left;
            Properties.Settings.Default.Save();
        }

        private void SearchExplorerWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) { Close(); }
        }

        private void SearchControlWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Collapsed;
            StringCollection checkedTreeItems = new StringCollection();
            checkedTreeItems.AddRange(
                StaticGlobals.treeItemsList
                    .Where(item => item.IsChecked == true)
                    .Select(item => item.Address)
                    .ToArray());
            Properties.Settings.Default.CheckedTreeItems = checkedTreeItems;

            StringCollection checkedListBoxItems = new StringCollection();
            checkedListBoxItems.AddRange(
                StaticGlobals.treeItemsList
                    .Where(item => item.IsChecked2 == true)
                    .Select(item => item.Address)
                    .ToArray());
            Properties.Settings.Default.CheckedListBoxItems = checkedListBoxItems;

            Properties.Settings.Default.Save();
        }

        public void SetOwner()
        {
            WordWIndowOwner.SetOwner(this, searchExplorerControl);
        }
    }
}
