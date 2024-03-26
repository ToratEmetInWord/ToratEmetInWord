using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._5.BookParsingModels;

namespace תורת_אמת_בוורד_3._1._6.WebViewModels
{
    public class WebViewMessageHandler
    {
        public void BookViewAttachEvent(BookViewerViewModel bookViewModel, WebView2 webView2)
        {            
            webView2.CoreWebView2.WebMessageReceived += (sender, e) => 
            {
                string message = e.TryGetWebMessageAsString();               
                if (message.StartsWith("navigateTo="))
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
                else if (message.Contains("keyEvent="))
                {
                    MessageBox.Show(message);
                }
            };
        }
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
