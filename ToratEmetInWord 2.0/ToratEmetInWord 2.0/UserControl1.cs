using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using mshtml;
using System.Drawing;
using Lucene.Net.Documents;
using System.Diagnostics;
using System.Security.Policy;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Office.Interop.Word;
using Lucene.Net.Messages;

namespace ToratEmetInWord_2._0
{
    [ComVisible(true)] 
    public partial class UserControl1 : UserControl
    {
        public Microsoft.Office.Tools.Excel.Controls.WebBrowser fileViewer;
        public Microsoft.Office.Tools.Excel.Controls.WebBrowser tempFileViewer;
        public OpenFileForm openFileForm;
        public SimpleSearchForm searchForm;
        public DictionaryForm dictionaryForm;
        public FileViewerContextMenu fileViewerContextMenu = new FileViewerContextMenu();
        public FileViewerHeaders fileViewerHeaders = new FileViewerHeaders();
        FileViewerSearch fileViewerSearch = new FileViewerSearch(); 
        public FileViewerHistory fileViewerHistory = new FileViewerHistory();
        public BookCompiler bookCompiler = new BookCompiler();
        FileViewerExactLocation fileViewerExactLocation = new FileViewerExactLocation();

        bool documentfinishedloading = false;
        public string currentFileName = "";
        public string exactAdress = "";
        public List<string> visitedFiles = new List<string>();
        public List<string> visitedFilesGoForward = new List<string>();
        public bool GoButtonClicked = false;

        public UserControl1()
        {
            fileViewerContextMenu.SetTaskPaneUserControl(this);
            fileViewerHeaders.SetTaskPaneUserControl(this);
            fileViewerExactLocation.SetTaskPaneUserControl(this);
            fileViewerSearch.SetTaskPaneUserControl(this);
            fileViewerHistory.SetTaskPaneUserControl(this);

            InitializeComponent();
            LoadTempFileViewer();
            loadFirstMessage();
            fileViewerHistory.PopulateVisitedFilesList();
            fileViewerHistory.populateHistoryList();
            if (Properties.Settings.Default.DonationsReminder == 0)
            { OpenDonationsPage(); Properties.Settings.Default.DonationsReminder++; Properties.Settings.Default.Save(); }
            
            tabControl1.MouseDown += TabControl1_MouseDown;
            selectAllButton.Click += SelectAllButton_Click;
            copyButton.Click += CopyButton_Click;
            copyCleanButton.Click += CopyCleanButton_Click;
            copyToWordButton.Click += CopyToWordButton_Click;
            copyCleanTextToWordButton.Click += CopyCleanTextToWordButton_Click;
            copyToSearchButton.Click += CopyToSearchButton_Click;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            //PrevoiusTabPageButton.Click += PrevoiusTabPageButton_Click;
            //NextTabPageButton.Click += NextTabPageButton_Click;
            SearchTextBox.KeyDown += SearchTextBox_KeyDown;
            SearchNextButton.Click += SearchNextButton_Click;
            SearchPreviousButton.Click += SearchPreviousButton_Click;
            buttonDonations.Click += ButtonDonations_Click;
            searchFormOpenButton.Click += SearchFormOpenButton_Click;
        }

        

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Control | Keys.T:
                    {
                        // Get a reference to the Word application
                        Microsoft.Office.Interop.Word.Application wordApp = Globals.ThisAddIn.Application;
                        // Get the active document
                        Microsoft.Office.Interop.Word.Document doc = wordApp.ActiveDocument;
                        // Insert  at the current selection or cursor position
                        doc.Application.Selection.StartIsActive = true;
                        //MessageBox.Show("hghg");
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref message, keys);
        }

