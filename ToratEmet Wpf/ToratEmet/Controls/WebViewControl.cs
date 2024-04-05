using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToratEmet.Models;
using ToratEmet.WebViewModels;

namespace ToratEmet.Controls
{
    internal class WebViewControl : WebView2
    {
        public WebViewControl()
        {
            Loaded += WebViewControl_Loaded;
            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
        }

        private void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "HtmlFontFamily"|| e.PropertyName == "HtmlFontSize")
            {
                WebViewCommands.SetFont(this);                
            }
        }

        private void WebViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetCore();
        }

        async void SetCore()
        {
            try
            {
                string tempWebCacheDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var webView2Environment = await CoreWebView2Environment.CreateAsync(userDataFolder: tempWebCacheDir);
                await this.EnsureCoreWebView2Async(webView2Environment);
                this.AllowExternalDrop = false;
            }
            catch {  }
        }
    }
}
