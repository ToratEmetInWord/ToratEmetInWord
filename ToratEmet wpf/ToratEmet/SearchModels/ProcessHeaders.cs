using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Shapes;
using ToratEmet.BookParsingModels;
using ToratEmet.Extensions;

namespace ToratEmet
{
    public class ProcessHeaders
    {
        Stack<string> headersStack = new Stack<string>();
        ToratEmetTemplates templates = new ToratEmetTemplates();

        public string Execute(string line, string filePath)
        {
            if (filePath.Contains("TORA")||filePath.Contains("NAVI")||filePath.Contains("KTUVIM"))
            {
                line = templates.TanachTemplate(line, filePath);
                string[] splitLines = line.LinesArray();
                foreach (string splitLine in splitLines) { Execute(splitLine, ""); }
            }
            else
            {
                if (line.StartsWith("$"))
                {
                    UpdateStack(line.Replace("$ ", ""), 1);
                }
                else if (line.StartsWith("#"))
                {
                    UpdateStack(line.Replace("# ", ""), 2);
                }
                else if (line.StartsWith("@") || line.StartsWith("הקדמה") || line.StartsWith("פתיחה") || line.StartsWith("שער"))
                {
                    UpdateStack(line.Replace("@ ", ""), 3);
                }
                else if (line.StartsWith("^"))
                {
                    UpdateStack(line.Replace("^ ", ""), 3);
                }
                else if (line.StartsWith("~"))
                {
                    UpdateStack(line.Replace("~ ", ""), 4);
                }
                else if (line.StartsWith("!"))
                {
                    UpdateStack(line.Replace("! ", ""), 5);
                }
            }

            if (headersStack.Count > 0) { return headersStack.Peek().CleanHeaders(); }
            else { return ""; }
        }

        void UpdateStack(string line, int level)
        {

            while (level > headersStack.Count)
            {
                if (headersStack.Count == 0) { headersStack.Push(""); }
                else { headersStack.Push(headersStack.Peek()); }
                
            }
            while(level < headersStack.Count) 
            {
                headersStack.Pop();
            }
            headersStack.Pop();
            headersStack.Push(headersStack.Peek() + line + ", ");
        }
    }
}
