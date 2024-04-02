using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToratEmet.Models;

namespace ToratEmet.BookParsingModels
{
    public class BookIdSearch
    {
        ObservableCollection<ChapterItem> resultItems;
        public ObservableCollection<ChapterItem> Search(string searchterm, IdItem rootItem)
        {
            searchterm = searchterm.Trim();
            resultItems = new ObservableCollection<ChapterItem>();
            searchRecursively(searchterm, rootItem);
           if (resultItems.Count == 0)
            {
                string[] words = searchterm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ContainsSearchRecursive(words, rootItem);
            }
            if (resultItems.Count == 0)
            {
                LevenshteinSearchRecursive(searchterm, rootItem);
            }
            return resultItems;
        }
        void searchRecursively(string searchterm, IdItem IdItem) 
        {
            if (IdItem.ShortId.EndsWith(searchterm)|| IdItem.ShortId.StartsWith(searchterm)) { resultItems.Add(IdItem); }
            foreach (IdItem childItem in IdItem.IdChildren)
            {
                searchRecursively(searchterm, childItem);
            }
        }
        void ContainsSearchRecursive(string[] searchTerm, IdItem IdItem)
        {
            if(searchTerm.All(word => IdItem.ShortId.Contains(word)))
            {
                resultItems.Add(IdItem); 
            }

            foreach (IdItem childItem in IdItem.IdChildren)
            {
                ContainsSearchRecursive(searchTerm, childItem);
            }
        }
        void LevenshteinSearchRecursive(string searchterm, IdItem IdItem)
        {
            if (Levenshtein.LevenshtienByArray(searchterm, IdItem.ShortId, 3)) { resultItems.Add(IdItem); }
            foreach (IdItem childItem in IdItem.IdChildren)
            {
                LevenshteinSearchRecursive(searchterm, childItem);
            }

        }
    }
}
