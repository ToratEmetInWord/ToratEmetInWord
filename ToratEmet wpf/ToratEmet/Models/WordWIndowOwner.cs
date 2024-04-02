using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using ToratEmet;

namespace ToratEmet.Models
{
    public static class WordWindowOwner
    {
        public static void SetOwner(Window window, UserControl userControl)
        {
            if (userControl != null) { window.Content = null; }
            IntPtr wordWindowHandle = IntPtr.Zero;
            try
            {
                var activeWindow = Globals.ThisAddIn.Application.ActiveWindow;
                wordWindowHandle = new IntPtr(activeWindow.Hwnd);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting Word window handle: {ex.Message}", "Error");
            }
            WindowInteropHelper helper = new WindowInteropHelper(window);             // Set the owner using the obtained handle
            helper.Owner = wordWindowHandle;
            if (userControl != null) { window.Content = userControl; }
        }
    }
}
