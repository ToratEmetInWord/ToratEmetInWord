using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToratEmet.BookParsingModels;
using ToratEmet.Controls;
using ToratEmet.Extensions;
using ToratEmet.Models;
using ToratEmet.TreeModels;

namespace ToratEmet.FileManaging.FileRequestProcessors
{
    public static class HyperLinkManager
    {
        public static void OpenBooklink(string message, WebView2 webView2)
        {
            TabControlX tabControlX = FindParentOrChild.TryFindParent<TabControlX>(webView2);

            TreeItem treeItem = ProcessBooklink(ref message);

            if (treeItem != null)
            {
                OpenSelected openSelected = new OpenSelected();
                if (tabControlX != null)
                {
                    openSelected.OpenSelectedFile(treeItem, message, "", tabControlX.tabControl);
                }
                //else { openSelected.OpenSelectedFile(treeItem, message, null); }
            }
        }

        public static TreeItem ProcessBooklink(ref string message)
        {
            message = message.RemoveAllParenthesis().FixBookName().Trim();
            TreeItem treeItem = GetMostSimilarTreeItem(message);
            message = message.FixBookLink().Trim();
            string bookname = treeItem.Name;
            if (message != bookname) { message = message.Replace(bookname, ""); }
            return treeItem;
        }

        public static TreeItem GetMostSimilarTreeItem(string input)
        {
            var highestRankingItems = StaticGlobals.treeItemsList
                .GroupBy(item => IntersectCalculation(input, item.Name, false))
                .OrderByDescending(group => group.Key)
                .FirstOrDefault();

            if (highestRankingItems != null)
            {
                return highestRankingItems
                    .OrderByDescending(item => IntersectCalculation(input, item.Name, true))
                    .FirstOrDefault();
            }

            return null; // Return null if no items are found
        }


        public static double IntersectCalculation(string string1, string string2, bool adjustRanking)
        {
            string[] words1 = string1.Split(' ');
            string[] words2 = string2.Split(' ');

            string[] intersectedWords = words1.Intersect(words2).ToArray();
            int itersectCount = intersectedWords.Count();


            if (adjustRanking == true && itersectCount > 0)
            {
                if (string2.StartsWith(intersectedWords[0]))
                {
                    itersectCount++;
                }

                if (intersectedWords.Length > 1 && string2.StartsWith(intersectedWords[0] + " " + intersectedWords[1]))
                {
                    itersectCount++;
                }

                if (string2 == intersectedWords[0])
                {
                    itersectCount++;
                }

                if (intersectedWords.Length > 1 && string2 == intersectedWords[0] + " " + intersectedWords[1])
                {
                    itersectCount++;
                }

                if (string2.Contains("תלמוד") && string2.Contains("בבלי"))
                {
                    itersectCount++; itersectCount++;
                }
                else if (string2.Contains("משנה"))
                {
                    itersectCount++;
                }               
            }
            return itersectCount;
        }


        public static void SetLinkTitle(string message, WebView2 webView2)
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
                    BookContentAssembler bookExport = new BookContentAssembler();
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
    }
}
