using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using תורת_אמת_בוורד_3._1._3.Models;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    public class OpenFileControlWindow:Window
    {
        public OpenFileControlWindow() 
        {
            IntializeOpenFileControl();

            Width = 315;
            Height = 400;
            FlowDirection = FlowDirection.RightToLeft;
            this.Left = Math.Max(Properties.Settings.Default.OpenFileWindowLeft, 200);

            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            PreviewKeyDown +=OpenFileControlWindow_PreviewKeyDown;
            LocationChanged += OpenFileControlWindow_LocationChanged;
            Closing += OpenFileControlWindow_Closing;
        }

        public void IntializeOpenFileControl()
        {
            if (StaticGlobals.openFileControl == null) { StaticGlobals.openFileControl = new OpenFileControl(); }
            if (StaticGlobals.openFileControl.Parent is TabItem tab)
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
            Content = StaticGlobals.openFileControl;
        }
        public void SetOwner()
        {
            IntializeOpenFileControl();
            WordWIndowOwner.SetOwner(this, StaticGlobals.openFileControl);
        }


        private void OpenFileControlWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) {   Close();   }
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
