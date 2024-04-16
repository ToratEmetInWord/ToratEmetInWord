using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;

using ToratEmet.WebViewModels;

namespace ToratEmet.Controls
{
    internal class WebViewControl : WebView2
    {
        bool isLoaded = false;
        public WebViewControl()
        {
            SetCore();
            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
        }

        private void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "HtmlFontFamily"|| e.PropertyName == "HtmlFontSize")
            {
                Dispatcher.InvokeAsync((Action)(() => WebViewCommands.SetFont(this)));     
            }
        }

        public async void SetCore()
        {
            if (isLoaded == false)
            {
                try { 
                string tempWebCacheDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var webView2Environment = await CoreWebView2Environment.CreateAsync(userDataFolder: tempWebCacheDir);
                await this.EnsureCoreWebView2Async(webView2Environment);
                this.AllowExternalDrop = false;
                isLoaded = true;
                }
                catch(InvalidOperationException)
                {
                    Loaded += (sender, e) => { SetCore(); };
                }
                catch { }
            }
        }
    }
}
