using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Web.WebView2.Wpf;
using System.Windows.Controls;
using תורת_אמת_בוורד_3._1.TreeModels;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_בוורד_3._1._1.Controls;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System;

namespace תורת_אמת_בוורד_3._1._6.WebViewModels
{
    public class WebViewContextMenu
    {
        ObservableCollection<object> relativeItemsList;
        TabItem tabItem;
        BookViewerViewModel bookViewer;
        public void CreateCustomContextMenu(BookViewerViewModel bookViewerViewModel,
            ObservableCollection<object> relatives, TabItem tabitem)
        {
            bookViewer = bookViewerViewModel;
            tabItem = tabitem;
            relativeItemsList = relatives;
            bookViewer.webView.CoreWebView2.ContextMenuRequested += CoreWebView2_ContextMenuRequested; // Subscribe to the ContextMenuRequested event
        }
        private void CoreWebView2_ContextMenuRequested(object sender, CoreWebView2ContextMenuRequestedEventArgs e)
        {
            // Get the list of menu items
            IList<CoreWebView2ContextMenuItem> menuList = e.MenuItems;
            CoreWebView2Deferral deferral = e.GetDeferral(); // Get a deferral object to delay completion of the event        
            e.Handled = true; // Mark the event as handled

            // Create a new ContextMenu
            ContextMenu cm = new ContextMenu();
            cm.Closed += (s, ex) => deferral.Complete();  // Handle the Closed event of the ContextMenu to complete the deferral

            cm.ItemsSource = PopulateContextMenu(e, menuList); // Populate the ContextMenu with items
            cm.FlowDirection = FlowDirection.RightToLeft;
            cm.IsOpen = true;            // Open the ContextMenu
        }

        private ObservableCollection<object> PopulateContextMenu(CoreWebView2ContextMenuRequestedEventArgs args,
                                          IList<CoreWebView2ContextMenuItem> menuList)
        {
            ObservableCollection<object> cm = new ObservableCollection<object>();
            for (int i = 0; i < menuList.Count; i++)
            {
                CoreWebView2ContextMenuItem current = menuList[i];
                string header = current.Label.Replace("&", "");
                if (header.Equals("קישור") || header.ToLower().Contains("link")) { }
                else if (header.Equals("העתק")||header.ToLower().Contains("copy"))
                {
                    cm.Add(NewMenuItem(args, current, "העתק"));
                    buildCostumMenu(cm);
                }
                else if (header.Contains("שמור")||header.ToLower().Contains("save"))
                {
                    cm.Add(NewMenuItem(args, current, "שמור"));
                }
                else if (header.Contains("לכיד") || header.ToLower().Contains("screenshot") || header.ToLower().Contains("צילום"))
                {
                    cm.Add(NewMenuItem(args, current, "לכידת תמונה"));
                }
            }

            cm.Add(new Separator());
            cm.Add(BuidRelativeBooksMenu());
            cm.Add(new Separator());
            AddTabHandlerItems(cm);
            return cm;
        }
        MenuItem NewMenuItem(CoreWebView2ContextMenuRequestedEventArgs args,
            CoreWebView2ContextMenuItem current, string header)
        {
            MenuItem newItem = new MenuItem
            {
                Header = header,
                InputGestureText = current.ShortcutKeyDescription,
                IsEnabled = current.IsEnabled,
            };
            if (current.Kind == CoreWebView2ContextMenuItemKind.CheckBox
            || current.Kind == CoreWebView2ContextMenuItemKind.Radio)
            {
                newItem.IsCheckable = true;
                newItem.IsChecked = current.IsChecked;
            }

            newItem.Click += (s, ex) =>
            {
                args.SelectedCommandId = current.CommandId;
            };
            return newItem;
        }
        void buildCostumMenu(ObservableCollection<object> cm)
        {
            MenuItem newItem2 = new MenuItem { Header = "העתק ללא עיצוב" };
            newItem2.Click += (s, ex) =>
            {
                WebViewCommands.CopySelection(bookViewer.webView);
            };
            cm.Add(newItem2);

            newItem2 = new MenuItem { Header = "העתק ציטוט עם מקור" };
            newItem2.Click += (s, ex) =>
            {
                WebViewCommands.CopyWithSource(bookViewer.webView);
            };
            cm.Add(newItem2);

            newItem2 = new MenuItem { Header = "העתק עם כותרת" };
            newItem2.Click += (s, ex) =>
            {
                WebViewCommands.CopyWithHeader(bookViewer.webView);
            };
            cm.Add(newItem2);

            MenuItem newItem3 = new MenuItem { Header = "העתק לוורד (ללא עיצוב)" };
            newItem3.Click += (s, ex) =>
            {
                WebViewCommands.CopyToWord(bookViewer.webView);
            };
            cm.Add(newItem3);

            MenuItem newItem4 = new MenuItem { Header = "העתק לוורד - ציטוט עם מקור" };
            newItem4.Click += (s, ex) =>
            {
                WebViewCommands.CopyToWordWithSource(bookViewer.webView);
            };
            cm.Add(newItem4);

            MenuItem newItem5 = new MenuItem { Header = "העתק לוורד - עם כותרת" };
            newItem5.Click += (s, ex) =>
            {
                WebViewCommands.CopyToWordWithHeader(bookViewer.webView);
            };
            cm.Add(newItem5);
        }
        MenuItem BuidRelativeBooksMenu()
        {
            MenuItem newItem = new MenuItem { Header = "ספרים קרובים" };
            foreach (var item in relativeItemsList)
            {
                if (item is FileTreeItem fileItem)
                {
                    MenuItem menuItem = new MenuItem { Header = fileItem.Name };
                    menuItem.Click += (s, ex) =>
                    {
                        OpenSelected openSelected = new OpenSelected();
                        openSelected.OpenSelectedFile(fileItem, bookViewer.currentId);
                    };
                    newItem.Items.Add(menuItem);
                }             
            }
            return newItem;
        }
      
        void AddTabHandlerItems(ObservableCollection<object> cm)
        {
            MenuItem newItem = new MenuItem { Header = "סגור" };
            newItem.Click += (s, ex) =>
            {
                TabControl tabControl = tabItem.Parent as TabControl;
                tabControl.Items.Remove(tabItem);
                if (tabItem.Content is BookViewer bookViewer)
                {
                    bookViewer.Dispose();
                }
            };
            cm.Add(newItem);

            newItem = new MenuItem { Header = "פתח בחלון חדש" };
            newItem.Click += (s, ex) =>
            {
                TabControl tabControl = tabItem.Parent as TabControl;
                tabControl.Items.Remove(tabItem);
                TabControl newTabControl = new TabControl();
                newTabControl.Items.Add(tabItem);
                System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
                Window window = new Window 
                {
                    Content = newTabControl,
                    FlowDirection = FlowDirection.RightToLeft,
                    Icon = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
                };
                tabItem.IsSelected = true;
                GlobalsX.windowList.Add(window);
                window.Closing += Window_Closing;
                window.Show();
            };
            cm.Add(newItem);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is Window window) 
            {
                GlobalsX.windowList.Remove(window);
            }
            
            if (tabItem.Content is BookViewer viewer)
            { 
                viewer.Dispose();
            }
        }
    }
}
