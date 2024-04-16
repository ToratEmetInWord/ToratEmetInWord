using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToratEmet.BookParsingModels;
using ToratEmet.Extensions;


namespace ToratEmet.Models
{
    public static class FindTargetItem
    {
        public static ChapterItem Find(BookItem bookItem, string targetId)
        {
            targetId = targetId.NormalizeIdString();
            //ChapterItem targetItem = bookItem.AllChapters.FirstOrDefault(chapter => chapter.Id.NormalizeIdString().EndsWith(targetId));
            string[] splitIds;
            if (targetId.Contains(",")) { splitIds = targetId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); }
            else { splitIds = targetId.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); }
            

            
            ChapterItem targetItem = searchNextLevel(new ObservableCollection<ChapterItem> { bookItem.RootItem }, splitIds, 0);

            if (targetItem == null)
            {
                foreach (var item in bookItem.AllChapters)
                {
                    string id = item.Id.NormalizeIdString();
                    if (id.EndsWith(targetId)) { targetItem = item; break; }
                }
            }
            if (targetItem == null) { targetItem = JaccardSearch(bookItem, targetId); }
            return targetItem;
        }

        static ChapterItem searchNextLevel(ObservableCollection<ChapterItem> currentLevelCollection, string[] splitId, int searchPart)
        {
            string idToFind = splitId[searchPart].Trim();

            ObservableCollection<ChapterItem> nextLevelCollection = new ObservableCollection<ChapterItem>(
                currentLevelCollection.SelectMany(collectionItem => collectionItem.Children)
            );

            if (nextLevelCollection.Any())
            {
                ChapterItem foundItem = SearchChildren(nextLevelCollection, idToFind);
                if (foundItem != null) { return RecursiveApplier(foundItem, splitId, searchPart + 1); }
                else { return searchNextLevel(nextLevelCollection, splitId, searchPart); }
            }
            return null;
        }

        static ChapterItem RecursiveApplier(ChapterItem currentChapter, string[] splitId, int searchPart)
        {
            if (currentChapter == null || searchPart >= splitId.Length) { return currentChapter;}

            string idToFind = splitId[searchPart].Trim();

            ChapterItem foundItem = SearchChildren(currentChapter.Children, idToFind);
            return foundItem != null ? RecursiveApplier(foundItem, splitId, searchPart + 1) : null;
        }       

        static ChapterItem SearchChildren(ObservableCollection<ChapterItem> chapterChildren, string idToFind)
        {
            return chapterChildren
                .FirstOrDefault(chapter =>
                    chapter.Id.NormalizeIdString().EndsWith($" {idToFind}") ||
                    chapter.Id.NormalizeIdString().EndsWith($" {idToFind} א"));
        }


        static string NormalizeIdString(this string input)
        {
            string normalizedString = input
                .Replace(".", " א")
                .Replace(":", " ב")
                .Replace("-", " ");
            normalizedString = normalizedString.RemoveChapterChar();
            normalizedString = Regex.Replace(normalizedString, @" {2,}", " ").Trim();
            return normalizedString;
        }

        static string RemoveChapterChar(this string input)
        {
            return Regex.Replace(input, @"פרק|פסוק|משנה|דף|הלכה|סימן|סעיף|תשובה|רמז|פרשה|מזמור|חלק|מדרש|פי?סקה|אות|כלל|פרשת|המשך|עמוד", "");
        }

        public static ChapterItem JaccardSearch(BookItem bookItem, string targetId)
        {
            string[] splitTargetId = targetId.CleanHeaders().Replace(",", " ").NormalizeIdString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Variable to keep track of the best match and its score
            ChapterItem bestMatch = null;
            double bestScore = 0.0;

            foreach (var chapterItem in bookItem.AllChapters)
            {
                string chapterId = chapterItem.Id.RemoveTextTillFirstChar(',');
                string[] chapterItemIds = chapterId.CleanHeaders().Replace(",", " ").NormalizeIdString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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

        

    }
}
