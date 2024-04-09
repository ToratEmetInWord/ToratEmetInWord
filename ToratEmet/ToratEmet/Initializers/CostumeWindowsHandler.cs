using System.Linq;
using ToratEmet.Controls;
using System.Windows;
using System.Windows.Controls;

namespace ToratEmet.Models
{
    public static class CostumeWindowsHandler
    {
        public static void ShowDictionaryWindow()
        {
            if (StaticGlobals.DictionaryWindow != null) { StaticGlobals.DictionaryWindow.Close(); }
            AramaicDictionaryControl aramaicDictionaryControl = new AramaicDictionaryControl();
            StaticGlobals.DictionaryWindow = new HostWindow {
            Content  = aramaicDictionaryControl,
            Width = 425,
            Height = 270,
            FlowDirection = FlowDirection.RightToLeft,
            Title = "מילון ארמי עברי - וראשי תיבות",
            };
            StaticGlobals.DictionaryWindow.Show();
        }

        public static void ShowOpenFileTab(TabControl tabControl)
        {
            if (StaticGlobals.OpenFileControl == null) { StaticGlobals.OpenFileControl = new OpenFileControl(); }
            CloseOpenFileControlParent();

            TabItem tabitem = tabControl.Items.OfType<TabItem>().FirstOrDefault(tab => tab.Content == StaticGlobals.OpenFileControl);
            if (tabitem == null)
            {
                tabitem = new TabItem
                {
                    Header = "פתח ספר",
                    Content = StaticGlobals.OpenFileControl,
                    IsSelected = true,
                };
                tabControl.Items.Add(tabitem);
            }
            tabitem.IsSelected = true;
        }

        public static void ShowOpenFileWindow()
        {
            if (StaticGlobals.OpenFileControl == null) { StaticGlobals.OpenFileControl = new OpenFileControl(); }
            CloseOpenFileControlParent();

            HostWindow hostWindow = new HostWindow
            {
                Width = 315,
                Height = 400,
                Left = Properties.Settings.Default.OpenFileWindowLeft,
                Title = "פתיחת ספר",
                Content = StaticGlobals.OpenFileControl,
            };

            if (Properties.Settings.Default.OpenFileWindowLeft == 0) { hostWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen; }
            hostWindow.LocationChanged += (sender, e) =>
            {
                Properties.Settings.Default.OpenFileWindowLeft = hostWindow.Left;
                Properties.Settings.Default.Save();
            };
            if (StaticGlobals.OpenFileControlWindow != null) { StaticGlobals.OpenFileControlWindow.Close(); }
            StaticGlobals.OpenFileControlWindow = hostWindow;
            hostWindow.Show();
        }

        public static void ShowSearchTab(TabControl tabControl)
        {
            if (StaticGlobals.SearchControl == null) { StaticGlobals.SearchControl = new SearchControl(); }
            CloseSearchControlParent();

            TabItem tabitem = tabControl.Items.OfType<TabItem>().FirstOrDefault(tab => tab.Content == StaticGlobals.SearchControl);
            if (tabitem == null)
            {
                tabitem = new TabItem
                {
                    Header = "חיפוש",
                    Content = StaticGlobals.SearchControl,

                };
                tabControl.Items.Add(tabitem);
            }
            tabitem.IsSelected = true;
        }

        public static void ShowSearchWindow()
        {
            if (StaticGlobals.SearchControl == null) { StaticGlobals.SearchControl = new SearchControl(); }
            CloseSearchControlParent();
            HostWindow hostWindow = new HostWindow
            {
                Width = 315,
                Height = 425,
                Left = Properties.Settings.Default.SearchWindowLeft,
                Title = "חיפוש",
                Content = StaticGlobals.SearchControl,
            };

            if (Properties.Settings.Default.SearchWindowLeft == 0) { hostWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen; }
            hostWindow.LocationChanged += (sender, e) =>
            {
                Properties.Settings.Default.SearchWindowLeft = hostWindow.Left;
                Properties.Settings.Default.Save();
            };
            if (StaticGlobals.SearchControlWindow != null) { StaticGlobals.SearchControlWindow.Close(); }
            StaticGlobals.SearchControlWindow = hostWindow;
            hostWindow.Show();
        }

        public static void ShowSearchExplorerWindow()
        {
            SearchExplorerControl searchExplorerControl = new SearchExplorerControl();
            searchExplorerControl.ShowSearchResults_button.Visibility = Visibility.Collapsed;
            CloseOpenFileControlParent();
            if (StaticGlobals.SearchControlExplorerWindow != null)
            { StaticGlobals.SearchControlExplorerWindow.Close(); StaticGlobals.SearchControlExplorerWindow = null; }
            HostWindow hostWindow = new HostWindow
            {
                Width = 316,
                Height = 400,
                Left = Properties.Settings.Default.SearchWindowLeft,
                Title = "פתיחת ספר",
                Content = searchExplorerControl,
            };
            if (Properties.Settings.Default.SearchWindowLeft == 0) { hostWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen; }

            hostWindow.LocationChanged += (sender, e) =>
            {
                Properties.Settings.Default.SearchWindowLeft = hostWindow.Left;
                Properties.Settings.Default.Save();
            };
            StaticGlobals.SearchControlExplorerWindow = hostWindow;
            hostWindow.Show();
        }

        static void CloseOpenFileControlParent()
        {
            var parent = StaticGlobals.OpenFileControl.Parent;
            if (parent != null)
            {
                if (parent is TabItem tab && tab.Parent is TabControl tabParent)
                {
                    tabParent.Items.Remove(tab);
                }
                else if (parent is HostWindow hostWindow)
                {
                    hostWindow.Content = null;
                    hostWindow.Close();
                }
            }
        }

        static void CloseSearchControlParent()
        {
            var parent = StaticGlobals.SearchControl.Parent;
            if (parent != null)
            {
                if (parent is TabItem tab && tab.Parent is TabControl tabParent)
                {
                    tabParent.Items.Remove(tab);
                }
                else if (parent is HostWindow hostWindow)
                {
                    hostWindow.Content = null;
                    hostWindow.Close();
                }
            }
        }
    }
}
