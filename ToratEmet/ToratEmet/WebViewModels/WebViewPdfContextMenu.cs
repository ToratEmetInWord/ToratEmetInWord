using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToratEmet.Controls;
using ToratEmet.Models;
using ToratEmet.ViewModels;

namespace ToratEmet.WebViewModels
{
    public static class WebViewPdfContextMenu
    {
        public static void CreateCustomContextMenu(WebView2 webView, TabItem tabItem)
        {
            webView.CoreWebView2.ContextMenuRequested += delegate (object sender,
                                    CoreWebView2ContextMenuRequestedEventArgs args)
            {
                IList<CoreWebView2ContextMenuItem> menuList = args.MenuItems;
                CoreWebView2Deferral deferral = args.GetDeferral();
                args.Handled = true;
                ContextMenu cm = new ContextMenu();
                cm.Closed += (s, ex) => deferral.Complete();
                PopulateContextMenu(args, menuList, cm);
                cm.IsOpen = true;
            };
            
            void PopulateContextMenu(CoreWebView2ContextMenuRequestedEventArgs args,
            IList<CoreWebView2ContextMenuItem> menuList, ItemsControl cm)
            {
                for (int i = 0; i < menuList.Count; i++)
                {
                    CoreWebView2ContextMenuItem current = menuList[i];
                    if (current.Kind == CoreWebView2ContextMenuItemKind.Separator)
                    {
                        Separator sep = new Separator();
                        cm.Items.Add(sep);
                        continue;
                    }
                    MenuItem newItem = new MenuItem();
                    // The accessibility key is the key after the & in the label
                    // Replace with '_' so it is underlined in the label
                    newItem.Header = current.Label.Replace('&', '_');
                    newItem.InputGestureText = current.ShortcutKeyDescription;
                    newItem.IsEnabled = current.IsEnabled;
                    if (current.Kind == CoreWebView2ContextMenuItemKind.Submenu)
                    {
                        PopulateContextMenu(args, current.Children, newItem);
                    }
                    else
                    {
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
                    }
                    cm.Items.Add(newItem);
                }

                cm.Items.Add(new Separator());

                MenuItem menuItem = new MenuItem { Header = "סגור"};
                menuItem.Click += (s, e) => {
                    TabControlX tabControlX = FindParentOrChild.TryFindParent<TabControlX>(tabItem);
                    int index = tabControlX.tabControl.SelectedIndex;
                    tabControlX.tabControl.Items.Remove(tabItem);
                    tabControlX.DiposeTabContent(tabItem);
                    if (index > 0) { tabControlX.tabControl.SelectedIndex = index - 1; }    
                };

                cm.Items.Add(menuItem);

                menuItem = new MenuItem { Header = "פתח בחלונית חדשה" };
                menuItem.Click += (s, e) => {
                    MoveTabToNewWindow.Execute(tabItem, 450);
                };

                cm.Items.Add(menuItem);
            }
        }
    }
}
