using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_בוורד_3._1._5.BookParsingModels;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public class Navigate_To_Header
    {
        BookViewerViewModel viewModel;
        public Navigate_To_Header(BookViewerViewModel ViewModel)
        {
            this.viewModel = ViewModel;
        }
        public async void Navigate(ChapterItem targetItem)
        {
            var result = await viewModel.webView.CoreWebView2.ExecuteScriptWithResultAsync($@"document.getElementById(""{targetItem.Id}"");");
            if (result.ResultAsJson != "null")
            {
                await viewModel.webView.CoreWebView2.ExecuteScriptWithResultAsync(
                    $@"var element = document.getElementById(""{targetItem.Id}""); 
                    if (element !== null) {{ element.scrollIntoView(); }} 
                    else {{alert(""אירעה שגיאת ניווט"")}}");
            }
            else if (viewModel.currentChapter.Level < targetItem.Level)
            {
                ChapterItem parentitem = FindParentItem(targetItem);
                viewModel.NavigateToItem(parentitem, targetItem.Id, false);
            }
            else
            {
                viewModel.NavigateToItem(targetItem, "", false);
            }
        }

        ChapterItem FindParentItem(ChapterItem targetItem)
        {
            ChapterItem grandParent = targetItem; //get grandparent level
            while (viewModel.currentChapter.Level <= grandParent.Level && grandParent.Parent != null) //adjust grandparent level
            {
                grandParent = grandParent.Parent;
            }
            foreach (ChapterItem htmlItem in grandParent.Children) //search through siblings
            {
                if (FindChildItem(htmlItem, targetItem) == true) { return htmlItem; } ///detetct if siblings contain targetitem
            }
            return targetItem;
        }
        bool FindChildItem(ChapterItem parentItem, ChapterItem targetItem)
        {
            if (parentItem == targetItem) { return true; }
            foreach (ChapterItem item in parentItem.Children)
            {
                if (FindChildItem(item, targetItem)) { return true; }
            }
            return false;
        }
    }
}
