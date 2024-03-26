using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    public class WebViewControl: WebView2
    {
        public WebViewControl() 
        {
            Loaded +=WebViewControl_Loaded;
          
        }

        private void WebViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetCore();
            Loaded -=WebViewControl_Loaded;
        }

        async void SetCore()
        {
            try
            {
                //GlobalsX.webViewList.Add(webView);
                string tempWebCacheDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var webView2Environment = await CoreWebView2Environment.CreateAsync(userDataFolder: tempWebCacheDir);
                await this.EnsureCoreWebView2Async(webView2Environment);
                this.AllowExternalDrop = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}
