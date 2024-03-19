using Microsoft.Web.WebView2.Core;
using System;
using System.Windows;
using System.Windows.Controls;


namespace תורת_אמת_בוורד_3._1._1.Controls
{
    /// <summary>
    /// Interaction logic for WebViewControl.xaml
    /// </summary>
    public partial class WebViewControl : UserControl
    {
        public WebViewControl()
        {
            InitializeComponent();
            SetCore();
        }

        async void SetCore()
        {
            try
            { 
            //GlobalsX.webViewList.Add(webView);
            string tempWebCacheDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var webView2Environment = await CoreWebView2Environment.CreateAsync(userDataFolder: tempWebCacheDir);
            await webView.EnsureCoreWebView2Async(webView2Environment);
            webView.AllowExternalDrop = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
