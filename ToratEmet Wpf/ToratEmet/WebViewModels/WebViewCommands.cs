using Microsoft.Web.WebView2.Wpf;
using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace ToratEmet.WebViewModels
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
            string selectedText = await GetSelectedText(webView);
            if (!string.IsNullOrWhiteSpace(selectedText))
            {               
                Clipboard.SetText(selectedText.Trim('"'));
            }
        }
        public static async void CopyWithSource(WebView2 webView)
        {
            string selectedText = await GetSelectedText(webView);
            string title = await webView.ExecuteScriptAsync("document.title;");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = $"\"{selectedText.Trim()}\"";
                title = $" ({title.Trim('"')})"
                    .Replace(": (", " (")
                    .Replace("\\\"", "\"")
                    .Trim();
                Clipboard.SetText(selectedText + " " + title);
            }
        }
        public static async void CopyWithSource2(WebView2 webView)
        {
            string selectedText = await GetSelectedText(webView);
            string title = await webView.ExecuteScriptAsync("document.title;");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = $"\"{selectedText.Trim()}\"";
                title = $"({title.Trim('"')}): "
                    .Replace(": (", " (")
                    .Replace("\\\"", "\"")
                    .Trim();
                Clipboard.SetText(title + " " + selectedText);
            }
        }
        public static async void CopyWithHeader(WebView2 webView)
        {
            string selectedText = await GetSelectedText(webView);
            string title = await webView.ExecuteScriptAsync("document.title;");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = $"{title.Trim('"')}\r\n".Replace("📑 ", "") + selectedText.Trim('"')
                    .Replace("\\n", "\n").Replace("\\\"", "\"");
                Clipboard.SetText(selectedText);
            }
        }
        public static async void CopyToWord(WebView2 webView)
        {
            string selectedText = await GetSelectedText(webView);
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = selectedText.Trim('"').Replace("\\n", "\n").Replace("\\\"", "\""); ;
                InsertTextIntoWord(selectedText);
            }
        }
        public static async void CopyToWordWithSource(WebView2 webView)
        {
            string selectedText = await GetSelectedText(webView);
            string title = await webView.ExecuteScriptAsync("document.title;");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = $"\"{selectedText.Trim()}\"";
                title = $" ({title.Trim('"')})"
                    .Replace(": (", " (")
                    .Replace("\\\"", "\"")
                    .Trim();
                InsertTextIntoWord(selectedText + " " + title);
            }
        }

        public static async void CopyToWordWithSource2(WebView2 webView)
        {
            string selectedText = await GetSelectedText(webView);
            string title = await webView.ExecuteScriptAsync("document.title;");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = $"\"{selectedText.Trim()}\"";
                title = $"({title.Trim('"')}): "
                    .Replace(": (", " (")
                    .Replace("\\\"", "\"")
                    .Trim();
                InsertTextIntoWord(title + " " + selectedText);
            }
        }

        public static async void CopyToWordWithHeader(WebView2 webView)
        {
            string selectedText = await GetSelectedText(webView);
            string title = await webView.ExecuteScriptAsync("document.title;");
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                selectedText = $"{title.Trim('"')}\r\n" + selectedText.Trim('"')
                    .Replace("\\n", "\n").Replace("\\\"", "\"");
                InsertTextIntoWord(selectedText);
            }
        }

        static async Task<string> GetSelectedText(WebView2 webView)
        {
            string selectedText = await webView.ExecuteScriptAsync("window.getSelection().toString();");
            selectedText = selectedText.Trim('"').Replace("\\n", "\n")
                .Replace("\\\"", "\"")
                .Replace("\n\n", "\n")
                .Replace("\'\'", "\"")
                .Replace("\\\"", "\"");          
            return selectedText;
        }

        public static void InsertTextIntoWord(string text)
        {
            text = Regex.Replace(text, @"[\\/]", "")
                .Replace("\n\n", "\n") ;
            Word.Application wordApp = Globals.ThisAddIn.Application;
            Word.Document doc = wordApp.ActiveDocument;
            doc.Application.Selection.TypeText(text);
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
            try
            {
                await webView.ExecuteScriptAsync($@"
var textboxElement = document.getElementById('contentBox');
textboxElement.style.fontFamily = '{Properties.Settings.Default.HtmlFontFamily}';
textboxElement.style.fontSize = '{Properties.Settings.Default.HtmlFontSize}%';
");
            }
            catch { }
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
