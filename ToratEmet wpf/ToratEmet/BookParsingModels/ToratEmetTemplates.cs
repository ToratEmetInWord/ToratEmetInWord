using System.Linq;
using System.Text.RegularExpressions;
using ToratEmet.Extensions;
using ToratEmet.Models;

namespace ToratEmet.BookParsingModels
{
    public class ToratEmetTemplates
    {
        BookParser parser;
        public int counter = 0;
        public string placeHolder = "";
        Regex generalRegex = new Regex(@"aa|bb| אִגֶּרֶת הַתְּשׁוּבָה|ExpandColapseScript\(\)|RIGHT|LEFT");
        Regex squareBraketsRegex = new Regex(@"\[{2,}", RegexOptions.Compiled);
        Regex squareBraketsRegex2 = new Regex(@"\]{2,}", RegexOptions.Compiled);
        Regex curlyBrackets = new Regex(@"\{+", RegexOptions.Compiled);
        Regex curlyBrackets2 = new Regex(@"\}+", RegexOptions.Compiled);

        public string ApplyTemplates(string line, string filePath, BookParser bookParser, bool reProcessLine)
        {
            parser = bookParser;
            if (filePath.Contains("shimoni"))
            {
                line = ShimoniTemplate(line);
            }
            else if (filePath.Contains("hok"))
            {
                line = Hok_Template(line);
            }
            else if (filePath.Contains("SHIR_HASHIRIM") && filePath.Contains("raba"))
            {
                line = ShirHashirimRabbaTemplate(line);
            }
            else if (filePath.Contains("TORA")||filePath.Contains("NAVI")||filePath.Contains("KTUVIM"))
            {
                line = TanachTemplate(line, filePath);
            }
            else if (filePath.Contains("BAVLI")&&filePath.Contains("Hav"))
            {
                line = Chavruta_Template(line);
            }
            else if (filePath.Contains("BAVLI"))
            {
                line = Bavli_Template(line);
            }
            else if (filePath.Contains("RAMBAM"))
            {
                line = Rambam_Template(line);
            }
            else if (Regex.IsMatch(filePath, @"orach_chaim|yore_deaa|even_haezer|choshen_mishpat"))
            {
                line = ShulchanAruch_Template(line);
            }
            else if (filePath.Contains("kitzur"))
            {
                line = Kitzur_Template(line);
            }
            else if (filePath.Contains("hh_L1")||filePath.EndsWith("ShmiratHalashon_L1.txt"))
            {
                line = ChofetzChayim_Template(line);
            }
            else if (filePath.Contains("OTSAR_DINIM"))
            {
                line = OtzarDinim_Template(line);
            }
            else if (filePath.Contains("shaarei_kedusha"))
            {
                line = ShaareiKedushaTemplate(line);
            }
            else if (filePath.Contains("DAAT_TVUNOT"))
            {
                line = ShequelHakodeshTemplate(line);
            }
            else if (filePath.Contains("TomerDevora")||filePath.EndsWith("igeret_teiman.txt"))
            {
                line = TomerDovraTemplate(line);
            }
            else if (filePath.Contains("derech_hashem")||filePath.EndsWith("TenPrakinLaRanchal.txt"))
            {
                line = RamchalTemplate(line);
            }
            else if (filePath.EndsWith("SeferHayashar.txt"))
            {
                line = SeferHayasharTemplate(line);
            }
            else if (filePath.EndsWith("DaatTvunot.txt"))
            {
                line = DaasTvunosTemplate(line);
            }
            else if (filePath.EndsWith("ahavat_chesed.txt"))
            {
                line = AhavatChesed(line);
            }
            else if(filePath.Contains("sidur"))
            {
                line = SiddurTemplate(line);
            }
            else if (filePath.Contains("sidur"))
            {
                line = SiddurTemplate(line);
            }
            else if (filePath.ToLower().Contains("hagada"))
            {
                line = HaggadaTemplate(line);
            }

            line = GeneralTemplate(line);
            if (reProcessLine) { processLine(line); }
            return line;
        }