        private void loadFirstMessage()
        {
            try
            {
                if (!System.IO.Directory.Exists(Path.Combine(Properties.Settings.Default.toratEmetInstallFolder, "ToratEmetInstall")))
                {
                    //set ToratEmet install folder
                    string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folderToCheck = Path.Combine(documentsFolder, "ToratEmetInstall");
                    if (System.IO.Directory.Exists(folderToCheck))
                    {
                        Properties.Settings.Default.toratEmetInstallFolder = documentsFolder;
                        Properties.Settings.Default.Save();
                    }
                }

                if (Directory.Exists(Properties.Settings.Default.toratEmetInstallFolder))
                {
                    string basePath = Path.Combine(Properties.Settings.Default.toratEmetInstallFolder, "ToratEmetInWord");
                    if (!Directory.Exists(basePath)) { Directory.CreateDirectory(basePath); }

                    string htmlPath = Path.Combine(basePath, "ToratEmetInWordCC.html");
                    if (!File.Exists(htmlPath))
                    {
                        string textToInsert = "<div align=\"center\"><p></p><p>© כל הזכויות שמורות ליוצר התוכנה tosaftorani@gmail.com </p><p>אין להשתמש בתוכנה למטרות מסחריות<br><p>לקבלת עדכונים אפשר לשלוח למייל הנ\"ל עם הכותרת - קבלת עדכונים<p></p><h2>הודעה חשובה</h2><p>פרוייקט זה הינו חלק קטן מתוך מפרוייקט נרחב להנגשת הספרייה היהודית במחשב לציבור הרחב <br>אם אתם משתמשים בתוכנה באורח קבע או שהינכם מעוניינים להשתתף בפרוייקט אנא לחצו כעת על לחצן התרומות <br>לתרומות גדולות לעילוי נשמת יקירכם וכיו\"ב אפשר ליצור איתי קשר במייל הנ\"ל<br></p><p><br>בברכה המערכת<br></p><p>שימו לב! כדי להשתמש בתוסף יש להתקין במחשב את המאגר המקורי של תורת אמת</p></div>";
                        textToInsert = textToInsert + "<hr><html>\r\n\r\n<head>\r\n\t<meta http-equiv=Content-Type content=\"text/html; charset=windows-1255\">\r\n\t<!--ADDITIONAL_HEAD-->\r\n</head>\r\n<style body-\"text/css\">\r\nbody{border-width: 1px;border-style:solid;border-color: #ffffff; background-color: #ffffff; }\r\nhr{height:2; color:RGB(225,231,244);}\r\n\r\n.shadow {-ms-box-shadow\t:     3px 3px 15px 1px #999999; box-shadow:         3px 3px 15px 1px #999999;}\r\n.round {-ms-border-radius:10px;        -ms-border-top-right-radius:10px; border-radius:10px; }\r\n.grad {\tbackground-image: -ms-linear-gradient(top, #FFFFFF 0%, #00A3EF 100%);   background-image: linear-gradient(to bottom, #FFFFFF 0%, #00A3EF 100%); }\r\nADDITIONAL_STYLE{}\r\n</style>\r\n\r\n\r\n\r\n<title>תורת אמת</title>\r\n\r\n<body lang=EN-US link=\"#2f6dbb\" vlink=\"#2f6dbb\" alink=\"#cc00cc\" style=\"tab-interval:36.0pt;background-image: url(//reka3.bmp); \" >\r\n       <div class=Section1 dir=LTR > <div class=Section2 dir=RTL >\r\n\r\n<span style=\"color:#000000;\"><span style=\"font-weight:bold; font-size:18px; \">\r\n<center><span style=\"color:#BE32BE;\"></center></span></span><CENTER><P>\r\n<span style=\"font-weight:bold; font-size:52px; \">\r\nתורת אמת<BR></span></CENTER><CENTER><B><BIG><BIG>מאגר תורני חופשי לכבוד השם יתברך</BIG></BIG></B><small><br><br></small>\r\n</CENTER>\r\n\r\n<!--SOURCE_FILE=C:\\Users\\0533105132\\Documents\\ToratEmetInstall\\Books\\000_ACCESORIES\\000_!WELLCOME.txt-->\r\n<HR>\r\n<span style=\"font-size:20px; \">\r\n\r\n<!--BODY_START-->\r\n<!--DAILY_LEARNING_PARAMS=-->\r\n<div style='text-align: justify; padding:15;'>\r\n<!--END_PARTIAL_PREFIX--><!--_LSTART-->\r\n<P><big><small><span style=\"\"> \t<li>תוכנה זו נכתבה במיוחד בכדי לזכות את הרבים בספרי קודש המותרים בהעתקה והפצה בחינם בכפוף לתנאים המפורטים בהמשך.\r\n<BR><P><li> <span style=\"color:#FF0000;\">אין לעשות בתוכנה זו או בחלק ממנה שימוש מסחרי .</span>\r\n<BR><P><li>מותר להפיץ תוכנה זו בשלמותה בחינם בלבד.\r\n<BR><P><li>מותר להפיץ חלקים מתוכנה זו אך ורק לפי תנאי רשיון 2.5-Creative Commons-CC שמפורט בהמשך וספרי ''ויקיטקסט'' תחת תנאי רשיון GNU Free Doc. License .\r\n<BR><P><li>כל הנכלל בתוכנה זו הופק על ידינו בחסדי ה' עלינו או צורף לתוכנה בהסכמתם של בעלי זכויות היוצרים ולא נכלל בתוכנה זו שום דבר ממקור מסחרי לא מאושר שיש עליו זכויות יוצרים.\r\n<BR><P><li>כאשר מדפיסים קטעים מהמאגר במדפסת, הדפים המודפסים טעונים גניזה בסיום השימוש בהם.\r\n<BR><P><li>גילוי דעת: ברוך השם זכינו להכניס למאגר ספרים של הרבה רבנים גאונים וגדולים מבני דורינו הראויים לתואר '<B>הרה\"ג</B>', וכן רבנים שבס\"ד בעתיד יהיו ראויים לתואר זה, וידוע מאמר חז\"ל  \"כשם שנפרעים מן המתים כך נפרעים מן הספדנים\" שפירושו שאסור לתת גדולה לאדם יותר מכפי ערכו, ומכוון שאין אנו יכולים לדקדק לגבי כל אחד מהרבנים ולתת לו את התואר הראוי לו לפי כבודו ומעלתו, הורה לנו רבנו לכנות את כולם בתואר '<B>הרב</B>', ועכ\"פ כולם תלמידי חכמים אשריהם ואשרי חלקם.\r\n<BR><P><hr> <!--  <marquee direction=up width=200 height=100 >   -->\r\n<BR><big><b> בעלי זכויות היוצרים שליט''א: </big></b>    \r\n<BR><P><li><span style=\"\"> זכויות היוצרים על הספרים שייכות לבעליהם כפי שמפורט בהערת \"כל הזכויות שמורות ל ...\" המופיעה בראש כל ספר, וכל מה שהתירו - זה להפיץ בחינם לזיכוי הרבים - ולא לשימוש מסחרי .\r\n<BR><P><li><span style=\"\"> זכויות היוצרים על חלק נכבד מהמילון שייכות להוצאת \"שיח ישראל\" לר' יעקב כהן שליט\"א.\r\n<BR><P><li><span style=\"\"> חלק מהמילים של המילון הארמי עברי נלקחו מאתר <a href='http://wikimedia.cet.ac.il/mediawiki/index.php?title=%D7%A2%D7%9E%D7%95%D7%93_%D7%A8%D7%90%D7%A9%D7%99' target='_blank' >פשיטא</a>  מבית <a href='http://www3.cet.ac.il' target='_blank'> המרכז לטכנולוגיה חינוכית </a>.\r\n<BR><P><li><span style=\"\"> זכויות היוצרים על הזמנים בלוחות השנה שייכות לרב חיים קלר שליט''א מאתר ''לוחות חי''  http://www.chaitables.com\r\n<BR><P><li><span style=\"\"> זכויות היוצרים על גופני EZRA-SIL שאסור בשימוש מסחרי, שייכות לארגון http://www.sil.org תחת תנאי רשיון  SIL Open Font License\r\n<BR><P><li><span style=\"\"> זכויות היוצרים על גופן  SBL_Hbrw שאסור בשימוש מסחרי, שמורות ל Tiro Typeworks and the Society of Biblical Literature <a href='#sbl-licence'>לפירוט תנאי הרשיון בגופן זה לחץ כאן.</a>\r\n<BR><P><li><span style=\"\">תכנת ההתקנה באדיבות NSIS\r\n<BR><P><hr>\r\n<BR><li><big><B> תנאי רשיון Creative Commons-CC-2.5: </big></B>\r\n<BR><P> ניתן לך החופש לשתף ,להעתיק, להפיץ ולהעביר את היצירה להכין רמיקס ולעבד את היצירה בכפוף לתנאים הבאים:\r\n<BR><P><B>ייחוס.</B> עליך לייחס את היצירה (לתת קרדיט) באופן המצויין על-ידי היוצר או מעניק הרישיון (אך לא בשום אופן המרמז על כך שהם תומכים בך או בשימוש שלך ביצירה). \r\n<BR><P><B>שימוש לא מסחרי.</B> אינך רשאי/ת להשתמש ביצירה זו לצרכים מסחריים. \r\n<BR><P><B>שיתוף זהה.</B> אם תחליט/י לשנות, לעבד או ליצור יצירה נגזרת בהסתמך על יצירה זו, תוכל/י להפיץ את יצירתך החדשה רק תחת אותו הרישיון או רישיון דומה לרישיון זה. \r\n<BR><P>בכל שימוש חוזר או הפצה של היצירה עליך להבהיר לאחרים את תנאי הרישיון ביצירה זו. \r\n<BR><P>ניתן לוותר על כל אחד מתנאים אלו בכפוף לקבלת רשות מבעלי זכויות היוצרים. \r\n<BR><P>רישיון זה אינו פוגע או מגביל את זכויותיו של היוצר. \r\n<BR><P><hr>\r\n<BR><big><B>תודתנו נתונה</B></big>\r\n<BR><P>בראש וראשונה לבורא עולם ישתבח שמו שמשפיע עלינו בכל עת מחסדיו הרבים.\r\n<BR><P>תודה מיוחדת למורינו ורבינו הגדול הרב חיים רבי שליט\"א מאור עינינו שבזכותו מאגר זה רואה אור.\r\n<BR><P>תודה מיוחדת מקרב לב למזכה הרבים הגדול ר' פנחס ראובן שליט\"א שבזכותו מאגר זה רואה אור שבאהבת השם הגדולה שלו ובאהבת ישראל הגדולה וברוחב לבו התיר לנו להכניס למאגר זה את כל ספרי הקודש שיש לו זכויות יוצרים עליהם !!! השם יברכהו בכל ברוחניות ובגשמיות וימלא כל משאלות לבו לטובה לעבודתו יתברך.\r\n<BR><P>וכן לרבנים ושאר בעלי זכויות היוצרים שהתירו לנו להשתמש בספרים שלהם ולכל המסייעים לנו במלאכת הקודש:\r\n<BR><P>הרב יצחק יוסף שליט\"א\r\n<BR>הרב יעקב ישראל לוגאסי שליט\"א \r\n<BR>הרב מח''ס \"בלבבי משכן אבנה\" שליט\"א החפץ בעילום שמו\r\n<BR>הרב אליהו אדיר שליט\"א\r\n<BR>הרב אלון כהן שליט''א\r\n<BR>הרב משה פרזיס שליט\"א\r\n<BR>הרב דוד גבריאל שליט\"א\r\n<BR>הרב בנימין נבול שליט\"א\r\n<BR>הרב יואל קטן שליט''א\r\n<BR>הרב אליהו שמואל שליט''א\r\n<BR>הרב אפרים עובד שליט''א\r\n<BR>הרב אליעזר הכהן שליט''א\r\n<BR>הרב איתן כהן שליט''א\r\n<BR>הרב אבישלום מונייצר שליט\"א \r\n<BR>הרב אברהם ישראל שליט\"א \r\n<BR>הרב חנן אפללו שליט''א\r\n<BR>הרב דניאל אוחיון שליט''א\r\n<BR>הרב שמעון אשר שליט''א\r\n<BR>הרב ניסים בריח שליט''א\r\n<BR>הרב ניצן ראובן שליט''א\r\n<BR>הרב יעקב יעקב שליט\"א\r\n<BR>הרב אליהו שלומי שליט\"א\r\n<BR>הרב חנן פרנג'י שליט''א\r\n<BR>הרב גדעון הרמן שליט\"א\r\n<BR>הרב (פרופ') אליהו ריפס שליט''א\r\n<BR>הרב אדי דואק שליט''א \r\n<BR>הרב אברהם אופמן שליט\"א\r\n<BR>הרב חיים קלר שליט''א\r\n<BR>הרב אלמקיאס רפאל שליט\"א\r\n<BR>הרב אליהו עבוד שליט''א\r\n<BR>הרב דוד פרור שליט''א\r\n<BR>הרב יפתח סופר שליט''א\r\n<BR>הרב דוד נקי שליט\"א\r\n<BR>הרב יוחנן רפאלי שליט''א\r\n<BR>הרב שלמה שו\"ב שליט''א\r\n<BR>הרב יחזקאל אסחייק שליט\"א\r\n<BR>הרב שלמה בניזרי שליט\"א\r\n<BR>הרב קובי לוי שליט\"א\r\n<BR>הרב תמיר בן חיים שליט''א\r\n<BR>הרב יחזקאל ס' שליט''א\r\n<BR>הרב שאול שהרבני שליט\"א\r\n<BR>הרב אליהו יוחאי אלקיים שליט\"א\r\n<BR>הרב יצחק שלום שליט\"א\r\n<BR>הרב יעקב שולביץ שליט\"א\r\n<BR><P>הרבנית שלומית קטן תליט''א\r\n<BR>הרבנית ליקבורניק תליט''א\t\r\n<BR>הרבנית שלומית גד זצ''ל\r\n<BR><P>ר' גלעד רצון וב''ב שליט''א\r\n<BR>ר' זיו מאור שליט''א\r\n<BR>ר' יאיר אבא שאול שליט''א\r\n<BR>ר' דניאל גמבום שליט''א\r\n<BR>ר' י.מ שליט\"א\r\n<BR>ר' ציון כהן שליט\"א\r\n<BR>ר' יעקב כהן שליט\"א\r\n<BR>ר' שגיב מחפוד שליט\"א\r\n<BR>ר'  אביהו איתן שליט''א\r\n<BR>ר' אלדד לוי שליט''א\r\n<BR>ר' מרדכי אלפיה שליט''א\r\n<BR>ר' שמעון שמואלי שליט''א\r\n<BR>ר' רוני פיזנטי שליט''א\r\n<BR>ר' שמעון כהן שליט''א  <!--ר' אריאל צברי שליט''א-->\r\n<BR>ר' ישראל דוידובסקי שליט\"א\r\n<BR>ר' מאיר רפלוביץ שליט\"א\r\n<BR>ר' קובי ישורון שליט''א\r\n<BR>ר' יוסף חיים שמואל סגרון שליט''א <small> <small>(http://dorot.jimdo.com)</small></small>\r\n<BR>ר' זרח חוטר שליט\"א\r\n<BR>ר' דניאל שרשבסקי שליט\"א וכל יוצרי מילון פשיטא הי\"ו\r\n<BR>ר' יהושע אנוקא שליט\"א\r\n<BR>ר' עודד מזרחי שליט\"א\r\n<BR><P>ע.ג תליט''א\r\n<BR>ה.ג תליט''א\r\n<BR>מ.ג תליט''א\r\n<BR>ט.ג תליט''א\r\n<BR>א.זאוש תליט''א\r\n<BR>ש.אברהמיאן תליט\"א\r\n<BR>ח.אברהמיאן תליט\"א\r\n<BR>א. לוי תליט\"א\r\n<BR><P>ירון וקנין  שליט''א\r\n<BR>דוד מהגרפטה שליט''א\r\n<BR>דני בן יעקב  שליט''א\r\n<BR>אלי פלד שליט\"א\r\n<BR><P>מכון \"אורח חיים היומי\" הי\"ו\r\n<BR>מכון \"חמדת ימים\" הי\"ו\r\n<BR>ארגון ''ויקיטקסט'' הי''ו\r\n<BR>אתר www.bilvavi.net  הי\"ו\r\n<BR>אתר שערי ברסלב www.breslev.org \r\n<BR>המרכז לטכנולוגיה חינוכית הי\"ו\r\n<BR>J. Alan Groves Center\r\n<BR><P>ועוד כמה החפצים בעילום שמם הי\"ו\r\n<BR><P>השם ימלא כל משאלות לבם לטובה לעבודתו יתברך  ויאריך ימיהם בטוב ושנותיהם בנעימים אכי''ר\r\n<BR><P><hr>\r\n<BR><a name='sbl-licence'></a>\r\n<BR><P><big><b>תנאי הרשיון בגופן SBL</b></big>\r\n<BR><P>באופן כללי - גופן זה מותר לשימוש אישי לא מסחרי - ללא תשלום כלשהו, אם ברצונך להפיץ גופן זה (לא כחלק מ\"תורת אמת\") אנא קרא בעיון את תנאי הרשיון המלאים ככתבם וכלשונם: \r\n<BR><P><div dir='ltr' style='background-color:RGB(255,239,213); padding:20; border-style:solid; border-width:1;'>\r\n<BR><B>SBL Fonts - End User License Agreement (EULA)</B>\r\n<BR><small>\r\n<BR>1. The digitally encoded machine readable font software for producing the typefaces licensed to you is the property of Tiro Typeworks. It is licensed to you for use under the terms of this end user license agreement. If you have any questions about this license agreement, or have a need to use the font software in a way not covered by this agreement, please write to license@tiro.com.\r\n<BR><P>2. You may use this font software free of charge for all non-commercial purposes. If you wish to obtain a license for commercial use of this font software, please contact the Society of Biblical Literature at sblexec@sbl-site.org, or write to license@tiro.com. Fees for commercial licenses are at the individual discretion of the Society of Biblical Literature and Tiro Typeworks.\r\n<BR><P>3. You may redistribute this font software free of charge as long as the software is unmodified, all copyright and trademark notices are intact, and the font contains or is accompanied by a copy of this license agreement. You may not charge any fee for the distribution of this font software or alter the terms of this license agreement.\r\n<BR><P>4. You may decompile and modify this font software for non-commercial and personal use by you as an individual or internal use within your organisation. Tiro Typeworks maintains copyright to all derivative fonts in any format. You may not delete, edit or add to copyright, trademark or license information in the font. You may not change the embedding bit. You may not redistribute any modified version of the font software, either free of charge or for a fee. Copies of modified fonts should be submitted to Tiro Typeworks (license@tiro.com) and to the Society of Biblical Literature (sblexec@sbl-site.org}, along with any relevant documentation. Tiro Typeworks reserves the right to incorporate any such changes into its own fonts.\r\n<BR><P>5. You may embed the font software in non-commercial electronic documents, including but not limited to web pages and e-books. Font embedding must respect the embedding bit in the font, which must not be changed. The embedding bit for this font software is set to 'Editable Embedding', meaning that documents containing this font software may be viewed, printed and edited, but the embedded font may not be installed on the recipient user’s system.\r\n<BR><P>6. All other rights are reserved by Tiro Typeworks, except as otherwise designated in contract between Tiro Typeworks and the Society of Biblical Literature.\r\n<BR><P>7. Neither Tiro Typeworks not the Society of Biblical Literature warrant the performance or results you may obtain by using this font software. Excepting any warranty, condition, representation or term that cannot or may not be excluded or limited by law applicable to you in your jurisdiction, Tiro Typeworks and the Society of Biblical Literature make no warranties, conditions, representations, or terms (express or implied whether by statute, common law, custom, usage or otherwise) as to any matter including, without limitation, noninfringement of third party rights, merchantability, integration, satisfactory quality, or fitness for any particular purpose.\r\n<BR><P>8. Neither Tiro Typeworks nor the Society of Biblical Literature accept any liability for injury, death, financial loss or damage to person or property (including computer hardware, software or data) resulting from the use of this font software.\r\n<BR><P>9. The act of installing this font software on any computer system constitutes acceptance of the terms of this license agreement, without exception.\r\n<BR><small>\r\n<BR></div>\r\n<BR><P><!- marquee direction=up width=400 height=100 --> <!--/marquee-->\r\n<BR><P><!--\r\n<BR><form method=\"post\" action=\"mailto:ToratEmetFreeware@gmail.com\">\r\n<BR>What kind of shirt are you wearing? <br />\r\n<BR>Shade: \r\n<BR><P><input type=\"radio\" name=\"shade\" value=\"dark\">Dark\r\n<BR><input type=\"radio\" name=\"shade\" value=\"light\">Light <br />\r\n<BR>Size:\r\n<BR><P><input type=\"radio\" name=\"size\" value=\"small\">Small\r\n<BR><input type=\"radio\" name=\"size\" value=\"medium\">Medium\r\n<BR><input type=\"radio\" name=\"size\" value=\"large\">Large <br />\r\n<BR><input type=\"submit\" value=\"Email Myself\">\r\n<BR></form>\r\n<BR><P><form method=\"post\" action=\"mailto:youremail@email.com\">\r\n<BR>Select your favorite cartoon characters.\r\n<BR><input type=\"checkbox\" name=\"toon\" value=\"Goofy\">Goofy\r\n<BR><input type=\"checkbox\" name=\"toon\" value=\"Donald\">Donald\r\n<BR><input type=\"checkbox\" name=\"toon\" value=\"Bugs\">Bugs Bunny\r\n<BR><input type=\"checkbox\" name=\"toon\" value=\"Scoob\">Scooby Doo\r\n<BR><input type=\"submit\" value=\"Email Myself\">\r\n<BR></form>\r\n<BR>-->\r\n<BR><P>\t\r\n<BR>\r\n<!--BODY_END-->\r\n<!--_LEND-->       </div>\r\n</body>\r\n</html>\r\n";
                        File.WriteAllText(htmlPath, textToInsert, Encoding.UTF8);//Save the UTF - 8 encoded HTML content to file
                    }

                    if (File.Exists(htmlPath)) { webBrowser1.Navigate(htmlPath); }
                }
                else
                {
                    MessageBox.Show("תיקיית ההתקנה המקורית של תורת אמת לא זוהתה", "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex) { MessageBox.Show("loadFirstMessage Error:\r\n" + ex.Message); }
        }

        public void LoadTempFileViewer()
        {
            try
            {
                tempFileViewer = new Microsoft.Office.Tools.Excel.Controls.WebBrowser();
                tempFileViewer.Dock = DockStyle.Fill;
                tempFileViewer.ContextMenuStrip = this.contextMenuStrip1;
                tempFileViewer.IsWebBrowserContextMenuEnabled = false;
                tempFileViewer.WebBrowserShortcutsEnabled = true;
                tempFileViewer.ScriptErrorsSuppressed = true;
                tempFileViewer.AllowWebBrowserDrop = false;
                tempFileViewer.Url = new System.Uri("about:blank", System.UriKind.Absolute);
                tempFileViewer.PreviewKeyDown += TempFileViewer_PreviewKeyDown;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void TempFileViewer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                fileViewerContextMenu.selectAll();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Control | Keys.C))
            {
                System.Windows.Clipboard.SetText(fileViewerContextMenu.copyText());
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.C))
            {
                System.Windows.Clipboard.SetText(fileViewerContextMenu.copycleantext());
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Control | Keys.V))
            {
                fileViewerContextMenu.copyToWord();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.V))
            {
                fileViewerContextMenu.CopyCleanTextDirctlyToWord();
                e.IsInputKey = true;
            }
        }

        private void TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tabControl1.TabPages.Count > 0)
            {
                int currnetIndex = tabControl1.SelectedIndex;

                //Looping through the controls.
                for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    System.Drawing.Rectangle r = tabControl1.GetTabRect(i);
                    //Getting the position of the "x" mark.
                    System.Drawing.Rectangle closeButton = new System.Drawing.Rectangle(r.Right - 20, r.Top + 0, 17, 17);
                    if (closeButton.Contains(e.Location))
                    {
                        string closingTabName = tabControl1.TabPages[i].Name;
                        removeClosedTabFromList(closingTabName);
                        tabControl1.TabPages.RemoveAt(i);
                        if (i == currnetIndex)
                        {
                            if (i > 1) { tabControl1.SelectedTab = tabControl1.TabPages[i - 1]; }
                        }
                        break;
                    }
                }
            }
        }

        private void removeClosedTabFromList(string fileName)
        {
            try
            {
                // Filter the ToolStripItem collection to get only ToolStripMenuItem items
                var toolStripMenuItems = VisitedBooksDropDown.DropDownItems.OfType<ToolStripMenuItem>().ToList();

                int menuItemNumber = 0;
                foreach (ToolStripMenuItem menuItem in toolStripMenuItems)
                {
                    menuItemNumber++;
                    if (menuItem.Text.Trim() == fileName.Trim())
                    {
                        if (menuItemNumber > 1 && menuItemNumber <= toolStripMenuItems.Count)
                        {
                            VisitedBooksDropDown.DropDownItems.RemoveAt(menuItemNumber);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        //
        //
        //Buttons
        //
        //

        private void FontOptions_Click(object sender, EventArgs e)
        {
            try
            {
                FontSettings fontSettings = new FontSettings();
                fontSettings.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SetToratEmetFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var folderPicker = new FolderPicker();

                if (folderPicker.ShowDialog(IntPtr.Zero) == true)
                {
                    string resultFolder = folderPicker.ResultPath;
                    if (resultFolder.Contains("ToratEmetInstall")) { resultFolder = Path.GetDirectoryName(resultFolder); }
                    Properties.Settings.Default.toratEmetInstallFolder = resultFolder;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadInAllFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.snapWithWindow == false)
                {
                    DialogResult result = MessageBox.Show("כרגע התוסף נפתח בכל מסמך בפני עצמו. האם ברצונך לשנות ההגדרה כדי שהתוסף יופיע בכל המסמכים בו זמנית?", "תצוגה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    if (result == DialogResult.Yes)
                    {
                        Properties.Settings.Default.snapWithWindow = true;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    DialogResult result2 = MessageBox.Show("כרגע התוסף מוצג בכל המסמכים בו זמנית. האם ברצונך לשנות את ההגדרה כדי שהתוסף ייפתח רק במסמך בו הוא נפתח?", "תצוגה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    if (result2 == DialogResult.Yes)
                    {
                        Properties.Settings.Default.snapWithWindow = false;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void bigFileAlertSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.skipBigFileAlert == false)
                {
                    DialogResult result = MessageBox.Show("כרגע התוכנה מוגדרת שבעת פתיחת מסמכים מאוד כבדים, מופיעה התראה. האם ברצונך לכבות התראה זו?", "התראה בעת פתיחת מסמכים כבדים", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    if (result == DialogResult.Yes)
                    {
                        Properties.Settings.Default.skipBigFileAlert = true;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("כרגע התוכנה מוגדרת שבעת פתיחת מסמכים מאוד כבדים, לא מופיעה התראה (למרות שפתיחתם עלולה לקחת יותר זמן מן הרגיל). האם ברצונך להדליק התראה זו?", "התראה בעת פתיחת מסמכים כבדים", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    if (result == DialogResult.Yes)
                    {
                        Properties.Settings.Default.skipBigFileAlert = false;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SearchFormOpenButton_Click(object sender, EventArgs e)
        {
        LoadSearchForm();
        }

        private void LoadSearchForm()
        {
            try
            {
                if (searchForm == null || searchForm.IsDisposed)
                {
                    searchForm = new SimpleSearchForm();
                    searchForm.SetTaskPaneUserControl(this);
                    searchForm.Show();
                    searchForm.BringToFront();
                    searchForm.Focus();
                    searchForm.textBox1.Focus();
                }
                else
                {
                    searchForm.Visible = true;
                    searchForm.BringToFront();
                    searchForm.Focus();
                    searchForm.textBox1.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void openFileFormButton_Click(object sender, EventArgs e)
        {
            loadOpenFileForm();
        }
        public void loadOpenFileForm()
        {
            try
            {
                if (openFileForm == null || openFileForm.IsDisposed)
                {
                    openFileForm = new OpenFileForm();
                    openFileForm.SetTaskPaneUserControl(this);
                    this.Controls.Add(openFileForm);
                    openFileForm.Dock = DockStyle.Fill;
                    openFileForm.Show();
                    openFileForm.BringToFront();
                    openFileForm.Visible = true;
                    openFileForm.textBox1.SelectAll();
                    openFileForm.textBox1.Focus();
                }
                else
                {
                    openFileForm.Visible = true;
                    openFileForm.BringToFront();
                    openFileForm.textBox1.SelectAll();
                    openFileForm.textBox1.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
            }

            //if (tabControl1.SelectedTab != null)
            //{
            //    try
            //    {
            //        if (visitedFiles.Count > 1)
            //        {
            //            string activeTabName = tabControl1.SelectedTab.Name.Replace("    X", "").Trim();
            //            if (!visitedFilesGoForward.Contains(activeTabName))
            //                { visitedFilesGoForward.Add(activeTabName); }
            //            int selectedTabIndex = visitedFiles.IndexOf(activeTabName);
            //            if (selectedTabIndex - 1 >= 0)
            //            {
            //                string previousItem = visitedFiles[selectedTabIndex - 1];
            //                GoButtonClicked = true;
            //                openSelectedFile(previousItem);
            //            }
            //        }
            //    }
            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            //}
        }

        private void goForwardButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            }
            //try
            //{
            //    if (visitedFilesGoForward.Count > 0) // Check if the list is not empty
            //    {
            //        string activeTabName = tabControl1.SelectedTab.Name.Replace("    X", "").Trim();
            //        if (visitedFilesGoForward.Contains(activeTabName))
            //        {                      
            //            int selectedTabIndex = visitedFilesGoForward.IndexOf(activeTabName);
            //            if (selectedTabIndex + - 1 >= 0)
            //            {
            //                string nextItem = visitedFilesGoForward[selectedTabIndex - 1];
            //                openSelectedFile(nextItem);
            //                GoButtonClicked = true;
            //            }
            //        }
            //        else
            //        {
            //            string nextItem = visitedFilesGoForward[0];
            //            openSelectedFile(nextItem);
            //            GoButtonClicked = true;
            //        }
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (fileViewer != null)
                if (fileViewer.DocumentText != null)
            try
            {
                string htmlRefresh = fileViewer.DocumentText;

                string fontSizePattern = @"font-size:\s*(\d+px);";
                string fontFamilyPattern = @"font-family:\s*['""]?([^;]+)['""]?;";
                string lineHeightPattern = @"line-height:\s*([^;]+);";

                string newfontname = Properties.Settings.Default.fontName;
                string newfontSize = Properties.Settings.Default.fontSize.ToString();
                string newlineheight = Properties.Settings.Default.fontlineSpacing.ToString();

                htmlRefresh = Regex.Replace(htmlRefresh, fontSizePattern, "font-size: " + newfontSize + "px;");
                htmlRefresh = Regex.Replace(htmlRefresh, fontFamilyPattern, "font-family: '" + newfontname + "';");
                htmlRefresh = Regex.Replace(htmlRefresh, lineHeightPattern, "line-height: " + newlineheight + "2;");

                fileViewer.DocumentText = htmlRefresh;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DictionaryButton_Click(object sender, EventArgs e)
        {
            LoadDictionaryForm();
        }

        public void LoadDictionaryForm()
        {
            try
            {

                if (dictionaryForm == null || dictionaryForm.IsDisposed)
                {
                    dictionaryForm?.Dispose(); // Dispose the existing form if it's disposed or null
                    dictionaryForm = new DictionaryForm();
                    dictionaryForm.Show();
                }
                else
                {
                    dictionaryForm.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void toolStripAboutButton_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("https://mitmachim.top/post/704012"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ButtonDonations_Click(object sender, EventArgs e)
        {
            OpenDonationsPage();
        }
        private void OpenDonationsPage()
        { 
            if (openFileForm != null && !openFileForm.IsDisposed) { openFileForm.Visible = false;/*openFileForm.Dispose();*/ }

            bool isFileOpen = false;
            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    int openTabNumber = 0;
                    foreach (TabPage tabPage in tabControl1.TabPages)
                    {
                        openTabNumber++;
                        if (tabPage.Name.Equals("דף תרומות    X"))
                        {
                            tabControl1.SelectedIndex = openTabNumber - 1;
                            isFileOpen = true;
                            break; // If you've found a match, you can exit the loop early.
                        }
                    }

                    if (!isFileOpen)
                    {
                        // Add the new tab to the TabControl
                        TabPage newTabPage = new TabPage();
                        newTabPage.Text = "דף תרומות    X"; // Set the title of the new tab
                        newTabPage.Name = "דף תרומות    X"; // Set the name of the new tab            

                        tempFileViewer.ObjectForScripting = this;
                        //tempFileViewer.ScrollBarsEnabled = false;
                        
                       

                        tempFileViewer.DocumentText = DonationPageContent();
                        newTabPage.Controls.Add(tempFileViewer);

                        tabControl1.TabPages.Add(newTabPage);
                        tabControl1.SelectedTab = newTabPage;// Activate the new tab page

                        LoadTempFileViewer();
                    }
                }));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
           
        }

        private string DonationPageContent()
        {
            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;

            // Convert Bitmap to Base64
            string base64Image = ImageToBase64(image);
            return $"<!DOCTYPE html>\r\n<html lang=\"he\" dir=\"rtl\">\r\n\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no\">\r\n    <link href=\"https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap\" rel=\"stylesheet\">\r\n    <title>דף תרומות</title>\r\n    <style>\r\n        body {{\r\n            font-family: 'Roboto', sans-serif;\r\n            background-color: #F4F4F4;\r\n            font-size: 20px;\r\n        }}\r\n\r\n        .container {{\r\n            border: 0px solid #0066CC;\r\n            border-radius: 10px;\r\n            text-align: center;\r\n      padding: 30px;              }}\r\n\r\n        button {{\r\n            font-size: 28px;\r\n            padding: 15px;\r\n            background-color: #339933;\r\n            color: white;\r\n            border: none;\r\n            border-radius: 8px;\r\n            cursor: pointer;\r\n            transition: background-color 0.3s ease;\r\n            margin-bottom: 20px;\r\n        }}\r\n\r\n        button:hover {{\r\n            background-color: #29A329;\r\n        }}\r\n\r\n        footer {{\r\n            font-size: 22px;\r\n            margin-top: 20px;\r\n            padding: 10px;\r\n            background-color: #0066CC;\r\n            color: white;\r\n            text-align: center;\r\n            border: 5px solid #0066CC;\r\n            border-radius: 10px;\r\n            cursor: pointer;\r\n        }}\r\n\r\n        footer a {{\r\n            color: #FFFFFF;\r\n            text-decoration: none;\r\n            font-weight: bold;\r\n            border: none;\r\n            transition: border-bottom 0.3s ease;\r\n            display: inline-block;\r\n        }}\r\n\r\n        footer a:hover {{\r\n            border-bottom: 2px solid #FFFFFF;\r\n        }}\r\n\r\n        footer p {{\r\n            font-size: 23px;\r\n            margin: 0;\r\n        }}\r\n\r\n        .phone {{\r\n            text-align: center;\r\n            margin: 20px 0;\r\n            color: #555;\r\n        }}\r\n\r\n        .top-right-text {{\r\n            text-align: right;\r\n            font-size: 18px;\r\n            color: #0066CC;\r\n        }}\r\n    </style>\r\n</head>\r\n\r\n" +
                $"<body>\r\n    <div class=\"container\">\r\n        <div class=\"top-right-text\">בס\"ד</div>\r\n        <img src=\"data:image/png;base64, {base64Image}\" width=\"100\" height=\"100\">\r\n        <h1 style=\"color: #0066CC;\">תורת אמת בוורד</h1>\r\n        <p>\r\n            <button onclick=\"donationsLink()\">לדף התרומות לחץ כאן</button>\r\n        </p>\r\n        <p class=\"phone\">תרומה בטלפון<br><br>073-275-7000 | שלוחה: 56665</p>\r\n        <footer onclick=\"copyFooterText()\" style=\"display: inline-block;\">\r\n            <p><a href=\"javascript:void(0);\" onclick=\"copyToClipboard('tosaftorani@gmail.com')\">tosaftorani@gmail.com</a></p>\r\n        </footer>\r\n        <script>\r\n            function copyFooterText() {{\r\n                var footerText = document.querySelector('footer p a').innerText;\r\n                var tempInput = document.createElement(\"input\");\r\n                tempInput.value = footerText;\r\n                document.body.appendChild(tempInput);\r\n                tempInput.select();\r\n\r\n                try {{\r\n                    var successful = document.execCommand('copy');\r\n        document.body.removeChild(tempInput);\r\n            var msg = successful ? 'כתובת האימייל הועתקה' : 'שגיאה בהעתקת הטקסט';\r\n                    alert(msg);\r\n                }} catch (err) {{\r\n                    console.error('Unable to copy to clipboard', err);\r\n                }}\r\n\r\n                            }}\r\n\r\n            function donationsLink() {{\r\n                window.external.DonationsLink(); // Assuming this function is correctly implemented elsewhere\r\n            }}\r\n        </script>\r\n    </div>\r\n</body>\r\n\r\n</html>\r\n";
        }

        static string ImageToBase64(Bitmap image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Convert Bitmap to byte array
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();

                // Convert byte array to Base64 string
                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }
        }

        public void DonationsLInk()
        {
            try
            {
                // Use Process.Start to open the default web browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://ultra.kesherhk.info/external/paymentPage/313975",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening URL: {ex.Message}");
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileViewerContextMenu.selectAll();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Clipboard.SetText(fileViewerContextMenu.copyText());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CopyCleanButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Clipboard.SetText(fileViewerContextMenu.copycleantext());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CopyToWordButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileViewerContextMenu.copyToWord();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CopyCleanTextToWordButton_Click(object sender, EventArgs e)
        {
            fileViewerContextMenu.CopyCleanTextDirctlyToWord();
        }

        private void CopyToSearchButton_Click(object sender, EventArgs e)
        {
            string texttosearch = fileViewerContextMenu.copyText();
            CopyTosearch(texttosearch);
        }

        public void CopyTosearch(string selectedText)
        {
            try
            {
                selectedText = NormalizeHebrewText(selectedText).Trim();
                LoadSearchForm();
                searchForm.textBox1.Text = selectedText;
                searchForm.regexCheckBox.Checked = false;
                searchForm.Focus();
                searchForm.textBox1.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys e.KeyData)
        //{
        //    try
        //    {
        //        //if (e.KeyData == (Keys.Control | Keys.A))
        //        //{
        //        //    if (textBox1.Focused) {textBox1.SelectAll(); }
        //        //    else if (webBrowser1.Focused) { selectAll(); webBrowser1.Focus(); }
        //        //    return true; // Indicates that the key press has been handled
        //        //}
        //        if (e.KeyData == (Keys.Control | Keys.D))
        //        { MessageBox.Show("DDD"); }
        //        if (e.KeyData == (Keys.Control | Keys.C))
        //        {
        //            if (SearchTextBox.Focused) { System.Windows.Clipboard.SetText(SearchTextBox.Text); }
        //            else if (fileViewer.Focused) { System.Windows.Clipboard.SetText(fileViewerContextMenu.copyText()); }
        //            return true; // Indicates that the key press has been handled
        //        }
        //        if (e.KeyData == (Keys.Control | Keys.Shift | Keys.C))
        //        {
        //            if (fileViewer.Focused) { System.Windows.Clipboard.SetText(fileViewerContextMenu.copycleantext()); }
        //            return true; // Indicates that the key press has been handled
        //        }
        //        if (e.KeyData == (Keys.Control | Keys.V))
        //        {
        //            if (SearchTextBox.Focused) { SearchTextBox.Text = System.Windows.Clipboard.GetText(); }
        //            else if (fileViewer.Focused) { fileViewerContextMenu.copyToWord(); }
        //            return true; // Indicates that the key press has been handled
        //        }
        //        if (e.KeyData == (Keys.Control | Keys.Shift | Keys.V))
        //        {
        //            if (fileViewer.Focused) { fileViewerContextMenu.CopyCleanTextDirctlyToWord(); }
        //            return true; // Indicates that the key press has been handled
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //    return base.ProcessCmdKey(ref msg, e.KeyData);
        //}

        public string NormalizeHebrewText(string text)
        {
            // Normalize Hebrew text (e.g., remove diacritics)
            text = new string(text.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()); // Normalize Hebrew text.
            return text; // Return the normalized text.
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab != null)
                {
                    string selectedTabName = tabControl1.SelectedTab.Name.Replace("    X", "").Trim();
                    fileViewerHeaders.populateHeadersMenu(selectedTabName);
                    loadRelatedFiles(selectedTabName);
                    visitedFiles.Add(selectedTabName);
                    foreach (Control control in tabControl1.SelectedTab.Controls)
                    {
                        if (control is Microsoft.Office.Tools.Excel.Controls.WebBrowser webBrowser)
                        {
                            fileViewer = webBrowser;
                        }
                    }
                    if (!GoButtonClicked)
                    {
                        visitedFilesGoForward.Clear();
                        visitedFiles.Add(selectedTabName);
                    }
                    else
                    { GoButtonClicked = false; }
                   
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { fileViewerSearch.searchNext(SearchTextBox.Text); e.Handled = true; e.SuppressKeyPress = true; }
        }

        private void SearchPreviousButton_Click(object sender, EventArgs e)
        {
            fileViewerSearch.searchPrevious(SearchTextBox.Text);
        }

        private void SearchNextButton_Click(object sender, EventArgs e)
        {
            fileViewerSearch.searchNext(SearchTextBox.Text);
        }


        

        //
        //
        //
        //openfile voids
        //
        //
        //

        public void openSelectedFile(string filename)
        {
            currentFileName = filename.Trim();

            if (openFileForm != null && !openFileForm.IsDisposed) { openFileForm.Visible = false;/*openFileForm.Dispose();*/ }

            bool isFileOpen = false;
            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    int openTabNumber = 0;
                    foreach (TabPage tabPage in tabControl1.TabPages)
                    {
                        openTabNumber++;
                        string tabName = tabPage.Name.Replace("X", "").Trim();
                        if (filename.Trim().Equals(tabName))
                        {
                            tabControl1.SelectedIndex = openTabNumber -1;
                            navigateToExactAdress();
                            isFileOpen = true;
                            break; // If you've found a match, you can exit the loop early.
                        }
                    }               

                    if (!isFileOpen)
                    {
                    CompileNewFile(filename);
                    }
                }));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        public void navigateToExactAdress()
        {
            try
            {
                if (!string.IsNullOrEmpty(exactAdress))
                {
                    string[] words;
                    if (exactAdress.Contains("%"))
                    {
                        words = exactAdress.Split(new[] { "%" }, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length > 1)
                        {
                            if (!fileViewerExactLocation.SearchNext(words[1]))
                            { fileViewerExactLocation.NavigateHeaders(words[0]); }
                        }
                    }
                    else if (exactAdress.Contains(","))
                    {
                        fileViewerExactLocation.NavigateHeaders(exactAdress);
                    }
                    exactAdress = "";
                    documentfinishedloading = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("navigateToExactAdress Error:\r\n" + ex.Message); }
        }

        public async void CompileNewFile(string fileName)
        {
            if (tabControl1.TabCount > 20)
            {
                MessageBox.Show("פתחתם חלונות טקסט רבים מדאי");
            }
            else
            { 
            await System.Threading.Tasks.Task.Run(() =>{bookCompiler.RunComplier(fileName);});
            if (!bookCompiler.isLongBook) { openNewFile(fileName); }
            }
        }

        public void openNewFile(string filename)
        {
            try
            {
                fileViewerHistory.UpdateVisitedFilesList(filename);
                if (tabControl1.TabPages.Count > 0) { if (tabControl1.TabPages[0].Text == "הודעה חשובה") { tabControl1.TabPages.RemoveAt(0); } }

                if (!fileViewerHeaders.headerMenuStructureDictionary.ContainsKey(filename.Trim()))
                {
                    fileViewerHeaders.headerMenuStructureDictionary[filename.Trim()] = bookCompiler.headerMenuStructure;
                }

                this.BeginInvoke((Action)(() => {

                    fileViewerHistory.updateHistoryList(filename);
                    visitedFiles.Add(filename.Trim());
                    visitedFilesGoForward.Clear();
                    fileViewerHeaders.populateHeadersMenu(filename);
                    loadRelatedFiles(filename.Trim());

                    // Add the new tab to the TabControl
                    TabPage newTabPage = new TabPage();
                    newTabPage.Text = filename.Trim() + "    X"; // Set the title of the new tab
                    newTabPage.Name = filename; // Set the name of the new tab            

                    fileViewer = tempFileViewer;
                    fileViewer.DocumentCompleted += FileViewer_DocumentCompleted;
                    fileViewer.DocumentText = bookCompiler.htmlContent;
                    //Clipboard.SetText(bookCompiler.htmlContent);
                    newTabPage.Controls.Add(fileViewer);
                    
                    tabControl1.TabPages.Add(newTabPage);
                    tabControl1.SelectedTab = newTabPage;// Activate the new tab page

                    LoadTempFileViewer();
                }));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void FileViewer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            navigateToExactAdress();
        }

        public void loadRelatedFiles(string fileName)
        {
            try
            {
                List<string> RelatedFiles = new List<string>();
                bookCompiler.relativeBooksDictionary.TryGetValue(fileName.Trim(), out RelatedFiles);

                if (RelatedFiles != null)
                {
                    relatedBooksButton.DropDownItems.Clear();
                    foreach (string file in RelatedFiles)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(file);
                        relatedBooksButton.DropDownItems.Add(item);
                        item.Click += (sender, e) => { openSelectedFile(item.Text); };
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}



//private void ActivateSelectedPage(string bookFilename)
//{
//    bool matchFound = false;
//    try
//    {
//        foreach (Control control in this.Controls)
//        {
//            if (control is WebBrowser bookViewer && control.AccessibleName == bookFilename)
//            {
//                matchFound = true;
//                fileViewer = bookViewer;
//                fileViewer.BringToFront();
//                //labelBookName.Text = bookFilename;
//                //updateRelativeBooksList(bookFilename);
//                //puplateHeadersMenu(bookFilename);
//            }
//        }

//        if (matchFound == false)
//        {
//            //openFileFromList(bookFilename);
//        }
//    }
//    catch (Exception ex) { MessageBox.Show(ex.Message); }
//}
//        //private async void openSelectedFile()
//        //{
//        //    
//        //        bool isFileOpen = false;

//        //        if (!string.IsNullOrEmpty(fileName))
//        //        {
//        //            //labelBookName.Text = pagename;
//        //            //updateHistoryList(pagename, ref isFileOpen);
//        //            //loadRelatedFiles(chosenFilePath, pagename);
//        //            //puplateHeadersMenu(pagename);

//        //            foreach (Control control in taskPaneUserControl.Controls)
//        //            {
//        //                if (control is UserControlFileView ControlFileView && control.AccessibleName == pagename)
//        //                {
//        //                    ControlFileView.BringToFront();
//        //                    userControlFileView = ControlFileView;
//        //                    if (islinkclicked == false) { userControlFileView.NavigaetHeaders(exactAdress); islinkclicked = false; }
//        //                    isFileOpen = true;
//        //                    break;
//        //                }
//        //            }

//        //            if (!isFileOpen)
//        //            {
//        //                updateHistoryList(pagename);
//        //                await System.Threading.Tasks.Task.Run(() =>
//        //                {
//        //                    BookCompiler bookCompiler = new BookCompiler();
//        //                    bookCompiler.RunComplier(chosenFilePath, tempHtmlFilePath);
//        //                    htmlContent = bookCompiler.htmlContent;
//        //                    headerMenuStructure = bookCompiler.headerMenuStructure;
//        //                });

//        //                this.BeginInvoke((Action)(() =>
//        //                {
//        //                    ; menuStructureDictionary[pagename] = headerMenuStructure;
//        //                    //puplateHeadersMenu(pagename);
//        //                    //headerMenuStructure = "";

//        //                    //fileViewer = new WebBrowser(); // Create a new WebBrowser instance
//        //                    //fileViewer.Dock = DockStyle.Fill;
//        //                    //fileViewer.IsWebBrowserContextMenuEnabled = false;
//        //                    //fileViewer.ContextMenuStrip = contextMenuStrip1;
//        //                    //panel2.Controls.Add(fileViewer); // Add the WebBrowser control to the panel
//        //                    //fileViewer.BringToFront();

//        //                    userControlFileView = tempControlFileView;
//        //                    userControlFileView.htmlText = htmlContent;

//        //                    userControlFileView.SetTaskPaneUserControl(this);
//        //                    userControlFileView.AccessibleName = pagename;
//        //                    //userControlFileView.Dock = DockStyle.Fill;
//        //                    userControlFileView.Disposed += UserControlFileView_Disposed;

//        //                    userControlFileView.labelBookName.Text = pagename;
//        //                    userControlFileView.loadRelatedFiles(chosenFilePath, pagename);
//        //                    userControlFileView.puplateHeadersMenu(pagename);

//        //                    //flags for when document is completed
//        //                    userControlFileView.exactAdress = exactAdress;
//        //                    if (shouldautoNavigate == true)
//        //                    {
//        //                        userControlFileView.shouldautoNavigate = true; shouldautoNavigate = false;
//        //                        userControlFileView.autoNavigateText = autoNavigateText; autoNavigateText = "";
//        //                        userControlFileView.autoNavigateAlternative = autoNavigateAlternative; autoNavigateAlternative = "";
//        //                    }
//        //                    //

//        //                    //this.panel2.Controls.Add(userControlFileView);
//        //                    //userControlFileView.Show();
//        //                    userControlFileView.webBrowser1.DocumentText = htmlContent;
//        //                    userControlFileView.Visible = true;
//        //                    userControlFileView.BringToFront();
//        //                    LoadTempControlFileView();

//        //                    //pagename = Uri.EscapeDataString(pagename);
//        //                    //string pageUrl = $"/{pagename}";
//        //                    //dataHtmls[pageUrl] = htmlContent;
//        //                    //string fullUrl = host + pageUrl;// Ensure that the URL is constructed correctly.
//        //                    //userControlFileView.webBrowser1.Navigate(fullUrl);

//        //                    //fileViewer.AccessibleName = Path.GetFileNameWithoutExtension(tempHtmlFilePath).Trim();

//        //                    //File.WriteAllText(tempHtmlFilePath, htmlContent, Encoding.GetEncoding(1255));
//        //                    //webBrowser1.Navigate(new Uri(tempHtmlFilePath));
//        //                }));
//        //            }
//        //        }

//        //    }
//        //    catch (Exception ex)
//        //    { MessageBox.Show(ex.ToString()); }

//        //}

//        public async void linkElementOpen(string bookName, string bookChapter)
//        {
//            try { 
//            bool isFileOpen = false;

//            this.Invoke((Action)(() =>
//            {
//                foreach (Control control in this.panel2.Controls)
//                {
//                    if (control is UserControlFileView ControlFileView && control.AccessibleName == bookName)
//                    {
//                        ControlFileView.BringToFront();
//                        userControlFileView = ControlFileView;
//                        userControlFileView.reverseSearchHeaders(bookChapter);
//                        //userControlFileView.NavigaetHeaders(exactAdress);
//                        isFileOpen = true;
//                        break;
//                    }
//                }
//            }));

//            if (isFileOpen == false)
//            {
//                await System.Threading.Tasks.Task.Run(() =>
//                {
//                    openFileFromList(bookName);
//                });
//                int breakpoint = 0;
//                while (userControlFileView == null || userControlFileView.AccessibleName != bookName)
//                {
//                    breakpoint++;
//                    Task.Delay(1000).Wait(); // Simulated work that takes 1 second
//                    if (breakpoint == 15) { break; }
//                }
//                //shouldautoNavigate = true;
//                //autoNavigateText = parts[1];
//                //autoNavigateAlternative = parts[2];               


//            }
//            this.Invoke((Action)(() =>
//            {
//                if (!string.IsNullOrEmpty(bookChapter))
//                {
//                    userControlFileView.reverseSearchHeaders(bookChapter);
//                    this.BringToFront();
//                }
//            }));
//            islinkclicked = false;
//            }
//            catch (Exception ex) { MessageBox.Show(ex.Message); }
//        }








//        private void toolStripButton9_Click(object sender, EventArgs e)
//        {
//            userControlFileView.ZoomOut();
//        }

//        private void toolStripButton10_Click(object sender, EventArgs e)
//        {
//            userControlFileView.ZoomIN();
//        }


//        //
//        //
//        //
//        //  OpenFileForm controls
//        //
//        //
//        //

//        private void openFileListBox1_MouseClick(object sender, MouseEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(openFileForm.listBox1.SelectedItem?.ToString()))
//            {
//                string selectedBook = openFileForm.listBox1.SelectedItem?.ToString();
//                openFileFromList(selectedBook);
//                openFileForm.Hide();
//            }           
//        }

//        private void openFileListBox1_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                if (!string.IsNullOrEmpty(openFileForm.listBox1.SelectedItem?.ToString()))
//                {
//                    string selectedBook = openFileForm.listBox1.SelectedItem?.ToString();
//                    openFileFromList(selectedBook);
//                    openFileForm.Hide();
//                }          
//                e.Handled = true;// Make sure to set e.Handled to true to prevent the control from processing the Enter key further
//            }
//        }

//        private void openFiletreeView1_AfterSelect(object sender, TreeViewEventArgs e)
//        {

//            if (openFileForm.treeView1.SelectedNode.ImageIndex != 0)
//            {
//                // Set the root directory to be displayed in the TrefeView
//                string basePath = Properties.Settings.Default.toratEmetInstallFolder;
//                string nodeRootPath = openFileForm.treeView1.SelectedNode.Text;

//                nodeRootPath = TranslatorClass.TranslateFilenameToPath(nodeRootPath);
//                nodeRootPath = Path.Combine(basePath, "ToratEmetInstall", nodeRootPath);

//                // Get the path to the system's temporary folder
//                string tempFolderPath = Path.GetTempPath();
//                // Create a temporary HTML file path with the same name as the original text file
//                string tempHtmlFilePath = Path.Combine(tempFolderPath, openFileForm.treeView1.SelectedNode.Text + ".html");

//                openSelectedFile(nodeRootPath, tempHtmlFilePath);
//                openFileForm.Hide();
//                //shouldDisposeForm = true; // Set the flag to true if the action is complete
//            }
//        }

//        private void openFiletreeView2_AfterSelect(object sender, TreeViewEventArgs e)
//        {
//            // Set the root directory
//            string basePath = Properties.Settings.Default.toratEmetInstallFolder;
//            string directoryPath = Path.Combine(basePath, "ToratEmetUserData", "MyBooks");
//            string nodeRootPath = openFileForm.treeView2.SelectedNode.Text;

//            // Search for file in directory without specifying ".txt" extension
//            string[] files = Directory.GetFiles(directoryPath, openFileForm.treeView2.SelectedNode.Text + "." + "*", System.IO.SearchOption.AllDirectories);

//            if (files.Length > 0)
//            {
//                string filePath = files[0]; // Get the first matching file's full path

//                // Get the path to the system's temporary folder
//                string tempFolderPath = Path.GetTempPath();
//                // Create a temporary HTML file path with the same name as the original text file
//                string tempHtmlFilePath = Path.Combine(tempFolderPath, openFileForm.treeView2.SelectedNode.Text + ".html");

//                openSelectedFile(filePath, tempHtmlFilePath);
//                openFileForm.Hide();
//                //shouldDisposeForm = true; // Set the flag to true if the action is complete
//            }
//        }

//        //
//        //
//        // servant voids for OpenFileForm
//        //
//        //




//        public void openFileFromList(string selectedBook)
//        {
//            bool istreeview1 = false;
//            if (selectedBook.EndsWith(" "))
//            {
//                istreeview1 = true;
//            }

//            string[] words;

//            if (selectedBook.Contains("("))
//            {
//                words = selectedBook.Split('(');
//                selectedBook = words[0].Trim();
//                exactAdress = words[1].Replace(")", "").Trim();
//            }
//            else
//            {
//                exactAdress = "";
//            }

//            //// Set the root directory
//            string basePath = Properties.Settings.Default.toratEmetInstallFolder;
//            string directoryPath = Path.Combine(basePath, "ToratEmetUserData", "MyBooks");

//            //// Search for file in directory without specifying ".txt" extension
//            //string[] files = Directory.GetFiles(directoryPath, selectedBook + "." + "*", System.IO.SearchOption.AllDirectories);

//            //if (files.Length > 0)
//            if (istreeview1 == false)
//            {
//                // Search for file in directory without specifying ".txt" extension
//                string[] files = Directory.GetFiles(directoryPath, selectedBook + "." + "*", System.IO.SearchOption.AllDirectories);

//                if (files.Length > 0)
//                {
//                    string filePath = files[0]; // Get the first matching file's full path

//                    // Get the path to the system's temporary folder
//                    string tempFolderPath = Path.GetTempPath();
//                    // Create a temporary HTML file path with the same name as the original text file
//                    string tempHtmlFilePath = Path.Combine(tempFolderPath, selectedBook.ToString() + ".html");

//                    openSelectedFile(filePath, tempHtmlFilePath);
//                }
//                else
//                {
//                    directoryPath = TranslatorClass.TranslateFilenameToPath(selectedBook.TrimEnd());
//                    directoryPath = Path.Combine(basePath, "ToratEmetInstall", directoryPath);

//                    // Get the path to the system's temporary folder
//                    string tempFolderPath = Path.GetTempPath();
//                    // Create a temporary HTML file path with the same name as the original text file
//                    string tempHtmlFilePath = Path.Combine(tempFolderPath, selectedBook.ToString() + ".html");

//                    openSelectedFile(directoryPath, tempHtmlFilePath);
//                }
//            }
//            else
//            {
//                directoryPath = TranslatorClass.TranslateFilenameToPath(selectedBook.TrimEnd());
//                directoryPath = Path.Combine(basePath, "ToratEmetInstall", directoryPath);

//                // Get the path to the system's temporary folder
//                string tempFolderPath = Path.GetTempPath();
//                // Create a temporary HTML file path with the same name as the original text file
//                string tempHtmlFilePath = Path.Combine(tempFolderPath, selectedBook.ToString() + ".html");

//                openSelectedFile(directoryPath, tempHtmlFilePath);
//            }
//        }


//        //
//        //
//        // 
//        // open selected file codes.
//        // 
//        // 
//        //
//        private void openSelectedFile(string selectedFilePath, string tempHtmlFilePath1)
//        {
//            if (string.IsNullOrEmpty(Properties.Settings.Default.toratEmetInstallFolder)) { CheckInstallationFolder(); }
//            if (File.Exists(selectedFilePath))
//            {
//                FileInfo fileInfo = new FileInfo(selectedFilePath);
//                long fileSizeInBytes = fileInfo.Length;
//                long fileSizeInKilobytes = fileSizeInBytes / 1024; // Convert bytes to kilobytes

//                if (fileSizeInKilobytes > 1000 && Properties.Settings.Default.skipBigFileAlert == false)
//                {
//                    DialogResult result = MessageBox.Show("עקב גודל הקובץ זמן הטעינה עלול לארוך יותר מן הרגיל. האם להמשיך?\r\n\r\nלחץ על 'ביטול' כדי לבטל הודעה זו בעתיד.", "אזהרת קובץ גדול", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

//                    if (result == DialogResult.Yes)
//                    {
//                        openSelectedFile2(selectedFilePath, tempHtmlFilePath1);
//                    }
//                    else if(result == DialogResult.Cancel)
//                    {
//                        Properties.Settings.Default.skipBigFileAlert = true;
//                        Properties.Settings.Default.Save();
//                        openSelectedFile2(selectedFilePath, tempHtmlFilePath1);
//                    }
//                }
//                else
//                {
//                    openSelectedFile2(selectedFilePath, tempHtmlFilePath1);
//                }
//            }
//        }

//        private async void openSelectedFile2(string chosenFilePath, string tempHtmlFilePath)
//        {
//            try { 
//            string pagename = Path.GetFileNameWithoutExtension(tempHtmlFilePath).Trim();
//            bool isFileOpen = false;

//            if (!string.IsNullOrEmpty(pagename))
//            {
//                //labelBookName.Text = pagename;
//                //updateHistoryList(pagename, ref isFileOpen);
//                //loadRelatedFiles(chosenFilePath, pagename);
//                //puplateHeadersMenu(pagename);

//                foreach (Control control in this.panel2.Controls)
//                {
//                    if (control is UserControlFileView ControlFileView && control.AccessibleName == pagename)
//                    {
//                        ControlFileView.BringToFront();
//                        userControlFileView = ControlFileView;
//                            if (islinkclicked == false) { userControlFileView.NavigaetHeaders(exactAdress); islinkclicked = false; }
//                        isFileOpen = true;
//                        break;
//                    }
//                }

//                if (!isFileOpen)
//                {
//                    updateHistoryList(pagename);
//                    await System.Threading.Tasks.Task.Run(() =>
//                    {
//                        BookCompiler bookCompiler = new BookCompiler();
//                        bookCompiler.RunComplier(chosenFilePath, tempHtmlFilePath);
//                        htmlContent = bookCompiler.htmlContent;
//                        headerMenuStructure = bookCompiler.headerMenuStructure;
//                    });

//                    this.BeginInvoke((Action)(() =>
//                    {
//                        ; menuStructureDictionary[pagename] = headerMenuStructure;
//                        //puplateHeadersMenu(pagename);
//                        //headerMenuStructure = "";

//                        //fileViewer = new WebBrowser(); // Create a new WebBrowser instance
//                        //fileViewer.Dock = DockStyle.Fill;
//                        //fileViewer.IsWebBrowserContextMenuEnabled = false;
//                        //fileViewer.ContextMenuStrip = contextMenuStrip1;
//                        //panel2.Controls.Add(fileViewer); // Add the WebBrowser control to the panel
//                        //fileViewer.BringToFront();

//                        userControlFileView = tempControlFileView;
//                        userControlFileView.htmlText = htmlContent;

//                        userControlFileView.SetTaskPaneUserControl(this);
//                        userControlFileView.AccessibleName = pagename;
//                        //userControlFileView.Dock = DockStyle.Fill;
//                        userControlFileView.Disposed += UserControlFileView_Disposed;

//                        userControlFileView.labelBookName.Text = pagename;
//                        userControlFileView.loadRelatedFiles(chosenFilePath, pagename);
//                        userControlFileView.puplateHeadersMenu(pagename);

//                        //flags for when document is completed
//                        userControlFileView.exactAdress = exactAdress;
//                        if (shouldautoNavigate == true)
//                        {
//                            userControlFileView.shouldautoNavigate = true; shouldautoNavigate = false;
//                            userControlFileView.autoNavigateText = autoNavigateText; autoNavigateText = "";
//                            userControlFileView.autoNavigateAlternative = autoNavigateAlternative; autoNavigateAlternative = "";
//                        }
//                        //

//                        //this.panel2.Controls.Add(userControlFileView);
//                        //userControlFileView.Show();
//                        userControlFileView.webBrowser1.DocumentText = htmlContent;
//                        userControlFileView.Visible = true;
//                        userControlFileView.BringToFront();
//                        LoadTempControlFileView();

//                        //pagename = Uri.EscapeDataString(pagename);
//                        //string pageUrl = $"/{pagename}";
//                        //dataHtmls[pageUrl] = htmlContent;
//                        //string fullUrl = host + pageUrl;// Ensure that the URL is constructed correctly.
//                        //userControlFileView.webBrowser1.Navigate(fullUrl);

//                        //fileViewer.AccessibleName = Path.GetFileNameWithoutExtension(tempHtmlFilePath).Trim();

//                        //File.WriteAllText(tempHtmlFilePath, htmlContent, Encoding.GetEncoding(1255));
//                        //webBrowser1.Navigate(new Uri(tempHtmlFilePath));
//                    }));
//                }
//            }

//            }
//            catch(Exception ex)
//            { MessageBox.Show(ex.ToString()); }

//        }

//        private void updateHistoryList(string currentUrl)
//        {
//            this.BeginInvoke((Action)(() =>
//            { 
//            string[] existingItems = historyListButton.DropDownItems
//                        .OfType<ToolStripMenuItem>()
//                        .Select(item => item.Text)
//                        .ToArray();

//            bool urlExists = existingItems.Any(item => string.Equals(item, currentUrl, StringComparison.OrdinalIgnoreCase));

//            if (!urlExists)
//            {
//                ToolStripMenuItem urlMenuItem = new ToolStripMenuItem(currentUrl);
//                urlMenuItem.Click += UrlMenuItem_Click;
//                historyListButton.DropDownItems.Add(urlMenuItem);

//                // Remove the oldest item if the number of items exceeds the limit
//                if (historyListButton.DropDownItems.Count > 20)
//                {
//                    string oldestItem = historyListButton.DropDownItems[2].Text;
//                    historyListButton.DropDownItems.RemoveAt(2);
//                    foreach (UserControlFileView userControlFileview in this.panel2.Controls)
//                    {
//                        if (userControlFileview.AccessibleName == oldestItem)
//                        {
//                            userControlFileView.Dispose();
//                        }
//                    }
//                }
//            }

//            // Assuming you want to join the text of each item in toolStripDropDownButton1.DropDownItems
//            string historyList = string.Join(",", historyListButton.DropDownItems
//                    .OfType<ToolStripMenuItem>() // Assuming the items are ToolStripMenuItem
//                    .Select(item => item.Text));

//            Properties.Settings.Default.historyList = historyList;
//            Properties.Settings.Default.Save();
//            }));

//        }

//        private void UrlMenuItem_Click(object sender, EventArgs e)
//        {
//            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
//            int clickedIndex = historyListButton.DropDownItems.IndexOf(clickedItem);
//            string itemName = historyListButton.DropDownItems[clickedIndex].Text;
//            if (itemName == "סגור הכל") { closeAllBooks(); }
//            else { ActivateSelectedPage(itemName); }
//        }







//        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {
//            if (firstMessage == false)
//            {
//                //    Navigate to a blank page
//                //webBrowser1.Navigate("about:blank");
//                string textToInsert = "<div align=\"center\"><p></p><p>© כל הזכויות שמורות ליוצר התוכנה tosaftorani@gmail.com </p><p>אין להשתמש בתוכנה למטרות מסחריות<br></p><p>לקבלת עדכונים אפשר לשלוח למייל הנ"ל עם הכותרת "קבלת עדכונים"<p><h2>הודעה חשובה</h2><p>פרוייקט זה הינו חלק קטן מתוך מפרוייקט נרחב להנגשת הספרייה היהודית במחשב לציבור הרחב <br>אם אתם משתמשים בתוכנה באורח קבע או שהינכם מעוניינים להשתתף בפרוייקט אנא לחצו כעת על לחצן התרומות <br>לתרומות גדולות לעילוי נשמת יקירכם וכיו\"ב אפשר ליצור איתי קשר במייל הנ\"ל<br></p><p><br>בברכה המערכת<br></p><p>שימו לב! כדי להשתמש בתוסף יש להתקין במחשב את המאגר המקורי של תורת אמת</p></div>";
//                webBrowser1.Document.Body.InnerHtml = textToInsert;

//                firstMessage = true;
//            }
//        }





//    }
//}
//}





//public string autoNavigateText = "";
//public bool shouldautoNavigate = false;
//private string autoNavigateAlternative = "";

//private bool firstMessage = false;
//private string exactAdress = "";
//string htmlContent = "";
//public string disposedFile = "";
//public bool xButtonClicked = false;

//DictionaryForm dictionaryForm;
//UserControlFileView userControlFileView;
//UserControlFileView tempControlFileView;
//public bool needControlFileview = false;
//public string searchformChpaterNavigate = "";



//public bool islinkclicked = false;

//ListsWithHeadings listsWithHeadings = new ListsWithHeadings();

//public String headerMenuStructure = "";

//private void goBackButton_Click(object sender, EventArgs e)
//{
//    try
//    {
//        if (fileViewer != null)
//        {
//            int openBookIndex = -1;
//            foreach (ToolStripItem item in historyListButton.DropDownItems)
//            {
//                openBookIndex++;
//                if (item.Text.Trim() == tabControl1.SelectedTab.Name.Trim()) { break; }
//            }
//            if (openBookIndex > 2)
//            {
//                string fileName = historyListButton.DropDownItems[openBookIndex - 1].Text;
//                openSelectedFile(fileName);
//            }
//        }
//    }
//    catch (Exception ex) { MessageBox.Show(ex.Message); }
//}

//private void goForwardButton_Click(object sender, EventArgs e)
//{
//    try
//    {
//        if (fileViewer != null)
//        {
//            int openBookIndex = -1;
//            foreach (ToolStripItem item in historyListButton.DropDownItems)
//            {
//                openBookIndex++;
//                if (item.Text.Trim() == tabControl1.SelectedTab.Name.Trim()) { break; }
//            }

//            if (openBookIndex < historyListButton.DropDownItems.Count - 1)
//            {
//                string fileName = historyListButton.DropDownItems[openBookIndex + 1].Text;
//                openSelectedFile(fileName);
//            }
//        }
//        else
//        {
//            string fileName = historyListButton.DropDownItems[2].Text;
//            openSelectedFile(fileName);
//        }
//    }
//    catch (Exception ex) { MessageBox.Show(ex.Message); }
//}