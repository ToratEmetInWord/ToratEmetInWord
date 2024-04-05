using Microsoft.Web.WebView2.Wpf;
using System;
using System.Linq;
using System.Windows;
using ToratEmet.ViewModels;
using ToratEmet.Models;
using ToratEmet.BookParsingModels;
using ToratEmet.Extensions;
using ToratEmet.TreeModels;
using System.Windows.Controls;
using ToratEmet.Controls;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ToratEmet.WebViewModels
{
    public class WebViewMessageHandler
    {
        public void BookViewAttachEvent(BookViewerViewModel bookViewModel, WebView2 webView2)
        {            
            webView2.CoreWebView2.WebMessageReceived += (sender, e) => 
            {
                string message = e.TryGetWebMessageAsString();

                if (message.StartsWith("bookLink="))
                {
                    OpenBooklink(message.Replace("bookLink=", ""), webView2);
                }
                else if (message.StartsWith("setBookLinkTitle="))
                {
                    SetLinkTitle(message.Replace("setBookLinkTitle=", ""), webView2);
                }
                else if (message.StartsWith("copyToWord="))
                {
                    WebViewCommands.InsertTextIntoWord(message.Replace("copyToWord=", ""));
                } 
                else if (message.StartsWith("navigateTo="))
                {
                    message = message.Replace("navigateTo=", "").Trim();
                    ChapterItem chapterItem = bookViewModel.currentBook.AllChapters.FirstOrDefault(chapter => chapter.Id.Equals(message));
                    if (chapterItem != null) { bookViewModel.NavigateToHeader(chapterItem); }
                }
                else if (message.Contains("currentId="))
                {
                    bookViewModel.currentId = message.Replace("currentId=", "");
                }
                else if (message.Contains("openComboContent="))
                {
                    OpenComboContent(message, webView2);
                }
                else if (message.Contains("keyEvent="))
                {
                    MessageBox.Show(message);
                }
            };
        }

        void OpenComboContent(string message, WebView2 webView2)
        {
            string content = "לא נמצא תוכן תואם";
            message = message.Replace("openComboContent=", "").Replace("`", "");
            string[] splitMessage = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            BookParser parser = new BookParser();
            ChapterItem chapterItem = parser.GetTargetItem(splitMessage[0], splitMessage[1]);
            string bookName = "בחר ספר";
            if (chapterItem != null)
            {
                bookName = chapterItem.Id.GetTextTillFirstChar(',');
                BookExport bookExport = new BookExport();
                content = $"<div style=\"color:gray\">{chapterItem.Id}</div>{bookExport.ComboViewChapterExport(chapterItem)}";
                content = content.Replace("\r\n", "\\n");

            }
            string contentID = splitMessage[2] + splitMessage[3];
            string script = $@"var content = `{content}`;
                    document.getElementById(`{contentID}`).innerHTML = content;";
            webView2.CoreWebView2.ExecuteScriptAsync(script);

            string label = "listBox_Label" + splitMessage[3];
            string script2 = $@"var bookname = `{bookName}`;
                    document.getElementById(`{label}`).innerHTML = bookname;";
            webView2.CoreWebView2.ExecuteScriptAsync(script2);
        }

        void OpenBooklink(string message, WebView2 webView2)
        {
            TabControlX tabControlX = FindParentOrChild.TryFindParent<TabControlX>(webView2);

            TreeItem treeItem = ProcessBooklink(ref message);

            if (treeItem != null)
            {
                OpenSelected openSelected = new OpenSelected();
                if (tabControlX != null) { openSelected.OpenSelectedFile(treeItem, message, tabControlX.tabControl); }
                //else { openSelected.OpenSelectedFile(treeItem, message, null); }
            }
        }

        TreeItem ProcessBooklink(ref string message)
        {            
            message = message.RemoveAllParenthesis().FixBookLink().Trim();
            string bookname;
            bookname = Regex.Replace(message, @"(דברי הימים [אב]|שמואל [אב]|מלכים [אב]).*", "$1,");           

            bookname = message.GetTextTillFirstChar(',');
            

            if (bookname == message && message.Count(c => c == ' ') == 1)
            {
                message = message.Replace(" ", ", ");
                bookname = message.GetTextTillFirstChar('ת');
            }

            if (message != bookname) { message = message.Replace(bookname, ""); }

            return StaticGlobals.treeItemsList
                    .OrderBy(item => Levenshtein.LevenshteinDistance(bookname, item.Name))
                    .FirstOrDefault();
        }

        void SetLinkTitle(string message, WebView2 webView2)
        {
            string content = "לא נמצא תוכן תואם או שהתוכן ארוך מדי";
            string originalMessage = message;

           TreeItem treeItem = ProcessBooklink(ref message);

            if (treeItem != null)
            {
                BookParser parser = new BookParser();
                ChapterItem chapterItem = parser.GetTargetItem(treeItem.Address, message);
                if (chapterItem != null)
                {
                    BookExport bookExport = new BookExport();
                    content = $"{bookExport.ComboViewChapterExport(chapterItem).Trim('\r', '\n')} ({chapterItem.Id})";
                    content = Regex.Replace(content, @"<h.>.*?</h.>|<.*?inlineHeader.*?>.*?</span>|<.*?>|&nbsp.*?&nbsp;?|&nbsp;?", "").Trim('\r', '\n');
                }

                if (content.Length < 300)
                { 
                string script = $@"
var spans = document.querySelectorAll('.booklinks');
if (spans.length > 0) {{
    spans.forEach(function(span) {{
        if (span.innerHTML === `{originalMessage}`) {{
            span.setAttribute('title', `{content}`);
var event = new MouseEvent('mouseover', {{bubbles: true,
            cancelable: true,
            view: window
        }});
        span.dispatchEvent(event);
        }}
    }});
}}";

                webView2.CoreWebView2.ExecuteScriptAsync(script);
                }

            }
        }

         //spans.forEach(function(span) {{
         //   if (span.textContent === '{originalMessage}') {{
         //       span.setAttribute('title', '{content}');
         //   }}
        //public void chapterTreeAttachEvent(BookViewerViewModel bookViewModel, WebView2 webView2)
        //{
        //    webView2.WebMessageReceived += (sender, e) =>
        //    {
        //        string message = e.TryGetWebMessageAsString();
        //        if (message.Equals("windowClose")) { bookViewModel.ChapterTreeButtonIsChecked = false; }
        //        else if (message != null)
        //        {
        //            ChapterItem chapterItem = bookViewModel.currentBook.AllChapters.FirstOrDefault(chapter => chapter.Id.Equals(message));
        //            if (chapterItem != null) { bookViewModel.NavigateToHeader(chapterItem); }
        //        }
        //    };
        //}
    }
}
