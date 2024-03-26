using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using תורת_אמת_בוורד_3._1._5.BookParsingModels;
using תורת_אמת_בוורד_3._1._8.Extensions;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public class BookParser
    {
        ToratEmetTemplates templates;
        Stack<ChapterItem> itemStack = new Stack<ChapterItem>();
        BookItem newBook;
        Regex chapterHederRegex = new Regex(@"פרק |פסוק |משנה |דף |הלכה |סימן |סעיף |תשובה |רמז |פרשה |מזמור |חלק |מדרש |פי?סקה |אות |כלל ", RegexOptions.Compiled);

        public BookParser()
        {
        }

        public ChapterItem GetTargetItem(string filePath, string targetId)
        {
            string fileName = filePath.GetCleanFileName();            
            Parse(filePath, fileName);

            targetId = Regex.Replace(targetId, @"^.*?, ", "");
            ChapterItem targetItem = newBook.AllChapters.FirstOrDefault(chapteritem => matchChapters(chapteritem.Id, targetId));
            if (targetItem == null) // Calculate Jaccard similarity score
            {
                targetItem = FIndTargetItem.JaccardSearch(newBook, targetId);
            }
            return targetItem;
        }

        bool matchChapters(string chpaterId, string targetId)
        {
            if (chpaterId.EndsWith(targetId) ||
                chapterMatchRplacements(chpaterId).EndsWith(chapterMatchRplacements(targetId)))
            { return true; }
            else { return false; }
        }

        string chapterMatchRplacements(string input)
        {
            return chapterHederRegex.Replace(input, "");
        }

        public BookItem Parse(string filePath, string fileName)
        {
            templates = new ToratEmetTemplates();
            bool startHasBeenFound = false;
            itemStack.Clear();
            Regex bookinfoRegex = new Regex(@"&TextSource=.*?&|&SpecialTitle=.*?\.");
            newBook = new BookItem { Title = fileName, FilePath = filePath };
            newBook.RootItem.Id = fileName;
            itemStack.Push(newBook.RootItem);
            string line;

            StringBuilder stb = new StringBuilder();
            using (StreamReader str = StreamReaderX.Reader(filePath))
            {                
                List<string> startChars = new List<string> { "!", "~", "^", "@", "הקדמה", "<h", "<H", "שער", "פתיחה" };
                while (!str.EndOfStream)
                {
                    line = str.ReadLine();
                    if (startChars.Any(c => line.StartsWith(c)))
                    {
                        ProcessLine(line, filePath);
                        break;
                    }
                    else if (!startHasBeenFound)
                    {
                        if (bookinfoRegex.IsMatch(line))
                        {
                            Match match = bookinfoRegex.Match(line);
                            line = "© " + match.Value.Replace("&", ""); 
                        }
                        stb.AppendLine(line);
                        if (line.StartsWith(@"\\")){ continue; }
                        else if (line.StartsWith("$ ") || line.StartsWith("# ") || string.IsNullOrEmpty(line)) 
                        {
                            startHasBeenFound = true; 
                            newBook.Info = stb.ToString();
                            stb.Clear();
                        }
                    }
                    else
                    {
                        if (line.StartsWith("$")) { newBook.Info = newBook.Info + line; }
                        else if (startChars.Any(c => line.StartsWith(c.ToString()))||line.StartsWith("# "))
                        {
                            newBook.Info = newBook.Info + "\r\n" + stb.ToString();
                            stb.Clear();
                            ProcessLine(line, filePath);
                            break;
                        }
                        else
                        {
                            stb.AppendLine(line);
                        }
                    }
                }

                if (str.EndOfStream)
                {
                    string content = stb.ToString();
                    content = content.Replace("\n", "<p>");
                    ProcessLine(content, filePath);
                }


                while (!str.EndOfStream)
                {
                    line = str.ReadLine();
                    ProcessLine(line, filePath);
                }
            }
            removeEmptyChapters();
            return newBook;
        }

        void removeEmptyChapters()
        {
            foreach (IdItem idItem in newBook.AllChapters)
            {
                if (idItem.IdChildren.Count > 0 && idItem.IdChildren.All(idChild => idChild.Children.Count == 0))
                {
                    idItem.Parent.Children.Remove(idItem);
                    idItem.Parent.IdChildren.Remove(idItem);
                }
                else if (idItem.Children.Count == 0)
                {
                    idItem.Parent.Children.Remove(idItem);
                    idItem.Parent.IdChildren.Remove(idItem);
                }
            }
        }

        public void ProcessLine(string line, string filePath)
        {
            if (string.IsNullOrEmpty(line)) { }
            else if (filePath.Contains("ToratEmetInstall"))
            {
               templates.ApplyTemplates(line, filePath, this, true);
            }            
            else if (line.StartsWith("#"))
            {
                line = line.Replace("# ", "");
                AddIdItem("<h2 dir=\"rtl\" id>" + line + "</h2><p dir=\"rtl\">", 1, line);
            }
            else if (line.StartsWith("@")||line.StartsWith("הקדמה")||line.StartsWith("פתיחה")||line.StartsWith("שער"))
            {
                line = line.Replace("@ ", "");
                AddIdItem("<h2 dir=\"rtl\" id>" + line + "</h2><p dir=\"rtl\">", 2, line);
            }
            else if (line.StartsWith("^"))
            {
                line = line.Replace("^ ", "");
                AddIdItem("<h2 dir=\"rtl\" id>" + line + "</h2><p dir=\"rtl\">", 2, line);
            }
            else if (line.StartsWith("~"))
            {
                line = line.Replace("~ ", "");
                AddIdItem("<h3 dir=\"rtl\" id>" + line + "</h3><p dir=\"rtl\">", 3, line);
            }
            else if (line.StartsWith("!"))
            {
                line = line.Replace("! ", "").Replace("{", "").Replace("}", "");
                AddIdItem("<span dir=\"rtl\" class=\"inlineHeader\" id>" + line + "</span>", 4, line);
            }
            else 
            {
                AddItem(line.ShemHashemWriting().Replace(@"//", "") + "<p dir=\"rtl\">", 5, "");
            }
        }

        IdItem CreateIdItem(string line, int level, string id, string shortId)
        {
            return new IdItem
            {
                Content = line,
                Level = level,
                Id = id.Trim(),
                ShortId = shortId,
                Parent = itemStack.Peek(),
            };
        }

        void AddIdItem(string line, int level, string id)
        {
            popSatck(level);

            string shortId = id.Replace("-", " ").Replace("  ", " ");
            if (!string.IsNullOrEmpty(id))
            {
                id = processId(id);
                line = line.Replace("id", $"id=\"{id}\"").Trim();
            }
            IdItem newItem = CreateIdItem(line, level, id, shortId);
            newBook.AllChapters.Add(newItem);
            processNewItem(newItem);
        }

        public void AddItem(string line, int level, string id)
        {
            popSatck(level);

            if (!string.IsNullOrEmpty(id))
            {
                id = processId(id);
                line = line.Replace("id", $"id=\"{id}\"").Trim();
            }

            ChapterItem newItem = CreateChapterItem(line, level, id);
            processNewItem(newItem);
        }

        void processNewItem(ChapterItem newItem)
        {
            itemStack.Peek().AddChild(newItem);
            itemStack.Push(newItem);
        }
        ChapterItem CreateChapterItem(string line, int level, string id)
        {
            return new ChapterItem
            {
                Content = line,
                Level = level,
                Id = id.Trim(),
                Parent = itemStack.Peek(),
            };
        }
        void popSatck(int level)
        {
            while (itemStack.Peek().Level >= level)
            {
                itemStack.Pop();
            }
        }
        string processId(string id)
        {
            id = itemStack.Peek().Id + ", " + id.NormalizeHebrewText()
                .Replace(".", "")
                .Replace("-", " ");
            return Regex.Replace(id, @" +", " ").Trim();


        }
    }   
}
