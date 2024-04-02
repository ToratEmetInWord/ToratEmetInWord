using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Windows.Media;
using ToratEmet.Initializers;
using ToratEmet.Models;
using ToratEmet.WebViewModels;

namespace ToratEmet.Controls.ViewModels
{
    public class MainControlViewModel
    {
        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<FontFamily> _fontsList = new ObservableCollection<FontFamily>();
        public ObservableCollection<FontFamily> FontsList
        {
            get { return _fontsList; }
            set
            {
                _fontsList = value;
                OnPropertyChanged(nameof(FontsList));
            }
        }
        #endregion

        public TabControl tabControl;
        public MainControlViewModel(MainControl mainControl)
        {
            tabControl = mainControl.tabControlX.tabControl;
            PopulateFontList();
        }

        void PopulateFontList()
        {
            string[] prioritizedFontNames = { "frankruehl", "times", "narkisim", "hadas", "calibri", "arial", "david", "gisha", "frank", "segoe", "guttman", "aharoni" };
            var fontFamilies = prioritizedFontNames
                .Select(name => new FontFamily(name))
                .Concat(Fonts.SystemFontFamilies.Except(prioritizedFontNames.Select(name => new FontFamily(name))));
            FontsList = new ObservableCollection<FontFamily>(fontFamilies);
        }
        public void ShowCopyRight(TabControl tabControl)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.AllowDrop = false;
            webBrowser.KeyDown += (sender, e) => { e.Handled = true; };
            webBrowser.NavigateToString(CopyRight.ToratEmetCopyRight());
            TabItem tabItem = new TabItem { Header = "זכויות יוצרים", Content = webBrowser };
            tabControl.Items.Add(tabItem);
            tabControl.SelectedItem = tabItem;
        }
    }
}
