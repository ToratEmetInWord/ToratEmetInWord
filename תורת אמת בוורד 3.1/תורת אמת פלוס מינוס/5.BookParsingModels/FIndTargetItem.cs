using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using תורת_אמת_בוורד_3._1._5.BookParsingModels;
using תורת_אמת_בוורד_3._1._8.Extensions;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public static class FIndTargetItem
    {
        public static ChapterItem SearchForItem(ChapterItem rootItem, string Id)
        {
            Id.NormalizedDafString();
            string[] splitIds = Id.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return RecursiveApplier(rootItem, splitIds, 1, false);
        }
        static ChapterItem RecursiveApplier(ChapterItem currentChapter, string[] splitId, int searchPart, bool chapterFound)
        {
            if (currentChapter == null || searchPart >= splitId.Length) { return currentChapter; } //stop loop if nothing left to search

            string idToFind = splitId[searchPart].Trim(); //define current searchTerm
            ChapterItem foundItem = SearchChildren(currentChapter.Children, idToFind);
            if (foundItem != null)
            {
                ChapterItem nextLevelItem = RecursiveApplier(foundItem, splitId, searchPart + 1, true);
                if (nextLevelItem != null) return nextLevelItem;
                else { return foundItem; }
            }
            else if (!chapterFound)
            {
                foreach (var currentChild in currentChapter.Children)
                {
                    foundItem = RecursiveApplier(currentChild as ChapterItem, splitId, searchPart, false);
                    if (foundItem != null) { return foundItem; }
                }
            }
            return null;
        }

        static ChapterItem SearchChildren(ObservableCollection<ChapterItem> chapterchildren, string idToFind)
        {
            foreach(var chapterchild in chapterchildren)
            {
                if (chapterchild is ChapterItem chapter)
                {
                    if (chapter.Id.NormalizedDafString().EndsWith(" " + idToFind) || chapter.Id.NormalizedDafString().EndsWith(" " + idToFind + " א"))
                    {
                        return chapter;
                    }
                }
            }
           return null;
        }

        static string NormalizedDafString(this string input)
        {
            string normalizedString = input
                .Replace(".", " א")
                .Replace(":", " ב")
                .Replace("-", " ");
            normalizedString = Regex.Replace(normalizedString, @"\s{2,}", " ").Trim();
            return normalizedString;
        }

        public static ChapterItem JaccardSearch(BookItem bookItem, string targetId)
        {
            string[] splitTargetId = targetId.CleanHeaders().Replace(",", " ").ChapterCharRemover().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Variable to keep track of the best match and its score
            ChapterItem bestMatch = null;
            double bestScore = 0.0;

            foreach (var chapterItem in bookItem.AllChapters)
            {
                string chapterId = chapterItem.Id.RemoveTextTillFirstChar(',');
                string[] chapterItemIds = chapterId.CleanHeaders().Replace(",", " ").ChapterCharRemover().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Calculate Jaccard similarity score
                double intersectionCount = splitTargetId.Intersect(chapterItemIds).Count();
                double unionCount = splitTargetId.Union(chapterItemIds).Count();
                double score = intersectionCount / unionCount;

                // Update best match if the current item has a higher score
                if (score > bestScore)
                {
                    bestMatch = chapterItem;
                    bestScore = score;
                }
            }

            // Return the best match
            return bestMatch;
        }

        static string ChapterCharRemover(this string input)
        {
            return Regex.Replace(input,@"פרק|פסוק|משנה|דף|הלכה|סימן|סעיף|תשובה|רמז|פרשה|מזמור|חלק|מדרש|פי?סקה|אות|כלל|פרשת","");
        }

    }
}