        void processLine(string line)
        {
            string[] lines = line.LinesArray();
            foreach (string splitLine in lines)
            {
                parser.ProcessLine(splitLine, "");
            }            
        }
        public string TanachTemplate(string line, string filePath)
        {
            if (filePath.Contains("\\a0")||filePath.Contains("\\b0"))
            {
                line = line.Replace("-", "־").Replace("background־color", "background-color").Replace("פרק־", "פרק ");
            }

            char[] startChars = { '!', '~', '^', '@', '#' };

            if (line.StartsWith("^ פרשת"))
            {
                line = line
                    .Replace("פרשת נח" ,"פרשת נח" +"\r\n" +"~ המשך פרק ו")
.Replace("פרשת תולדות" ,"פרשת תולדות" +"\r\n" +"~ המשך פרק כה")
.Replace("פרשת ויצא" ,"פרשת ויצא" +"\r\n" +"~ המשך פרק כח")
.Replace("פרשת וישלח" ,"פרשת וישלח" +"\r\n" +"~ המשך פרק לב")
.Replace("פרשת ויגש" ,"פרשת ויגש" +"\r\n" +"~ המשך פרק מד")
.Replace("פרשת ויחי" ,"פרשת ויחי" +"\r\n" +"~ המשך פרק מז")
.Replace("פרשת וארא" ,"פרשת וארא" +"\r\n" +"~ המשך פרק ו")
.Replace("פרשת בשלח" ,"פרשת בשלח" +"\r\n" +"~ המשך פרק יג")
.Replace("פרשת כי" ,"פרשת כי" +"\r\n" +"תשא ~ המשך פרק ל")
.Replace("פרשת פקודי" ,"פרשת פקודי" +"\r\n" +"~ המשך פרק לח")
.Replace("פרשת בחקתי" ,"פרשת בחקתי" +"\r\n" +"~ המשך פרק כו")
.Replace("פרשת נשא" ,"פרשת נשא" +"\r\n" +"~ המשך פרק ד")
.Replace("פרשת בלק" ,"פרשת בלק" +"\r\n" +"~ המשך פרק כב")
.Replace("פרשת פינחס" ,"פרשת פינחס" +"\r\n" +"~ המשך פרק כה")
.Replace("פרשת מטות" ,"פרשת מטות" +"\r\n" +"~ המשך פרק ל")
.Replace("פרשת ואתחנן" ,"פרשת ואתחנן" +"\r\n" +"~ המשך פרק ג")
.Replace("פרשת עקב" ,"פרשת עקב" +"\r\n" +"~ המשך פרק ז")
.Replace("פרשת ראה" ,"פרשת ראה" +"\r\n" +"~ המשך פרק יא")
.Replace("פרשת שופטים" ,"פרשת שופטים" +"\r\n" +"~ המשך פרק טז")
.Replace("פרשת כי" ,"פרשת כי" +"\r\n" +"תצא ~ המשך פרק כא")
.Replace("פרשת נצבים" ,"פרשת נצבים" +"\r\n" +"~ המשך פרק כט")
;
            }
            else if (startChars.Any(c => line.StartsWith(c.ToString())))
            {
            line = line.Replace("בראשית ", "")
.Replace("שמות ", "")
.Replace("ויקרא ", "")
.Replace("במדבר ", "")
.Replace("דברים ", "")
.Replace("יהושע ", "")
.Replace("שופטים ", "")
.Replace("שמואל א ", "")
.Replace("שמואל ב ", "")
.Replace("מלכים א ", "")
.Replace("מלכים ב ", "")
.Replace("ישעיה ", "")
.Replace("ירמיה ", "")
.Replace("יחזקאל ", "")
.Replace("הושע ", "")
.Replace("יואל ", "")
.Replace("עמוס ", "")
.Replace("עובדיה ", "")
.Replace("יונה ", "")
.Replace("מיכה ", "")
.Replace("נחום ", "")
.Replace("חבקוק ", "")
.Replace("צפניה ", "")
.Replace("חגי ", "")
.Replace("זכריה ", "")
.Replace("מלאכי ", "")
.Replace("תהילים ", "")
.Replace("משלי ", "")
.Replace("איוב ", "")
.Replace("שיר השירים ", "")
.Replace("רות ", "")
.Replace("איכה ", "")
.Replace("קהלת ", "")
.Replace("אסתר ", "")
.Replace("דניאל ", "")
.Replace("עזרא ", "")
.Replace("נחמיה ", "")
.Replace("דברי הימים א ", "")
.Replace("דברי הימים ב ", "");
            }
            return line;
        }
        string GeneralTemplate(string line)
        {
            if (line.StartsWith("**INDEX_WRITE")) { line = ""; }

            if (line.StartsWith("&"))
            {
                line = Regex.Replace(line, "^[א-ת]", " ");
                line = Regex.Replace(line, @"\s+", " ");
            }

            if (line.StartsWith("! ")) { line = line.Replace("{", "").Replace("}", ""); }

            line = Cantillations(line);
            line = generalRegex.Replace(line, "");
            line = squareBraketsRegex.Replace(line, "<b>");
            line = squareBraketsRegex2.Replace(line, "</b>");

            line = line
                .Replace("//", "")
                .Replace("((", "<small>")
                .Replace("))", "</small>")
                .Replace("(((", "<small>")
                .Replace(")))", "</small>")
                .Replace("xx", "[")
                .Replace("yy", "]")
                .Replace(" .", ". ")
                .Replace(" ,", ", ")
                .Replace(" :", ": ")
                .Replace("..", ".")
                .Replace("SB", "(")
                .Replace("SE", ")")
                .Replace("<span style=\"color:2266ff\">", "<span class=\"note2\">");

            line = curlyBrackets.Replace(line, "{");
            line = curlyBrackets2.Replace(line, "}");

            return line;
        }
        string Cantillations(string text)
        {
            if (text.Contains("+"))
            {
                //create טעמים
                //text = text.Replace(@"+\++\++\++\+", "&#x05A6;");
                //text = text.Replace(@"\\\+\++\\\++", "&#x059F;");
                //text = text.Replace(@"+\+\\++++++\", "&#x059D;&#x0597;");
                //text = text.Replace(@"\++\\\+++++\\++\\\", "&#856;&#856;");
                //text = text.Replace(@"\++\\\\++\\\", "&#856;");
                //text = text.Replace(@"+\++\+\\\\++", "&#5A8;&#5A5;");
                //text = text.Replace(@"\+\\++", "&#x05AA;");
                //text = text.Replace(@"+\\\\+", "&#x0599;");
                //text = text.Replace(@"\\\\++", "&#x0599;");
                //text = text.Replace(@"++\+\+", "&#x05A3;");
                //text = text.Replace(@"\\\\\+", "&#x0598;");
                //text = text.Replace(@"\+\++\", "&#x0592;");
                //text = text.Replace(@"+++++\", "&#x0597;");
                //text = text.Replace(@"\\+++\", "&#x0594;");
                //text = text.Replace(@"+\+++\", "&#x0595;");
                //text = text.Replace(@"+\++\+", "&#x05A5;");
                //text = text.Replace(@"\++++\", "&#x0596;");
                //text = text.Replace(@"+\\++\", "&#x0591;");
                //text = text.Replace(@"+\\+\+", "&#x05A1;");
                //text = text.Replace(@"+\\\++", "&#x05A9;");
                //text = text.Replace(@"\\\+\+", "&#x05A0;");
                //text = text.Replace(@"\\+\\+", "&#x059C;");
                //text = text.Replace(@"\++\\+", "&#x059E;");
                //text = text.Replace(@"++++\+", "&#x05A7;");
                //text = text.Replace(@"++\\\+", "&#x059B;");
                //text = text.Replace(@"\\++\+", "&#x05A4;");
                //text = text.Replace(@"++\++\", "&#x0593;");
                //text = text.Replace(@"++\++\", "&#x059A;");
                //text = text.Replace(@"\+\\\+", "&#x059A;");
                //text = text.Replace(@"\++\++", "&#x05AE;");
                //text = text.Replace(@"++\\++", "&#x05AB;");
                //text = text.Replace(@"+\+\++", "&#x05AD;");
                //text = text.Replace(@"+\+\\+", "&#x059D;");
                //text = text.Replace(@"\\+\++", "&#x05AC;");
                //text = text.Replace(@"\\+\++", "&#x05AC;");
                text = text.Replace(@"+\++\++\++\+", "֦");
                text = text.Replace(@"\\\+\++\\\++", "֟");
                text = text.Replace(@"+\+\\++++++\", "֝֗");
                text = text.Replace(@"\++\\\+++++\\++\\\", "֗");
                text = text.Replace(@"\++\\\\++\\\", "ׄ ׄ");
                text = text.Replace(@"+\++\+\\\\++", "֥֨");
                text = text.Replace(@"\+\\++", "֪");
                text = text.Replace(@"+\\\\+", "֙");
                text = text.Replace(@"\\\\++", "֙");
                text = text.Replace(@"++\+\+", "֣");
                text = text.Replace(@"\\\\\+", "֘");
                text = text.Replace(@"\+\++\", "֒");
                text = text.Replace(@"+++++\", "֗");
                text = text.Replace(@"\\+++\", "֔");
                text = text.Replace(@"+\+++\", "֕");
                text = text.Replace(@"+\++\+", "֥");
                text = text.Replace(@"\++++\", "֖");
                text = text.Replace(@"+\\++\", "֑");
                text = text.Replace(@"+\\+\+", "֡");
                text = text.Replace(@"+\\\++", "֩");
                text = text.Replace(@"\\\+\+", "֠");
                text = text.Replace(@"\\+\\+", "֜");
                text = text.Replace(@"\++\\+", "֞");
                text = text.Replace(@"++++\+", "֧");
                text = text.Replace(@"++\\\+", "֛");
                text = text.Replace(@"\\++\+", "֤");
                text = text.Replace(@"++\++\", "֓");
                text = text.Replace(@"++\++\", "֚");
                text = text.Replace(@"\+\\\+", "֚");
                text = text.Replace(@"\++\++", "֮");
                text = text.Replace(@"++\\++", "֫");
                text = text.Replace(@"+\+\++", "֭");
                text = text.Replace(@"+\+\\+", "֝");
                text = text.Replace(@"\\+\++", "֬");
                text = text.Replace(@"\\+\++", "֬");
            }
            return text;
        }
        string ShimoniTemplate(string line)
        {
            
            //Match match2 = Regex.Match(line, @"\{r.*?r\}");

            line = line.Replace("X", "<small style=\"color: #4169E1;\">(")
                .Replace("Y", ")</small>")
                .Replace("{r", "<b><small><small style='background-color:#7694DA; color:white;'>")
                .Replace("r}", "</small></small></b>");

            Match match = Regex.Match(line, @"\{p.*?p\}");
            if (match.Success)
            {
                line = line.Replace(match.Value, "");
                line = "! " + match.Value.Replace("{p", "").Replace("p}", "") +
                    "\r\n" + line;
            }
            return line;
        }
        string Hok_Template(string line)
        {
            if (line.StartsWith("<!--")||line.StartsWith("*")) { return ""; }
            else if (line.StartsWith("~ תפלה") || line.StartsWith("~ יסוד") || line.StartsWith("~ נוסחי")) 
            {
                line = line.Replace("~", "@"); 
            }
            else if (line.StartsWith("@ ") && Regex.IsMatch(line, @"יום [^ ]+ +תורה\z"))//fix mistakingly merged header of יום and תורה
            {
                line = line.Replace("@ ", "");
                string[] words = line.Split(' ');
                string line2 = words[words.Length - 1].Trim();
                if (!string.IsNullOrEmpty(line2)) { line = line.Replace(line2, ""); }

                line = "@ " + line + "\r\n~ " + line2;
            }

            line = line.Replace("<br>", "").Replace("<span>", "").Replace("</span>", "").Replace("<j>", " ").Replace("<p>", "");

            if (line.Contains("<150>"))
            {
                line = "<p style=\"font-size:110%\">" 
                    + line.Replace("</span> <90>", "<span style=\"font-size:80%\">")
                    + "</span></p>";
            }
            else if (line.Contains("RashiTitle"))
            {
                line = Regex.Replace(line, "<RashiTitle.>",
                    "<p class=\"note\"><b style=\"color:gray;\">רש''י:</b><br>") + "</p>";
            }   
            else if (line.Contains("<110>"))
            {
                line = line
                    .Replace("<110>", "<p style=\"font-size:110%\">")
                    .Replace("<BartaTitle>", "</p><p class=\"note\"><b style=\"color:gray;\">ברטנורא:</b><br>")
                    + "</p>";
            }
            else if (line.Contains("<100>") && !line.Contains("<small>"))
            {
                line = line
                    .Replace("<100>", "<p style=\"font-size:110%\">") + "</p>";
            }
            else if (line.Contains("ZoharTitle"))
            {
                line = line.Replace("<ZoharTitle>", "<p class=\"note\"><b style=\"color:gray;\">תרגום הזוהר:</b><br>") + "</p>";
            }
            
                
            line = Regex.Replace(line, "<[0-9]{1,3}>|<[^>]+--[^>]+>|<[^>]+70%[^>]+>", "");
            return line;
        }
        string Bavli_Template(string line)
        {
            if (line.EndsWith("מתני\'") || line.EndsWith("גמ\'")) 
            {
                line = "<big><b>" + Regex.Replace(line, "<.*?>", "") + "</b></big>"; 
            }
            return line;
        }
        string Chavruta_Template(string line)
        {
            if (!line.StartsWith("&") && !line.StartsWith("$"))
            {
                
                line = Regex.Replace(line, @"\{\~(\d+)\~\}", match => $"<sup><a href=\"#{"fn_" + match.Groups[1].Value}\" id=\"{"src_" + match.Groups[1].Value}\" title=\"לחץ כדי לעבור להערה\">" + match.Groups[1].Value + "</a></sup>");
                line = Regex.Replace(line, @"\[\~(\d+)\.\~\]", match => $"<br><b><a href=\"#{"src_" + match.Groups[1].Value}\" id=\"{"fn_" + match.Groups[1].Value}\" style=\"color:#ff6347;\" title=\"לחץ כדי לעבור חזרה לתוכן\">" + match.Groups[1].Value + ".</a></b>");
                
                line = line
                     .Replace("BBOX1", "<hr>").Replace("BBOX2", "<hr>")
                     .Replace("{ההה} <br>", "<div class=\"note\">")
                     .Replace("{ססס}", "</div>")
                    .Replace("{אאא}", "")
                    .Replace("{", "<b>")
                    .Replace("}", "</b>")
                    .Replace("line", "p")
                    .Replace("BBOX1", "")
                    .Replace("BBOX2", "")
                    .Replace("(((", "<p><big><span>")
                    .Replace(")))", "</p></big></span>")
                    .Replace("Y", "")
                    .Replace("Z", "");
            }
            return line;
        }
        string Rambam_Template(string line)
        {
            if (line.ToLower().Equals("<br>")) { line = ""; }
            if (!line.StartsWith("&") && !line.StartsWith("$"))
            {
                line = line.Replace("{{", "%%")
                     .Replace("}}", "%")
                     .Replace("{", "")
                     .Replace("}", "");
                line = line.Replace("%%", "{")
                           .Replace("%", "}");
            }
            return line;
        }
        string ShulchanAruch_Template(string line)
        {
            if (!line.StartsWith("{{{{{")){ line = line.Replace("{{{{", "%%").Replace("}}}}", "%"); }
            line = curlyBrackets.Replace(line, "<small>");
            line = curlyBrackets2.Replace(line, "</small>");
            line = line.Replace("%%", "{").Replace("%", "}");
            return line;
        }
        string Kitzur_Template(string line)
        {
            line = line.Replace("~ ", "@ ");
            if (line.StartsWith("^ ")) { line = "<h4 class=\"customHeader\">" + Regex.Replace(line, @"\^ |\! |\}|\{", "") + ".</h4>"; }
            return line;
        }
        string ChofetzChayim_Template(string line)
        {
            if (line.StartsWith("**INDEX_WRITE")) { line = ""; }
            else if (line.StartsWith("~") && line.Contains("כלל"))
            {
                line = line.Replace("הלכות לשון הרע ", "").Replace("הלכות רכילות ", "").Replace("- ", "");
            }
            else if (line.StartsWith("@") && line.Contains("- כלל"))
            {
                line = line.Replace("הלכות לשון הרע ", "").Replace("הלכות רכילות ", "").Replace("- ", "");
            }
            else
            {
                if (line.Contains("(("))
                {
                    counter++;
                    line = Regex.Replace(line, @"\(\(([^)]*)\)\)", match => $"<a href=\"#{"fn_" + match.Groups[1].Value + counter}\" id=\"{"src_" + match.Groups[1].Value +counter}\" title=\"לחץ כדי לעבור להערה\">(" + match.Groups[1].Value + ")</a>");
                }
               
                if (line.StartsWith("CC")) { line = Regex.Replace(line, @"CC<b>\(([^)]*)\)", match => $"<div class=\"note\"><div class=\"noteHeader\">🙟 באר מים חיים 🙝</div><a href=\"#{"src_" + match.Groups[1].Value + counter}\" id=\"{"fn_" + match.Groups[1].Value + counter}\" style=\"color:#ff6347;\" title=\"לחץ כדי לעבור חזרה לתוכן\">(" + match.Groups[1].Value + ")</a><b>"); }
                else if (line.StartsWith("<b>")){line = Regex.Replace(line, @"<b>\(([^)]*)\)", match => $"<a href=\"#{"src_" + match.Groups[1].Value + counter}\" id=\"{"fn_" + match.Groups[1].Value + counter}\" style=\"color:#ff6347;\" title=\"לחץ כדי לעבור חזרה לתוכן\">(" + match.Groups[1].Value + ")</a><b>");}


                if (line.StartsWith("AA")||line.StartsWith("EE"))
                {
                    line = line.Replace("**", $"<a href=\"#{"src_" + counter}\" id=\"{"fn_" + counter}\" title=\"לחץ כדי לעבור להערה\">" + "%%" + "</a>")
                                .Replace("*", $"<a href=\"#{"src_" + counter}\" id=\"{"fn_" + counter}\" title=\"לחץ כדי לעבור להערה\">" + "%" + "</a>");
                }
                else if (line.Contains("*"))
                {
                    counter++;
                    line = line.Replace("**", $"<a href=\"#{"fn_" + counter}\" id=\"{"src_" + counter}\" title=\"לחץ כדי לעבור להערה\">" + "%%" + "</a>")
                                .Replace("*", $"<a href=\"#{"fn_" + counter}\" id=\"{"src_" + counter}\" title=\"לחץ כדי לעבור להערה\">" + "%" + "</a>");
                }

                line = line
                    .Replace("AA", "<p class=\"note2\">")
                    .Replace("EE", "<p class=\"note2\">")
                    .Replace("CC", "<div class=\"note\">")
                    .Replace("BB", "(הגהה)</p>")
                    .Replace("FF", "</p>")
                    .Replace("DD", "</div>")
                    .Replace("{{", "<small>")
                    .Replace("}}", "</small>")
                    .Replace("%", "*");
            }
            
            return line;
        }
        string AhavatChesed(string line)
        {
            if (line.StartsWith("{{"))
            {
                line = Regex.Replace(line, @"<b>\{([^}]+)\}", match => $"<a href=\"#{"src_" + match.Groups[1].Value + counter}\" id=\"{"fn_" + match.Groups[1].Value + counter}\" title=\"לחץ כדי לעבור חזרה לתוכן\" style=\"color:#ff6347;\">(" + match.Groups[1].Value + ")</a><b>");
                line = line.Replace("**", $"<a href=\"#{"src_" + counter+ "2"}\" id=\"{"fn_" + counter + "2"}\" title=\"לחץ כדי לעבור להערה\" style=\"color:#ff6347;\">%%</a>");
                line = line.Replace("*", $"<a href=\"#{"src_" + counter}\" id=\"{"fn_" + counter}\" title=\"לחץ כדי לעבור להערה\" style=\"color:#ff6347;\">%</a>");
            }

            if (line.StartsWith("[[["))
            {
                counter++;
            }
                line = Regex.Replace(line, @"\(\(([^)]*)\)\)", match => $"<a href=\"#{"fn_" + match.Groups[1].Value + counter}\" id=\"{"src_" + match.Groups[1].Value +counter}\" title=\"לחץ כדי לעבור להערה\" style=\"color:#ff6347;\">(" + match.Groups[1].Value + ")</a>");
                line = line.Replace("**", $"<a href=\"#{"fn_" + counter + "2"}\" id=\"{"src_" + counter + "2"}\" title=\"לחץ כדי לעבור להערה\" style=\"color:#ff6347;\">%%</a>");
                line = line.Replace("*", $"<a href=\"#{"fn_" + counter}\" id=\"{"src_" + counter}\" title=\"לחץ כדי לעבור להערה\" style=\"color:#ff6347;\">%</a>");
                       
            line = line
                .Replace("%", "*")
                .Replace("{{", "<div class=\"note\">")
                .Replace("}}", "</div>")
                .Replace("{", "")
                .Replace("}", "");
            return line;
        }
        string OtzarDinim_Template(string line)
        {
            line = line.Replace("{", "<sup style=\"color: gray;\">")
                .Replace("}", "</sup>");
            return line;
        }
        string ShirHashirimRabbaTemplate(string line)
        {
            if (line.StartsWith("~ ")) { counter = 0; }
            else if (line.StartsWith("! "))
            {
                counter++;
                line = "! " + counter.ToHebNumber();
            }
            else if (line.Equals("^ סדרא תנינא"))
            {
                line = line + "\r\n~ המשך פרשה ב";
            }
            return line;
        }
        string ShaareiKedushaTemplate(string line)
        {
            if (line.Equals("הקדמה")) { line = "@ " + line; }
            else if (Regex.IsMatch(line, @"\Aחלק [א-ת]+ שער [א-ת]+")) { line = "@ " + line; }
            else if (Regex.IsMatch(line, @"\Aחלק [א-ת]+ שער [א-ת]+")) { line = "@ " + line; }
            return line;
        }
        string ShequelHakodeshTemplate(string line)
        {
            if (line.StartsWith("שער") || line.StartsWith("הקדמה")) { line = "@ " + line; }
            return line;
        }
        string TomerDovraTemplate(string line)
        {
            line = line.Replace("{", "<b>").Replace("}", "</b>");
            return line;
        }
        string RamchalTemplate(string line)
        {
            line = line.Replace("{", "! ").Replace("}", "\r\n");
            return line;
        }
        string SeferHayasharTemplate(string line)
        {
            line = line.Replace("[", "").Replace("]", "");
            return line;
        }
        string DaasTvunosTemplate(string line)
        {
            line = line
                .Replace("{{", "<b>")
                .Replace("}}", "</b>")
                .Replace("<<", "<b>")
                .Replace(">>", "</b>");
            return line;
        }
        string SiddurTemplate(string line)
        {
            line = line.Replace("{{{{", @"<div style=""padding:15; margin:30; border-width: 2px;
            border-style:solid; border-color: lightgray; backgroundcolor: RGB(244,244,244);"">")
                .Replace("}}}}", "</div>")
                .Replace("[[{", "<small style=\"color: darkgray;\">")
                .Replace("}]]", "</small>")
                .Replace("{{", "<small>")
                .Replace("}}", "</small>")
                .Replace("{", "<small style=\"color: darkgray;\">")
                .Replace("}", "</small>");
            line = GeneralTemplate(line);
            return line;
        }
        string HaggadaTemplate(string line)
        {
            line = line
                .Replace("{{{", "<small style=\"color: darkgray;\">")
                .Replace("}}}", "</small>")
                .Replace("{{", "<small style=\"padding-right: 5px; padding-left: 5px; color: darkgray;\">")
                .Replace("}}", "</small>")
                .Replace("{", "<b>")
                .Replace("}", "</b>")
                .Replace("[[[[", "<b>")
                .Replace("]]]]", "</b>")
                .Replace("[[[", "<b><big>")
                .Replace("]]]", "</big></b>");
            line = GeneralTemplate(line);
            return line;
        }
    }
}

