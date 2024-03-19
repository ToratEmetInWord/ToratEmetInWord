using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace תורת_אמת_בוורד_3._1._5.BookParsingModels
{
    internal static class ChapterTreeLoader
    {
        public static string LoadHtmlTree(ChapterItem rootItem)
        {
            StringBuilder stb = new StringBuilder();
            foreach (ChapterItem chapter in rootItem.IdChildren)
            {
                parseHeaders(chapter, stb, 0);
            }
            return stb.ToString();
        }
        static void parseHeaders(ChapterItem chapterItem, StringBuilder stb, int indentationLevel)
        {
            stb.AppendLine($@"
                            <details>
                            <summary title=""{chapterItem.Id}"" class=""hiddenSummaryArrow"" style=""padding-right: {chapterItem.Level * 10}px;"">
                            <button onclick=""treeViewSelection(`{chapterItem.Id}`)"" title=""הצג"">👁</button>
                            {chapterItem.ShortId.NormalizeHebrewText()}</summary>");

            foreach (ChapterItem childItem in chapterItem.IdChildren)
            {
                parseHeaders(childItem, stb, indentationLevel + 1);
            }
            stb.AppendLine("</details>");
        }
    }
}
