using Microsoft.Web.WebView2.Wpf;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using תורת_אמת_בוורד_3._1._1.Controls;

namespace תורת_אמת_בוורד_3._1._6.WebViewModels
{
    public static class WebViewCommands
    {
        public static void WebViewNavigateToString(string content, WebView2 webView)
        {
                string filePath = Path.Combine(Path.GetTempPath(), "temp.html");
                File.WriteAllText(filePath, content);
                webView.Source = new Uri("about:blank");
                webView.Source = new Uri(filePath);
        }
        public static async void ToggleHideNikud(WebView2 webView)
        {
            await webView.ExecuteScriptAsync($@"
            var newText = originalText;
            if (!isVowelsReversed)
            {{
                newText = newText.replace(/[\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]/g, """");
            }}           
            if (isCantillationReversed)
            {{
                newText = newText.replace(/[\u0591-\u05AF]/g, """");
            }}   

            document.body.innerHTML = newText
            isVowelsReversed = !isVowelsReversed;");
        }
        public static async void ToggleHideCantillations(WebView2 webView)
        {
            await webView.ExecuteScriptAsync($@"
            var newText = originalText;
            if (!isCantillationReversed)
            {{
                newText = newText.replace(/[\u0591-\u05AF]/g, """");
            }}
            if (isVowelsReversed)
            {{
                newText = newText.replace(/[\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]/g, """");
            }}          
            document.body.innerHTML = newText
            isCantillationReversed = !isCantillationReversed;");
        }
        public static async void SearchNext(string searchText, WebView2 webView)
        {
            var result = await webView.ExecuteScriptAsync($"window.find('{searchText}');");
            if (result != null && result.ToString() == "false")
            {
                MessageBox.Show("לא נמצאה תוצאה", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        public static async void SearchPrevious(string searchText, WebView2 webView)
        {
            var result = await webView.ExecuteScriptAsync($"window.find('{searchText}', false, true);");
            if (result != null && result.ToString() == "false")
            {
                MessageBox.Show("לא נמצאה תוצאה", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public static async void CopySelection(WebView2 webView)
        {
            string selectedText = await webView.ExecuteScriptAsync("window.getSelection().toString();");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = selectedText.Trim('"').Replace("\\n", "\n").Replace("\\\"", "\""); ;
                Clipboard.SetText(selectedText);
            }
        }
        public static async void CopyWithSource(WebView2 webView)
        {
            string selectedText = await webView.ExecuteScriptAsync("window.getSelection().toString();");
            string title = await webView.ExecuteScriptAsync("document.title;");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = selectedText
                    .Replace("\\n", "\n") + $" ({title.Trim('"')})"
                    .Replace(": (", " (")
                    .Replace("\\\"", "\""); ;
                selectedText = Regex.Replace(selectedText, @"\n[א-ת]+\.|\A[א-ת]+\.", "")
                    .Trim();
                Clipboard.SetText(selectedText);
            }
        }
        public static async void CopyWithHeader(WebView2 webView)
        {
            string selectedText = await webView.ExecuteScriptAsync("window.getSelection().toString();");
            string title = await webView.ExecuteScriptAsync("document.title;");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = $"{title.Trim('"')}\r\n".Replace("📑 ", "") + selectedText.Trim('"')
                    .Replace("\\n", "\n").Replace("\\\"", "\"");
                Clipboard.SetText(selectedText);
            }
        }

        public static async void MarkSearchTerm(WebView2 webView, string searchTerm)
        {
            await webView.ExecuteScriptAsync($@"
        var searchTerm = '{searchTerm}';
        var searchTermEscaped = escapeRegExp(searchTerm);
        var detailsElements = document.querySelectorAll('details');
        detailsElements.forEach(function(detailsElement) {{
            var detailsContent = detailsElement.querySelectorAll('p');
            if (detailsContent.length > 0) {{
                detailsContent.forEach(function(paragraph) {{
                    var contentText = paragraph.textContent;
                    var escapedTerm = searchTermEscaped.replace(/\\\*/g, '.*?').replace(/\\\?/g, '.');
                    var regex = new RegExp(escapedTerm, 'gi');
                    var highlightedContent = contentText.replace(regex, function(match) {{
                        return '<span class=""highlight"">' + match + '</span>';
                    }});
                    paragraph.innerHTML = highlightedContent;
                }});
            }}
        }});

    function escapeRegExp(str) {{
        return str.replace(/[.*+?^${{}}()|[\]\\]/g, '\\$&');
    }}
");
        }
        public static async void SetFont(WebView2 webView)
        {
            await webView.ExecuteScriptAsync($@"
       document.body.style.fontFamily = '{תורת_אמת_פלוס_מינוס.Properties.Settings.Default.HtmlFontFamily}';
                document.body.style.fontSize = '{תורת_אמת_פלוס_מינוס.Properties.Settings.Default.HtmlFontSize}%';
");
        }

        public static async void ToggleSnippets(WebView2 webView, bool IsExpanded)
        {
            try
            {
                string script = "";
if (IsExpanded) { 
                script = @" var detailsElements = document.querySelectorAll('details');
            detailsElements.forEach(function(details) { details.setAttribute('open', 'open');  });";
                }
else
                {
                    script = @" var detailsElements = document.querySelectorAll('details');
            detailsElements.forEach(function(details) {  details.removeAttribute('open');  });";
                }
                await webView.ExecuteScriptAsync(script);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }  
        }


    }
}
