using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using תורת_אמת_בוורד_3._1._3.Models;

namespace תורת_אמת_בוורד_3._1._5.BookParsingModels
{
    public class BookParser_Temp
    {
        Templates templates = new Templates();
        Stack<IdItem> itemStack = new Stack<IdItem>();
        bool itemFound;
        int itemFoundLevel;
        bool finishedProcessing;
        StringBuilder stb = new StringBuilder();
        public string Parse(string filePath, string targetId)
        {
            IdItem idItem = new IdItem
            {
                Id = "",
                Level = 0,
            };
            itemStack.Push(idItem);

            Regex regex = new Regex(@"\A.*?,");
            targetId = ", " + regex.Replace(targetId, "").Trim();

            using (StreamReader str = new StreamReader(filePath, Encoding.GetEncoding("Windows-1255")))
            {
                char[] startChars = { '!', '~', '^', '@', '#' };

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    if (startChars.Any(c => line.StartsWith(c.ToString())))
                    {
                        ProcessHeaders(line, targetId);
                        break;
                    }
                }

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (finishedProcessing)
                        {
                            break;
                        }
                        ProcessHeaders(line, targetId);
                        if (itemFound)
                        {
                            processContent(line);
                        }
                    }
                }
            }

            return stb.ToString();
        }

        void ProcessHeaders(string line, string targetId)
        {
            if (string.IsNullOrEmpty(line)) { }
            else if (line.StartsWith("#"))
            {
                line = line.Replace("# ", "");
                AddIdItem(line, 1);
            }
            else if (line.StartsWith("@"))
            {
                line = line.Replace("@ ", "");
                AddIdItem(line, 2);
            }
            else if (line.StartsWith("^"))
            {
                line = line.Replace("^ ", "");
                AddIdItem(line, 2);
            }
            else if (line.StartsWith("~"))
            {
                line = line.Replace("~ ", "");
                AddIdItem(line, 3);
            }
            else if (line.StartsWith("!"))
            {
                line = line.Replace("! ", "");
                AddIdItem(line, 4);
            }

            if (itemStack.Peek().Id == targetId)
            {
                itemFound = true;
                itemFoundLevel = itemStack.Peek().Level;
            }

            if (itemFoundLevel == itemStack.Peek().Level)
            {
                finishedProcessing = true;
            }
        }
        void processContent(string line)
        {
            if (line.StartsWith("#"))
            {
                line = line.Replace("# ", "");
                stb.AppendLine($"<h2>{line}</h2>");
            }
            else if (line.StartsWith("@"))
            {
                line = line.Replace("@ ", "");
                stb.AppendLine($"<h2>{line}</h2>");
            }
            else if (line.StartsWith("^"))
            {
                line = line.Replace("^ ", "");
                stb.AppendLine($"<h2>{line}</h2>");
            }
            else if (line.StartsWith("~"))
            {
                line = line.Replace("~ ", "");
                stb.AppendLine($"<h3>{line}</h3>");
            }
            else if (line.StartsWith("!"))
            {
                line = line.Replace("! ", "").Replace("{", "").Replace("}", "");
                stb.AppendLine($"<span class=\"inlineHeader\">{line}</span>");
            }
            else
            {
                line = templates.General(line);
                line = line.Replace("\"", "&quot;").Replace("\'", "&apos;") + "<p>";
                stb.AppendLine(line);
            }
        }
       

        void AddIdItem(string id, int level)
        {
            if (!string.IsNullOrEmpty(id))
            { 
            popSatck(level);
            id = processId(id);

            IdItem idItem = new IdItem
            {
                Id = id,
                Level = level,
            };
            itemStack.Push(idItem);
            }
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
            id = itemStack.Peek().Id + ", " + id;
            return id.Trim()
                    .Replace(".", "")
                    .Replace("-", " ")
                    .Replace("  ", " ")
                    .Replace("\"", "")
                    .Replace("\'", "");
        }
    }

   
}
