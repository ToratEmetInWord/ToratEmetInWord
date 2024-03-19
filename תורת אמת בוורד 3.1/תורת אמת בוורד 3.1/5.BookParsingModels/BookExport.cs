using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1.TreeModels;


namespace תורת_אמת_בוורד_3._1._5.BookParsingModels
{
    public class BookExport
    {
        bool combinedView;
        List<TreeItem> combinedViewItems;
        string content;
        int counter;

        public string Export(ChapterItem chapterItem, string itemId,
            bool isCombinedView, List<TreeItem> combinedviewitems, ChapterItem rootChapter)
        {
            combinedViewItems = combinedviewitems?? new List<TreeItem>();
            combinedView = isCombinedView;
            StringBuilder stb = new StringBuilder();
            AppendItemContent(chapterItem, stb);
            content = stb.ToString();
            return BuildPage(rootChapter, itemId);
        }

        string CreateChapterTreeView(ChapterItem rootChapter)
        {
            return $@"
<div id=""treeView-container"" class=""treeView-container"" onmouseover=""expandTreeView()"" onmouseout=""collapseTreeView()"">
    <input type=""text"" id=""treeView-SearchInput"" onkeyup=""findAndSelectItem()"" placeholder=""חפש כותרת..."">
    <div class=""treeView"" id=""treeView"">{ChapterTreeLoader.LoadHtmlTree(rootChapter)} </div>
  </div>
";
        }
        //onmouseout=""collapseTreeView()""
        string BuildPage(ChapterItem rootChapter, string itemId)
        {
            
            return $@"
{HtmlHead.htmlHead(itemId)}

<div class=""container"">

{CreateChapterTreeView(rootChapter)}

 <div class=""textContentBox"" id=""contentBox"" onmouseover=""collapseTreeView()"">

{content}

  </div>
</div>

{HtmlHead.HtmlEnd(itemId)}
";
        }
    
        public string ComboViewChapterExport(ChapterItem chapterItem) //get spesific text for comboview targetchapter
        {
            StringBuilder stb = new StringBuilder();
            AppendItemContent(chapterItem, stb);
            return stb.ToString();
        }

        void AppendItemContent(ChapterItem chapterItem, StringBuilder stb)
        {
            if (chapterItem is IdItem && chapterItem.Children.Count == 0) { }
            else { stb.AppendLine(chapterItem.Content); }

            var Chapterlist = chapterItem.Children;
            foreach (ChapterItem childItem in Chapterlist)
            {
                AppendItemContent(childItem, stb);
            }

            if (combinedView == true && chapterItem.IdChildren.Count == 0 && chapterItem is IdItem)
            {
                counter++; //counter for meforshim tabcontrol id
                stb.AppendLine(ComboView(counter, chapterItem.Id));
            }
        }
        string ComboView(int counter, string id)
         {
            if (combinedViewItems.Count > 0)
            {
                StringBuilder stb = new StringBuilder();
                stb.AppendLine($@"<div class=""comboView_container""> 
                                      <div class=""listBox-container"">
                                        <div class=""listBox""> 
                                    ");
                foreach (TreeItem item in combinedViewItems)
                {
                    stb.AppendLine($@" <button value='{item.Address}|{id}|comboContent|{counter}' onclick=""openComboContent(event)"">{item.Name}</button>");
                }
                stb.AppendLine($@"</div>  
                                    <listBox_Label id=""listBox_Label{counter}"">בחר ספר</listBox_Label>
                                        </div>
                                    <div class=""comboView_ContentBox"" id=""comboContent{counter}""> 
                                        </div>
                                     </div>");
                return stb.ToString();
            }
            return "";
        }
    }
}
