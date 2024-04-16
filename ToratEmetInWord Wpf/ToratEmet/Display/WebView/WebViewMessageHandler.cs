using Microsoft.Web.WebView2.Wpf;
using System;
using System.Linq;
using System.Windows;
using ToratEmet.ViewModels;
using ToratEmet.Models;
using ToratEmet.BookParsingModels;
using ToratEmet.FileManaging.FileRequestProcessors;

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
                    HyperLinkManager.OpenBooklink(message.Replace("bookLink=", ""), webView2);
                }
                else if (message.StartsWith("setBookLinkTitle="))
                {
                    HyperLinkManager.SetLinkTitle(message.Replace("setBookLinkTitle=", ""), webView2);
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
                BookContentAssembler bookExport = new BookContentAssembler();
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


//TreeItem ProcessBooklink(ref string message)
//{
//    message = message.RemoveAllParenthesis().FixBookLink().Trim();
//    string bookname;
//    bookname = Regex.Replace(message, @"(דברי הימים [אב]|שמואל [אב]|מלכים [אב]).*", "$1,");
//    bookname = message.GetTextTillFirstChar(',');


//    if (bookname == message && message.Count(c => c == ' ') == 1)
//    {
//        message = message.Replace(" ", ", ");
//        bookname = message.GetTextTillFirstChar('ת');
//    }

//    if (message != bookname) { message = message.Replace(bookname, ""); }

//    return StaticGlobals.treeItemsList
//            .OrderBy(item => Levenshtein.LevenshteinDistance(bookname, item.Name))
//            .FirstOrDefault();
//}
