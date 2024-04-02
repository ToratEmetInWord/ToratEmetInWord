using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ToratEmetInWord_2._0
{
    public class BookCompiler
    {
        public bool isToratEmetBook = false;
        public String headerMenuStructure = "";
        public string htmlContent = "";
        public bool isLongBook = false;
        public bool fileIsTanach;

        public Dictionary<string, List<string>> relativeBooksDictionary = new Dictionary<string, List<string>>();

        public void RunComplier(string fileName)
        {
            CheckInstallationFolder();
            string filePath = getFilePath(fileName);
            isLongBook = false;

            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    long fileSizeInBytes = fileInfo.Length;
                    long fileSizeInKilobytes = fileSizeInBytes / 1024; // Convert bytes to kilobytes

                    if (fileSizeInKilobytes > 1000 && Properties.Settings.Default.skipBigFileAlert == false)
                    {
                        DialogResult result = MessageBox.Show("עקב גודל הקובץ זמן הטעינה עלול לארוך יותר מן הרגיל. האם להמשיך?\r\n\r\nלחץ על 'ביטול' כדי לבטל הודעה זו בעתיד.", "אזהרת קובץ גדול", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                        if (result == DialogResult.Yes) { startCompiling(filePath, fileName); }
                        else if (result == DialogResult.Cancel)
                        {
                            startCompiling(filePath, fileName);
                            Properties.Settings.Default.skipBigFileAlert = true;
                            Properties.Settings.Default.Save();
                        }
                        else { isLongBook = true; }
                    }
                    else
                    {
                        startCompiling(filePath, fileName);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void CheckInstallationFolder()
        {
            try
            {
                if (!System.IO.Directory.Exists(Path.Combine(Properties.Settings.Default.toratEmetInstallFolder, "ToratEmetInstall")))
                {
                    //set ToratEmet install folder
                    string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folderToCheck = Path.Combine(documentsFolder, "ToratEmetInstall");
                    if (Directory.Exists(folderToCheck))
                    {
                        Properties.Settings.Default.toratEmetInstallFolder = documentsFolder;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("תיקיית ההתקנה של תורת אמת לא זוהתה! אנא הזן את מיקום התיקייה באופן ידני.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        var folderPicker = new FolderPicker();

                        if (folderPicker.ShowDialog(IntPtr.Zero) == true)
                        {
                            string resultFolder = folderPicker.ResultPath;
                            if (resultFolder.Contains("ToratEmetInstall")) { resultFolder = Path.GetDirectoryName(resultFolder); }
                            Properties.Settings.Default.toratEmetInstallFolder = resultFolder;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string getFilePath(string selectedBook)
        {
            try
            {
                if (selectedBook.EndsWith(" ")) { isToratEmetBook = true; }

                string bookPath = selectedBook.TrimEnd();
                if (isToratEmetBook == true) { bookPath = toratEmetBookPath(bookPath); isToratEmetBook = false; }
                else { bookPath = myBooksBookPath(bookPath); }

                return bookPath;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return selectedBook; }
        }

        private string toratEmetBookPath(string bookPath)
        {
            try
            {
                    string translatedBookPath = TranslatorClass.TranslateFilenameToPath(bookPath);
                    if (!translatedBookPath.Contains(".txt")) {translatedBookPath = TranslatorClass.TranslateFilenameToPath(bookPath); }
                    string basePath = Properties.Settings.Default.toratEmetInstallFolder;
                    string finalBookPath = Path.Combine(basePath, "ToratEmetInstall", translatedBookPath);
                    return finalBookPath;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return bookPath; }
        }

        private string myBooksBookPath(string bookPath)
        {
            try
            {
                string basePath = Properties.Settings.Default.toratEmetInstallFolder;
                string myBooksPath = Path.Combine(basePath, "ToratEmetUserData", "MyBooks");
                if (Directory.Exists(myBooksPath))
                {
                    string[] files = Directory.GetFiles(myBooksPath, bookPath + "." + "txt", System.IO.SearchOption.AllDirectories);
                    if (files.Length > 0) { return files[0]; }
                    else { return toratEmetBookPath(bookPath); }
                }
                else { return bookPath; }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return bookPath; }
        }

        private void startCompiling(string filePath, string fileName)
        {
            if (File.Exists(filePath))
            {
                CompileText(filePath, fileName);
                getRelatedFiles(filePath, fileName);
            }
            else
            {
                MessageBox.Show("לא ניתן לפתוח קובץ זה", "קובץ חסר", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getRelatedFiles(string filePath, string fileName)
        {
            List<string> RelatedFiles = new List<string>();

            filePath = Path.GetDirectoryName(filePath);
            string[] filesInSameFolder = Directory.GetFiles(filePath);

            foreach (string file in filesInSameFolder)
            {
                string fileHebrewName = "";
                if (!file.Contains("Interleave") && !file.Contains("merged")) { fileHebrewName = relatedFilename(file); }
                if (!string.IsNullOrEmpty(fileHebrewName) && fileHebrewName != fileName)
                {
                    RelatedFiles.Add(fileHebrewName);
                }
            }
            if (!relativeBooksDictionary.ContainsKey(fileName.Trim()))
            { relativeBooksDictionary[fileName.Trim()] = RelatedFiles;}
        }

        string relatedFilename(string filePath)
        {
            int index = filePath.IndexOf("ToratEmetInstall");

            if (index != -1)
            {
                index = filePath.IndexOf("Books");
                filePath = filePath.Substring(index);
                return TranslatorClass.TranslateFilename(filePath) + " ";
            }
            else
            {
                return Path.GetFileNameWithoutExtension(filePath);
            }
        }

        private void CompileText(string filePath, string fileName)
        {
            try
            {
                // Check if file exists && Check if the file is a text file
                if (File.Exists(filePath) && Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    // Read the content of the text file using the Windows-1255 encoding
                    string textContent = File.ReadAllText(filePath, Encoding.GetEncoding(1255));

                    if (filePath.Contains("001_TORA")|| filePath.Contains("002_NAVI") || filePath.Contains("003_KTUVIM")) fileIsTanach = true;
                    else { fileIsTanach = false; }
                    if (fileIsTanach == false)
                    { NormalizeHebrewText(ref textContent); };

                    ApplyReplacements(ref textContent, fileName);

                    CreateHeadersAndParagraphs(ref textContent, fileName);

                    // Create the HTML file and write the content with justified styling using the Windows-1255 encoding
                    htmlContent = buildhtml(textContent);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CreateHeadersAndParagraphs(ref string textContent, string fileName)
        {
            try
            {
                //reset menu structure
                headerMenuStructure = "";
                int headerNumber = 0;

                // Split the text content into lines
                string[] modifiedLines = textContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                // Apply modifications to the remaining lines based on special characters
                for (int i = 0; i < modifiedLines.Length; i++)
                {
                    modifiedLines[i] = modifiedLines[i].Replace("-", " ");
                    modifiedLines[i] = Regex.Replace(modifiedLines[i], " {2,}", " ");

                    if (modifiedLines[i].Contains("UniqueId") || modifiedLines[i].Contains("LastLevelIndex") || modifiedLines[i].Contains("Comments") || modifiedLines[i].Contains("TextSource") || modifiedLines[i].Contains("ForcedBookName") || modifiedLines[i].Contains("RavMechaber"))
                    {
                        modifiedLines[i] = "<center><small>כל הזכויות שמורות ל - " + Regex.Replace(modifiedLines[i], @"ForcedBookName.*?&|(\([^)]*\))|[^א-ת""'\s]", "") + "</small></center>";
                    }
                    else if (!Regex.IsMatch(modifiedLines[i], "[א-ת]"))
                    {
                        modifiedLines[i] = "";
                    }
                    else if (modifiedLines[i].StartsWith(@"//"))
                    {
                        modifiedLines[i] = "";
                    }
                    else if (modifiedLines[i].StartsWith("~ "))
                    {
                        headerNumber++;
                        headerMenuStructure += modifiedLines[i].Replace("~ ", "") + "|";
                        modifiedLines[i] = modifiedLines[i].Replace("~ ", "<h3 id=\"" + headerNumber + "\">") + "</h3>";
                    }
                    else if (modifiedLines[i].StartsWith("^ "))
                    {
                        headerNumber++;
                        headerMenuStructure += "^" + modifiedLines[i].Replace("^ ", "") + "|";
                        modifiedLines[i] = modifiedLines[i].Replace("^ ", "</div><div><h2 id=\"" + headerNumber + "\">") + "</h2>";
                    }
                    else if (modifiedLines[i].StartsWith("@ "))
                    {
                        headerNumber++;
                        headerMenuStructure += "^" + modifiedLines[i].Replace("@ ", "") + "|";
                        modifiedLines[i] = modifiedLines[i].Replace("@ ", "</div><div><h2 id=\"" + headerNumber + "\">") + "</h2>";
                    }
                    else if (modifiedLines[i].StartsWith("# "))
                    {
                        headerNumber++;
                        headerMenuStructure += "^" + modifiedLines[i].Replace("# ", "") + "|";
                        modifiedLines[i] = modifiedLines[i].Replace("# ", "</div><div><h2 id=\"" + headerNumber + "\">") + "</h2>";
                    }
                    else if (modifiedLines[i].StartsWith("$ "))
                    {
                        modifiedLines[i] = modifiedLines[i].Replace("$ ", "<h1>") + "</h1>";
                    }
                    else if (modifiedLines[i].StartsWith("! "))
                    {
                        if (modifiedLines[i].Contains("{")) { modifiedLines[i] = modifiedLines[i].Replace("!", "<span style=\"color: navy;\"><b>") + "</b></span>"; }
                        else { modifiedLines[i] = modifiedLines[i].Replace("!", "<p><span style=\"color: navy;\"><b>") + "</b></span>"; }
                    }
                    else if (!modifiedLines[i].Contains("{") && !isTanach(fileName))
                    {
                        modifiedLines[i] =  modifiedLines[i] + "<br>";
                    }
                }
                // Join the modified lines back to create the updated text content
                textContent = string.Join("\r\n", modifiedLines);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ApplyReplacements(ref string textContent, string fileName)
        {
            textContent = textContent.Replace("{p", "<p><b><large>");
            textContent = textContent.Replace("p}", "</large></b>");
            textContent = textContent.Replace("{r", "<span style=\"background: #7694DA; display: inline-block;\"><small>");
            textContent = textContent.Replace("r}", "</small></span>");
            textContent = textContent.Replace("color:white", "color:red");

            textContent = textContent.Replace("  ", " ");
            if (fileName.Contains("חברותא"))
            {
                textContent = textContent.Replace("{", "<b>");
                textContent = textContent.Replace("}", "</b>");
                textContent = textContent.Replace("(((", "<b><big style=\"color:blue\">");
                textContent = textContent.Replace(")))", "</b></big>");
            }

            //textContent = textContent.Replace("[[", "");
            //textContent = textContent.Replace("]]", "");
            textContent = textContent.Replace("{{", "(");
            //textContent = textContent.Replace("{ {", "(");
            textContent = textContent.Replace("}}", ")");
            //textContent = textContent.Replace("} }", ")");
            textContent = Regex.Replace(textContent, "<!--.*?-->מתני'", "<span style=\"color: Navy; font-size: larger; font-weight: bold;\">מתני'</span>");
            textContent = Regex.Replace(textContent, "<!--.*?-->גמ'", "<span style=\"color: Navy; font-size: larger; font-weight: bold;\">גמ'</span>");
            //textContent = textContent.Replace("!", "");

            if (textContent.Contains("+"))
            {
                //create טעמים
                textContent = textContent.Replace(@"+\++\++\++\+", "&#x05A6;");
                textContent = textContent.Replace(@"\\\+\++\\\++", "&#x059F;");
                textContent = textContent.Replace(@"+\+\\++++++\", "&#x059D;&#x0597;");
                textContent = textContent.Replace(@"\++\\\+++++\\++\\\", "&#856;&#856;");
                textContent = textContent.Replace(@"\++\\\\++\\\", "&#856;");
                textContent = textContent.Replace(@"+\++\+\\\\++", "&#5A8;&#5A5;");
                textContent = textContent.Replace(@"\+\\++", "&#x05AA;");
                textContent = textContent.Replace(@"+\\\\+", "&#x0599;");
                textContent = textContent.Replace(@"\\\\++", "&#x0599;");
                textContent = textContent.Replace(@"++\+\+", "&#x05A3;");
                textContent = textContent.Replace(@"\\\\\+", "&#x0598;");
                textContent = textContent.Replace(@"\+\++\", "&#x0592;");
                textContent = textContent.Replace(@"+++++\", "&#x0597;");
                textContent = textContent.Replace(@"\\+++\", "&#x0594;");
                textContent = textContent.Replace(@"+\+++\", "&#x0595;");
                textContent = textContent.Replace(@"+\++\+", "&#x05A5;");
                textContent = textContent.Replace(@"\++++\", "&#x0596;");
                textContent = textContent.Replace(@"+\\++\", "&#x0591;");
                textContent = textContent.Replace(@"+\\+\+", "&#x05A1;");
                textContent = textContent.Replace(@"+\\\++", "&#x05A9;");
                textContent = textContent.Replace(@"\\\+\+", "&#x05A0;");
                textContent = textContent.Replace(@"\\+\\+", "&#x059C;");
                textContent = textContent.Replace(@"\++\\+", "&#x059E;");
                textContent = textContent.Replace(@"++++\+", "&#x05A7;");
                textContent = textContent.Replace(@"++\\\+", "&#x059B;");
                textContent = textContent.Replace(@"\\++\+", "&#x05A4;");
                textContent = textContent.Replace(@"++\++\", "&#x0593;");
                textContent = textContent.Replace(@"++\++\", "&#x059A;");
                textContent = textContent.Replace(@"\+\\\+", "&#x059A;");
                textContent = textContent.Replace(@"\++\++", "&#x05AE;");
                textContent = textContent.Replace(@"++\\++", "&#x05AB;");
                textContent = textContent.Replace(@"+\+\++", "&#x05AD;");
                textContent = textContent.Replace(@"+\+\\+", "&#x059D;");
                textContent = textContent.Replace(@"\\+\++", "&#x05AC;");
                textContent = textContent.Replace(@"\\+\++", "&#x05AC;");
            }
            //textContent = Regex.Replace(textContent, @"\{{2,}", "{");
            //textContent = Regex.Replace(textContent, @"\}{2,}", "}");
            textContent = Regex.Replace(textContent, @"\[{2,}", "[");
            textContent = Regex.Replace(textContent, @"\]{2,}", "]");
            textContent = Regex.Replace(textContent, @"\({2,}", "(");
            textContent = Regex.Replace(textContent, @"\){2,}", ")");

            string tanachBooks = "\r\n|בראשית - עם ניקוד\r\n|בראשית - עם טעמים\r\n|בראשית - ללא ניקוד\r\n|בראשית - רש''י\r\n|בראשית - רש''י (ב)\r\n|בראשית - שפתי חכמים\r\n|בראשית - רמב''ן\r\n|בראשית - תרגום יונתן\r\n|בראשית - אור החיים\r\n|בראשית - אבן עזרא\r\n|בראשית - בעל הטורים\r\n|בראשית - תרגום אונקלוס\r\n|בראשית - ספורנו\r\n|בראשית - כלי יקר\r\n|בראשית - דעת זקנים\r\n|מדרש רבה - חומש בראשית\r\n|מדרש תנחומא - בראשית\r\n|ילקוט שמעוני - בראשית\r\n|חק לישראל - בראשית\r\n|חק לישראל - בראשית  (ט)\r\n|שמות  -עם ניקוד\r\n|שמות  -עם טעמים\r\n|שמות  - ללא ניקוד\r\n|שמות - רש''י\r\n|שמות - רש''י (ב)\r\n|שמות - שפתי חכמים\r\n|שמות - רמב''ן\r\n|שמות - תרגום יונתן\r\n|שמות - אור החיים\r\n|שמות - אבן עזרא\r\n|שמות - בעל הטורים\r\n|שמות - תרגום אונקלוס\r\n|שמות - ספורנו\r\n|שמות - כלי יקר\r\n|שמות - דעת זקנים\r\n|מדרש רבה - חומש שמות\r\n|מדרש תנחומא - שמות\r\n|ילקוט שמעוני - שמות\r\n|חק לישראל - שמות\r\n|חק לישראל - שמות  (ט)\r\n|ויקרא - עם ניקוד\r\n|ויקרא - עם טעמים\r\n|ויקרא  - ללא ניקוד\r\n|ויקרא - רש''י\r\n|ויקרא - רש''י (ב)\r\n|ויקרא - שפתי חכמים\r\n|ויקרא - רמב''ן\r\n|ויקרא - תרגום יונתן\r\n|ויקרא אור החיים\r\n|ויקרא - אבן עזרא\r\n|ויקרא - בעל הטורים\r\n|ויקרא - תרגום אונקלוס\r\n|ויקרא - ספורנו\r\n|ויקרא - כלי יקר\r\n|ויקרא - דעת זקנים\r\n|מדרש רבה - חומש ויקרא\r\n|מדרש תנחומא - ויקרא\r\n|ילקוט שמעוני - ויקרא\r\n|חק לישראל - ויקרא\r\n|חק לישראל - ויקרא  (ט)\r\n|במדבר - עם ניקוד\r\n|במדבר - עם טעמים\r\n|במדבר - ללא ניקוד\r\n|במדבר - רש''י\r\n|במדבר - רש''י (ב)\r\n|במדבר - שפתי חכמים\r\n|במדבר - רמב''ן\r\n|במדבר - תרגום יונתן\r\n|במדבר אור החיים\r\n|במדבר - אבן עזרא\r\n|במדבר - בעל הטורים\r\n|במדבר - תרגום אונקלוס\r\n|במדבר - ספורנו\r\n|במדבר - כלי יקר\r\n|במדבר - דעת זקנים\r\n|מדרש רבה - חומש במדבר\r\n|מדרש תנחומא - במדבר\r\n|ילקוט שמעוני - במדבר\r\n|חק לישראל - במדבר\r\n|חק לישראל - במדבר  (ט)\r\n|דברים - עם ניקוד\r\n|דברים - עם טעמים\r\n|דברים - ללא ניקוד\r\n|דברים - רש''י\r\n|דברים - רש''י (ב)\r\n|דברים - שפתי חכמים\r\n|דברים - רמב''ן\r\n|דברים - תרגום יונתן\r\n|דברים אור החיים\r\n|דברים - אבן עזרא\r\n|דברים - בעל הטורים\r\n|דברים - תרגום אונקלוס\r\n|דברים - ספורנו\r\n|דברים - כלי יקר\r\n|דברים - דעת זקנים\r\n|מדרש רבה - חומש דברים\r\n|מדרש תנחומא - דברים\r\n|ילקוט שמעוני - דברים\r\n|חק לישראל - דברים\r\n|חק לישראל - דברים  (ט)\r\n|יהושע - עם ניקוד\r\n|יהושע - עם טעמים\r\n|יהושע - ללא ניקוד\r\n|יהושע - רש''י\r\n|יהושע - מצודת דוד\r\n|יהושע - מצודת ציון\r\n|יהושע - רלב''ג\r\n|שופטים - עם ניקוד\r\n|שופטים - עם טעמים\r\n|שופטים - ללא ניקוד\r\n|שופטים - רש''י\r\n|שופטים - מצודת דוד\r\n|שופטים - מצודת ציון\r\n|שופטים - רלב''ג\r\n|שמואל א - עם ניקוד\r\n|שמואל א - עם טעמים\r\n|שמואל א - ללא ניקוד\r\n|שמואל א - רש''י\r\n|שמואל א - מצודת דוד\r\n|שמואל א - מצודת ציון\r\n|שמואל א - רלב''ג\r\n|שמואל א - מלבי''ם\r\n|שמואל ב - עם ניקוד\r\n|שמואל ב - עם טעמים\r\n|שמואל ב - ללא ניקוד\r\n|שמואל ב - רש''י\r\n|שמואל ב - מצודת דוד\r\n|שמואל ב - מצודת ציון\r\n|שמואל ב - רלב''ג\r\n|שמואל ב - מלבי''ם\r\n|מלכים א - עם ניקוד\r\n|מלכים א - עם טעמים\r\n|מלכים א - ללא ניקוד\r\n|מלכים א - רש''י\r\n|מלכים א - מצודת דוד\r\n|מלכים א - מצודת ציון\r\n|מלכים א - רלב''ג\r\n|מלכים א - מלבי''ם\r\n|מלכים ב - עם ניקוד\r\n|מלכים ב - עם טעמים\r\n|מלכים ב - ללא ניקוד\r\n|מלכים ב - רש''י\r\n|מלכים ב - מצודת דוד\r\n|מלכים ב - מצודת ציון\r\n|מלכים ב - רלב''ג\r\n|מלכים ב - מלבי''ם\r\n|ישעיה - עם ניקוד\r\n|ישעיה - עם טעמים\r\n|ישעיה - ללא ניקוד\r\n|ישעיה - רש''י\r\n|ישעיה - מצודת דוד\r\n|ישעיה - מצודת ציון\r\n|ישעיה - מלבי''ם - ב. הענין\r\n|ישעיה - מלבי''ם - ב. המילת\r\n|ירמיה - עם ניקוד\r\n|ירמיה - עם טעמים\r\n|ירמיה - ללא ניקוד\r\n|ירמיה - רש''י\r\n|ירמיה - מצודת דוד\r\n|ירמיה - מצודת ציון\r\n|ירמיה- מלבי''ם - ב. הענין\r\n|ירמיה - מלבי''ם - ב. המילת\r\n|יחזקאל - עם ניקוד\r\n|יחזקאל - עם טעמים\r\n|יחזקאל - ללא ניקוד\r\n|יחזקאל - רש''י\r\n|יחזקאל - מצודת דוד\r\n|יחזקאל - מצודת ציון\r\n|יחזקאל - מלבי''ם - ב. הענין\r\n|(2) יחזקאל - מלבי''ם - ב. הענין\r\n|הושע - עם ניקוד\r\n|הושע - עם טעמים\r\n|הושע - ללא ניקוד\r\n|הושע - רש''י\r\n|הושע - מצודת דוד\r\n|הושע - מצודת ציון\r\n|יואל - עם ניקוד\r\n|יואל - עם טעמים\r\n|יואל - ללא ניקוד\r\n|יואל - רש''י\r\n|יואל - מצודת דוד\r\n|יואל - מצודת ציון\r\n|עמוס - עם ניקוד\r\n|עמוס - עם טעמים\r\n|עמוס - ללא ניקוד\r\n|עמוס - רש''י\r\n|עמוס - מצודת דוד\r\n|עמוס - מצודת ציון\r\n|עובדיה - עם ניקוד\r\n|עובדיה - עם טעמים\r\n|עובדיה - ללא ניקוד\r\n|עובדיה - רש''י\r\n|עובדיה - מצודת דוד\r\n|עובדיה - מצודת ציון\r\n|יונה - עם ניקוד\r\n|יונה - עם טעמים\r\n|יונה - ללא ניקוד\r\n|יונה - רש''י\r\n|יונה - מצודת דוד\r\n|יונה - מצודת ציון\r\n|מיכה - עם ניקוד\r\n|מיכה - עם טעמים\r\n|מיכה - ללא ניקוד\r\n|מיכה - רש''י\r\n|מיכה - מצודת דוד\r\n|מיכה - מצודת ציון\r\n|נחום - עם ניקוד\r\n|נחום - עם טעמים\r\n|נחום - ללא ניקוד\r\n|נחום - רש''י\r\n|נחום - מצודת דוד\r\n|נחום - מצודת ציון\r\n|חבקוק - עם ניקוד\r\n|חבקוק - עם טעמים\r\n|חבקוק - ללא ניקוד\r\n|חבקוק - רש''י\r\n|חבקוק - מצודת דוד\r\n|חבקוק - מצודת ציון\r\n|צפניה - עם ניקוד\r\n|צפניה - עם טעמים\r\n|צפניה - ללא ניקוד\r\n|צפניה - רש''י\r\n|צפניה - מצודת דוד\r\n|צפניה - מצודת ציון\r\n|חגי - עם ניקוד\r\n|חגי - עם טעמים\r\n|חגי - ללא ניקוד\r\n|חגי - רש''י\r\n|חגי - מצודת דוד\r\n|חגי - מצודת ציון\r\n|זכריה - עם ניקוד\r\n|זכריה - עם טעמים\r\n|זכריה - ללא ניקוד\r\n|זכריה - רש''י\r\n|זכריה - מצודת דוד\r\n|זכריה - מצודת ציון\r\n|מלאכי - עם ניקוד\r\n|מלאכי - עם טעמים\r\n|מלאכי - ללא ניקוד\r\n|מלאכי - רש''י\r\n|מלאכי - מצודת דוד\r\n|מלאכי - מצודת ציון\r\n|תהילים - עם ניקוד\r\n|תהילים - עם טעמים\r\n|תהילים - ללא ניקוד\r\n|תהילים - רש''י\r\n|תהילים - מצודת דוד\r\n|תהילים - מצודת ציון\r\n|תהילים - מלבי''ם - ב. הענין\r\n|תהילים - מלבי''ם - ב. המלות\r\n|תהילים - מחולק לספרים\r\n|תהילים - מחולק לימי השבוע\r\n|תהילים - מחולק לימי החודש\r\n|משלי - עם ניקוד\r\n|משלי - עם טעמים\r\n|משלי - ללא ניקוד\r\n|משלי - רש''י\r\n|משלי - מצודת דוד\r\n|משלי - מצודת ציון\r\n|משלי - רלב''ג\r\n|איוב - עם ניקוד\r\n|איוב - עם טעמים\r\n|איוב - ללא ניקוד\r\n|איוב - רש''י\r\n|איוב - מצודת דוד\r\n|איוב - מצודת ציון\r\n|איוב - רלב''ג\r\n|שיר השירים - עם ניקוד\r\n|שיר השירים - עם טעמים\r\n|שיר השירים - ללא ניקוד\r\n|שיר השירים - רש''י\r\n|שיר השירים - מצודת דוד\r\n|שיר השירים - מצודת ציון\r\n|מדרש רבה - שיר השירים רבה\r\n|רות - עם ניקוד\r\n|רות - עם טעמים\r\n|רות - ללא ניקוד\r\n|רות - רש''י\r\n|מדרש רבה - רות רבה\r\n|איכה - עם ניקוד\r\n|איכה - עם טעמים\r\n|איכה - ללא ניקוד\r\n|איכה - רש''י\r\n|מדרש רבה - איכה רבתי\r\n|קהלת - עם ניקוד\r\n|קהלת - עם טעמים\r\n|קהלת - ללא ניקוד\r\n|קהלת - רש''י\r\n|קהלת - מצודת דוד\r\n|קהלת - מצודת ציון\r\n|מדרש רבה - קהלת רבה\r\n|אסתר - עם ניקוד\r\n|אסתר - עם טעמים\r\n|אסתר - ללא ניקוד\r\n|אסתר - רש''י\r\n|אסתר - מלבי''ם\r\n|מדרש רבה - אסתר רבה\r\n|דניאל - עם ניקוד\r\n|דניאל - עם טעמים\r\n|דניאל - ללא ניקוד\r\n|דניאל - רש''י\r\n|דניאל - מצודת דוד\r\n|דניאל - מצודת ציון\r\n|עזרא - עם ניקוד\r\n|עזרא - עם טעמים\r\n|עזרא - ללא ניקוד\r\n|עזרא - רש''י\r\n|עזרא - מצודת דוד\r\n|עזרא - מצודת ציון\r\n|עזרא - רלב''ג\r\n|נחמיה - עם ניקוד\r\n|נחמיה - עם טעמים\r\n|נחמיה - ללא ניקוד\r\n|נחמיה - רש''י\r\n|נחמיה - מצודת דוד\r\n|נחמיה - מצודת ציון\r\n|נחמיה - רלב''ג\r\n|דברי הימים א - עם ניקוד\r\n|דברי הימים א - עם טעמים\r\n|דברי הימים א - ללא ניקוד\r\n|דברי הימים א - רש''י\r\n|דברי הימים א - מצודת דוד\r\n|דברי הימים א - מצודת ציון\r\n|דברי הימים א - רלב''ג\r\n|דברי הימים ב - עם ניקוד\r\n|דברי הימים ב - עם טעמים\r\n|דברי הימים ב - ללא ניקוד\r\n|דברי הימים ב - רש''י\r\n|דברי הימים ב - מצודת דוד\r\n|דברי הימים ב - מצודת ציון\r\n|דברי הימים ב - רלב''ג";
            string[] books = tanachBooks.Split(new[] { "\r\n|" }, StringSplitOptions.RemoveEmptyEntries);
            bool istanachbooks = books.Any(word => fileName.Trim().Equals(word.Trim()));
            if (!istanachbooks) { textContent = textContent.Replace("{", ""); textContent = textContent.Replace("}", ""); }
        }

        private string buildhtml(string fileContent)
        {
            try
            {
                string fontName = Properties.Settings.Default.fontName;
                string fontSize = Properties.Settings.Default.fontSize.ToString();
                string fontLineSpacing = Properties.Settings.Default.fontlineSpacing.ToString();

                // Use string interpolation to insert the CSS styles into the HTML content
                string htmlContent = $@"
<!DOCTYPE html>
<html>
<meta http-equiv=""X-UA-Compatible"" content=""IE=8"">
<head>
    <meta charset=""UTF-8"">
    <style>
        h1, h2, h3, h4, h5, h6 {{
            color: Navy !important;
            font-family: {fontName};
            direction: rtl;
            text-align: right;
        }}
       body {{
        font-family: '{fontName}';
        padding: 0.5px;
        padding-top: 0;
        direction: rtl;
        text-align: right;
        text-align: justify;
        line-height: {fontLineSpacing};
        font-size: {fontSize}px; // Explicitly set font size here
    }}
</style>
</head>
<body>
{fileContent}
</body>
</html>";
                return htmlContent;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return fileContent; }
        }

        public bool isTanach(string bookName)
        {
            if (bookName.Contains("אונקלוס")
|| bookName.Contains("בראשית - עם ניקוד")
|| bookName.Contains("בראשית - עם טעמים")
|| bookName.Contains("בראשית - ללא ניקוד")
|| bookName.Contains("שמות  -עם ניקוד")
|| bookName.Contains("שמות  -עם טעמים")
|| bookName.Contains("שמות  - ללא ניקוד")
|| bookName.Contains("ויקרא - עם ניקוד")
|| bookName.Contains("ויקרא - עם טעמים")
|| bookName.Contains("ויקרא  - ללא ניקוד")
|| bookName.Contains("במדבר - עם ניקוד")
|| bookName.Contains("במדבר - עם טעמים")
|| bookName.Contains("במדבר - ללא ניקוד")
|| bookName.Contains("דברים - עם ניקוד")
|| bookName.Contains("דברים - עם טעמים")
|| bookName.Contains("דברים - ללא ניקוד")
|| bookName.Contains("יהושע - עם ניקוד")
|| bookName.Contains("יהושע - עם טעמים")
|| bookName.Contains("יהושע - ללא ניקוד")
|| bookName.Contains("שופטים - עם ניקוד")
|| bookName.Contains("שופטים - עם טעמים")
|| bookName.Contains("שופטים - ללא ניקוד")
|| bookName.Contains("שמואל א - עם ניקוד")
|| bookName.Contains("שמואל א - עם טעמים")
|| bookName.Contains("שמואל א - ללא ניקוד")
|| bookName.Contains("שמואל ב - עם ניקוד")
|| bookName.Contains("שמואל ב - עם טעמים")
|| bookName.Contains("שמואל ב - ללא ניקוד")
|| bookName.Contains("מלכים א - עם ניקוד")
|| bookName.Contains("מלכים א - עם טעמים")
|| bookName.Contains("מלכים א - ללא ניקוד")
|| bookName.Contains("מלכים ב - עם ניקוד")
|| bookName.Contains("מלכים ב - עם טעמים")
|| bookName.Contains("מלכים ב - ללא ניקוד")
|| bookName.Contains("ישעיה - עם ניקוד")
|| bookName.Contains("ישעיה - עם טעמים")
|| bookName.Contains("ישעיה - ללא ניקוד")
|| bookName.Contains("ירמיה - עם ניקוד")
|| bookName.Contains("ירמיה - עם טעמים")
|| bookName.Contains("ירמיה - ללא ניקוד")
|| bookName.Contains("יחזקאל - עם ניקוד")
|| bookName.Contains("יחזקאל - עם טעמים")
|| bookName.Contains("יחזקאל - ללא ניקוד")
|| bookName.Contains("הושע - עם ניקוד")
|| bookName.Contains("הושע - עם טעמים")
|| bookName.Contains("הושע - ללא ניקוד")
|| bookName.Contains("יואל - עם ניקוד")
|| bookName.Contains("יואל - עם טעמים")
|| bookName.Contains("יואל - ללא ניקוד")
|| bookName.Contains("עמוס - עם ניקוד")
|| bookName.Contains("עמוס - עם טעמים")
|| bookName.Contains("עמוס - ללא ניקוד")
|| bookName.Contains("עובדיה - עם ניקוד")
|| bookName.Contains("עובדיה - עם טעמים")
|| bookName.Contains("עובדיה - ללא ניקוד")
|| bookName.Contains("יונה - עם ניקוד")
|| bookName.Contains("יונה - עם טעמים")
|| bookName.Contains("יונה - ללא ניקוד")
|| bookName.Contains("מיכה - עם ניקוד")
|| bookName.Contains("מיכה - עם טעמים")
|| bookName.Contains("מיכה - ללא ניקוד")
|| bookName.Contains("נחום - עם ניקוד")
|| bookName.Contains("נחום - עם טעמים")
|| bookName.Contains("נחום - ללא ניקוד")
|| bookName.Contains("חבקוק - עם ניקוד")
|| bookName.Contains("חבקוק - עם טעמים")
|| bookName.Contains("חבקוק - ללא ניקוד")
|| bookName.Contains("צפניה - עם ניקוד")
|| bookName.Contains("צפניה - עם טעמים")
|| bookName.Contains("צפניה - ללא ניקוד")
|| bookName.Contains("חגי - עם ניקוד")
|| bookName.Contains("חגי - עם טעמים")
|| bookName.Contains("חגי - ללא ניקוד")
|| bookName.Contains("זכריה - עם ניקוד")
|| bookName.Contains("זכריה - עם טעמים")
|| bookName.Contains("זכריה - ללא ניקוד")
|| bookName.Contains("מלאכי - עם ניקוד")
|| bookName.Contains("מלאכי - עם טעמים")
|| bookName.Contains("מלאכי - ללא ניקוד")
|| bookName.Contains("תהילים - עם ניקוד")
|| bookName.Contains("תהילים - עם טעמים")
|| bookName.Contains("תהילים - ללא ניקוד")
|| bookName.Contains("משלי - עם ניקוד")
|| bookName.Contains("משלי - עם טעמים")
|| bookName.Contains("משלי - ללא ניקוד")
|| bookName.Contains("איוב - עם ניקוד")
|| bookName.Contains("איוב - עם טעמים")
|| bookName.Contains("איוב - ללא ניקוד")
|| bookName.Contains("שיר השירים - עם ניקוד")
|| bookName.Contains("שיר השירים - עם טעמים")
|| bookName.Contains("שיר השירים - ללא ניקוד")
|| bookName.Contains("רות - עם ניקוד")
|| bookName.Contains("רות - עם טעמים")
|| bookName.Contains("רות - ללא ניקוד")
|| bookName.Contains("איכה - עם ניקוד")
|| bookName.Contains("איכה - עם טעמים")
|| bookName.Contains("איכה - ללא ניקוד")
|| bookName.Contains("קהלת - עם ניקוד")
|| bookName.Contains("קהלת - עם טעמים")
|| bookName.Contains("קהלת - ללא ניקוד")
|| bookName.Contains("אסתר - עם ניקוד")
|| bookName.Contains("אסתר - עם טעמים")
|| bookName.Contains("אסתר - ללא ניקוד")
|| bookName.Contains("דניאל - עם ניקוד")
|| bookName.Contains("דניאל - עם טעמים")
|| bookName.Contains("דניאל - ללא ניקוד")
|| bookName.Contains("עזרא - עם ניקוד")
|| bookName.Contains("עזרא - עם טעמים")
|| bookName.Contains("עזרא - ללא ניקוד")
|| bookName.Contains("נחמיה - עם ניקוד")
|| bookName.Contains("נחמיה - עם טעמים")
|| bookName.Contains("נחמיה - ללא ניקוד")
|| bookName.Contains("דברי הימים א - עם ניקוד")
|| bookName.Contains("דברי הימים א - עם טעמים")
|| bookName.Contains("דברי הימים א - ללא ניקוד")
|| bookName.Contains("דברי הימים ב - עם ניקוד")
|| bookName.Contains("דברי הימים ב - עם טעמים")
|| bookName.Contains("דברי הימים ב - ללא ניקוד")
                )
            { return true; }
            else { return false; }
        }

        private void NormalizeHebrewText(ref string textContent)
        {
            // Normalize Hebrew text (e.g., remove diacritics)
            // You may need to implement this normalization based on your specific requirements.
            // Example: Normalize to remove diacritics (NFD normalization)
            textContent = new string(textContent.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()); // Normalize Hebrew text.
        }
    }
}
