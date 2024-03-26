using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public static class TransaltorClass
    {
        public static string TranslateFolderName(string folderName)
        {
            folderName = folderName.Replace("ACCESORIES",
                "עזרים שונים").
            Replace("HORADOT",
                "הורדות").
                 Replace("HADERECH_LATORA",
                "הדרך לתורה").
            Replace("TORA",
                "תורה").
            Replace("NAVI",
                "נביאים").
            Replace("KTUVIM",
                "כתובים").
            Replace("MISHNA",
                "משנה").
            Replace("BAVLI",
                "תלמוד בבלי").
            Replace("RAMBAM",
                "משנה תורה להרמב''ם").
            Replace("HALACHA",
                "הלכה").
            Replace("IYUNIM",
                "עיונים בהלכה ובש''ס").
            Replace("MUSAR",
                "מוסר").
            Replace("KABALA",
                "קבלה").
            Replace("CHASIDUT",
                "חסידות").
            Replace("HANHAGOT",
                "הנהגות").
            Replace("PARSHA",
                "פרשת השבוע").
            Replace("HAGIM",
                "חגי ומועדי ישראל").
            Replace("GDOLEY_HADOROT",
                "גדולי הדורות").
            Replace("SHUT",
                "שאלות ותשובות").
            Replace("HABITE",
                "הבית היהודי").
            Replace("CONTRAS",
                "קונטרסים").
            Replace("TFILOT_VESGULOT",
                "תפילות וסגולות").
            Replace("HIDONIM",
                "חידונים").
            Replace("AHAVAT_ISRAEL",
                "אהבת ישראל").
            Replace("MISC",
                "שונות").
            Replace("GROUPS",
                "קבוצות").
            Replace("NOTES",
                "פנקסי ההערות שלי").
            Replace("MY_BOOKS",
                "הספרים שלי").
            Replace("TUR",
                "טור").
            Replace("YERUSHALMI",
                "תלמוד ירושלמי").
            Replace("RAMBAM_ON_MISHNA",
                "רמב''ם על המשנה").
            Replace("SHIMONI",
                "ילקוט שמעוני").
            Replace("BERESHIT",
                "בראשית").
            Replace("SHEMOT",
                "שמות").
            Replace("VAIKRA",
                "ויקרא").
            Replace("BAMIDBAR",
                "במדבר").
            Replace("DEVARIM",
                "דברים").
            Replace("YEHOSUA",
                "יהושע").
            Replace("SHOFETIM",
                "שופטים").
            Replace("SHEMUEL_A",
                "שמואל א").
            Replace("SHEMUEL_B",
                "שמואל ב").
            Replace("MELACIM_A",
                "מלכים א").
            Replace("MELACIM_B",
                "מלכים ב").
            Replace("YISHAYA",
                "ישעיה").
            Replace("YERMIYA",
                "ירמיה").
            Replace("YEHEZKEL",
                "יחזקאל").
            Replace("HOSEA",
                "הושע").
            Replace("YOEL",
                "יואל").
            Replace("AMOS",
                "עמוס").
            Replace("OVADYA",
                "עובדיה").
            Replace("YONA",
                "יונה").
            Replace("MICHA",
                "מיכה").
            Replace("NAHUM",
                "נחום").
            Replace("HAVAKUK",
                "חבקוק").
            Replace("ZFANYA",
                "צפניה").
            Replace("HAGAY",
                "חגי").
            Replace("ZECHARYA",
                "זכריה").
            Replace("MALACHI",
                "מלאכי").
            Replace("TEHILIM",
                "תהילים").
            Replace("MISHLEI",
                "משלי").
            Replace("IYOV",
                "איוב").
            Replace("SHIR_HASHIRIM",
                "שיר השירים").
            Replace("RUTH",
                "רות").
            Replace("EICHA",
                "איכה").
            Replace("KOHELET",
                "קהלת").
            Replace("ESTER",
                "אסתר").
            Replace("DANIEL",
                "דניאל").
            Replace("EZRA",
                "עזרא").
            Replace("NECHEMYA",
                "נחמיה").
            Replace("DIVRE_A",
                "דברי הימים א").
            Replace("DIVRE_B",
                "דברי הימים ב").
            Replace("SEDER_ZRAIM",
                "סדר זרעים").
            Replace("SEDER_MOED",
                "סדר מועד").
            Replace("SEDER_NASHIM",
                "סדר נשים").
            Replace("SEDER_NEZIKIN",
                "סדר נזיקין").
            Replace("SEDER_KADASHIM",
                "סדר קדשים").
            Replace("SEDER_TAHAROT",
                "סדר טהרות").
            Replace("MAS_BRACHOT",
                "מסכת ברכות").
            Replace("MAS_PEA",
                "מסכת פאה").
            Replace("MAS_DEMAI",
                "מסכת דמאי").
            Replace("MAS_KILAIIM",
                "מסכת כלאים").
            Replace("MAS_SHEVIIT",
                "מסכת שביעית").
            Replace("MAS_TRUMOT",
                "מסכת תרומות").
            Replace("MAS_MAASROT",
                "מסכת מעשרות").
            Replace("MAS_MAASER_SHENI",
                "מסכת מעשר שני").
            Replace("MAS_CHALA",
                "מסכת חלה").
            Replace("MAS_ORLA",
                "מסכת ערלה").
            Replace("MAS_BIKURIM",
                "מסכת ביכורים").
            Replace("MAS_SHABAT",
                "מסכת שבת").
            Replace("MAS_ERUVIN",
                "מסכת עירובין").
            Replace("MAS_PSACHIM",
                "מסכת פסחים").
            Replace("MAS_SHKALIM",
                "מסכת שקלים").
            Replace("MAS_ROSH",
                "מסכת ראש השנה").
            Replace("MAS_YOMA",
                "מסכת יומא").
            Replace("MAS_SUCA",
                "מסכת סוכה").
            Replace("MAS_BEITSA",
                "מסכת ביצה").
            Replace("MAS_TAANIT",
                "מסכת תענית").
            Replace("MAS_MEGILA",
                "מסכת מגילה").
            Replace("MAS_MOED_KATAN",
                "מסכת מועד קטן").
            Replace("MAS_HAGIGA",
                "מסכת חגיגה").
            Replace("MAS_YEVAMOT",
                "מסכת יבמות").
            Replace("MAS_KTUBOT",
                "מסכת כתובות").
            Replace("MAS_NEDARIM",
                "מסכת נדרים").
            Replace("MAS_NAZIR",
                "מסכת נזיר").
            Replace("MAS_SOTA",
                "מסכת סוטה").
            Replace("MAS_GITIN",
                "מסכת גיטין").
            Replace("MAS_KIDUSHIN",
                "מסכת קידושין").
            Replace("MAS_KAMA",
                "מסכת בבא קמא").
            Replace("MAS_METSIA",
                "מסכת בבא מציעא").
            Replace("MAS_BATRA",
                "מסכת בבא בתרא").
            Replace("MAS_SANHEDRIN",
                "מסכת סנהדרין").
            Replace("MAS_MAKOT",
                "מסכת מכות").
            Replace("MAS_SHVUOT",
                "מסכת שבועות").
            Replace("MAS_AVODA_ZARA",
                "מסכת עבודה זרה").
            Replace("MAS_AVOT",
                "מסכת אבות").
            Replace("MAS_HORAYOT",
                "מסכת הוריות").
            Replace("MAS_EDUYOT",
                "מסכת עדיות").
            Replace("MAS_ZEVACHIM",
                "מסכת זבחים").
            Replace("MAS_MENACHOT",
                "מסכת מנחות").
            Replace("MAS_CHULIN",
                "מסכת חולין").
            Replace("MAS_BECHOROT",
                "מסכת בכורות").
            Replace("MAS_ARACHIN",
                "מסכת ערכין").
            Replace("MAS_TEMURA",
                "מסכת תמורה").
            Replace("MAS_KRETOT",
                "מסכת כריתות").
            Replace("MAS_MEILA",
                "מסכת מעילה").
            Replace("MAS_TAMID",
                "מסכת תמיד").
            Replace("MAS_MIDOT",
                "מסכת מדות").
            Replace("MAS_KANIM",
                "מסכת קנים").
            Replace("MAS_KELIM",
                "מסכת כלים").
            Replace("MAS_AHALOT",
                "מסכת אהלות").
            Replace("MAS_NEGAIIM",
                "מסכת נגעים").
            Replace("MAS_PARA",
                "מסכת פרה").
            Replace("MAS_TAHAROT",
                "מסכת טהרות").
            Replace("MAS_MIKVAOT",
                "מסכת מקואות").
            Replace("MAS_NIDA",
                "מסכת נדה").
            Replace("MAS_MACHSHIRIN",
                "מסכת מכשירין").
            Replace("MAS_ZAVIM",
                "מסכת זבים").
            Replace("MAS_TEVUL_YOM",
                "מסכת טבול יום").
            Replace("MAS_YADAIIM",
                "מסכת ידים").
            Replace("MAS_OKATSIN",
                "מסכת עוקצין").
            Replace("GROUP_SHABAT",
                "קבוצת שבת קודש").
            Replace("GROUP_TAHARA",
                "קבוצת טהרת המשפחה").
            Replace("GROUP_TSNIUT",
                "קבוצת צניעות האשה").
            Replace("GROUP_KASHRUT",
                "קבוצת כשרות המטבח");

            return folderName;
        }
        public static string TranslateFilename(string originalFilename)
        {
            if (!originalFilename.Contains("ToratEmetInstall")) { return Path.GetFileNameWithoutExtension(originalFilename); }
            Match match = Regex.Match(originalFilename, @"(.*)(Books\\)(.*)");
            string newFilename = match.Groups[3].Value;

            switch (newFilename)
            {
                case "000_ACCESORIES\\0011_!help.htm":
                    return "0011_!help.htm";
                case "000_ACCESORIES\\0012_daily.txt":
                    return "הלימוד היומי";
                case "000_ACCESORIES\\0013_daily_info.txt":
                    return "מידע יומי";
                case "000_ACCESORIES\\0014_contents.txt":
                    return "תוכן עניינים מותאם אישית";
                case "000_ACCESORIES\\0015_stat.txt":
                    return "מעקב לימוד";
                case "000_ACCESORIES\\0016_mare.txt":
                    return "מארי דחושבנא";
                case "000_HORADOT\\100_TUR\\010_tur_orach_chaim_merged.txt":
                    return "טור - אורח חיים";
                case "000_HORADOT\\100_TUR\\011_tur_yore_deaa_merged.txt":
                    return "טור - יורה דעה";
                case "000_HORADOT\\100_TUR\\012_tur_even_haezer_merged.txt":
                    return "טור - אבן העזר";
                case "000_HORADOT\\100_TUR\\013_tur_choshen_mishpat_merged.txt":
                    return "טור - חשן משפט";
                case "000_HORADOT\\100_TUR\\100_tur_orach_chaiim_tur.txt":
                    return "טור - אורח חיים - טור";
                case "000_HORADOT\\100_TUR\\101_tur_orach_chaiim_beit_yosef.txt":
                    return "טור - אורח חיים - בית יוסף";
                case "000_HORADOT\\100_TUR\\102_tur_orach_chaiim_bach.txt":
                    return "טור - אורח חיים - בית חדש";
                case "000_HORADOT\\100_TUR\\103_tur_orach_chaiim_darkei_moshe.txt":
                    return "טור - אורח חיים - דרכי משה";
                case "000_HORADOT\\100_TUR\\104_tur_orach_chaiim_drisha.txt":
                    return "טור - אורח חיים - דרישה";
                case "000_HORADOT\\100_TUR\\105_tur_orach_chaiim_prisha.txt":
                    return "טור - אורח חיים - פרישה";
                case "000_HORADOT\\100_TUR\\106_tur_orach_chaiim_hagahot.txt":
                    return "טור - אורח חיים - חידושי הגהות";
                case "000_HORADOT\\100_TUR\\107_tur_orach_chaiim_notes.txt":
                    return "טור - אורח חיים - הערות";
                case "000_HORADOT\\100_TUR\\120_tur_yore_dea_tur.txt":
                    return "טור - יורה דעה - טור";
                case "000_HORADOT\\100_TUR\\121_tur_yore_dea_beit_yosef.txt":
                    return "טור - יורה דעה - בית יוסף";
                case "000_HORADOT\\100_TUR\\122_tur_yore_dea_bach.txt":
                    return "טור - יורה דעה - בית חדש";
                case "000_HORADOT\\100_TUR\\123_tur_yore_dea_darkei_moshe.txt":
                    return "טור - יורה דעה - דרכי משה";
                case "000_HORADOT\\100_TUR\\124_tur_yore_dea_drisha.txt":
                    return "טור - יורה דעה - דרישה";
                case "000_HORADOT\\100_TUR\\125_tur_yore_dea_prisha.txt":
                    return "טור - יורה דעה - פרישה";
                case "000_HORADOT\\100_TUR\\126_tur_yore_dea_hagahot.txt":
                    return "טור - יורה דעה - חידושי הגהות";
                case "000_HORADOT\\100_TUR\\127_tur_yore_dea_notes.txt":
                    return "טור - יורה דעה - הערות";
                case "000_HORADOT\\100_TUR\\140_tur_even_haezer_tur.txt":
                    return "טור - אבן העזר - טור";
                case "000_HORADOT\\100_TUR\\141_tur_even_haezer_beit_yosef.txt":
                    return "טור - אבן העזר - בית יוסף";
                case "000_HORADOT\\100_TUR\\142_tur_even_haezer_bach.txt":
                    return "טור - אבן העזר - בית חדש";
                case "000_HORADOT\\100_TUR\\143_tur_even_haezer_darkei_moshe.txt":
                    return "טור - אבן העזר - דרכי משה";
                case "000_HORADOT\\100_TUR\\144_tur_even_haezer_drisha.txt":
                    return "טור - אבן העזר - דרישה";
                case "000_HORADOT\\100_TUR\\145_tur_even_haezer_prisha.txt":
                    return "טור - אבן העזר - פרישה";
                case "000_HORADOT\\100_TUR\\146_tur_even_haezer_hagahot.txt":
                    return "טור - אבן העזר - חידושי הגהות";
                case "000_HORADOT\\100_TUR\\147_tur_even_haezer_notes.txt":
                    return "טור - אבן העזר - הערות";
                case "000_HORADOT\\100_TUR\\160_tur_choshen_mishpat_tur.txt":
                    return "טור - חושן משפט - טור";
                case "000_HORADOT\\100_TUR\\161_tur_choshen_mishpat_beit_yosef.txt":
                    return "טור - חושן משפט - בית יוסף";
                case "000_HORADOT\\100_TUR\\162_tur_choshen_mishpat_bach.txt":
                    return "טור - חושן משפט - בית חדש";
                case "000_HORADOT\\100_TUR\\163_tur_choshen_mishpat_darkei_moshe.txt":
                    return "טור - חושן משפט - דרכי משה";
                case "000_HORADOT\\100_TUR\\164_tur_choshen_mishpat_drisha.txt":
                    return "טור - חושן משפט - דרישה";
                case "000_HORADOT\\100_TUR\\165_tur_choshen_mishpat_prisha.txt":
                    return "טור - חושן משפט - פרישה";
                case "000_HORADOT\\100_TUR\\166_tur_choshen_mishpat_hagahot.txt":
                    return "טור - חושן משפט - חידושי הגהות";
                case "000_HORADOT\\100_TUR\\167_tur_choshen_mishpat_notes.txt":
                    return "טור - חושן משפט - הערות";
                case "000_HORADOT\\200_PARSHA\\dummy.dat":
                    return "dummy.dat";
                case "000_HORADOT\\250_SHIMONI\\001_shimoni_bereshit.txt":
                    return " ילקוט שמעוני - בראשית";
                case "000_HORADOT\\250_SHIMONI\\002_shimoni_shemot.txt":
                    return " ילקוט שמעוני - שמות";
                case "000_HORADOT\\250_SHIMONI\\003_shimoni_vaikra.txt":
                    return "ילקוט שמעוני - ויקרא ";
                case "000_HORADOT\\250_SHIMONI\\004_shimoni_bamidbar.txt":
                    return "ילקוט שמעוני - במדבר ";
                case "000_HORADOT\\250_SHIMONI\\005_shimoni_devarim.txt":
                    return "ילקוט שמעוני - דברים ";
                case "000_HORADOT\\250_SHIMONI\\006_shimoni_yehoshua.txt":
                    return "ילקוט שמעוני - יהושע";
                case "000_HORADOT\\250_SHIMONI\\007_shimoni_shofetim.txt":
                    return "ילקוט שמעוני - שופטים";
                case "000_HORADOT\\250_SHIMONI\\008_shimoni_shmuel_a.txt":
                    return "ילקוט שמעוני - שמואל א";
                case "000_HORADOT\\250_SHIMONI\\009_shimoni_shmuel_b.txt":
                    return "ילקוט שמעוני - שמואל ב";
                case "000_HORADOT\\250_SHIMONI\\010_shimoni_melachim_a.txt":
                    return "ילקוט שמעוני - מלכים א";
                case "000_HORADOT\\250_SHIMONI\\011_shimoni_melachim_b.txt":
                    return "ילקוט שמעוני - מלכים ב";
                case "000_HORADOT\\250_SHIMONI\\012_shimoni_yishaya.txt":
                    return "ילקוט שמעוני - ישעיה";
                case "000_HORADOT\\250_SHIMONI\\013_shimoni_yermiya.txt":
                    return "ילקוט שמעוני - ירמיה";
                case "000_HORADOT\\250_SHIMONI\\014_shimoni_yechezkel.txt":
                    return "ילקוט שמעוני - יחזקאל";
                case "000_HORADOT\\250_SHIMONI\\015_shimoni_hoshea.txt":
                    return "ילקוט שמעוני - הושע";
                case "000_HORADOT\\250_SHIMONI\\016_shimoni_yoel.txt":
                    return "ילקוט שמעוני - יואל";
                case "000_HORADOT\\250_SHIMONI\\017_shimoni_amos.txt":
                    return "ילקוט שמעוני - עמוס";
                case "000_HORADOT\\250_SHIMONI\\018_shimoni_ovadya.txt":
                    return "ילקוט שמעוני - עובדיה";
                case "000_HORADOT\\250_SHIMONI\\019_shimoni_yona.txt":
                    return "ילקוט שמעוני - יונה";
                case "000_HORADOT\\250_SHIMONI\\020_shimoni_micha.txt":
                    return "ילקוט שמעוני - מיכה";
                case "000_HORADOT\\250_SHIMONI\\021_shimoni_nachum.txt":
                    return "ילקוט שמעוני - נחום";
                case "000_HORADOT\\250_SHIMONI\\022_shimoni_havakuk.txt":
                    return "ילקוט שמעוני - חבקוק";
                case "000_HORADOT\\250_SHIMONI\\023_shimoni_zefanya.txt":
                    return "ילקוט שמעוני - צפניה";
                case "000_HORADOT\\250_SHIMONI\\024_shimoni_hagay.txt":
                    return "ילקוט שמעוני - חגי";
                case "000_HORADOT\\250_SHIMONI\\025_shimoni_zecharya.txt":
                    return "ילקוט שמעוני - זכריה";
                case "000_HORADOT\\250_SHIMONI\\026_shimoni_malachi.txt":
                    return "ילקוט שמעוני - מלאכי";
                case "000_HORADOT\\250_SHIMONI\\027_shimoni_tehilim.txt":
                    return "ילקוט שמעוני - תהילים";
                case "000_HORADOT\\250_SHIMONI\\028_shimoni_mishley.txt":
                    return "ילקוט שמעוני - משלי";
                case "000_HORADOT\\250_SHIMONI\\029_shimoni_iyov.txt":
                    return "ילקוט שמעוני - איוב";
                case "000_HORADOT\\250_SHIMONI\\030_shimoni_shir_hashirim.txt":
                    return "ילקוט שמעוני - שיר השירים";
                case "000_HORADOT\\250_SHIMONI\\031_shimoni_ruth.txt":
                    return "ילקוט שמעוני - רות";
                case "000_HORADOT\\250_SHIMONI\\032_shimoni_eicha.txt":
                    return "ילקוט שמעוני - איכה";
                case "000_HORADOT\\250_SHIMONI\\033_shimoni_kohelet.txt":
                    return "ילקוט שמעוני - קהלת";
                case "000_HORADOT\\250_SHIMONI\\034_shimoni_ester.txt":
                    return "ילקוט שמעוני - אסתר";
                case "000_HORADOT\\250_SHIMONI\\035_shimoni_daniel.txt":
                    return "ילקוט שמעוני - דניאל";
                case "000_HORADOT\\250_SHIMONI\\036_shimoni_ezra.txt":
                    return "ילקוט שמעוני - עזרא";
                case "000_HORADOT\\250_SHIMONI\\037_shimoni_nechemya.txt":
                    return "ילקוט שמעוני - נחמיה";
                case "000_HORADOT\\250_SHIMONI\\038_shimoni_divrei_a.txt":
                    return "ילקוט שמעוני - דברי הימים א";
                case "000_HORADOT\\250_SHIMONI\\039_shimoni_divrei_b.txt":
                    return "ילקוט שמעוני - דברי הימים ב";
                case "000_HORADOT\\250_SHIMONI\\dummy.dat":
                    return "dummy.dat";
                case "001_TORA\\01_BERESHIT\\a01__Genesis.txt":
                    return "בראשית";
                case "001_TORA\\01_BERESHIT\\a01_Genesis.txt":
                    return "בראשית - ללא טעמים";

                case "001_TORA\\01_BERESHIT\\b01_Genesis.txt":
                    return "בראשית - ללא ניקוד";
                case "001_TORA\\01_BERESHIT\\c_RASHI_BERESHIT_L1.txt":
                    return "בראשית - רש''י";
                case "001_TORA\\01_BERESHIT\\c_RASHI_BERESHIT_OLD.txt":
                    return "בראשית - רש''י (ב)";
                case "001_TORA\\01_BERESHIT\\c_siftei_1.txt":
                    return "בראשית - שפתי חכמים";
                case "001_TORA\\01_BERESHIT\\d_ramban_bereshit.txt":
                    return "בראשית - רמב''ן";
                case "001_TORA\\01_BERESHIT\\e01_Genesis.txt":
                    return "בראשית - תרגום יונתן";
                case "001_TORA\\01_BERESHIT\\f_OrHachaim.txt":
                    return "בראשית - אור החיים";
                case "001_TORA\\01_BERESHIT\\g_EbenEzra.txt":
                    return "בראשית - אבן עזרא";
                case "001_TORA\\01_BERESHIT\\h_BaalHaturim.txt":
                    return "בראשית - בעל הטורים";
                case "001_TORA\\01_BERESHIT\\i_onqelus.txt":
                    return "בראשית - תרגום אונקלוס";
                case "001_TORA\\01_BERESHIT\\j_sforno.txt":
                    return "בראשית - ספורנו";
                case "001_TORA\\01_BERESHIT\\k_keli_yakar1.txt":
                    return "בראשית - כלי יקר";
                case "001_TORA\\01_BERESHIT\\m_daatzkenim1.txt":
                    return "בראשית - דעת זקנים";
                case "001_TORA\\01_BERESHIT\\w_raba1.txt":
                    return "מדרש רבה - חומש בראשית";
                case "001_TORA\\01_BERESHIT\\w_tanchuma1.txt":
                    return "מדרש תנחומא - בראשית";
                case "001_TORA\\01_BERESHIT\\w_ts_shimoni_bereshit.txt":
                    return "ילקוט שמעוני - בראשית";
                case "001_TORA\\01_BERESHIT\\x2_Interleave.txt":
                    return "בראשית - רש''י ושפתי חכמים";
                case "001_TORA\\01_BERESHIT\\x_Interleave.txt":
                    return "בראשית - מקרא ותרגום";
                case "001_TORA\\01_BERESHIT\\x_Interleave2.txt":
                    return "בראשית - מקרא ותרגום (ט)";
                case "001_TORA\\01_BERESHIT\\y_hok10.txt":
                    return "חק לישראל - בראשית";
                case "001_TORA\\01_BERESHIT\\y_hok11.txt":
                    return "חק לישראל - בראשית  (ט)";
                case "001_TORA\\01_BERESHIT\\z_Interleave.txt":
                    return "בראשית";
                case "001_TORA\\01_BERESHIT\\z_Interleave2.txt":
                    return "בראשית (ט)";
                case "001_TORA\\02_SHEMOT\\a02__Exodus.txt":
                    return "שמות";
                case "001_TORA\\02_SHEMOT\\a02_Exodus.txt":
                    return "שמות - ללא טעמים";

                case "001_TORA\\02_SHEMOT\\b02_Exodus.txt":
                    return "שמות - ללא ניקוד";
                case "001_TORA\\02_SHEMOT\\c_RASHI_SHEMOT_L1.txt":
                    return "שמות - רש''י";
                case "001_TORA\\02_SHEMOT\\c_RASHI_SHEMOT_OLD.txt":
                    return "שמות - רש''י (ב)";
                case "001_TORA\\02_SHEMOT\\c_siftei_2.txt":
                    return "שמות - שפתי חכמים";
                case "001_TORA\\02_SHEMOT\\d_ramban_shemot.txt":
                    return "שמות - רמב''ן";
                case "001_TORA\\02_SHEMOT\\e02_Exodus.txt":
                    return "שמות - תרגום יונתן";
                case "001_TORA\\02_SHEMOT\\f_OrHachaim.txt":
                    return "שמות - אור החיים";
                case "001_TORA\\02_SHEMOT\\g_EbenEzra.txt":
                    return "שמות - אבן עזרא";
                case "001_TORA\\02_SHEMOT\\h_BaalHaturim.txt":
                    return "שמות - בעל הטורים";
                case "001_TORA\\02_SHEMOT\\i_onqelus.txt":
                    return "שמות - תרגום אונקלוס";
                case "001_TORA\\02_SHEMOT\\j_sforno.txt":
                    return "שמות - ספורנו";
                case "001_TORA\\02_SHEMOT\\k_keli_yakar2.txt":
                    return "שמות - כלי יקר";
                case "001_TORA\\02_SHEMOT\\m_daatzkenim2.txt":
                    return "שמות - דעת זקנים";
                case "001_TORA\\02_SHEMOT\\w_raba2.txt":
                    return "מדרש רבה - חומש שמות";
                case "001_TORA\\02_SHEMOT\\w_tanchuma2.txt":
                    return "מדרש תנחומא - שמות";
                case "001_TORA\\02_SHEMOT\\w_ts_shimoni_shemot.txt":
                    return "ילקוט שמעוני - שמות";
                case "001_TORA\\02_SHEMOT\\x2_Interleave.txt":
                    return "שמות - רש''י ושפתי חכמים";
                case "001_TORA\\02_SHEMOT\\x_Interleave.txt":
                    return "שמות - מקרא ותרגום";
                case "001_TORA\\02_SHEMOT\\x_Interleave2.txt":
                    return "שמות - מקרא ותרגום (ט)";
                case "001_TORA\\02_SHEMOT\\y_hok20.txt":
                    return "חק לישראל - שמות";
                case "001_TORA\\02_SHEMOT\\y_hok21.txt":
                    return "חק לישראל - שמות  (ט)";
                case "001_TORA\\02_SHEMOT\\z_Interleave.txt":
                    return "שמות";
                case "001_TORA\\02_SHEMOT\\z_Interleave2.txt":
                    return "שמות (ט)";
                case "001_TORA\\03_VAIKRA\\a03__Leviticus.txt":
                    return "ויקרא";
                case "001_TORA\\03_VAIKRA\\a03_Leviticus.txt":
                    return "ויקרא - ללא טעמים";

                case "001_TORA\\03_VAIKRA\\b03_Leviticus.txt":
                    return "ויקרא - ללא ניקוד";
                case "001_TORA\\03_VAIKRA\\c_RASHI_VAYIKRA_L1.txt":
                    return "ויקרא - רש''י";
                case "001_TORA\\03_VAIKRA\\c_RASHI_VAYIKRA_OLD.txt":
                    return "ויקרא - רש''י (ב)";
                case "001_TORA\\03_VAIKRA\\c_siftei_3.txt":
                    return "ויקרא - שפתי חכמים";
                case "001_TORA\\03_VAIKRA\\d_ramban_vayikra.txt":
                    return "ויקרא - רמב''ן";
                case "001_TORA\\03_VAIKRA\\e03_Leviticus.txt":
                    return "ויקרא - תרגום יונתן";
                case "001_TORA\\03_VAIKRA\\f_OrHachaim.txt":
                    return "ויקרא אור החיים";
                case "001_TORA\\03_VAIKRA\\g_EbenEzra.txt":
                    return "ויקרא - אבן עזרא";
                case "001_TORA\\03_VAIKRA\\h_BaalHaturim.txt":
                    return "ויקרא - בעל הטורים";
                case "001_TORA\\03_VAIKRA\\i_onqelus.txt":
                    return "ויקרא - תרגום אונקלוס";
                case "001_TORA\\03_VAIKRA\\j_sforno.txt":
                    return "ויקרא - ספורנו";
                case "001_TORA\\03_VAIKRA\\k_keli_yakar3.txt":
                    return "ויקרא - כלי יקר";
                case "001_TORA\\03_VAIKRA\\m_daatzkenim3.txt":
                    return "ויקרא - דעת זקנים";
                case "001_TORA\\03_VAIKRA\\w_raba3.txt":
                    return "מדרש רבה - חומש ויקרא";
                case "001_TORA\\03_VAIKRA\\w_tanchuma3.txt":
                    return "מדרש תנחומא - ויקרא";
                case "001_TORA\\03_VAIKRA\\w_ts_shimoni_vayikra.txt":
                    return "ילקוט שמעוני - ויקרא";
                case "001_TORA\\03_VAIKRA\\x2_Interleave.txt":
                    return "ויקרא - רש''י ושפתי חכמים";
                case "001_TORA\\03_VAIKRA\\x_Interleave.txt":
                    return "ויקרא - מקרא ותרגום";
                case "001_TORA\\03_VAIKRA\\x_Interleave2.txt":
                    return "ויקרא - מקרא ותרגום (ט)";
                case "001_TORA\\03_VAIKRA\\y_hok30.txt":
                    return "חק לישראל - ויקרא";
                case "001_TORA\\03_VAIKRA\\y_hok31.txt":
                    return "חק לישראל - ויקרא  (ט)";
                case "001_TORA\\03_VAIKRA\\z_Interleave.txt":
                    return "ויקרא";
                case "001_TORA\\03_VAIKRA\\z_Interleave2.txt":
                    return "ויקרא (ט)";

                case "001_TORA\\04_BAMIDBAR\\a04__Numbers.txt":
                    return "במדבר";
                case "001_TORA\\04_BAMIDBAR\\a04_Numbers.txt":
                    return "במדבר - ללא טעמים";

                case "001_TORA\\04_BAMIDBAR\\b04_Numbers.txt":
                    return "במדבר - ללא ניקוד";
                case "001_TORA\\04_BAMIDBAR\\c_RASHI_BAMIDBAR_L1.txt":
                    return "במדבר - רש''י";
                case "001_TORA\\04_BAMIDBAR\\c_RASHI_BAMIDBAR_OLD.txt":
                    return "במדבר - רש''י (ב)";
                case "001_TORA\\04_BAMIDBAR\\c_siftei_4.txt":
                    return "במדבר - שפתי חכמים";
                case "001_TORA\\04_BAMIDBAR\\d_ramban_bamidbar.txt":
                    return "במדבר - רמב''ן";
                case "001_TORA\\04_BAMIDBAR\\e04_Numbers.txt":
                    return "במדבר - תרגום יונתן";
                case "001_TORA\\04_BAMIDBAR\\f_OrHachaim.txt":
                    return "במדבר אור החיים";
                case "001_TORA\\04_BAMIDBAR\\g_EbenEzra.txt":
                    return "במדבר - אבן עזרא";
                case "001_TORA\\04_BAMIDBAR\\h_BaalHaturim.txt":
                    return "במדבר - בעל הטורים";
                case "001_TORA\\04_BAMIDBAR\\i_onqelus.txt":
                    return "במדבר - תרגום אונקלוס";
                case "001_TORA\\04_BAMIDBAR\\j_sforno.txt":
                    return "במדבר - ספורנו";
                case "001_TORA\\04_BAMIDBAR\\k_keli_yakar4.txt":
                    return "במדבר - כלי יקר";
                case "001_TORA\\04_BAMIDBAR\\m_daatzkenim4.txt":
                    return "במדבר - דעת זקנים";
                case "001_TORA\\04_BAMIDBAR\\w_raba4.txt":
                    return "מדרש רבה - חומש במדבר";
                case "001_TORA\\04_BAMIDBAR\\w_tanchuma4.txt":
                    return "מדרש תנחומא - במדבר";
                case "001_TORA\\04_BAMIDBAR\\w_ts_shimoni_bamidbar.txt":
                    return "ילקוט שמעוני - במדבר";
                case "001_TORA\\04_BAMIDBAR\\x2_Interleave.txt":
                    return "במדבר - רש''י ושפתי חכמים";
                case "001_TORA\\04_BAMIDBAR\\x_Interleave.txt":
                    return "במדבר - מקרא ותרגום";
                case "001_TORA\\04_BAMIDBAR\\x_Interleave2.txt":
                    return "במדבר - מקרא ותרגום (ט)";
                case "001_TORA\\04_BAMIDBAR\\y_hok40.txt":
                    return "חק לישראל - במדבר";
                case "001_TORA\\04_BAMIDBAR\\y_hok41.txt":
                    return "חק לישראל - במדבר  (ט)";
                case "001_TORA\\04_BAMIDBAR\\z_Interleave.txt":
                    return "במדבר";
                case "001_TORA\\04_BAMIDBAR\\z_Interleave2.txt":
                    return "במדבר (ט)";
                case "001_TORA\\05_DEVARIM\\a05__Deuteronomy.txt":
                    return "דברים";
                case "001_TORA\\05_DEVARIM\\a05_Deuteronomy.txt":
                    return "דברים - ללא טעמים";

                case "001_TORA\\05_DEVARIM\\b05_Deuteronomy.txt":
                    return "דברים - ללא ניקוד";
                case "001_TORA\\05_DEVARIM\\c_RASHI_DVARIM_L1.txt":
                    return "דברים - רש''י";
                case "001_TORA\\05_DEVARIM\\c_RASHI_DVARIM_OLD.txt":
                    return "דברים - רש''י (ב)";
                case "001_TORA\\05_DEVARIM\\c_siftei_5.txt":
                    return "דברים - שפתי חכמים";
                case "001_TORA\\05_DEVARIM\\d_ramban_dvarim.txt":
                    return "דברים - רמב''ן";
                case "001_TORA\\05_DEVARIM\\e05_Deuteronomy.txt":
                    return "דברים - תרגום יונתן";
                case "001_TORA\\05_DEVARIM\\f_OrHachaim.txt":
                    return "דברים אור החיים";
                case "001_TORA\\05_DEVARIM\\g_EbenEzra.txt":
                    return "דברים - אבן עזרא";
                case "001_TORA\\05_DEVARIM\\h_BaalHaturim.txt":
                    return "דברים - בעל הטורים";
                case "001_TORA\\05_DEVARIM\\i_onqelus.txt":
                    return "דברים - תרגום אונקלוס";
                case "001_TORA\\05_DEVARIM\\j_sforno.txt":
                    return "דברים - ספורנו";
                case "001_TORA\\05_DEVARIM\\k_keli_yakar5.txt":
                    return "דברים - כלי יקר";
                case "001_TORA\\05_DEVARIM\\m_daatzkenim5.txt":
                    return "דברים - דעת זקנים";
                case "001_TORA\\05_DEVARIM\\w_raba5.txt":
                    return "מדרש רבה - חומש דברים";
                case "001_TORA\\05_DEVARIM\\w_tanchuma5.txt":
                    return "מדרש תנחומא - דברים";
                case "001_TORA\\05_DEVARIM\\w_ts_shimoni_devarim.txt":
                    return "ילקוט שמעוני - דברים";
                case "001_TORA\\05_DEVARIM\\x2_Interleave.txt":
                    return "דברים - רש''י ושפתי חכמים";
                case "001_TORA\\05_DEVARIM\\x_Interleave.txt":
                    return "דברים - מקרא ותרגום";
                case "001_TORA\\05_DEVARIM\\x_Interleave2.txt":
                    return "דברים - מקרא ותרגום (ט)";
                case "001_TORA\\05_DEVARIM\\y_hok50.txt":
                    return "חק לישראל - דברים";
                case "001_TORA\\05_DEVARIM\\y_hok51.txt":
                    return "חק לישראל - דברים  (ט)";
                case "001_TORA\\05_DEVARIM\\z_Interleave.txt":
                    return "דברים";
                case "001_TORA\\05_DEVARIM\\z_Interleave2.txt":
                    return "דברים (ט)";
                case "002_NAVI":
                    return "יהושע";
                case "002_NAVI\\06_YEHOSUA\\a06__Joshua.txt":
                    return "יהושע";
                case "002_NAVI\\06_YEHOSUA\\a06_Joshua.txt":
                    return "יהושע - ללא טעמים";

                case "002_NAVI\\06_YEHOSUA\\b06_Joshua.txt":
                    return "יהושע - ללא ניקוד";
                case "002_NAVI\\06_YEHOSUA\\eNA_YEHOSUA_L1.txt":
                    return "יהושע - רש''י";
                case "002_NAVI\\06_YEHOSUA\\fNA_YEHOSUA_L1.txt":
                    return "יהושע - מצודת דוד";
                case "002_NAVI\\06_YEHOSUA\\gNA_YEHOSUA_L1.txt":
                    return "יהושע - מצודת ציון";
                case "002_NAVI\\06_YEHOSUA\\gNA_YEHOSUA_L1_2.txt":
                    return "יהושע - רלב''ג";
                case "002_NAVI\\06_YEHOSUA\\h_Interleave.txt":
                    return "יהושע";
                case "002_NAVI\\06_YEHOSUA\\h_Interleave2.txt":
                    return "יהושע (ט)";
                case "002_NAVI\\07_SHOFETIM":
                    return "שופטים";
                case "002_NAVI\\07_SHOFETIM\\a07__Judges.txt":
                    return "שופטים";
                case "002_NAVI\\07_SHOFETIM\\a07_Judges.txt":
                    return "שופטים - ללא טעמים";

                case "002_NAVI\\07_SHOFETIM\\b07_Judges.txt":
                    return "שופטים - ללא ניקוד";
                case "002_NAVI\\07_SHOFETIM\\eNA_SHOFTIM_L1.txt":
                    return "שופטים - רש''י";
                case "002_NAVI\\07_SHOFETIM\\fNA_SHOFTIM_L2.txt":
                    return "שופטים - מצודת דוד";
                case "002_NAVI\\07_SHOFETIM\\gNA_SHOFTIM_L1.txt":
                    return "שופטים - מצודת ציון";
                case "002_NAVI\\07_SHOFETIM\\gNA_SHOFTIM_L1_2.txt":
                    return "שופטים - רלב''ג";
                case "002_NAVI\\07_SHOFETIM\\h_Interleave.txt":
                    return "שופטים";
                case "002_NAVI\\07_SHOFETIM\\h_Interleave2.txt":
                    return "שופטים (ט)";
                case "002_NAVI\\08_SHEMUEL_A":
                    return "שמואל א";
                case "002_NAVI\\08_SHEMUEL_A\\a08_Samuel__1.txt":
                    return "שמואל א";
                case "002_NAVI\\08_SHEMUEL_A\\a08_Samuel_1.txt":
                    return "שמואל א - ללא טעמים";

                case "002_NAVI\\08_SHEMUEL_A\\b08_Samuel_1.txt":
                    return "שמואל א - ללא ניקוד";
                case "002_NAVI\\08_SHEMUEL_A\\eNA_SHMUEL_A_L1.txt":
                    return "שמואל א - רש''י";
                case "002_NAVI\\08_SHEMUEL_A\\fNA_SHMUEL_A_L1.txt":
                    return "שמואל א - מצודת דוד";
                case "002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L1.txt":
                    return "שמואל א - מצודת ציון";
                case "002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L1_2.txt":
                    return "שמואל א - רלב''ג";
                case "002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L3_MALBIM.txt":
                    return "שמואל א - מלבי''ם";
                case "002_NAVI\\08_SHEMUEL_A\\h_Interleave.txt":
                    return "שמואל א";
                case "002_NAVI\\08_SHEMUEL_A\\h_Interleave2.txt":
                    return "שמואל א (ט)";
                case "002_NAVI\\09_SHEMUEL_B":
                    return "שמואל ב";
                case "002_NAVI\\09_SHEMUEL_B\\a09_Samuel__2.txt":
                    return "שמואל ב";
                case "002_NAVI\\09_SHEMUEL_B\\a09_Samuel_2.txt":
                    return "שמואל ב - ללא טעמים";

                case "002_NAVI\\09_SHEMUEL_B\\b09_Samuel_2.txt":
                    return "שמואל ב - ללא ניקוד";
                case "002_NAVI\\09_SHEMUEL_B\\eNA_SHMUEL_B_L1.txt":
                    return "שמואל ב - רש''י";
                case "002_NAVI\\09_SHEMUEL_B\\fNA_SHMUEL_B_L1.txt":
                    return "שמואל ב - מצודת דוד";
                case "002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L1.txt":
                    return "שמואל ב - מצודת ציון";
                case "002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L1_2.txt":
                    return "שמואל ב - רלב''ג";
                case "002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L3_MALBIM.txt":
                    return "שמואל ב - מלבי''ם";
                case "002_NAVI\\09_SHEMUEL_B\\h_Interleave.txt":
                    return "שמואל ב";
                case "002_NAVI\\09_SHEMUEL_B\\h_Interleave2.txt":
                    return "שמואל ב (ט)";
                case "002_NAVI\\10_MELACIM_A":
                    return "מלכים א";
                case "002_NAVI\\10_MELACIM_A\\a10_Kings__1.txt":
                    return "מלכים א";
                case "002_NAVI\\10_MELACIM_A\\a10_Kings_1.txt":
                    return "מלכים א - ללא טעמים";

                case "002_NAVI\\10_MELACIM_A\\b10_Kings_1.txt":
                    return "מלכים א - ללא ניקוד";
                case "002_NAVI\\10_MELACIM_A\\eNA_MELACHIM_A_L1.txt":
                    return "מלכים א - רש''י";
                case "002_NAVI\\10_MELACIM_A\\fNA_MELACHIM_A_L1.txt":
                    return "מלכים א - מצודת דוד";
                case "002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1.txt":
                    return "מלכים א - מצודת ציון";
                case "002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1_2.txt":
                    return "מלכים א - רלב''ג";
                case "002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1_MALBIM.txt":
                    return "מלכים א - מלבי''ם";
                case "002_NAVI\\10_MELACIM_A\\h_Interleave.txt":
                    return "מלכים א";
                case "002_NAVI\\10_MELACIM_A\\h_Interleave2.txt":
                    return "מלכים א (ט)";
                case "002_NAVI\\11_MELACIM_B":
                    return "מלכים ב";
                case "002_NAVI\\11_MELACIM_B\\a11_Kings__2.txt":
                    return "מלכים ב";
                case "002_NAVI\\11_MELACIM_B\\a11_Kings_2.txt":
                    return "מלכים ב - ללא טעמים";

                case "002_NAVI\\11_MELACIM_B\\b11_Kings_2.txt":
                    return "מלכים ב - ללא ניקוד";
                case "002_NAVI\\11_MELACIM_B\\eNA_MELACHIM_B_L1.txt":
                    return "מלכים ב - רש''י";
                case "002_NAVI\\11_MELACIM_B\\fNA_MELACHIM_B_L1.txt":
                    return "מלכים ב - מצודת דוד";
                case "002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1.txt":
                    return "מלכים ב - מצודת ציון";
                case "002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1_2.txt":
                    return "מלכים ב - רלב''ג";
                case "002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1_MALBIM.txt":
                    return "מלכים ב - מלבי''ם";
                case "002_NAVI\\11_MELACIM_B\\h_Interleave.txt":
                    return "מלכים ב";
                case "002_NAVI\\11_MELACIM_B\\h_Interleave2.txt":
                    return "מלכים ב (ט)";
                case "002_NAVI\\12_YISHAYA":
                    return "ישעיה";
                case "002_NAVI\\12_YISHAYA\\a12__Isaiah.txt":
                    return "ישעיה";
                case "002_NAVI\\12_YISHAYA\\a12_Isaiah.txt":
                    return "ישעיה - ללא טעמים";

                case "002_NAVI\\12_YISHAYA\\b12_Isaiah.txt":
                    return "ישעיה - ללא ניקוד";
                case "002_NAVI\\12_YISHAYA\\eNA_YISHAYA_L1.txt":
                    return "ישעיה - רש''י";
                case "002_NAVI\\12_YISHAYA\\fNA_YISHAYA_L1.txt":
                    return "ישעיה - מצודת דוד";
                case "002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L1.txt":
                    return "ישעיה - מצודת ציון";
                case "002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L1_MALBIM.txt":
                    return "ישעיה - מלבי''ם - ב. הענין";
                case "002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L2_MALBIM.txt":
                    return "ישעיה - מלבי''ם - ב. המילת";
                case "002_NAVI\\12_YISHAYA\\h_Interleave.txt":
                    return "ישעיה";
                case "002_NAVI\\12_YISHAYA\\h_Interleave2.txt":
                    return "ישעיה (ט)";
                case "002_NAVI\\13_YERMIYA":
                    return "ירמיה";
                case "002_NAVI\\13_YERMIYA\\a13__Jeremiah.txt":
                    return "ירמיה";
                case "002_NAVI\\13_YERMIYA\\a13_Jeremiah.txt":
                    return "ירמיה - ללא טעמים";

                case "002_NAVI\\13_YERMIYA\\b13_Jeremiah.txt":
                    return "ירמיה - ללא ניקוד";
                case "002_NAVI\\13_YERMIYA\\eNA_YERMIYA_L1.txt":
                    return "ירמיה - רש''י";
                case "002_NAVI\\13_YERMIYA\\fNA_YERMIYA_L1.txt":
                    return "ירמיה - מצודת דוד";
                case "002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L1.txt":
                    return "ירמיה - מצודת ציון";
                case "002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L1_MALBIM.txt":
                    return "ירמיה- מלבי''ם - ב. הענין";
                case "002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L2_MALBIM.txt":
                    return "ירמיה - מלבי''ם - ב. המילת";
                case "002_NAVI\\13_YERMIYA\\h_Interleave.txt":
                    return "ירמיה";
                case "002_NAVI\\13_YERMIYA\\h_Interleave2.txt":
                    return "ירמיה (ט)";
                case "002_NAVI\\14_YEHEZKEL":
                    return "יחזקאל";
                case "002_NAVI\\14_YEHEZKEL\\a14__Ezekiel.txt":
                    return "יחזקאל";
                case "002_NAVI\\14_YEHEZKEL\\a14_Ezekiel.txt":
                    return "יחזקאל - ללא טעמים";

                case "002_NAVI\\14_YEHEZKEL\\b14_Ezekiel.txt":
                    return "יחזקאל - ללא ניקוד";
                case "002_NAVI\\14_YEHEZKEL\\eNA_YEHEZKEL_L1.txt":
                    return "יחזקאל - רש''י";
                case "002_NAVI\\14_YEHEZKEL\\fNA_YEHEZKEL_L1.txt":
                    return "יחזקאל - מצודת דוד";
                case "002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L1.txt":
                    return "יחזקאל - מצודת ציון";
                case "002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L1_MALBIM.txt":
                    return "יחזקאל - מלבי''ם - ב. הענין";
                case "002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L2_MALBIM.txt":
                    return "[2] יחזקאל - מלבי''ם - ב. הענין";
                case "002_NAVI\\14_YEHEZKEL\\h_Interleave.txt":
                    return "יחזקאל";
                case "002_NAVI\\14_YEHEZKEL\\h_Interleave2.txt":
                    return "יחזקאל (ט)";
                case "002_NAVI\\15_HOSEA":
                    return "הושע";
                case "002_NAVI\\15_HOSEA\\a15__Hosea.txt":
                    return "הושע";
                case "002_NAVI\\15_HOSEA\\a15_Hosea.txt":
                    return "הושע - ללא טעמים";

                case "002_NAVI\\15_HOSEA\\b15_Hosea.txt":
                    return "הושע - ללא ניקוד";
                case "002_NAVI\\15_HOSEA\\eNA_HOSEA_L1.txt":
                    return "הושע - רש''י";
                case "002_NAVI\\15_HOSEA\\fNA_HOSEA_L1.txt":
                    return "הושע - מצודת דוד";
                case "002_NAVI\\15_HOSEA\\gNA_HOSEA_L1.txt":
                    return "הושע - מצודת ציון";
                case "002_NAVI\\15_HOSEA\\h_Interleave.txt":
                    return "הושע";
                case "002_NAVI\\15_HOSEA\\h_Interleave2.txt":
                    return "הושע (ט)";
                case "002_NAVI\\16_YOEL":
                    return "יואל";
                case "002_NAVI\\16_YOEL\\a16__Joel.txt":
                    return "יואל";
                case "002_NAVI\\16_YOEL\\a16_Joel.txt":
                    return "יואל - ללא טעמים";

                case "002_NAVI\\16_YOEL\\b16_Joel.txt":
                    return "יואל - ללא ניקוד";
                case "002_NAVI\\16_YOEL\\eNA_YOEL_L1.txt":
                    return "יואל - רש''י";
                case "002_NAVI\\16_YOEL\\fNA_YOEL_L1.txt":
                    return "יואל - מצודת דוד";
                case "002_NAVI\\16_YOEL\\gNA_YOEL_L1.txt":
                    return "יואל - מצודת ציון";
                case "002_NAVI\\16_YOEL\\h_Interleave.txt":
                    return "יואל";
                case "002_NAVI\\16_YOEL\\h_Interleave2.txt":
                    return "יואל (ט)";
                case "002_NAVI\\17_AMOS":
                    return "עמוס";
                case "002_NAVI\\17_AMOS\\a17__Amos.txt":
                    return "עמוס";
                case "002_NAVI\\17_AMOS\\a17_Amos.txt":
                    return "עמוס - ללא טעמים";

                case "002_NAVI\\17_AMOS\\b17_Amos.txt":
                    return "עמוס - ללא ניקוד";
                case "002_NAVI\\17_AMOS\\eNA_AMOS_L1.txt":
                    return "עמוס - רש''י";
                case "002_NAVI\\17_AMOS\\fNA_AMOS_L2.txt":
                    return "עמוס - מצודת דוד";
                case "002_NAVI\\17_AMOS\\gNA_AMOS_L1.txt":
                    return "עמוס - מצודת ציון";
                case "002_NAVI\\17_AMOS\\h_Interleave.txt":
                    return "עמוס";
                case "002_NAVI\\17_AMOS\\h_Interleave2.txt":
                    return "עמוס (ט)";
                case "002_NAVI\\18_OVADYA":
                    return "עובדיה";
                case "002_NAVI\\18_OVADYA\\a18__Obadiah.txt":
                    return "עובדיה";
                case "002_NAVI\\18_OVADYA\\a18_Obadiah.txt":
                    return "עובדיה - ללא טעמים";

                case "002_NAVI\\18_OVADYA\\b18_Obadiah.txt":
                    return "עובדיה - ללא ניקוד";
                case "002_NAVI\\18_OVADYA\\eNA_OVADYA_L1.txt":
                    return "עובדיה - רש''י";
                case "002_NAVI\\18_OVADYA\\fNA_OVADYA_L1.txt":
                    return "עובדיה - מצודת דוד";
                case "002_NAVI\\18_OVADYA\\gNA_OVADYA_L1.txt":
                    return "עובדיה - מצודת ציון";
                case "002_NAVI\\18_OVADYA\\h_Interleave.txt":
                    return "עובדיה";
                case "002_NAVI\\18_OVADYA\\h_Interleave2.txt":
                    return "עובדיה (ט)";
                case "002_NAVI\\19_YONA":
                    return "יונה";
                case "002_NAVI\\19_YONA\\a19__Jonah.txt":
                    return "יונה";
                case "002_NAVI\\19_YONA\\a19_Jonah.txt":
                    return "יונה - ללא טעמים";

                case "002_NAVI\\19_YONA\\b19_Jonah.txt":
                    return "יונה - ללא ניקוד";
                case "002_NAVI\\19_YONA\\eNA_YONA_L1.txt":
                    return "יונה - רש''י";
                case "002_NAVI\\19_YONA\\fNA_YONA_L1.txt":
                    return "יונה - מצודת דוד";
                case "002_NAVI\\19_YONA\\gNA_YONA_L1.txt":
                    return "יונה - מצודת ציון";
                case "002_NAVI\\19_YONA\\h_Interleave.txt":
                    return "יונה";
                case "002_NAVI\\19_YONA\\h_Interleave2.txt":
                    return "יונה (ט)";
                case "002_NAVI\\20_MICHA":
                    return "מיכה";
                case "002_NAVI\\20_MICHA\\a20__Micah.txt":
                    return "מיכה";
                case "002_NAVI\\20_MICHA\\a20_Micah.txt":
                    return "מיכה - ללא טעמים";

                case "002_NAVI\\20_MICHA\\b20_Micah.txt":
                    return "מיכה - ללא ניקוד";
                case "002_NAVI\\20_MICHA\\eNA_MICHA_L1.txt":
                    return "מיכה - רש''י";
                case "002_NAVI\\20_MICHA\\fNA_MICHA_L1.txt":
                    return "מיכה - מצודת דוד";
                case "002_NAVI\\20_MICHA\\gNA_MICHA_L1.txt":
                    return "מיכה - מצודת ציון";
                case "002_NAVI\\20_MICHA\\h_Interleave.txt":
                    return "מיכה";
                case "002_NAVI\\20_MICHA\\h_Interleave2.txt":
                    return "מיכה (ט)";
                case "002_NAVI\\21_NAHUM":
                    return "נחום";
                case "002_NAVI\\21_NAHUM\\a21__Nahum.txt":
                    return "נחום";
                case "002_NAVI\\21_NAHUM\\a21_Nahum.txt":
                    return "נחום - ללא טעמים";

                case "002_NAVI\\21_NAHUM\\b21_Nahum.txt":
                    return "נחום - ללא ניקוד";
                case "002_NAVI\\21_NAHUM\\eNA_NAHUM_L1.txt":
                    return "נחום - רש''י";
                case "002_NAVI\\21_NAHUM\\fNA_NAHUM_L1.txt":
                    return "נחום - מצודת דוד";
                case "002_NAVI\\21_NAHUM\\gNA_NAHUM_L1.txt":
                    return "נחום - מצודת ציון";
                case "002_NAVI\\21_NAHUM\\h_Interleave.txt":
                    return "נחום";
                case "002_NAVI\\21_NAHUM\\h_Interleave2.txt":
                    return "נחום (ט)";
                case "002_NAVI\\22_HAVAKUK":
                    return "חבקוק";
                case "002_NAVI\\22_HAVAKUK\\a22__Habakkuk.txt":
                    return "חבקוק";
                case "002_NAVI\\22_HAVAKUK\\a22_Habakkuk.txt":
                    return "חבקוק - ללא טעמים";

                case "002_NAVI\\22_HAVAKUK\\b22_Habakkuk.txt":
                    return "חבקוק - ללא ניקוד";
                case "002_NAVI\\22_HAVAKUK\\eNA_HAVAKUK_L1.txt":
                    return "חבקוק - רש''י";
                case "002_NAVI\\22_HAVAKUK\\fNA_HAVAKUK_L1.txt":
                    return "חבקוק - מצודת דוד";
                case "002_NAVI\\22_HAVAKUK\\gNA_HAVAKUK_L1.txt":
                    return "חבקוק - מצודת ציון";
                case "002_NAVI\\22_HAVAKUK\\h_Interleave.txt":
                    return "חבקוק";
                case "002_NAVI\\22_HAVAKUK\\h_Interleave2.txt":
                    return "חבקוק (ט)";
                case "002_NAVI\\23_ZFANYA":
                    return "צפניה";
                case "002_NAVI\\23_ZFANYA\\a23__Zephaniah.txt":
                    return "צפניה";
                case "002_NAVI\\23_ZFANYA\\a23_Zephaniah.txt":
                    return "צפניה - ללא טעמים";

                case "002_NAVI\\23_ZFANYA\\b23_Zephaniah.txt":
                    return "צפניה - ללא ניקוד";
                case "002_NAVI\\23_ZFANYA\\eNA_ZFANYA_L1.txt":
                    return "צפניה - רש''י";
                case "002_NAVI\\23_ZFANYA\\fNA_ZFANYA_L1.txt":
                    return "צפניה - מצודת דוד";
                case "002_NAVI\\23_ZFANYA\\gNA_ZFANYA_L1.txt":
                    return "צפניה - מצודת ציון";
                case "002_NAVI\\23_ZFANYA\\h_Interleave.txt":
                    return "צפניה";
                case "002_NAVI\\23_ZFANYA\\h_Interleave2.txt":
                    return "צפניה (ט)";
                case "002_NAVI\\24_HAGAY":
                    return "חגי";
                case "002_NAVI\\24_HAGAY\\a24__Haggai.txt":
                    return "חגי";
                case "002_NAVI\\24_HAGAY\\a24_Haggai.txt":
                    return "חגי - ללא טעמים";

                case "002_NAVI\\24_HAGAY\\b24_Haggai.txt":
                    return "חגי - ללא ניקוד";
                case "002_NAVI\\24_HAGAY\\eNA_HAGAY_L1.txt":
                    return "חגי - רש''י";
                case "002_NAVI\\24_HAGAY\\fNA_HAGAY_L1.txt":
                    return "חגי - מצודת דוד";
                case "002_NAVI\\24_HAGAY\\gNA_HAGAY_L1.txt":
                    return "חגי - מצודת ציון";
                case "002_NAVI\\24_HAGAY\\h_Interleave.txt":
                    return "חגי";
                case "002_NAVI\\24_HAGAY\\h_Interleave2.txt":
                    return "חגי (ט)";
                case "002_NAVI\\25_ZECHARYA":
                    return "זכריה";
                case "002_NAVI\\25_ZECHARYA\\a25__Zechariah.txt":
                    return "זכריה";
                case "002_NAVI\\25_ZECHARYA\\a25_Zechariah.txt":
                    return "זכריה - ללא טעמים";

                case "002_NAVI\\25_ZECHARYA\\b25_Zechariah.txt":
                    return "זכריה - ללא ניקוד";
                case "002_NAVI\\25_ZECHARYA\\eNA_ZECHARYA_L1.txt":
                    return "זכריה - רש''י";
                case "002_NAVI\\25_ZECHARYA\\fNA_ZECHARYA_L1.txt":
                    return "זכריה - מצודת דוד";
                case "002_NAVI\\25_ZECHARYA\\gNA_ZECHARYA_L1.txt":
                    return "זכריה - מצודת ציון";
                case "002_NAVI\\25_ZECHARYA\\h_Interleave.txt":
                    return "זכריה";
                case "002_NAVI\\25_ZECHARYA\\h_Interleave2.txt":
                    return "זכריה (ט)";
                case "002_NAVI\\26_MALACHI":
                    return "מלאכי";
                case "002_NAVI\\26_MALACHI\\a26__Malachi.txt":
                    return "מלאכי";
                case "002_NAVI\\26_MALACHI\\a26_Malachi.txt":
                    return "מלאכי - ללא טעמים";

                case "002_NAVI\\26_MALACHI\\b26_Malachi.txt":
                    return "מלאכי - ללא ניקוד";
                case "002_NAVI\\26_MALACHI\\eNA_MALACHI_L1.txt":
                    return "מלאכי - רש''י";
                case "002_NAVI\\26_MALACHI\\fNA_MALACHI_L1.txt":
                    return "מלאכי - מצודת דוד";
                case "002_NAVI\\26_MALACHI\\gNA_MALACHI_L1.txt":
                    return "מלאכי - מצודת ציון";
                case "002_NAVI\\26_MALACHI\\h_Interleave.txt":
                    return "מלאכי";
                case "002_NAVI\\26_MALACHI\\h_Interleave2.txt":
                    return "מלאכי (ט)";
                case "003_KTUVIM":
                    return "תהילים";
                case "003_KTUVIM\\27_TEHILIM\\a27__Psalms.txt":
                    return "תהילים";
                case "003_KTUVIM\\27_TEHILIM\\a27_Psalms.txt":
                    return "תהילים - ללא טעמים";

                case "003_KTUVIM\\27_TEHILIM\\b27_Psalms.txt":
                    return "תהילים - ללא ניקוד";
                case "003_KTUVIM\\27_TEHILIM\\eNA_TEHILIM_L1.txt":
                    return "תהילים - רש''י";
                case "003_KTUVIM\\27_TEHILIM\\fNA_TEHILIM_L1.txt":
                    return "תהילים - מצודת דוד";
                case "003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L1.txt":
                    return "תהילים - מצודת ציון";
                case "003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L1_MALBIM.txt":
                    return "תהילים - מלבי''ם - ב. הענין";
                case "003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L2_MALBIM.txt":
                    return "תהילים - מלבי''ם - ב. המלות";
                case "003_KTUVIM\\27_TEHILIM\\h_Interleave.txt":
                    return "תהילים";
                case "003_KTUVIM\\27_TEHILIM\\h_Interleave2.txt":
                    return "תהילים (ט)";
                case "003_KTUVIM\\27_TEHILIM\\i_div1.txt":
                    return "תהילים - מחולק לספרים";
                case "003_KTUVIM\\27_TEHILIM\\i_div2.txt":
                    return "תהילים - מחולק לימי השבוע";
                case "003_KTUVIM\\27_TEHILIM\\i_div3.txt":
                    return "תהילים - מחולק לימי החודש";
                case "003_KTUVIM\\28_MISHLEI":
                    return "משלי";
                case "003_KTUVIM\\28_MISHLEI\\a28__Proverbs.txt":
                    return "משלי";
                case "003_KTUVIM\\28_MISHLEI\\a28_Proverbs.txt":
                    return "משלי - ללא טעמים";

                case "003_KTUVIM\\28_MISHLEI\\b28_Proverbs.txt":
                    return "משלי - ללא ניקוד";
                case "003_KTUVIM\\28_MISHLEI\\eNA_MISHLEI_L1.txt":
                    return "משלי - רש''י";
                case "003_KTUVIM\\28_MISHLEI\\fNA_MISHLEI_L1.txt":
                    return "משלי - מצודת דוד";
                case "003_KTUVIM\\28_MISHLEI\\gNA_MISHLEI_L1.txt":
                    return "משלי - מצודת ציון";
                case "003_KTUVIM\\28_MISHLEI\\gNA_MISHLEI_L1_2.txt":
                    return "משלי - רלב''ג";
                case "003_KTUVIM\\28_MISHLEI\\h_Interleave.txt":
                    return "משלי";
                case "003_KTUVIM\\28_MISHLEI\\h_Interleave2.txt":
                    return "משלי (ט)";
                case "003_KTUVIM\\29_IYOV":
                    return "איוב";
                case "003_KTUVIM\\29_IYOV\\a29__Job.txt":
                    return "איוב";
                case "003_KTUVIM\\29_IYOV\\a29_Job.txt":
                    return "איוב - ללא טעמים";

                case "003_KTUVIM\\29_IYOV\\b29_Job.txt":
                    return "איוב - ללא ניקוד";
                case "003_KTUVIM\\29_IYOV\\eNA_IYOV_L1.txt":
                    return "איוב - רש''י";
                case "003_KTUVIM\\29_IYOV\\fNA_IYOV_L1.txt":
                    return "איוב - מצודת דוד";
                case "003_KTUVIM\\29_IYOV\\gNA_IYOV_L1.txt":
                    return "איוב - מצודת ציון";
                case "003_KTUVIM\\29_IYOV\\gNA_IYOV_L1_2.txt":
                    return "איוב - רלב''ג";
                case "003_KTUVIM\\29_IYOV\\h_Interleave.txt":
                    return "איוב";
                case "003_KTUVIM\\29_IYOV\\h_Interleave2.txt":
                    return "איוב (ט)";
                case "003_KTUVIM\\30_SHIR_HASHIRIM":
                    return "שיר השירים";
                case "003_KTUVIM\\30_SHIR_HASHIRIM\\a30_Song_of__Songs.txt":
                    return "שיר השירים";
                case "003_KTUVIM\\30_SHIR_HASHIRIM\\a30_Song_of_Songs.txt":
                    return "שיר השירים - ללא טעמים";

                case "003_KTUVIM\\30_SHIR_HASHIRIM\\b30_Song_of_Songs.txt":
                    return "שיר השירים - ללא ניקוד";
                case "003_KTUVIM\\30_SHIR_HASHIRIM\\eNA_SHIR_HASHIRIM_L1.txt":
                    return "שיר השירים - רש''י";
                case "003_KTUVIM\\30_SHIR_HASHIRIM\\fNA_SHIR_HASHIRIM_L1.txt":
                    return "שיר השירים - מצודת דוד";
                case "003_KTUVIM\\30_SHIR_HASHIRIM\\gNA_SHIR_HASHIRIM_L1.txt":
                    return "שיר השירים - מצודת ציון";
                case "003_KTUVIM\\30_SHIR_HASHIRIM\\x_raba.txt":
                    return "מדרש רבה - שיר השירים רבה";
                case "003_KTUVIM\\30_SHIR_HASHIRIM\\z_Interleave.txt":
                    return "שיר השירים";
                case "003_KTUVIM\\30_SHIR_HASHIRIM\\z_Interleave2.txt":
                    return "שיר השירים (ט)";
                case "003_KTUVIM\\31_RUTH":
                    return "רות";
                case "003_KTUVIM\\31_RUTH\\a31__Ruth.txt":
                    return "רות";
                case "003_KTUVIM\\31_RUTH\\a31_Ruth.txt":
                    return "רות - ללא טעמים";

                case "003_KTUVIM\\31_RUTH\\b31_Ruth.txt":
                    return "רות - ללא ניקוד";
                case "003_KTUVIM\\31_RUTH\\eNA_RUTH_L1.txt":
                    return "רות - רש''י";
                case "003_KTUVIM\\31_RUTH\\x_raba.txt":
                    return "מדרש רבה - רות רבה";
                case "003_KTUVIM\\31_RUTH\\z_Interleave.txt":
                    return "רות";
                case "003_KTUVIM\\31_RUTH\\z_Interleave2.txt":
                    return "רות (ט)";
                case "003_KTUVIM\\32_EICHA":
                    return "איכה";
                case "003_KTUVIM\\32_EICHA\\a32__Lamentations.txt":
                    return "איכה";
                case "003_KTUVIM\\32_EICHA\\a32_Lamentations.txt":
                    return "איכה - ללא טעמים";

                case "003_KTUVIM\\32_EICHA\\b32_Lamentations.txt":
                    return "איכה - ללא ניקוד";
                case "003_KTUVIM\\32_EICHA\\eNA_EICHA_L1.txt":
                    return "איכה - רש''י";
                case "003_KTUVIM\\32_EICHA\\x_raba.txt":
                    return "מדרש רבה - איכה רבתי";
                case "003_KTUVIM\\32_EICHA\\z_Interleave.txt":
                    return "איכה";
                case "003_KTUVIM\\32_EICHA\\z_Interleave2.txt":
                    return "איכה (ט)";
                case "003_KTUVIM\\33_KOHELET":
                    return "קהלת";
                case "003_KTUVIM\\33_KOHELET\\a33__Ecclesiastes.txt":
                    return "קהלת";
                case "003_KTUVIM\\33_KOHELET\\a33_Ecclesiastes.txt":
                    return "קהלת - ללא טעמים";

                case "003_KTUVIM\\33_KOHELET\\b33_Ecclesiastes.txt":
                    return "קהלת - ללא ניקוד";
                case "003_KTUVIM\\33_KOHELET\\eNA_KOHELET_L1.txt":
                    return "קהלת - רש''י";
                case "003_KTUVIM\\33_KOHELET\\fNA_KOHELET_L1.txt":
                    return "קהלת - מצודת דוד";
                case "003_KTUVIM\\33_KOHELET\\gNA_KOHELET_L1.txt":
                    return "קהלת - מצודת ציון";
                case "003_KTUVIM\\33_KOHELET\\x_raba.txt":
                    return "מדרש רבה - קהלת רבה";
                case "003_KTUVIM\\33_KOHELET\\z_Interleave.txt":
                    return "קהלת";
                case "003_KTUVIM\\33_KOHELET\\z_Interleave2.txt":
                    return "קהלת (ט)";
                case "003_KTUVIM\\34_ESTER":
                    return "אסתר";
                case "003_KTUVIM\\34_ESTER\\a34__Esther.txt":
                    return "אסתר";
                case "003_KTUVIM\\34_ESTER\\a34_Esther.txt":
                    return "אסתר - ללא טעמים";

                case "003_KTUVIM\\34_ESTER\\b34_Esther.txt":
                    return "אסתר - ללא ניקוד";
                case "003_KTUVIM\\34_ESTER\\eNA_ESTER_L1.txt":
                    return "אסתר - רש''י";
                case "003_KTUVIM\\34_ESTER\\f_MALBIM_ESTER.txt":
                    return "אסתר - מלבי''ם";
                case "003_KTUVIM\\34_ESTER\\x_raba.txt":
                    return "מדרש רבה - אסתר רבה";
                case "003_KTUVIM\\34_ESTER\\z_Interleave.txt":
                    return "אסתר";
                case "003_KTUVIM\\34_ESTER\\z_Interleave2.txt":
                    return "אסתר (ט)";
                case "003_KTUVIM\\35_DANIEL":
                    return "דניאל";
                case "003_KTUVIM\\35_DANIEL\\a35__Daniel.txt":
                    return "דניאל";
                case "003_KTUVIM\\35_DANIEL\\a35_Daniel.txt":
                    return "דניאל - ללא טעמים";

                case "003_KTUVIM\\35_DANIEL\\b35_Daniel.txt":
                    return "דניאל - ללא ניקוד";
                case "003_KTUVIM\\35_DANIEL\\eNA_DANIEL_L1.txt":
                    return "דניאל - רש''י";
                case "003_KTUVIM\\35_DANIEL\\fNA_DANIEL_L1.txt":
                    return "דניאל - מצודת דוד";
                case "003_KTUVIM\\35_DANIEL\\gNA_DANIEL_L1.txt":
                    return "דניאל - מצודת ציון";
                case "003_KTUVIM\\35_DANIEL\\h_Interleave.txt":
                    return "דניאל";
                case "003_KTUVIM\\35_DANIEL\\h_Interleave2.txt":
                    return "דניאל (ט)";
                case "003_KTUVIM\\36_EZRA":
                    return "עזרא";
                case "003_KTUVIM\\36_EZRA\\a36__Ezra.txt":
                    return "עזרא";
                case "003_KTUVIM\\36_EZRA\\a36_Ezra.txt":
                    return "עזרא - ללא טעמים";

                case "003_KTUVIM\\36_EZRA\\b36_Ezra.txt":
                    return "עזרא - ללא ניקוד";
                case "003_KTUVIM\\36_EZRA\\eNA_EZRA_L1.txt":
                    return "עזרא - רש''י";
                case "003_KTUVIM\\36_EZRA\\fNA_EZRA_L1.txt":
                    return "עזרא - מצודת דוד";
                case "003_KTUVIM\\36_EZRA\\gNA_EZRA_L1.txt":
                    return "עזרא - מצודת ציון";
                case "003_KTUVIM\\36_EZRA\\gNA_EZRA_L1_2.txt":
                    return "עזרא - רלב''ג";
                case "003_KTUVIM\\36_EZRA\\h_Interleave.txt":
                    return "עזרא";
                case "003_KTUVIM\\36_EZRA\\h_Interleave2.txt":
                    return "עזרא (ט)";
                case "003_KTUVIM\\37_NECHEMYA":
                    return "נחמיה";
                case "003_KTUVIM\\37_NECHEMYA\\a37__Nehemiah.txt":
                    return "נחמיה";
                case "003_KTUVIM\\37_NECHEMYA\\a37_Nehemiah.txt":
                    return "נחמיה - ללא טעמים";

                case "003_KTUVIM\\37_NECHEMYA\\b37_Nehemiah.txt":
                    return "נחמיה - ללא ניקוד";
                case "003_KTUVIM\\37_NECHEMYA\\eNA_NECHEMYA_L1.txt":
                    return "נחמיה - רש''י";
                case "003_KTUVIM\\37_NECHEMYA\\fNA_NECHEMYA_L1.txt":
                    return "נחמיה - מצודת דוד";
                case "003_KTUVIM\\37_NECHEMYA\\gNA_NECHEMYA_L1.txt":
                    return "נחמיה - מצודת ציון";
                case "003_KTUVIM\\37_NECHEMYA\\gNA_NECHEMYA_L1_2.txt":
                    return "נחמיה - רלב''ג";
                case "003_KTUVIM\\37_NECHEMYA\\h_Interleave.txt":
                    return "נחמיה";
                case "003_KTUVIM\\37_NECHEMYA\\h_Interleave2.txt":
                    return "נחמיה (ט)";
                case "003_KTUVIM\\38_DIVRE_A":
                    return "דברי הימים א";
                case "003_KTUVIM\\38_DIVRE_A\\a38_Chronicles__1.txt":
                    return "דברי הימים א";
                case "003_KTUVIM\\38_DIVRE_A\\a38_Chronicles_1.txt":
                    return "דברי הימים א - ללא טעמים";

                case "003_KTUVIM\\38_DIVRE_A\\b38_Chronicles_1.txt":
                    return "דברי הימים א - ללא ניקוד";
                case "003_KTUVIM\\38_DIVRE_A\\eNA_DIVRE_A_L1.txt":
                    return "דברי הימים א - רש''י";
                case "003_KTUVIM\\38_DIVRE_A\\fNA_DIVRE_A_L1.txt":
                    return "דברי הימים א - מצודת דוד";
                case "003_KTUVIM\\38_DIVRE_A\\gNA_DIVRE_A_L1.txt":
                    return "דברי הימים א - מצודת ציון";
                case "003_KTUVIM\\38_DIVRE_A\\gNA_DIVRE_A_L1_2.txt":
                    return "דברי הימים א - רלב''ג";
                case "003_KTUVIM\\38_DIVRE_A\\h_Interleave.txt":
                    return "דברי הימים א";
                case "003_KTUVIM\\38_DIVRE_A\\h_Interleave2.txt":
                    return "דברי הימים א (ט)";
                case "003_KTUVIM\\39_DIVRE_B":
                    return "דברי הימים ב";
                case "003_KTUVIM\\39_DIVRE_B\\a39_Chronicles__2.txt":
                    return "דברי הימים ב";
                case "003_KTUVIM\\39_DIVRE_B\\a39_Chronicles_2.txt":
                    return "דברי הימים ב - ללא טעמים";

                case "003_KTUVIM\\39_DIVRE_B\\b39_Chronicles_2.txt":
                    return "דברי הימים ב - ללא ניקוד";
                case "003_KTUVIM\\39_DIVRE_B\\eNA_DIVRE_B_L1.txt":
                    return "דברי הימים ב - רש''י";
                case "003_KTUVIM\\39_DIVRE_B\\fNA_DIVRE_B_L1.txt":
                    return "דברי הימים ב - מצודת דוד";
                case "003_KTUVIM\\39_DIVRE_B\\gNA_DIVRE_B_L1.txt":
                    return "דברי הימים ב - מצודת ציון";
                case "003_KTUVIM\\39_DIVRE_B\\gNA_DIVRE_B_L1_2.txt":
                    return "דברי הימים ב - רלב''ג";
                case "003_KTUVIM\\39_DIVRE_B\\h_Interleave.txt":
                    return "דברי הימים ב";
                case "003_KTUVIM\\39_DIVRE_B\\h_Interleave2.txt":
                    return "דברי הימים ב (ט)";
                case "020_MISHNA":
                    return "משנה - ברכות";
                case "020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L2.txt":
                    return "משנה - ברכות - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L1.txt":
                    return "משנה - ברכות";

                case "020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L3.txt":
                    return "משנה - ברכות - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L5.txt":
                    return "משנה - ברכות - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\ZDebugMix.txt":
                    return "משנה מסכת ברכות";
                case "020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA":
                    return "משנה - פאה";
                case "020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L2.txt":
                    return "משנה - פאה - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L1.txt":
                    return "משנה - פאה";

                case "020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L3.txt":
                    return "משנה - פאה - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L5.txt":
                    return "משנה - פאה - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\ZDebugMix.txt":
                    return "משנה מסכת פאה";
                case "020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI":
                    return "משנה - דמאי";
                case "020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L2.txt":
                    return "משנה - דמאי - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L1.txt":
                    return "משנה - דמאי";

                case "020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L3.txt":
                    return "משנה - דמאי - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L5.txt":
                    return "משנה - דמאי - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\ZDebugMix.txt":
                    return "משנה מסכת דמאי";
                case "020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM":
                    return "משנה - כלאים";
                case "020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L2.txt":
                    return "משנה - כלאים - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L1.txt":
                    return "משנה - כלאים";

                case "020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L3.txt":
                    return "משנה - כלאים - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L5.txt":
                    return "משנה - כלאים - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\ZDebugMix.txt":
                    return "משנה מסכת כלאים";
                case "020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT":
                    return "משנה - שביעית";
                case "020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L2.txt":
                    return "משנה - שביעית - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L1.txt":
                    return "משנה - שביעית";

                case "020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L3.txt":
                    return "משנה - שביעית - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L5.txt":
                    return "משנה - שביעית - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\ZDebugMix.txt":
                    return "משנה מסכת שביעית";
                case "020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT":
                    return "משנה - תרומות";
                case "020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L2.txt":
                    return "משנה - תרומות - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L1.txt":
                    return "משנה - תרומות";

                case "020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L3.txt":
                    return "משנה - תרומות - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L5.txt":
                    return "משנה - תרומות - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\ZDebugMix.txt":
                    return "משנה מסכת תרומות";
                case "020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT":
                    return "משנה - מעשרות";
                case "020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L2.txt":
                    return "משנה - מעשרות - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L1.txt":
                    return "משנה - מעשרות";

                case "020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L3.txt":
                    return "משנה - מעשרות - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L5.txt":
                    return "משנה - מעשרות - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\ZDebugMix.txt":
                    return "משנה מסכת מעשרות";
                case "020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI":
                    return "משנה - מעשר שני";
                case "020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L2.txt":
                    return "משנה - מעשר שני - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L1.txt":
                    return "משנה - מעשר שני";

                case "020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L3.txt":
                    return "משנה - מעשר שני - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L5.txt":
                    return "משנה - מעשר שני - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\ZDebugMix.txt":
                    return "משנה מסכת מעשר שני";
                case "020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA":
                    return "משנה - חלה";
                case "020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L2.txt":
                    return "משנה - חלה - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L1.txt":
                    return "משנה - חלה";

                case "020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L3.txt":
                    return "משנה - חלה - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L5.txt":
                    return "משנה - חלה - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\ZDebugMix.txt":
                    return "משנה מסכת חלה";
                case "020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA":
                    return "משנה - ערלה";
                case "020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L2.txt":
                    return "משנה - ערלה - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L1.txt":
                    return "משנה - ערלה";

                case "020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L3.txt":
                    return "משנה - ערלה - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L5.txt":
                    return "משנה - ערלה - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\ZDebugMix.txt":
                    return "משנה מסכת ערלה";
                case "020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM":
                    return "משנה - ביכורים";
                case "020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L2.txt":
                    return "משנה - ביכורים - רע''ב";
                case "020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L1.txt":
                    return "משנה - ביכורים";

                case "020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L3.txt":
                    return "משנה - ביכורים - עיקר תוי''ט";
                case "020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L5.txt":
                    return "משנה - ביכורים - רמב''ם";
                case "020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\ZDebugMix.txt":
                    return "משנה מסכת ביכורים";
                case "020_MISHNA\\101_SEDER_MOED":
                    return "משנה - שבת";
                case "020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L2.txt":
                    return "משנה - שבת - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L1.txt":
                    return "משנה - שבת";

                case "020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L3.txt":
                    return "משנה - שבת - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L5.txt":
                    return "משנה - שבת - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\ZDebugMix.txt":
                    return "משנה מסכת שבת";
                case "020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN":
                    return "משנה - עירובין";
                case "020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L2.txt":
                    return "משנה - עירובין - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L1.txt":
                    return "משנה - עירובין";

                case "020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L3.txt":
                    return "משנה - עירובין - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L5.txt":
                    return "משנה - עירובין - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\ZDebugMix.txt":
                    return "משנה מסכת עירובין";
                case "020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM":
                    return "משנה - פסחים";
                case "020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L2.txt":
                    return "משנה - פסחים - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L1.txt":
                    return "משנה - פסחים";

                case "020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L3.txt":
                    return "משנה - פסחים - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L5.txt":
                    return "משנה - פסחים - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\ZDebugMix.txt":
                    return "משנה מסכת פסחים";
                case "020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM":
                    return "משנה - שקלים";
                case "020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L2.txt":
                    return "משנה - שקלים - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L1.txt":
                    return "משנה - שקלים";

                case "020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L3.txt":
                    return "משנה - שקלים - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\ZDebugMix.txt":
                    return "משנה מסכת שקלים";
                case "020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA":
                    return "משנה - יומא";
                case "020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L2.txt":
                    return "משנה - יומא - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L1.txt":
                    return "משנה - יומא";

                case "020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L3.txt":
                    return "משנה - יומא - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L5.txt":
                    return "משנה - יומא - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\ZDebugMix.txt":
                    return "משנה מסכת יומא";
                case "020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA":
                    return "משנה - סוכה";
                case "020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L2.txt":
                    return "משנה - סוכה - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L1.txt":
                    return "משנה - סוכה";

                case "020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L3.txt":
                    return "משנה - סוכה - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L5.txt":
                    return "משנה - סוכה - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\ZDebugMix.txt":
                    return "משנה מסכת סוכה";
                case "020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA":
                    return "משנה - ביצה";
                case "020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L2.txt":
                    return "משנה - ביצה - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L1.txt":
                    return "משנה - ביצה";

                case "020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L3.txt":
                    return "משנה - ביצה - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L5.txt":
                    return "משנה - ביצה - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\ZDebugMix.txt":
                    return "משנה מסכת ביצה";
                case "020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH":
                    return "משנה - ראש השנה";
                case "020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L2.txt":
                    return "משנה - ראש השנה - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L1.txt":
                    return "משנה - ראש השנה";

                case "020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L3.txt":
                    return "משנה - ראש השנה - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L5.txt":
                    return "משנה - ראש_השנה - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\ZDebugMix.txt":
                    return "משנה מסכת ראש השנה";
                case "020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT":
                    return "משנה - תענית";
                case "020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L2.txt":
                    return "משנה - תענית - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L1.txt":
                    return "משנה - תענית";

                case "020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L3.txt":
                    return "משנה - תענית - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L5.txt":
                    return "משנה - תענית - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\ZDebugMix.txt":
                    return "משנה מסכת תענית";
                case "020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA":
                    return "משנה - מגילה";
                case "020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L2.txt":
                    return "משנה - מגילה - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L1.txt":
                    return "משנה - מגילה";

                case "020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L3.txt":
                    return "משנה - מגילה - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L5.txt":
                    return "משנה - מגילה - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\ZDebugMix.txt":
                    return "משנה מסכת מגילה";
                case "020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN":
                    return "משנה - מועד קטן";
                case "020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L2.txt":
                    return "משנה - מועד קטן - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L1.txt":
                    return "משנה - מועד קטן";

                case "020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L3.txt":
                    return "משנה - מועד קטן - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L5.txt":
                    return "משנה - מועד_קטן - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\ZDebugMix.txt":
                    return "משנה מסכת מועד קטן";
                case "020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA":
                    return "משנה - חגיגה";
                case "020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L2.txt":
                    return "משנה - חגיגה - רע''ב";
                case "020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L1.txt":
                    return "משנה - חגיגה";

                case "020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L3.txt":
                    return "משנה - חגיגה - עיקר תוי''ט";
                case "020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L5.txt":
                    return "משנה - חגיגה - רמב''ם";
                case "020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\ZDebugMix.txt":
                    return "משנה מסכת חגיגה";
                case "020_MISHNA\\102_SEDER_NASHIM":
                    return "משנה - יבמות";
                case "020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L2.txt":
                    return "משנה - יבמות - רע''ב";
                case "020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L1.txt":
                    return "משנה - יבמות";

                case "020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L3.txt":
                    return "משנה - יבמות - עיקר תוי''ט";
                case "020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L5.txt":
                    return "משנה - יבמות - רמב''ם";
                case "020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\ZDebugMix.txt":
                    return "משנה מסכת יבמות";
                case "020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT":
                    return "משנה - כתובות";
                case "020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L2.txt":
                    return "משנה - כתובות - רע''ב";
                case "020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L1.txt":
                    return "משנה - כתובות";

                case "020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L3.txt":
                    return "משנה - כתובות - עיקר תוי''ט";
                case "020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L5.txt":
                    return "משנה - כתובות - רמב''ם";
                case "020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\ZDebugMix.txt":
                    return "משנה מסכת כתובות";
                case "020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM":
                    return "משנה - נדרים";
                case "020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L2.txt":
                    return "משנה - נדרים - רע''ב";
                case "020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L1.txt":
                    return "משנה - נדרים";

                case "020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L3.txt":
                    return "משנה - נדרים - עיקר תוי''ט";
                case "020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L5.txt":
                    return "משנה - נדרים - רמב''ם";
                case "020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\ZDebugMix.txt":
                    return "משנה מסכת נדרים";
                case "020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR":
                    return "משנה - נזיר";
                case "020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L2.txt":
                    return "משנה - נזיר - רע''ב";
                case "020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L1.txt":
                    return "משנה - נזיר";

                case "020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L3.txt":
                    return "משנה - נזיר - עיקר תוי''ט";
                case "020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L5.txt":
                    return "משנה - נזיר - רמב''ם";
                case "020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\ZDebugMix.txt":
                    return "משנה מסכת נזיר";
                case "020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA":
                    return "משנה - סוטה";
                case "020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L2.txt":
                    return "משנה - סוטה - רע''ב";
                case "020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L1.txt":
                    return "משנה - סוטה";

                case "020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L3.txt":
                    return "משנה - סוטה - עיקר תוי''ט";
                case "020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L5.txt":
                    return "משנה - סוטה - רמב''ם";
                case "020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\ZDebugMix.txt":
                    return "משנה מסכת סוטה";
                case "020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN":
                    return "משנה - גיטין";
                case "020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L2.txt":
                    return "משנה - גיטין - רע''ב";
                case "020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L1.txt":
                    return "משנה - גיטין";

                case "020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L3.txt":
                    return "משנה - גיטין - עיקר תוי''ט";
                case "020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L5.txt":
                    return "משנה - גיטין - רמב''ם";
                case "020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\ZDebugMix.txt":
                    return "משנה מסכת גיטין";
                case "020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN":
                    return "משנה - קידושין";
                case "020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L2.txt":
                    return "משנה - קידושין - רע''ב";
                case "020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L1.txt":
                    return "משנה - קידושין";

                case "020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L3.txt":
                    return "משנה - קידושין - עיקר תוי''ט";
                case "020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L5.txt":
                    return "משנה - קידושין - רמב''ם";
                case "020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\ZDebugMix.txt":
                    return "משנה מסכת קידושין";
                case "020_MISHNA\\103_SEDER_NEZIKIN":
                    return "משנה - בבא קמא";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L2.txt":
                    return "משנה - בבא קמא - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L1.txt":
                    return "משנה - בבא קמא";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L3.txt":
                    return "משנה - בבא קמא - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L5.txt":
                    return "משנה - בבא_קמא - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\ZDebugMix.txt":
                    return "משנה מסכת בבא קמא";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA":
                    return "משנה - בבא מציעא";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L2.txt":
                    return "משנה - בבא מציעא - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L1.txt":
                    return "משנה - בבא מציעא";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L3.txt":
                    return "משנה - בבא מציעא - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L5.txt":
                    return "משנה - בבא_מציעא - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\ZDebugMix.txt":
                    return "משנה מסכת בבא מציעא";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA":
                    return "משנה - בבא בתרא";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L2.txt":
                    return "משנה - בבא בתרא - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L1.txt":
                    return "משנה - בבא בתרא";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L3.txt":
                    return "משנה - בבא בתרא - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L5.txt":
                    return "משנה - בבא_בתרא - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\ZDebugMix.txt":
                    return "משנה מסכת בבא בתרא";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN":
                    return "משנה - סנהדרין";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L2.txt":
                    return "משנה - סנהדרין - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L1.txt":
                    return "משנה - סנהדרין";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L3.txt":
                    return "משנה - סנהדרין - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L5.txt":
                    return "משנה - סנהדרין - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\ZDebugMix.txt":
                    return "משנה מסכת סנהדרין";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT":
                    return "משנה - מכות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L2.txt":
                    return "משנה - מכות - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L1.txt":
                    return "משנה - מכות";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L3.txt":
                    return "משנה - מכות - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L5.txt":
                    return "משנה - מכות - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\ZDebugMix.txt":
                    return "משנה מסכת מכות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT":
                    return "משנה - שבועות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L2.txt":
                    return "משנה - שבועות - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L1.txt":
                    return "משנה - שבועות";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L3.txt":
                    return "משנה - שבועות - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L5.txt":
                    return "משנה - שבועות - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\ZDebugMix.txt":
                    return "משנה מסכת שבועות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT":
                    return "משנה - עדיות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L2.txt":
                    return "משנה - עדיות - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L1.txt":
                    return "משנה - עדיות";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L3.txt":
                    return "משנה - עדיות - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L5.txt":
                    return "משנה - עדיות - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\ZDebugMix.txt":
                    return "משנה מסכת עדיות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA":
                    return "משנה - עבודה זרה";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L2.txt":
                    return "משנה - עבודה זרה - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L1.txt":
                    return "משנה - עבודה זרה";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L3.txt":
                    return "משנה - עבודה זרה - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L5.txt":
                    return "משנה - עבודה_זרה - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\ZDebugMix.txt":
                    return "משנה מסכת עבודה זרה";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT":
                    return "משנה - אבות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L2.txt":
                    return "משנה - אבות - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L1.txt":
                    return "משנה - אבות";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L3.txt":
                    return "משנה - אבות - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L4.txt":
                    return "משנה - אבות - רש''י";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L5.txt":
                    return "משנה - אבות - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\ZDebugMix.txt":
                    return "משנה מסכת אבות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT":
                    return "משנה - הוריות";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L2.txt":
                    return "משנה - הוריות - רע''ב";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L1.txt":
                    return "משנה - הוריות";

                case "020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L3.txt":
                    return "משנה - הוריות - עיקר תוי''ט";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L5.txt":
                    return "משנה - הוריות - רמב''ם";
                case "020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\ZDebugMix.txt":
                    return "משנה מסכת הוריות";
                case "020_MISHNA\\104_SEDER_KADASHIM":
                    return "משנה - זבחים";
                case "020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L2.txt":
                    return "משנה - זבחים - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L1.txt":
                    return "משנה - זבחים";

                case "020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L3.txt":
                    return "משנה - זבחים - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L5.txt":
                    return "משנה - זבחים - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\ZDebugMix.txt":
                    return "משנה מסכת זבחים";
                case "020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT":
                    return "משנה - מנחות";
                case "020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L2.txt":
                    return "משנה - מנחות - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L1.txt":
                    return "משנה - מנחות";

                case "020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L3.txt":
                    return "משנה - מנחות - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L5.txt":
                    return "משנה - מנחות - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\ZDebugMix.txt":
                    return "משנה מסכת מנחות";
                case "020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN":
                    return "משנה - חולין";
                case "020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L2.txt":
                    return "משנה - חולין - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L1.txt":
                    return "משנה - חולין";

                case "020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L3.txt":
                    return "משנה - חולין - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L5.txt":
                    return "משנה - חולין - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\ZDebugMix.txt":
                    return "משנה מסכת חולין";
                case "020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT":
                    return "משנה - בכורות";
                case "020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L2.txt":
                    return "משנה - בכורות - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L1.txt":
                    return "משנה - בכורות";

                case "020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L3.txt":
                    return "משנה - בכורות - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L5.txt":
                    return "משנה - בכורות - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\ZDebugMix.txt":
                    return "משנה מסכת בכורות";
                case "020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN":
                    return "משנה - ערכין";
                case "020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L2.txt":
                    return "משנה - ערכין - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L1.txt":
                    return "משנה - ערכין";

                case "020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L3.txt":
                    return "משנה - ערכין - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L5.txt":
                    return "משנה - ערכין - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\ZDebugMix.txt":
                    return "משנה מסכת ערכין";
                case "020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA":
                    return "משנה - תמורה";
                case "020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L2.txt":
                    return "משנה - תמורה - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L1.txt":
                    return "משנה - תמורה";

                case "020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L3.txt":
                    return "משנה - תמורה - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L5.txt":
                    return "משנה - תמורה - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\ZDebugMix.txt":
                    return "משנה מסכת תמורה";
                case "020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT":
                    return "משנה - כריתות";
                case "020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L2.txt":
                    return "משנה - כריתות - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L1.txt":
                    return "משנה - כריתות";

                case "020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L3.txt":
                    return "משנה - כריתות - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L5.txt":
                    return "משנה - כריתות - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\ZDebugMix.txt":
                    return "משנה מסכת כריתות";
                case "020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA":
                    return "משנה - מעילה";
                case "020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L2.txt":
                    return "משנה - מעילה - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L1.txt":
                    return "משנה - מעילה";

                case "020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L3.txt":
                    return "משנה - מעילה - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L5.txt":
                    return "משנה - מעילה - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\ZDebugMix.txt":
                    return "משנה מסכת מעילה";
                case "020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID":
                    return "משנה - תמיד";
                case "020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L2.txt":
                    return "משנה - תמיד - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L1.txt":
                    return "משנה - תמיד";

                case "020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L3.txt":
                    return "משנה - תמיד - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L5.txt":
                    return "משנה - תמיד - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\ZDebugMix.txt":
                    return "משנה מסכת תמיד";
                case "020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT":
                    return "משנה - מדות";
                case "020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L2.txt":
                    return "משנה - מדות - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L1.txt":
                    return "משנה - מדות";

                case "020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L3.txt":
                    return "משנה - מדות - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L5.txt":
                    return "משנה - מדות - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\ZDebugMix.txt":
                    return "משנה מסכת מדות";
                case "020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM":
                    return "משנה - קנים";
                case "020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L2.txt":
                    return "משנה - קנים - רע''ב";
                case "020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L1.txt":
                    return "משנה - קנים";

                case "020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L3.txt":
                    return "משנה - קנים - עיקר תוי''ט";
                case "020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L5.txt":
                    return "משנה - קנים - רמב''ם";
                case "020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\ZDebugMix.txt":
                    return "משנה מסכת קנים";
                case "020_MISHNA\\105_SEDER_TAHAROT":
                    return "משנה - כלים";
                case "020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L2.txt":
                    return "משנה - כלים - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L1.txt":
                    return "משנה - כלים";

                case "020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L3.txt":
                    return "משנה - כלים - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L5.txt":
                    return "משנה - כלים - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\ZDebugMix.txt":
                    return "משנה מסכת כלים";
                case "020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT":
                    return "משנה - אהלות";
                case "020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L2.txt":
                    return "משנה - אהלות - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L1.txt":
                    return "משנה - אהלות";

                case "020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L3.txt":
                    return "משנה - אהלות - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L5.txt":
                    return "משנה - אהלות - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\ZDebugMix.txt":
                    return "משנה מסכת אהלות";
                case "020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM":
                    return "משנה - נגעים";
                case "020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L2.txt":
                    return "משנה - נגעים - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L1.txt":
                    return "משנה - נגעים";

                case "020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L3.txt":
                    return "משנה - נגעים - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L5.txt":
                    return "משנה - נגעים - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\ZDebugMix.txt":
                    return "משנה מסכת נגעים";
                case "020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA":
                    return "משנה - פרה";
                case "020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L2.txt":
                    return "משנה - פרה - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L1.txt":
                    return "משנה - פרה";

                case "020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L3.txt":
                    return "משנה - פרה - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L5.txt":
                    return "משנה - פרה - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\ZDebugMix.txt":
                    return "משנה מסכת פרה";
                case "020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT":
                    return "משנה - טהרות";
                case "020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L2.txt":
                    return "משנה - טהרות - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L1.txt":
                    return "משנה - טהרות";

                case "020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L3.txt":
                    return "משנה - טהרות - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L5.txt":
                    return "משנה - טהרות - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\ZDebugMix.txt":
                    return "משנה מסכת טהרות";
                case "020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT":
                    return "משנה - מקואות";
                case "020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L2.txt":
                    return "משנה - מקואות - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L1.txt":
                    return "משנה - מקואות";

                case "020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L3.txt":
                    return "משנה - מקואות - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L5.txt":
                    return "משנה - מקואות - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\ZDebugMix.txt":
                    return "משנה מסכת מקוואות";
                case "020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA":
                    return "משנה - נדה";
                case "020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L2.txt":
                    return "משנה - נדה - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L1.txt":
                    return "משנה - נדה";

                case "020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L3.txt":
                    return "משנה - נדה - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L5.txt":
                    return "משנה - נדה - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\ZDebugMix.txt":
                    return "משנה מסכת נדה";
                case "020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN":
                    return "משנה - מכשירין";
                case "020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L2.txt":
                    return "משנה - מכשירין - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L1.txt":
                    return "משנה - מכשירין";

                case "020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L3.txt":
                    return "משנה - מכשירין - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L5.txt":
                    return "משנה - מכשירין - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\ZDebugMix.txt":
                    return "משנה מסכת מכשירין";
                case "020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM":
                    return "משנה - זבים";
                case "020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L2.txt":
                    return "משנה - זבים - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L1.txt":
                    return "משנה - זבים";

                case "020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L3.txt":
                    return "משנה - זבים - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L5.txt":
                    return "משנה - זבים - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\ZDebugMix.txt":
                    return "משנה מסכת זבים";
                case "020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM":
                    return "משנה - טבול יום";
                case "020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L2.txt":
                    return "משנה - טבול יום - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L1.txt":
                    return "משנה - טבול יום";

                case "020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L3.txt":
                    return "משנה - טבול יום - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L5.txt":
                    return "משנה - טבול_יום - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\ZDebugMix.txt":
                    return "משנה מסכת טבול יום";
                case "020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM":
                    return "משנה - ידים";
                case "020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L2.txt":
                    return "משנה - ידים - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L1.txt":
                    return "משנה - ידים";

                case "020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L3.txt":
                    return "משנה - ידים - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L5.txt":
                    return "משנה - ידים - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\ZDebugMix.txt":
                    return "משנה מסכת ידים";
                case "020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN":
                    return "משנה - עוקצין";
                case "020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L2.txt":
                    return "משנה - עוקצין - רע''ב";
                case "020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L1.txt":
                    return "משנה - עוקצין";

                case "020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L3.txt":
                    return "משנה - עוקצין - עיקר תוי''ט";
                case "020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L5.txt":
                    return "משנה - עוקצין - רמב''ם";
                case "020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\ZDebugMix.txt":
                    return "משנה מסכת עוקצין";
                case "030_BAVLI":
                    return "תלמוד בבלי - ברכות";
                case "030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L2.txt":
                    return "תלמוד בבלי - ברכות - רש''י";
                case "030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L1.txt":
                    return "תלמוד בבלי - ברכות";

                case "030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L3.txt":
                    return "תלמוד בבלי - ברכות - תוספות";
                case "030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L6_rashba.txt":
                    return "רשב''א - מסכת ברכות";
                case "030_BAVLI\\01_MAS_BRACHOT\\DebugMix.txt":
                    return "מסכת ברכות";
                case "030_BAVLI\\01_MAS_BRACHOT\\HavAll.txt":
                    return "חברותא - ברכות";
                case "030_BAVLI\\01_MAS_BRACHOT\\HavTempNoNotes.txt":
                    return "חברותא - ברכות - בלי הערות";
                case "030_BAVLI\\01_MAS_BRACHOT\\HavTempNotes.txt":
                    return "חברותא - ברכות - הערות";
                case "030_BAVLI\\02_MAS_SHABAT":
                    return "תלמוד בבלי - שבת";
                case "030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L2.txt":
                    return "תלמוד בבלי - שבת - רש''י";
                case "030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L1.txt":
                    return "תלמוד בבלי - שבת";

                case "030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L3.txt":
                    return "תלמוד בבלי - שבת - תוספות";
                case "030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L6_rashba.txt":
                    return "רשב''א - מסכת שבת";
                case "030_BAVLI\\02_MAS_SHABAT\\DebugMix.txt":
                    return "מסכת שבת";
                case "030_BAVLI\\02_MAS_SHABAT\\HavAll.txt":
                    return "חברותא - שבת";
                case "030_BAVLI\\02_MAS_SHABAT\\HavTempNoNotes.txt":
                    return "חברותא - שבת - בלי הערות";
                case "030_BAVLI\\02_MAS_SHABAT\\HavTempNotes.txt":
                    return "חברותא - שבת - הערות";
                case "030_BAVLI\\03_MAS_ERUVIN":
                    return "תלמוד בבלי - עירובין";
                case "030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L2.txt":
                    return "תלמוד בבלי - עירובין - רש''י";
                case "030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L1.txt":
                    return "תלמוד בבלי - עירובין";

                case "030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L3.txt":
                    return "תלמוד בבלי - עירובין - תוספות";
                case "030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L6_rashba.txt":
                    return "רשב''א - מסכת עירובין";
                case "030_BAVLI\\03_MAS_ERUVIN\\DebugMix.txt":
                    return "מסכת עירובין";
                case "030_BAVLI\\03_MAS_ERUVIN\\HavAll.txt":
                    return "חברותא - עירובין";
                case "030_BAVLI\\03_MAS_ERUVIN\\HavTempNoNotes.txt":
                    return "חברותא - עירובין - בלי הערות";
                case "030_BAVLI\\03_MAS_ERUVIN\\HavTempNotes.txt":
                    return "חברותא - עירובין - הערות";
                case "030_BAVLI\\04_MAS_PSACHIM":
                    return "תלמוד בבלי - פסחים";
                case "030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L2.txt":
                    return "תלמוד בבלי - פסחים - רש''י";
                case "030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L1.txt":
                    return "תלמוד בבלי - פסחים";

                case "030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L3.txt":
                    return "תלמוד בבלי - פסחים - תוספות";
                case "030_BAVLI\\04_MAS_PSACHIM\\Bav PSAHIM_L4.txt":
                    return "תלמוד בבלי - פסחים - רשב''ם";
                case "030_BAVLI\\04_MAS_PSACHIM\\DebugMix.txt":
                    return "מסכת פסחים";
                case "030_BAVLI\\04_MAS_PSACHIM\\HavAll.txt":
                    return "חברותא - פסחים";
                case "030_BAVLI\\04_MAS_PSACHIM\\HavTempNoNotes.txt":
                    return "חברותא - פסחים - בלי הערות";
                case "030_BAVLI\\04_MAS_PSACHIM\\HavTempNotes.txt":
                    return "חברותא - פסחים - הערות";
                case "030_BAVLI\\05_MAS_SHKALIM":
                    return "תלמוד ירושלמי - שקלים";
                case "030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L2.txt":
                    return "[2] תלמוד ירושלמי - שקלים - קרבן העדה";
                case "030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L1.txt":
                    return "[1] תלמוד ירושלמי - שקלים - קרבן העדה";

                case "030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L3.txt":
                    return "תלמוד ירושלמי - שקלים - ריבב''ן";
                case "030_BAVLI\\05_MAS_SHKALIM\\DebugMix.txt":
                    return "מסכת שקלים";
                case "030_BAVLI\\05_MAS_SHKALIM\\HavAll.txt":
                    return "חברותא - שקלים";
                case "030_BAVLI\\05_MAS_SHKALIM\\HavTempNoNotes.txt":
                    return "חברותא - שקלים - בלי הערות";
                case "030_BAVLI\\05_MAS_SHKALIM\\HavTempNotes.txt":
                    return "חברותא - שקלים - הערות";
                case "030_BAVLI\\06_MAS_ROSH":
                    return "תלמוד בבלי - ראש השנה";
                case "030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L2.txt":
                    return "תלמוד בבלי - ראש השנה - רש''י";
                case "030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L1.txt":
                    return "תלמוד בבלי - ראש השנה";

                case "030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L3.txt":
                    return "תלמוד בבלי - ראש השנה - תוספות";
                case "030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L6_rashba.txt":
                    return "רשב''א - מסכת ראש השנה";
                case "030_BAVLI\\06_MAS_ROSH\\DebugMix.txt":
                    return "מסכת ראש השנה";
                case "030_BAVLI\\06_MAS_ROSH\\HavAll.txt":
                    return "חברותא - ראש השנה";
                case "030_BAVLI\\06_MAS_ROSH\\HavTempNoNotes.txt":
                    return "חברותא - ראש השנה - בלי הערות";
                case "030_BAVLI\\06_MAS_ROSH\\HavTempNotes.txt":
                    return "חברותא - ראש השנה - הערות";
                case "030_BAVLI\\07_MAS_YOMA":
                    return "תלמוד בבלי - יומא";
                case "030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L2.txt":
                    return "תלמוד בבלי - יומא - רש''י";
                case "030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L1.txt":
                    return "תלמוד בבלי - יומא";

                case "030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L3.txt":
                    return "תלמוד בבלי - יומא - תוספות";
                case "030_BAVLI\\07_MAS_YOMA\\DebugMix.txt":
                    return "מסכת יומא";
                case "030_BAVLI\\07_MAS_YOMA\\HavAll.txt":
                    return "חברותא - יומא";
                case "030_BAVLI\\07_MAS_YOMA\\HavTempNoNotes.txt":
                    return "חברותא - יומא - בלי הערות";
                case "030_BAVLI\\07_MAS_YOMA\\HavTempNotes.txt":
                    return "חברותא - יומא - הערות";
                case "030_BAVLI\\08_MAS_SUCA":
                    return "תלמוד בבלי - סוכה";
                case "030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L2.txt":
                    return "תלמוד בבלי - סוכה - רש''י";
                case "030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L1.txt":
                    return "תלמוד בבלי - סוכה";

                case "030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L3.txt":
                    return "תלמוד בבלי - סוכה - תוספות";
                case "030_BAVLI\\08_MAS_SUCA\\DebugMix.txt":
                    return "מסכת סוכה";
                case "030_BAVLI\\08_MAS_SUCA\\HavAll.txt":
                    return "חברותא - סוכה";
                case "030_BAVLI\\08_MAS_SUCA\\HavTempNoNotes.txt":
                    return "חברותא - סוכה - בלי הערות";
                case "030_BAVLI\\08_MAS_SUCA\\HavTempNotes.txt":
                    return "חברותא - סוכה - הערות";
                case "030_BAVLI\\09_MAS_BEITSA":
                    return "תלמוד בבלי - ביצה";
                case "030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L2.txt":
                    return "תלמוד בבלי - ביצה - רש''י";
                case "030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L1.txt":
                    return "תלמוד בבלי - ביצה";

                case "030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L3.txt":
                    return "תלמוד בבלי - ביצה - תוספות";
                case "030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L6_rashba.txt":
                    return "רשב''א - מסכת ביצה";
                case "030_BAVLI\\09_MAS_BEITSA\\DebugMix.txt":
                    return "מסכת ביצה";
                case "030_BAVLI\\09_MAS_BEITSA\\HavAll.txt":
                    return "חברותא - ביצה";
                case "030_BAVLI\\09_MAS_BEITSA\\HavTempNoNotes.txt":
                    return "חברותא - ביצה - בלי הערות";
                case "030_BAVLI\\09_MAS_BEITSA\\HavTempNotes.txt":
                    return "חברותא - ביצה - הערות";
                case "030_BAVLI\\10_MAS_TAANIT":
                    return "תלמוד בבלי - תענית";
                case "030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L2.txt":
                    return "תלמוד בבלי - תענית - רש''י";
                case "030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L1.txt":
                    return "תלמוד בבלי - תענית";

                case "030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L3.txt":
                    return "תלמוד בבלי - תענית - תוספות";
                case "030_BAVLI\\10_MAS_TAANIT\\DebugMix.txt":
                    return "מסכת תענית";
                case "030_BAVLI\\10_MAS_TAANIT\\HavAll.txt":
                    return "חברותא - תענית";
                case "030_BAVLI\\10_MAS_TAANIT\\HavTempNoNotes.txt":
                    return "חברותא - תענית - בלי הערות";
                case "030_BAVLI\\10_MAS_TAANIT\\HavTempNotes.txt":
                    return "חברותא - תענית - הערות";
                case "030_BAVLI\\11_MAS_MEGILA":
                    return "תלמוד בבלי - מגילה";
                case "030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L2.txt":
                    return "תלמוד בבלי - מגילה - רש''י";
                case "030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L1.txt":
                    return "תלמוד בבלי - מגילה";

                case "030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L3.txt":
                    return "תלמוד בבלי - מגילה - תוספות";
                case "030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L6_rashba.txt":
                    return "רשב''א - מסכת מגילה";
                case "030_BAVLI\\11_MAS_MEGILA\\DebugMix.txt":
                    return "מסכת מגילה";
                case "030_BAVLI\\11_MAS_MEGILA\\HavAll.txt":
                    return "חברותא - מגילה";
                case "030_BAVLI\\11_MAS_MEGILA\\HavTempNoNotes.txt":
                    return "חברותא - מגילה - בלי הערות";
                case "030_BAVLI\\11_MAS_MEGILA\\HavTempNotes.txt":
                    return "חברותא - מגילה - הערות";
                case "030_BAVLI\\12_MAS_MOED_KATAN":
                    return "תלמוד בבלי - מועד קטן";
                case "030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L2.txt":
                    return "תלמוד בבלי - מועד קטן - רש''י";
                case "030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L1.txt":
                    return "תלמוד בבלי - מועד קטן";

                case "030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L3.txt":
                    return "תלמוד בבלי - מועד קטן - תוספות";
                case "030_BAVLI\\12_MAS_MOED_KATAN\\DebugMix.txt":
                    return "מסכת מועד קטן";
                case "030_BAVLI\\12_MAS_MOED_KATAN\\HavAll.txt":
                    return "חברותא - מועד קטן";
                case "030_BAVLI\\12_MAS_MOED_KATAN\\HavTempNoNotes.txt":
                    return "חברותא - מועד קטן - בלי הערות";
                case "030_BAVLI\\12_MAS_MOED_KATAN\\HavTempNotes.txt":
                    return "חברותא - מועד קטן - הערות";
                case "030_BAVLI\\13_MAS_HAGIGA":
                    return "תלמוד בבלי - חגיגה";
                case "030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L2.txt":
                    return "תלמוד בבלי - חגיגה - רש''י";
                case "030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L1.txt":
                    return "תלמוד בבלי - חגיגה";

                case "030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L3.txt":
                    return "תלמוד בבלי - חגיגה - תוספות";
                case "030_BAVLI\\13_MAS_HAGIGA\\DebugMix.txt":
                    return "מסכת חגיגה";
                case "030_BAVLI\\13_MAS_HAGIGA\\HavAll.txt":
                    return "חברותא - חגיגה";
                case "030_BAVLI\\13_MAS_HAGIGA\\HavTempNoNotes.txt":
                    return "חברותא - חגיגה - בלי הערות";
                case "030_BAVLI\\13_MAS_HAGIGA\\HavTempNotes.txt":
                    return "חברותא - חגיגה - הערות";
                case "030_BAVLI\\14_MAS_YEVAMOT":
                    return "תלמוד בבלי - יבמות";
                case "030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L2.txt":
                    return "תלמוד בבלי - יבמות - רש''י";
                case "030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L1.txt":
                    return "תלמוד בבלי - יבמות";

                case "030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L3.txt":
                    return "תלמוד בבלי - יבמות - תוספות";
                case "030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L6_rashba.txt":
                    return "רשב''א - מסכת יבמות";
                case "030_BAVLI\\14_MAS_YEVAMOT\\DebugMix.txt":
                    return "מסכת יבמות";
                case "030_BAVLI\\14_MAS_YEVAMOT\\HavAll.txt":
                    return "חברותא - יבמות";
                case "030_BAVLI\\14_MAS_YEVAMOT\\HavTempNoNotes.txt":
                    return "חברותא - יבמות - בלי הערות";
                case "030_BAVLI\\14_MAS_YEVAMOT\\HavTempNotes.txt":
                    return "חברותא - יבמות - הערות";
                case "030_BAVLI\\15_MAS_KTUBOT":
                    return "תלמוד בבלי - כתובות";
                case "030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L2.txt":
                    return "תלמוד בבלי - כתובות - רש''י";
                case "030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L1.txt":
                    return "תלמוד בבלי - כתובות";

                case "030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L3.txt":
                    return "תלמוד בבלי - כתובות - תוספות";
                case "030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L6_rashba.txt":
                    return "רשב''א - מסכת כתובות";
                case "030_BAVLI\\15_MAS_KTUBOT\\DebugMix.txt":
                    return "מסכת כתובות";
                case "030_BAVLI\\15_MAS_KTUBOT\\HavAll.txt":
                    return "חברותא - כתובות";
                case "030_BAVLI\\15_MAS_KTUBOT\\HavTempNoNotes.txt":
                    return "חברותא - כתובות - בלי הערות";
                case "030_BAVLI\\15_MAS_KTUBOT\\HavTempNotes.txt":
                    return "חברותא - כתובות - הערות";
                case "030_BAVLI\\16_MAS_NEDARIM":
                    return "תלמוד בבלי - נדרים";
                case "030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L2.txt":
                    return "תלמוד בבלי - נדרים - רש''י";
                case "030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L1.txt":
                    return "תלמוד בבלי - נדרים";

                case "030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L3.txt":
                    return "תלמוד בבלי - נדרים - תוספות";
                case "030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L4.txt":
                    return "תלמוד בבלי - נדרים - ר''נ";
                case "030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L6_rashba.txt":
                    return "רשב''א - מסכת נדרים";
                case "030_BAVLI\\16_MAS_NEDARIM\\DebugMix.txt":
                    return "מסכת נדרים";
                case "030_BAVLI\\16_MAS_NEDARIM\\HavAll.txt":
                    return "חברותא - נדרים";
                case "030_BAVLI\\16_MAS_NEDARIM\\HavTempNoNotes.txt":
                    return "חברותא - נדרים - בלי הערות";
                case "030_BAVLI\\16_MAS_NEDARIM\\HavTempNotes.txt":
                    return "חברותא - נדרים - הערות";
                case "030_BAVLI\\17_MAS_NAZIR":
                    return "תלמוד בבלי - נזיר";
                case "030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L2.txt":
                    return "תלמוד בבלי - נזיר - רש''י";
                case "030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L1.txt":
                    return "תלמוד בבלי - נזיר";

                case "030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L3.txt":
                    return "תלמוד בבלי - נזיר - תוספות";
                case "030_BAVLI\\17_MAS_NAZIR\\DebugMix.txt":
                    return "מסכת נזיר";
                case "030_BAVLI\\17_MAS_NAZIR\\HavAll.txt":
                    return "חברותא - נזיר";
                case "030_BAVLI\\17_MAS_NAZIR\\HavTempNoNotes.txt":
                    return "חברותא - נזיר - בלי הערות";
                case "030_BAVLI\\17_MAS_NAZIR\\HavTempNotes.txt":
                    return "חברותא - נזיר - הערות";
                case "030_BAVLI\\18_MAS_SOTA":
                    return "תלמוד בבלי - סוטה";
                case "030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L2.txt":
                    return "תלמוד בבלי - סוטה - רש''י";
                case "030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L1.txt":
                    return "תלמוד בבלי - סוטה";

                case "030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L3.txt":
                    return "תלמוד בבלי - סוטה - תוספות";
                case "030_BAVLI\\18_MAS_SOTA\\DebugMix.txt":
                    return "מסכת סוטה";
                case "030_BAVLI\\18_MAS_SOTA\\HavAll.txt":
                    return "חברותא - סוטה";
                case "030_BAVLI\\18_MAS_SOTA\\HavTempNoNotes.txt":
                    return "חברותא - סוטה - בלי הערות";
                case "030_BAVLI\\18_MAS_SOTA\\HavTempNotes.txt":
                    return "חברותא - סוטה - הערות";
                case "030_BAVLI\\19_MAS_GITIN":
                    return "תלמוד בבלי - גיטין";
                case "030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L2.txt":
                    return "תלמוד בבלי - גיטין - רש''י";
                case "030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L1.txt":
                    return "תלמוד בבלי - גיטין";

                case "030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L3.txt":
                    return "תלמוד בבלי - גיטין - תוספות";
                case "030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L6_rashba.txt":
                    return "רשב''א - מסכת גיטין";
                case "030_BAVLI\\19_MAS_GITIN\\DebugMix.txt":
                    return "מסכת גיטין";
                case "030_BAVLI\\19_MAS_GITIN\\HavAll.txt":
                    return "חברותא - גיטין";
                case "030_BAVLI\\19_MAS_GITIN\\HavTempNoNotes.txt":
                    return "חברותא - גיטין - בלי הערות";
                case "030_BAVLI\\19_MAS_GITIN\\HavTempNotes.txt":
                    return "חברותא - גיטין - הערות";
                case "030_BAVLI\\20_MAS_KIDUSHIN":
                    return "תלמוד בבלי - קידושין";
                case "030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L2.txt":
                    return "תלמוד בבלי - קידושין - רש''י";
                case "030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L1.txt":
                    return "תלמוד בבלי - קידושין";

                case "030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L3.txt":
                    return "תלמוד בבלי - קידושין - תוספות";
                case "030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L6_rashba.txt":
                    return "רשב''א - מסכת קידושין";
                case "030_BAVLI\\20_MAS_KIDUSHIN\\DebugMix.txt":
                    return "מסכת קידושין";
                case "030_BAVLI\\20_MAS_KIDUSHIN\\HavAll.txt":
                    return "חברותא - קידושין";
                case "030_BAVLI\\20_MAS_KIDUSHIN\\HavTempNoNotes.txt":
                    return "חברותא - קידושין - בלי הערות";
                case "030_BAVLI\\20_MAS_KIDUSHIN\\HavTempNotes.txt":
                    return "חברותא - קידושין - הערות";
                case "030_BAVLI\\21_MAS_KAMA":
                    return "תלמוד בבלי - בבא קמא";
                case "030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L2.txt":
                    return "תלמוד בבלי - בבא קמא - רש''י";
                case "030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L1.txt":
                    return "תלמוד בבלי - בבא קמא";

                case "030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L3.txt":
                    return "תלמוד בבלי - בבא קמא - תוספות";
                case "030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L6_rashba.txt":
                    return "רשב''א - מסכת בבא קמא";
                case "030_BAVLI\\21_MAS_KAMA\\DebugMix.txt":
                    return "מסכת בבא קמא";
                case "030_BAVLI\\21_MAS_KAMA\\HavAll.txt":
                    return "חברותא - בבא קמא";
                case "030_BAVLI\\21_MAS_KAMA\\HavTempNoNotes.txt":
                    return "חברותא - בבא קמא - בלי הערות";
                case "030_BAVLI\\21_MAS_KAMA\\HavTempNotes.txt":
                    return "חברותא - בבא קמא - הערות";
                case "030_BAVLI\\22_MAS_METSIA":
                    return "תלמוד בבלי - בבא מציעא";
                case "030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L2.txt":
                    return "תלמוד בבלי - בבא מציעא - רש''י";
                case "030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L1.txt":
                    return "תלמוד בבלי - בבא מציעא";

                case "030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L3.txt":
                    return "תלמוד בבלי - בבא מציעא - תוספות";
                case "030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L6_rashba.txt":
                    return "רשב''א - מסכת בבא מציעא";
                case "030_BAVLI\\22_MAS_METSIA\\DebugMix.txt":
                    return "מסכת בבא מציעא";
                case "030_BAVLI\\22_MAS_METSIA\\HavAll.txt":
                    return "חברותא - בבא מציעא";
                case "030_BAVLI\\22_MAS_METSIA\\HavTempNoNotes.txt":
                    return "חברותא - בבא מציעא - בלי הערות";
                case "030_BAVLI\\22_MAS_METSIA\\HavTempNotes.txt":
                    return "חברותא - בבא מציעא - הערות";
                case "030_BAVLI\\23_MAS_BATRA":
                    return "תלמוד בבלי - בבא בתרא";
                case "030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L2.txt":
                    return "תלמוד בבלי - בבא בתרא - רש''י";
                case "030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L1.txt":
                    return "תלמוד בבלי - בבא בתרא";

                case "030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L3.txt":
                    return "תלמוד בבלי - בבא בתרא - תוספות";
                case "030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L6_rashba.txt":
                    return "רשב''א - מסכת בבא בתרא";
                case "030_BAVLI\\23_MAS_BATRA\\DebugMix.txt":
                    return "מסכת בבא בתרא";
                case "030_BAVLI\\23_MAS_BATRA\\HavAll.txt":
                    return "חברותא - בבא בתרא";
                case "030_BAVLI\\23_MAS_BATRA\\HavTempNoNotes.txt":
                    return "חברותא - בבא בתרא - בלי הערות";
                case "030_BAVLI\\23_MAS_BATRA\\HavTempNotes.txt":
                    return "חברותא -  בבא בתרא - הערות";
                case "030_BAVLI\\24_MAS_SANHEDRIN":
                    return "תלמוד בבלי - סנהדרין";
                case "030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L2.txt":
                    return "תלמוד בבלי - סנהדרין - רש''י";
                case "030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L1.txt":
                    return "תלמוד בבלי - סנהדרין";

                case "030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L3.txt":
                    return "תלמוד בבלי - סנהדרין - תוספות";
                case "030_BAVLI\\24_MAS_SANHEDRIN\\DebugMix.txt":
                    return "מסכת סנהדרין";
                case "030_BAVLI\\24_MAS_SANHEDRIN\\HavAll.txt":
                    return "חברותא - סנהדרין";
                case "030_BAVLI\\24_MAS_SANHEDRIN\\HavTempNoNotes.txt":
                    return "חברותא - סנהדרין - בלי הערות";
                case "030_BAVLI\\24_MAS_SANHEDRIN\\HavTempNotes.txt":
                    return "חברותא - סנהדרין - הערות";
                case "030_BAVLI\\25_MAS_MAKOT":
                    return "תלמוד בבלי - מכות";
                case "030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L2.txt":
                    return "תלמוד בבלי - מכות - רש''י";
                case "030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L1.txt":
                    return "תלמוד בבלי - מכות";

                case "030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L3.txt":
                    return "תלמוד בבלי - מכות - תוספות";
                case "030_BAVLI\\25_MAS_MAKOT\\DebugMix.txt":
                    return "מסכת מכות";
                case "030_BAVLI\\25_MAS_MAKOT\\HavAll.txt":
                    return "חברותא - מכות";
                case "030_BAVLI\\25_MAS_MAKOT\\HavTempNoNotes.txt":
                    return "חברותא - מכות - בלי הערות";
                case "030_BAVLI\\25_MAS_MAKOT\\HavTempNotes.txt":
                    return "חברותא - מכות - הערות";
                case "030_BAVLI\\26_MAS_SHVUOT":
                    return "תלמוד בבלי - שבועות";
                case "030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L2.txt":
                    return "תלמוד בבלי - שבועות - רש''י";
                case "030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L1.txt":
                    return "תלמוד בבלי - שבועות";

                case "030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L3.txt":
                    return "תלמוד בבלי - שבועות - תוספות";
                case "030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L6_rashba.txt":
                    return "רשב''א - מסכת שבועות";
                case "030_BAVLI\\26_MAS_SHVUOT\\DebugMix.txt":
                    return "מסכת שבועות";
                case "030_BAVLI\\26_MAS_SHVUOT\\HavAll.txt":
                    return "חברותא - שבועות";
                case "030_BAVLI\\26_MAS_SHVUOT\\HavTempNoNotes.txt":
                    return "חברותא - שבועות - בלי הערות";
                case "030_BAVLI\\26_MAS_SHVUOT\\HavTempNotes.txt":
                    return "חברותא - שבועות - הערות";
                case "030_BAVLI\\27_MAS_AVODA_ZARA":
                    return "תלמוד בבלי - עבודה זרה";
                case "030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L2.txt":
                    return "תלמוד בבלי - עבודה זרה - רש''י";
                case "030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L1.txt":
                    return "תלמוד בבלי - עבודה זרה";

                case "030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L3.txt":
                    return "תלמוד בבלי - עבודה זרה - תוספות";
                case "030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L6_rashba.txt":
                    return "רשב''א - מסכת עבודה זרה";
                case "030_BAVLI\\27_MAS_AVODA_ZARA\\DebugMix.txt":
                    return "מסכת עבודה זרה";
                case "030_BAVLI\\27_MAS_AVODA_ZARA\\HavAll.txt":
                    return "חברותא - עבודה זרה";
                case "030_BAVLI\\27_MAS_AVODA_ZARA\\HavTempNoNotes.txt":
                    return "חברותא - עבודה זרה - בלי הערות";
                case "030_BAVLI\\27_MAS_AVODA_ZARA\\HavTempNotes.txt":
                    return "חברותא - עבודה זרה - הערות";
                case "030_BAVLI\\28_MAS_HORAYOT":
                    return "תלמוד בבלי - הוריות";
                case "030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L2.txt":
                    return "תלמוד בבלי - הוריות - רש''י";
                case "030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L1.txt":
                    return "תלמוד בבלי - הוריות";

                case "030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L3.txt":
                    return "תלמוד בבלי - הוריות - תוספות";
                case "030_BAVLI\\28_MAS_HORAYOT\\DebugMix.txt":
                    return "מסכת הוריות";
                case "030_BAVLI\\28_MAS_HORAYOT\\HavAll.txt":
                    return "חברותא - הוריות";
                case "030_BAVLI\\28_MAS_HORAYOT\\HavTempNoNotes.txt":
                    return "חברותא - הוריות - בלי הערות";
                case "030_BAVLI\\28_MAS_HORAYOT\\HavTempNotes.txt":
                    return "חברותא - הוריות - הערות";
                case "030_BAVLI\\29_MAS_EDUYOT":
                    return "תלמוד בבלי - עדיות";
                case "030_BAVLI\\30_MAS_ZEVACHIM":
                    return "תלמוד בבלי - זבחים";
                case "030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L2.txt":
                    return "תלמוד בבלי - זבחים - רש''י";
                case "030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L1.txt":
                    return "תלמוד בבלי - זבחים";

                case "030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L3.txt":
                    return "תלמוד בבלי - זבחים - תוספות";
                case "030_BAVLI\\30_MAS_ZEVACHIM\\DebugMix.txt":
                    return "מסכת זבחים";
                case "030_BAVLI\\30_MAS_ZEVACHIM\\HavAll.txt":
                    return "חברותא - זבחים";
                case "030_BAVLI\\30_MAS_ZEVACHIM\\HavTempNoNotes.txt":
                    return "חברותא - זבחים - בלי הערות";
                case "030_BAVLI\\30_MAS_ZEVACHIM\\HavTempNotes.txt":
                    return "חברותא - זבחים - הערות";
                case "030_BAVLI\\31_MAS_MENACHOT":
                    return "תלמוד בבלי - מנחות";
                case "030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L2.txt":
                    return "תלמוד בבלי - מנחות - רש''י";
                case "030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L1.txt":
                    return "תלמוד בבלי - מנחות";

                case "030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L3.txt":
                    return "תלמוד בבלי - מנחות - תוספות";
                case "030_BAVLI\\31_MAS_MENACHOT\\DebugMix.txt":
                    return "מסכת מנחות";
                case "030_BAVLI\\31_MAS_MENACHOT\\HavAll.txt":
                    return "חברותא - מנחות";
                case "030_BAVLI\\31_MAS_MENACHOT\\HavTempNoNotes.txt":
                    return "חברותא - מנחות - בלי הערות";
                case "030_BAVLI\\31_MAS_MENACHOT\\HavTempNotes.txt":
                    return "חברותא - מנחות - הערות";
                case "030_BAVLI\\32_MAS_CHULIN":
                    return "תלמוד בבלי - חולין";
                case "030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L2.txt":
                    return "תלמוד בבלי - חולין - רש''י";
                case "030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L1.txt":
                    return "תלמוד בבלי - חולין";

                case "030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L3.txt":
                    return "תלמוד בבלי - חולין - תוספות";
                case "030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L6_rashba.txt":
                    return "רשב''א - מסכת חולין";
                case "030_BAVLI\\32_MAS_CHULIN\\DebugMix.txt":
                    return "מסכת חולין";
                case "030_BAVLI\\32_MAS_CHULIN\\HavAll.txt":
                    return "חברותא - חולין";
                case "030_BAVLI\\32_MAS_CHULIN\\HavTempNoNotes.txt":
                    return "חברותא - חולין - בלי הערות";
                case "030_BAVLI\\32_MAS_CHULIN\\HavTempNotes.txt":
                    return "חברותא - חולין - הערות";
                case "030_BAVLI\\33_MAS_BECHOROT":
                    return "תלמוד בבלי - בכורות";
                case "030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L2.txt":
                    return "תלמוד בבלי - בכורות - רש''י";
                case "030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L1.txt":
                    return "תלמוד בבלי - בכורות";

                case "030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L3.txt":
                    return "תלמוד בבלי - בכורות - תוספות";
                case "030_BAVLI\\33_MAS_BECHOROT\\DebugMix.txt":
                    return "מסכת בכורות";
                case "030_BAVLI\\33_MAS_BECHOROT\\HavAll.txt":
                    return "חברותא - בכורות";
                case "030_BAVLI\\33_MAS_BECHOROT\\HavTempNoNotes.txt":
                    return "חברותא - בכורות - בלי הערות";
                case "030_BAVLI\\33_MAS_BECHOROT\\HavTempNotes.txt":
                    return "חברותא - בכורות - הערות";
                case "030_BAVLI\\34_MAS_ARACHIN":
                    return "תלמוד בבלי - ערכין";
                case "030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L2.txt":
                    return "תלמוד בבלי - ערכין - רש''י";
                case "030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L1.txt":
                    return "תלמוד בבלי - ערכין";

                case "030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L3.txt":
                    return "תלמוד בבלי - ערכין - תוספות";
                case "030_BAVLI\\34_MAS_ARACHIN\\DebugMix.txt":
                    return "מסכת ערכין";
                case "030_BAVLI\\34_MAS_ARACHIN\\HavAll.txt":
                    return "חברותא - ערכין";
                case "030_BAVLI\\34_MAS_ARACHIN\\HavTempNoNotes.txt":
                    return "חברותא - ערכין - בלי הערות";
                case "030_BAVLI\\34_MAS_ARACHIN\\HavTempNotes.txt":
                    return "חברותא - ערכין - הערות";
                case "030_BAVLI\\35_MAS_TEMURA":
                    return "תלמוד בבלי - תמורה";
                case "030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L2.txt":
                    return "תלמוד בבלי - תמורה - רש''י";
                case "030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L1.txt":
                    return "תלמוד בבלי - תמורה";

                case "030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L3.txt":
                    return "תלמוד בבלי - תמורה - תוספות";
                case "030_BAVLI\\35_MAS_TEMURA\\DebugMix.txt":
                    return "מסכת תמורה";
                case "030_BAVLI\\35_MAS_TEMURA\\HavAll.txt":
                    return "חברותא - תמורה";
                case "030_BAVLI\\35_MAS_TEMURA\\HavTempNoNotes.txt":
                    return "חברותא - תמורה - בלי הערות";
                case "030_BAVLI\\35_MAS_TEMURA\\HavTempNotes.txt":
                    return "חברותא - תמורה - הערות";
                case "030_BAVLI\\36_MAS_KRETOT":
                    return "תלמוד בבלי - כריתות";
                case "030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L2.txt":
                    return "תלמוד בבלי - כריתות - רש''י";
                case "030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L1.txt":
                    return "תלמוד בבלי - כריתות";

                case "030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L3.txt":
                    return "תלמוד בבלי - כריתות - תוספות";
                case "030_BAVLI\\36_MAS_KRETOT\\DebugMix.txt":
                    return "מסכת כריתות";
                case "030_BAVLI\\36_MAS_KRETOT\\HavAll.txt":
                    return "חברותא - כריתות";
                case "030_BAVLI\\36_MAS_KRETOT\\HavTempNoNotes.txt":
                    return "חברותא - כריתות - בלי הערות";
                case "030_BAVLI\\36_MAS_KRETOT\\HavTempNotes.txt":
                    return "חברותא - כריתות - הערות";
                case "030_BAVLI\\37_MAS_MEILA":
                    return "תלמוד בבלי - מעילה";
                case "030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L2.txt":
                    return "תלמוד בבלי - מעילה - רש''י";
                case "030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L1.txt":
                    return "תלמוד בבלי - מעילה";

                case "030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L3.txt":
                    return "תלמוד בבלי - מעילה - תוספות";
                case "030_BAVLI\\37_MAS_MEILA\\DebugMix.txt":
                    return "מסכת מעילה";
                case "030_BAVLI\\37_MAS_MEILA\\HavAll.txt":
                    return "חברותא - מעילה";
                case "030_BAVLI\\37_MAS_MEILA\\HavTempNoNotes.txt":
                    return "חברותא - מעילה - בלי הערות";
                case "030_BAVLI\\37_MAS_MEILA\\HavTempNotes.txt":
                    return "חברותא -  מעילה - הערות";
                case "030_BAVLI\\38_MAS_TAMID":
                    return "תלמוד בבלי - תמיד";
                case "030_BAVLI\\38_MAS_TAMID\\BAV TAMID_L2.txt":
                    return "[2] תלמוד בבלי - תמיד - פירוש";
                case "030_BAVLI\\38_MAS_TAMID\\BAV TAMID_L1.txt":
                    return "[1] תלמוד בבלי - תמיד - פירוש";

                case "030_BAVLI\\38_MAS_TAMID\\DebugMix.txt":
                    return "מסכת תמיד";
                case "030_BAVLI\\38_MAS_TAMID\\HavAll.txt":
                    return "חברותא - תמיד";
                case "030_BAVLI\\38_MAS_TAMID\\HavTempNoNotes.txt":
                    return "חברותא - תמיד - בלי הערות";
                case "030_BAVLI\\38_MAS_TAMID\\HavTempNotes.txt":
                    return "חברותא - תמיד - הערות";
                case "030_BAVLI\\39_MAS_NIDA":
                    return "תלמוד בבלי - נדה";
                case "030_BAVLI\\39_MAS_NIDA\\Bav Nida_L2.txt":
                    return "תלמוד בבלי - נדה - רש''י";
                case "030_BAVLI\\39_MAS_NIDA\\Bav Nida_L1.txt":
                    return "תלמוד בבלי - נדה";

                case "030_BAVLI\\39_MAS_NIDA\\Bav Nida_L3.txt":
                    return "תלמוד בבלי - נדה - תוספות";
                case "030_BAVLI\\39_MAS_NIDA\\Bav Nida_L6_rashba.txt":
                    return "רשב''א - מסכת נדה";
                case "030_BAVLI\\39_MAS_NIDA\\DebugMix.txt":
                    return "מסכת נדה";
                case "030_BAVLI\\39_MAS_NIDA\\HavAll.txt":
                    return "חברותא - נידה";
                case "030_BAVLI\\39_MAS_NIDA\\HavTempNoNotes.txt":
                    return "חברותא - נידה - בלי הערות";
                case "030_BAVLI\\39_MAS_NIDA\\HavTempNotes.txt":
                    return "חברותא - נידה - הערות";
                case "030_BAVLI\\29_MAS_EDUYOT\\Bav EDUYOT_L1.txt":
                    return "תלמוד בבלי - עדיות";
                case "Books\040_HALACHA1\030_orach_chaim_merged.txt":
                    return "שלחן ערוך - אורח חיים";


                case "035_RAMBAM\\00000_RAMBAM-MRG_NEW.txt":
                    return "הקדמת הרמב''ם למשנה תורה";
                case "035_RAMBAM\\00001_RAMBAM-MRG_L1.txt":
                    return "רמב''ם משנה תורה - ספר המצוות";
                case "035_RAMBAM\\00002_mada_merged.txt":
                    return "משנה תורה - ספר מדע";
                case "035_RAMBAM\\00003_ahava_merged.txt":
                    return "משנה תורה - ספר אהבה";
                case "035_RAMBAM\\00004_zmanim_merged.txt":
                    return "משנה תורה - ספר זמנים";
                case "035_RAMBAM\\00005_nashim_merged.txt":
                    return "משנה תורה - ספר נשים";
                case "035_RAMBAM\\00006_kdusha_merged.txt":
                    return "משנה תורה - ספר קדושה";
                case "035_RAMBAM\\00007_haflaa_merged.txt":
                    return "משנה תורה - ספר הפלאה";
                case "035_RAMBAM\\00008_zraiim_merged.txt":
                    return "משנה תורה - ספר זרעים";
                case "035_RAMBAM\\00009_avoda_merged.txt":
                    return "משנה תורה - ספר עבודה";
                case "035_RAMBAM\\00010_korbanot_merged.txt":
                    return "משנה תורה - ספר קרבנות";
                case "035_RAMBAM\\00011_tahara_merged.txt":
                    return "משנה תורה - ספר טהרה";
                case "035_RAMBAM\\00012_nezikin_merged.txt":
                    return "משנה תורה - ספר נזיקין";
                case "035_RAMBAM\\00013_kinyan_merged.txt":
                    return "משנה תורה - ספר קנין";
                case "035_RAMBAM\\00014_mishpatim_merged.txt":
                    return "משנה תורה - ספר משפטים";
                case "035_RAMBAM\\00015_shoftim_merged.txt":
                    return "משנה תורה - ספר שופטים";
                case "035_RAMBAM\\0020_RAMBAM-MRG_L0.txt":
                    return "הקדמת הרמב''ם למשנה תורה";

                case "035_RAMBAM\\0040_RAMBAM AHAVA_L1.txt":
                    return "משנה תורה - ספר אהבה";
                case "035_RAMBAM\\0050_RAMBAM-ZMANIM_L1.txt":
                    return "משנה תורה - ספר זמנים";
                case "035_RAMBAM\\0060_RAMBAM-NASHIM_L1.txt":
                    return "משנה תורה - ספר נשים";
                case "035_RAMBAM\\0070_RAMBAM KDUSHA_L1.txt":
                    return "משנה תורה - ספר קדושה";
                case "035_RAMBAM\\0080_RAMBAM-HAFLAA_L1.txt":
                    return "משנה תורה - ספר הפלאה";
                case "035_RAMBAM\\0090_RAMBAM_ZRAIIM_L1.txt":
                    return "משנה תורה - ספר זרעים";
                case "035_RAMBAM\\0100_RAMBAM AVODA_L1.txt":
                    return "משנה תורה - ספר עבודה";
                case "035_RAMBAM\\0110_RAMBAM KORBANOT_L1.txt":
                    return "משנה תורה - ספר הקרבנות";
                case "035_RAMBAM\\0120_RAMBAM TAHARA_L1.txt":
                    return "משנה תורה - ספר טהרה";
                case "035_RAMBAM\\0130_RAMBAM NEZIKIN_L1.txt":
                    return "משנה תורה - ספר נזיקין";
                case "035_RAMBAM\\0140_RAMBAM_KINYAN_L1.txt":
                    return "משנה תורה - ספר קנין";
                case "035_RAMBAM\\0150_RAMBAM_MISPATIM_L1.txt":
                    return "משנה תורה - ספר משפטים";
                case "035_RAMBAM\\0160_RAMBAM_SHOFTIM_L1.txt":
                    return "משנה תורה - ספר שופטים";
                case "035_RAMBAM\\0030_RAMBAM_MADA_L1.txt":

                    return "רמב''ם משנה תורה - ספר מדע";
                case "035_RAMBAM\\90002_mada.txt":
                    return "רמב''ם משנה תורה - ספר מדע";
                case "035_RAMBAM\\90002_mada_kesef.txt":
                    return "כסף משנה - מדע";
                case "035_RAMBAM\\90002_mada_lechem.txt":
                    return "לחם משנה - מדע";
                case "035_RAMBAM\\90002_mada_perush.txt":
                    return "פירוש - ספר מדע";
                case "035_RAMBAM\\90002_mada_raavad.txt":
                    return "השגות הראב''ד - מדע";
                case "035_RAMBAM\\90003_ahava.txt":
                    return "רמב''ם משנה תורה - ספר אהבה";
                case "035_RAMBAM\\90003_ahava_kesef.txt":
                    return "כסף משנה - אהבה";
                case "035_RAMBAM\\90003_ahava_lechem.txt":
                    return "לחם משנה - אהבה";
                case "035_RAMBAM\\90003_ahava_raavad.txt":
                    return "השגות הראב''ד - אהבה";
                case "035_RAMBAM\\90004_zmanim.txt":
                    return "רמב''ם משנה תורה - ספר זמנים";
                case "035_RAMBAM\\90004_zmanim_haviv.txt":
                    return "מהר''ל נ' חביב - זמנים";
                case "035_RAMBAM\\90004_zmanim_kesef.txt":
                    return "כסף משנה - זמנים";
                case "035_RAMBAM\\90004_zmanim_lechem.txt":
                    return "לחם משנה - זמנים";
                case "035_RAMBAM\\90004_zmanim_magid.txt":
                    return "מגיד משנה - זמנים";
                case "035_RAMBAM\\90004_zmanim_perush.txt":
                    return "פירוש - זמנים";
                case "035_RAMBAM\\90004_zmanim_raavad.txt":
                    return "השגות הראב''ד - זמנים";
                case "035_RAMBAM\\90005_nashim.txt":
                    return "רמב''ם משנה תורה - ספר נשים";
                case "035_RAMBAM\\90005_nashim_kesef.txt":
                    return "כסף משנה - נשים";
                case "035_RAMBAM\\90005_nashim_lechem.txt":
                    return "לחם משנה - נשים";
                case "035_RAMBAM\\90005_nashim_magid.txt":
                    return "מגיד משנה - נשים";
                case "035_RAMBAM\\90005_nashim_raavad.txt":
                    return "השגות הראב''ד - נשים";
                case "035_RAMBAM\\90006_kdusha.txt":
                    return "רמב''ם משנה תורה - ספר קדושה";
                case "035_RAMBAM\\90006_kdusha_kesef.txt":
                    return "כסף משנה - קדושה";
                case "035_RAMBAM\\90006_kdusha_lechem.txt":
                    return "לחם משנה - קדושה";
                case "035_RAMBAM\\90006_kdusha_magid.txt":
                    return "מגיד משנה - קדושה";
                case "035_RAMBAM\\90006_kdusha_raavad.txt":
                    return "השגות הראב''ד - קדושה";
                case "035_RAMBAM\\90007_haflaa.txt":
                    return "רמב''ם משנה תורה - ספר הפלאה";
                case "035_RAMBAM\\90007_haflaa_kesef.txt":
                    return "כסף משנה - הפלאה";
                case "035_RAMBAM\\90007_haflaa_lechem.txt":
                    return "לחם משנה - הפלאה";
                case "035_RAMBAM\\90007_haflaa_raavad.txt":
                    return "השגות הראב''ד - הפלאה";
                case "035_RAMBAM\\90008_zraiim.txt":
                    return "רמב''ם משנה תורה - ספר זרעים";
                case "035_RAMBAM\\90008_zraiim_kesef.txt":
                    return "כסף משנה - זרעים";
                case "035_RAMBAM\\90008_zraiim_raavad.txt":
                    return "השגות הראב''ד - זרעים";
                case "035_RAMBAM\\90009_avoda.txt":
                    return "רמב''ם משנה תורה - ספר עבודה";
                case "035_RAMBAM\\90009_avoda_kesef.txt":
                    return "כסף משנה - עבודה";
                case "035_RAMBAM\\90009_avoda_raavad.txt":
                    return "השגות הראב''ד - עבודה";
                case "035_RAMBAM\\90010_korbanot.txt":
                    return "רמב''ם משנה תורה - ספר קרבנות";
                case "035_RAMBAM\\90010_korbanot_kesef.txt":
                    return "כסף משנה - קרבנות";
                case "035_RAMBAM\\90010_korbanot_raavad.txt":
                    return "השגות הראב''ד - קרבנות";
                case "035_RAMBAM\\90011_tahara.txt":
                    return "רמב''ם משנה תורה - ספר טהרה";
                case "035_RAMBAM\\90011_tahara_kesef.txt":
                    return "כסף משנה - ספר טהרה";
                case "035_RAMBAM\\90011_tahara_raavad.txt":
                    return "השגות הראב''ד - טהרה";
                case "035_RAMBAM\\90012_nezikin.txt":
                    return "רמב''ם משנה תורה - ספר נזיקין";
                case "035_RAMBAM\\90012_nezikin_kesef.txt":
                    return "כסף משנה-ספר נזיקין";
                case "035_RAMBAM\\90012_nezikin_magid.txt":
                    return "מגיד משנה - ספר נזיקין";
                case "035_RAMBAM\\90012_nezikin_raavad.txt":
                    return "השגות הראב''ד - נזיקין";
                case "035_RAMBAM\\90013_kinyan.txt":
                    return "רמב''ם משנה תורה - ספר קנין";
                case "035_RAMBAM\\90013_kinyan_kesef.txt":
                    return "כסף משנה - קנין";
                case "035_RAMBAM\\90013_kinyan_magid.txt":
                    return "מגיד משנה - ספר קנין";
                case "035_RAMBAM\\90013_kinyan_raavad.txt":
                    return "השגות הראב''ד - קנין";
                case "035_RAMBAM\\90014_mishpatim.txt":
                    return "רמב''ם משנה תורה - ספר משפטים";
                case "035_RAMBAM\\90014_mishpatim_kesef.txt":
                    return "כסף משנה - משפטים";
                case "035_RAMBAM\\90014_mishpatim_magid.txt":
                    return "מגיד משנה - משפטים";
                case "035_RAMBAM\\90014_mishpatim_raavad.txt":
                    return "השגות הראב''ד - משפטים";
                case "035_RAMBAM\\90015_shoftim.txt":
                    return "רמב''ם משנה תורה - ספר שופטים";
                case "035_RAMBAM\\90015_shoftim_kesef.txt":
                    return "כסף משנה-שופטים";
                case "035_RAMBAM\\90015_shoftim_raavad.txt":
                    return "השגות הראב''ד - שופטים";
                case "035_RAMBAM\\99999_00001_RAMBAM-MRG_NEW.txt":
                    return "רמב''ם משנה תורה - ספר המצוות";
                case "040_HALACHA1":
                    return "שלחן ערוך - אורח חיים";
                case "040_HALACHA1\\031_yore_deaa_merged.txt":
                    return "שלחן ערוך - יורה דעה";
                case "040_HALACHA1\\032_even_haezer_merged.txt":
                    return "שלחן ערוך - אבן העזר";
                case "040_HALACHA1\\033_choshen_mishpat_merged.txt":
                    return "שלחן ערוך - חשן משפט";
                case "040_HALACHA1\\040_orach_chaim_menukad.txt":
                    return "שלחן ערוך - אורח חיים - מנוקד";
                case "040_HALACHA1\\041_yore_deaa_menukad.txt":
                    return "שלחן ערוך - יורה דעה - מנוקד";
                case "040_HALACHA1\\042_even_haezer_menukad.txt":
                    return "שלחן ערוך - אבן העזר - מנוקד";
                case "040_HALACHA1\\043_choshen_mishpat_menukad.txt":
                    return "שלחן ערוך - חשן משפט - מנוקד";
                case "040_HALACHA1\\050_orach_chaim_baer_heitev.txt":
                    return "שלחן ערוך או''ח - באר היטב";
                case "040_HALACHA1\\051_yore_deaa_baer_heitev.txt":
                    return "שלחן ערוך יו''ד - באר היטב";
                case "040_HALACHA1\\052_even_haezer_baer_heitev.txt":
                    return "שלחן ערוך אה''ע - באר היטב";
                case "040_HALACHA1\\053_choshen_mishpat_baer_heitev.txt":
                    return "שלחן ערוך חו''מ - באר היטב";
                case "040_HALACHA1\\060_orach_chaim.txt":
                    return "שלחן ערוך - אורח חיים - לא מנוקד";
                case "040_HALACHA1\\061_yore_deaa.txt":
                    return "שלחן ערוך - יורה דעה - לא מנוקד";
                case "040_HALACHA1\\063_choshen_mishpat.txt":
                    return "שלחן ערוך - חשן משפט - לא מנוקד";
                case "040_HALACHA1\\080_hinuch.txt":
                    return "ספר החינוך";
                case "040_HALACHA1\\081_aruch_hasulchan1.txt":
                    return "ערוך השולחן - אורח חיים";
                case "040_HALACHA1\\082_mishna_brura_merged.txt":
                    return "משנה ברורה";
                case "040_HALACHA1\\083_mishna_brura.txt":
                    return "משנה ברורה";
                case "040_HALACHA1\\084_mishna_brura_beur_halacha.txt":
                    return "ביאור הלכה";
                case "040_HALACHA1\\085_mishna_brura_maran_rama.txt":
                    return "משנה ברורה - מרן ורמא";
                case "040_HALACHA1\\105_kitzur.txt":
                    return "קיצור שולחן ערוך";
                case "040_HALACHA1\\106_0_0_hh_L1.txt":
                    return "חפץ חיים";
                case "000_HORADOT\\200_PARSHA\\050_ben_ish_chai.txt":
                    return "בן איש חי";
                case "040_HALACHA1\\106_0_1_geder_olam.txt":
                    return "ספר גדר עולם";
                case "040_HALACHA1\\106_1_KITZUR_YALKUT_YOSEF.txt":
                    return "קיצור ש''ע ילקוט יוסף";
                case "040_HALACHA1\\106_2_OTSAR_DINIM.txt":
                    return "אוצר דינים לאשה ולבת";
                case "042_HALACHA2":
                    return "ספר החיים";
                case "042_HALACHA2\\109_shaar_hazahav_latahara.txt":
                    return "שער הזהב לטהרה";
                case "042_HALACHA2\\110_1_nesuin_ve_ishut.txt":
                    return "נשואין ואישות";
                case "042_HALACHA2\\110_2_tahara2.txt":
                    return "טהרה הריון ולידה כהלכה";
                case "042_HALACHA2\\111_yikra_dechayei.txt":
                    return "הלכות ביקור חולים ואבלות - יקרא דחיי";
                case "042_HALACHA2\\112_yikra_dechayei - notes.txt":
                    return "מראה מקומות והערות לספר יקרא דחיי";
                case "042_HALACHA2\\115_piske_moshe_hanuka.txt":
                    return "הלכות חנוכה - פסקי משה";
                case "042_HALACHA2\\116_PatBag.txt":
                    return "פתבג המלך";
                case "042_HALACHA2\\117_TaharatKelim.txt":
                    return "טהרת כלים";
                case "042_HALACHA2\\170_kol_eliyahu.txt":
                    return "ספר קול אליהו";
                case "042_HALACHA2\\180_MarotHatsovot.txt":
                    return "מראות הצובאות";
                case "042_HALACHA2\\181_machanecha_kadosh.txt":
                    return "ספר מחניך קדוש";
                case "042_HALACHA2\\201_shabat.txt":
                    return "שבת כהלכה";
                case "042_HALACHA2\\202_yeladim.txt":
                    return "ילדים כהלכה";
                case "042_HALACHA2\\203_NashimBahalacha.txt":
                    return "נשים בהלכה";
                case "042_HALACHA2\\204_ShmiratEnaiim.txt":
                    return "שמירת עיניים כהלכה";
                case "042_HALACHA2\\205_veaavta_kahalacha.txt":
                    return "ואהבת כהלכה";
                case "042_HALACHA2\\220_VeenLamoTora.txt":
                    return "ואין למו מכשול - הלכות תלמוד תורה";
                case "042_HALACHA2\\221_VeenLamoChesed.txt":
                    return "ואין למו מכשול - הלכות גמילות חסדים";
                case "042_HALACHA2\\223_VeenLamoTshuva.txt":
                    return "ואין למו מכשול - חלק י'";
                case "042_HALACHA2\\224_VeenLamoLifneiIver.txt":
                    return "ואין למו מכשול - חלק ה'";
                case "042_HALACHA2\\230_neki_kapaiim.txt":
                    return "נקי כפים";
                case "042_HALACHA2\\231_tolaiim.txt":
                    return "קדושים תהיו על הלכות תולעים";
                case "042_HALACHA2\\299_kashrut_gamitbach.txt":
                    return "כשרות המטבח";
                case "042_HALACHA2\\300_bahalacha_ubaagada_kibid_horim.txt":
                    return "כבוד אב ואם - בהלכה ובאגדה";
                case "042_HALACHA2\\301_bahalacha_ubaagada_mitsvot_haarets.txt":
                    return "מצוות הארץ - בהלכה ובאגדה";
                case "042_HALACHA2\\301_bahalacha_ubaagada_shabat.txt":
                    return "השבת בהלכה ובאגדה";
                case "042_HALACHA2\\302_bahalacha_ubaagada_tahara.txt":
                    return "הטהרה בהלכה ובאגדה";
                case "042_HALACHA2\\303_hilchot_seuda.txt":
                    return "הלכות סעודה";
                case "042_HALACHA2\\304_seder_hayom.txt":
                    return "סדר היום בהלכה ובאגדה";
                case "042_HALACHA2\\305_rosh_hodesh_bahalacha_ubaagada.txt":
                    return "ראש חודש בהלכה ובאגדה";
                case "042_HALACHA2\\400_piskei_moshe_hagaala_lepesach.txt":
                    return "הלכות הגעלת כלים לפסח";
                case "042_HALACHA2\\400_piskei_moshe_hagaala_lepesach.txt.notes.txt":
                    return "הערות פסקי משה - הלכות הגעלת כלים לפסח";
                case "042_HALACHA2\\401_mishna_brura_smicha_lerabanut.txt":
                    return "משנה ברורה";
                case "042_HALACHA2\\410_beyom_hashabat.txt":
                    return "וביום השבת";
                case "042_HALACHA2\\420_shay_basar_bechalav.txt":
                    return "מנחת שי - הלכות בשר בחלב";
                case "042_HALACHA2\\421_shay_tvilat_kelim.txt":
                    return "מנחת שי - הלכות טבילת כלים";
                case "042_HALACHA2\\430_holchot_yichud.txt":
                    return "גן נעול - על הלכות ייחוד";
                case "042_HALACHA2\\430_holchot_yichud.txt.notes.txt":
                    return "הערות להלכות יחוד";
                case "042_HALACHA2\\440_midot.txt":
                    return "שלחן ערוך המדות - א";
                case "042_HALACHA2\\441_midot2.txt":
                    return "שלחן ערוך המדות - ב";
                case "042_HALACHA2\\442_midot3.txt":
                    return "שלחן ערוך המדות - ג";
                case "042_IYUNIM\\028_vekane.txt":
                    return "וקָנֶה לך חבר";
                case "042_IYUNIM\\029_ShaarAsher.txt":
                    return "שער אשר - הלכות נדה";
                case "042_IYUNIM\\030_RavZilber1.txt":
                    return "בעניין מספר הפסוקים התיבות והאותיות בתורה";
                case "042_IYUNIM\\040_nachalot.txt":
                    return "בעניין הנחלות בארץ ישראל";
                case "042_IYUNIM\\050_BeerYaakovHavurot.txt":
                    return "באר יעקב - חבורות";
                case "042_IYUNIM\\051_BeerYaakovAgadot.txt":
                    return "ספר באר יעקב - אגדות הש''ס";
                case "042_IYUNIM\\070_YosefLekachMishlei.txt":
                    return "יוסף לקח - משלי";
                case "042_IYUNIM\\080_sheiya.txt":
                    return "קונטרס בגדרי שהייה וחזרה";
                case "042_IYUNIM\\090_machsevet_cohen.txt":
                    return "מחשבת כהן";
                case "042_IYUNIM\\100_minhat_shay_tfila_ad_brachot.txt":
                    return "מנחת שי - הלכות";
                case "042_IYUNIM\\100_minhat_shay_yom_tov.txt":
                    return "מנחת שי - הלכות יום טוב";
                case "042_IYUNIM\\110_birchat_israel.txt":
                    return "ספר ברכת ישראל";
                case "042_IYUNIM\\120_YadHaleviMetsia.txt":
                    return "יד הלוי - מסכת בבא מציעא";
                case "042_IYUNIM\\230_minchat_israel.txt":
                    return "ספר מנחת ישראל";
                case "042_IYUNIM\\240_maor_moadim.txt":
                    return "מאור המועדים";
                case "100_MUSAR\\010_mesilat_yesharim.TXT":
                    return "מסילת ישרים";
                case "100_MUSAR\\011_orchot_tsadikim.TXT":
                    return "אורחות צדיקים";
                case "100_MUSAR\\012_ShaareiTeshuva.txt":
                    return "שערי תשובה";
                case "100_MUSAR\\012_chovot_halevavot.txt":
                    return "חובות הלבבות";
                case "100_MUSAR\\013_TomerDevora.txt":
                    return "תומר דבורה";
                case "100_MUSAR\\014_derech_hashem.txt":
                    return "דרך השם";
                case "100_MUSAR\\015_SeferHayashar.txt":
                    return "ספר הישר";
                case "100_MUSAR\\020_igeret_haramban.TXT":
                    return "אגרת הרמב''ן";
                case "100_MUSAR\\023_igeret_teiman.txt":
                    return "אגרת תימן להרמב''ם ז''ל";
                case "100_MUSAR\\024_ShmiratHalashon_L1.txt":
                    return "שמירת הלשון";
                case "100_MUSAR\\025_NEFESH_HAHAIM_L1.txt":
                    return "נפש החיים";
                case "100_MUSAR\\035_pele.txt":
                    return "פלא יועץ";
                case "100_MUSAR\\070_EvedHashem_L1.txt":
                    return "עבד השם";
                case "100_MUSAR\\070_emuna_maasit.txt":
                    return "קובץ אמונה מעשית";
                case "100_MUSAR\\071_bilvavi1.txt":
                    return "בלבבי משכן אבנה - א";
                case "100_MUSAR\\072_bilvavi2.txt":
                    return "בלבבי משכן אבנה - ב";
                case "100_MUSAR\\073_bilvavi3.txt":
                    return "בלבבי משכן אבנה - ג";
                case "100_MUSAR\\073_bilvavi4.txt":
                    return "בלבבי משכן אבנה - ד";
                case "100_MUSAR\\076_bilvavi6.txt":
                    return "בלבבי משכן אבנה - ו";
                case "100_MUSAR\\079_bilvavi9.txt":
                    return "בלבבי משכן אבנה - ט";
                case "100_MUSAR\\090_NerLeragli.txt":
                    return "נר לרגלי";
                case "100_MUSAR\\091_OrLintivati.txt":
                    return "אור לנתיבתי";
                case "100_MUSAR\\095_BikvetaDimsiha.txt":
                    return "בעיקבתא דמשיחא";
                case "100_MUSAR\\096_BerumoShelOlam.txt":
                    return "ברומו של עולם - על התפילה";
                case "100_MUSAR\\097_ShuvaIsrael.txt":
                    return "שובה ישראל";
                case "100_MUSAR\\110_BINYAMIN_L1.txt":
                    return "בני בנימין - על מסכת אבות";
                case "100_MUSAR\\115_ShuviNafshi.txt":
                    return "שובי נפשי";
                case "100_MUSAR\\130_machane_shechina.TXT":
                    return "מחנה שכינה";
                case "100_MUSAR\\200_ANAVA_L1.txt":
                    return "ואנכי עפר ואפר - מעלות הענווה";
                case "100_MUSAR\\300_menorat_hamaor.txt":
                    return "מנורת המאור";
                case "100_MUSAR\\310_Avot_Israel.txt":
                    return "אבות ישראל - על פרקי אבות";
                case "100_MUSAR\\320_imrei_yechezkel.txt":
                    return "אמרי יחזקאל";
                case "100_MUSAR\\321_imeri_yechezkel_maagal_hachaiim.txt":
                    return "אמרי יחזקאל - מעגל החיים";
                case "100_MUSAR\\400_pardes_rimonim_1.txt":
                    return "פרדס רמונים - חלק א";
                case "100_MUSAR\\401_pardes_rimonim_2.txt":
                    return "פרדס רימונים - חלק ב";
                case "100_MUSAR\\500_chai_1.txt":
                    return "חי באמונה א - חי באמונה";
                case "100_MUSAR\\501_chai_2.txt":
                    return "חי באמונה ב - אהבת עולם אהבתנו";
                case "100_MUSAR\\502_chai_3.txt":
                    return "חי באמונה ג  -  ישמח ישראל";
                case "100_MUSAR\\503_chai_4.txt":
                    return "חי באמונה ד  -  אוצר החיים";
                case "100_MUSAR\\504_chai_5.txt":
                    return "חי באמונה ה  -  כל עכבה לטובה";
                case "100_MUSAR\\505_chai_betoda.txt":
                    return "חי בתודה";
                case "100_MUSAR\\510_chaya_beemuna.txt":
                    return "חיה באמונה";
                case "100_MUSAR\\600_vayetse_itschak.txt":
                    return "ויצא יצחק לשוח - א";
                case "100_MUSAR\\610_amal_israel.txt":
                    return "ספר עמל ישראל";
                case "106_KABALA\\000025_Hakdamot.txt":
                    return "הקדמת ספר הזוהר";
                case "106_KABALA\\000021_ZOHAR1_L1.txt":
                    return "הזוהר הקדוש - ספר בראשית";
                case "106_KABALA\\000021_ZOHAR2_L1.txt":
                    return "הזוהר הקדוש - ספר שמות";
                case "106_KABALA\\000021_ZOHAR3_L1.txt":
                    return "הזוהר הקדוש - ספר ויקרא";
                case "106_KABALA\\000021_ZOHAR4_L1.txt":
                    return "הזוהר הקדוש - ספר במדבר";
                case "106_KABALA\\000021_ZOHAR5_L1.txt":
                    return "הזוהר הקדוש - ספר דברים";
                case "106_KABALA\\000022_ZOHAR6-tikunim_L1.txt":
                    return "תיקוני הזוהר";
                case "106_KABALA\\000022_ZOHAR7-hadash_L1.txt":
                    return "זוהר חדש";
                case "106_KABALA\\000023_ZOHAR-VETARGUM-0.txt":
                    return "הזוהר המתורגם - הקדמת ספר הזוהר";
                case "106_KABALA\\000023_ZOHAR-VETARGUM-1.txt":
                    return "הזוהר המתורגם - ספר בראשית";
                case "106_KABALA\\000023_ZOHAR-VETARGUM-2.txt":
                    return "הזוהר המתורגם - ספר שמות";
                case "106_KABALA\\000023_ZOHAR-VETARGUM-3.txt":
                    return "הזוהר המתורגם - ספר ויקרא";
                case "106_KABALA\\000023_ZOHAR-VETARGUM-4.txt":
                    return "הזוהר המתורגם - ספר במדבר";
                case "106_KABALA\\000023_ZOHAR-VETARGUM-5.txt":
                    return "הזוהר המתורגם - ספר דברים";
                case "106_KABALA\\000023_ZOHAR-VETARGUM-6.txt":
                    return "הזוהר המתורגם - תיקוני הזוהר";
                case "106_KABALA\\000023_ZOHAR-VETARGUM-7.txt":
                    return "הזוהר המתורגם - זוהר חדש";
                case "106_KABALA\\000024_MaamarHaIkarim.txt":
                    return "מאמר העיקרים";
                case "106_KABALA\\000024_drashat_haramban.txt":
                    return "דרשת הרמב''ן";

                case "106_KABALA\\000026_PtichaLakabala.txt":
                    return "פתיחה לחכמת הקבלה";
                case "106_KABALA\\000027_MavoLazohar.txt":
                    return "מבוא לספר הזהר";
                case "106_KABALA\\006_sefer_hapliaa.txt":
                    return "ספר הפליאה";
                case "106_KABALA\\010_shaar_hakaavnot.TXT":
                    return "שער הכוונות";
                case "106_KABALA\\011_magid_meisharim.TXT":
                    return "ספר מגיד מישרים";
                case "106_KABALA\\012_sefer_habahir.TXT":
                    return "ספר הבהיר";
                case "106_KABALA\\013_sefer_hachashmal.TXT":
                    return "ספר החשמל";
                case "106_KABALA\\014_sefer_yezira.TXT":
                    return "ספר יצירה";
                case "106_KABALA\\015_p_ramban_sefer_yezira.TXT":
                    return "פירוש הרמב''ן לספר יצירה";
                case "106_KABALA\\016_p_ramak_sefer_yezira.txt":
                    return "פירוש הרמ''ק לספר יצירה";
                case "106_KABALA\\017_sifra_detsniuta.txt":
                    return "ספרא דצניעותא";
                case "106_KABALA\\018_shaarei_kedusha.TXT":
                    return "ספר שערי קדושה";
                case "106_KABALA\\020_DAAT_TVUNOT.txt":
                    return "ספר שקל הקדש";
                case "106_KABALA\\020_shla.TXT":
                    return "ספר תולדות אדם";
                case "106_KABALA\\021_DaatTvunot.txt":
                    return "דעת תבונות";
                case "106_KABALA\\052_MatanToraRavAshlag.txt":
                    return "מתן תורה";
                case "106_KABALA\\053_TenPrakinLaRanchal.txt":
                    return "עשרה פרקים להרמח''ל";
                case "110_CHASIDUT":
                    return "לִקּוּטֵי אֲמָרִים תַּנְיָא";
                case "110_CHASIDUT\\046_taniya_3.txt":
                    return "ספר התניא - אגרת התשובה";
                case "110_CHASIDUT\\070_LikuteiMuharan_A_BreslevOrg.txt":
                    return "ליקוטי מוהר''ן - חלק א";
                case "110_CHASIDUT\\070_LikuteiMuharan_B_BreslevOrg.txt":
                    return "ליקוטי מוהר''ן - חלק ב";
                case "110_CHASIDUT\\070_moharan_1.txt":
                    return "ליקוטי מוהר''ן - חלק א";
                case "110_CHASIDUT\\071_moharan_2.txt":
                    return "ליקוטי מוהר''ן - חלק ב";
                case "110_CHASIDUT\\072_midot.txt":
                    return "ספר המידות";
                case "110_CHASIDUT\\073_meshivat_nefesh.txt":
                    return "משיבת נפש";
                case "110_CHASIDUT\\100_kitsur_likutei.txt":
                    return "קיצור ליקוטי מוהר''ן השלם";
                case "112_HANHAGOT":
                    return "אנשי קודש";
                case "112_HANHAGOT\\0_OrchotHaiim.txt":
                    return "ארחות חיים";
                case "112_HANHAGOT\\1_hanagot_yom_yom.TXT":
                    return "הנהגות יום יום";
                case "112_HANHAGOT\\2_hanhagot_aiin_tova.TXT":
                    return "הנהגות עין טובה";
                case "112_HANHAGOT\\3_hanhagot_leshabat_kodesh.TXT":
                    return "הנהגות לשבת קודש";
                case "112_HANHAGOT\\4_kontras_shabat_kodesk.TXT":
                    return "קונטרס שבת קודש";
                case "112_HANHAGOT\\5_zohar_shabat_kodesh.TXT":
                    return "פניני הזוהר לשבת קודש";
                case "112_HANHAGOT\\6_hanhagot_leshabat_kodesh_2.txt":
                    return "הנהגות לשבת קודש - חלק ב";
                case "112_HANHAGOT\\7_avelim.txt":
                    return "הנהגות ועצות מעשיות לאבלים";
                case "112_HANHAGOT\\8_emula_maasit.txt":
                    return "הנהגות אמונה מעשית";
                case "112_HANHAGOT\\SAVIV_L1.txt":
                    return "סביב למשפחה";
                case "112_HANHAGOT\\elul.txt":
                    return "הנהגות חודש אלול וימים נוראים";
                case "112_HANHAGOT\\igeret_leben_tora.txt":
                    return "קונטרס - אגרת לבן תורה";
                case "115_PARSHA\\008_bd1.txt":
                    return "בים דרך - בראשית";
                case "115_PARSHA\\008_bd2.txt":
                    return "בים דרך - שמות";
                case "115_PARSHA\\008_bd3.txt":
                    return "בים דרך - ויקרא";
                case "115_PARSHA\\008_bd4.txt":
                    return "בים דרך - במדבר";
                case "115_PARSHA\\008_bd5.txt":
                    return "בים דרך - דברים";
                case "115_PARSHA\\010_TIFERET_L1.txt":
                    return "תפארת ישראל";
                case "115_PARSHA\\050_NerTamidHaravBrener.txt":
                    return "נר תמיד - על פרשת השבוע";
                case "115_PARSHA\\070_PriHanan1.txt":
                    return "פרי חנן על התורה - בראשית";
                case "115_PARSHA\\070_PriHanan2.txt":
                    return "פרי חנן על התורה - שמות";
                case "115_PARSHA\\080_YagelYaakovTora.txt":
                    return "יגל יעקב - על פרשת השבוע";
                case "115_PARSHA\\090_bacharta_bachaiim.txt":
                    return "ובחרת בחיים";
                case "115_PARSHA\\100_BeerYaakovTora.txt":
                    return "באר יעקב על התורה";
                case "115_PARSHA\\101_SipurMinHahaftara1.txt":
                    return "סיפור מן ההפטרה - בראשית";
                case "115_PARSHA\\102_SipurMinHahaftara2.txt":
                    return "סיפור מן ההפטרה - שמות";
                case "115_PARSHA\\103_SipurMinHahaftara3.txt":
                    return "סיפור מן ההפטרה - ויקרא";
                case "115_PARSHA\\104_SipurMinHahaftara4.txt":
                    return "סיפור מן ההפטרה - במדבר";
                case "115_PARSHA\\105_SipurMinHahaftara5.txt":
                    return "סיפור מן ההפטרה - דברים";
                case "115_PARSHA\\106_PneiDavid.txt":
                    return "פני דוד - על התורה";
                case "115_PARSHA\\110_dovev.txt":
                    return "דובב שפתי ישנים";
                case "115_PARSHA\\120_pninei_ynon_veeliyahu.txt":
                    return "פניני ינון ואליהו - על הפרשה";
                case "115_PARSHA\\130_maase_avot.txt":
                    return "באר יעקב - מעשי אבות - בראשית";
                case "115_PARSHA\\140_afikey.txt":
                    return "אפיקי אליהו על התורה";
                case "115_PARSHA\\150_shulchan_melachim_al_hatora.txt":
                    return "מיד מלכים - על התורה";
                case "115_PARSHA\\160_siman_levanim.txt":
                    return "סימן לבנים - שמות";
                case "115_PARSHA\\170_miyad_melachim_tora.txt":
                    return "ספר מיד מלכים - על התורה";
                case "118_HAGIM\\080_MISHPETE_L1.txt":
                    return "משפטי ישראל - על חגי ומועדי ישראל";
                case "118_HAGIM\\090_beer_yaakov_moadim.txt":
                    return "באר יעקב - מועדים";
                case "118_HAGIM\\100_arba_taaniot_naki.txt":
                    return "ארבע התעניות ובין המצרים";
                case "118_HAGIM\\101_yamim_noraiim_kaki.txt":
                    return "הימים הנוראים בהלכה ובאגדה";
                case "118_HAGIM\\102_sukot_naki.txt":
                    return "חג הסוכות בהלכה ובאגדה";
                case "118_HAGIM\\103_hanuka_naki.txt":
                    return "ימי החנוכה בהלכה ובאגדה";
                case "118_HAGIM\\104_kurim_naki.txt":
                    return "ימי הפורים בהלכה ובאגדה";
                case "118_HAGIM\\105_pesach_naki.txt":
                    return "חג הפסח בהלכה והאגדה";
                case "118_HAGIM\\106_shvuot_naki.txt":
                    return "חג השבועות בהלכה ובאגדה";
                case "118_HAGIM\\111_chemdat_yamim_1.txt":
                    return "ספר חמדת ימים - חלק א";
                case "118_HAGIM\\111_chemdat_yamim_2.txt":
                    return "ספר חמדת ימים - חלק ב";
                case "118_HAGIM\\111_chemdat_yamim_3.txt":
                    return "ספר חמדת ימים - חלק ג";
                case "118_HAGIM\\190_HAGADA_L1.txt":
                    return "הגדה של פסח - למען תספר";
                case "118_HAGIM\\191_HAGADA2.txt":
                    return "הגדה של פסח - נוסח אשכנז";
                case "118_HAGIM\\192_HagadaOrDaniel.txt":
                    return "הגדה של פסח - אור דניאל";
                case "118_HAGIM\\193_$_1002_piske_moshe_chanuka.txt":
                    return "הלכות חנוכה - פסקי משה";
                case "118_HAGIM\\200_megilat_hester.txt":
                    return "מגילת הסתר - נס בכל פסוק במגילת אסתר";
                case "118_HAGIM\\440_seder_israel.txt":
                    return "קונטרס סדר ישראל";
                case "118_HAGIM\\520_miyad_melachim_moadim.txt":
                    return "מיד מלכים - שער המועדים";
                case "118_HAGIM\\hagada_for_beit_mikdash.htm":
                    return "hagada_for_beit_mikdash.htm";
                case "120_GDOLEY_HADOROT\\100_seder_hadorot.txt":
                    return "סדר הדורות המקוצר";
                case "120_GDOLEY_HADOROT\\150_hilula.txt":
                    return "ימי הילולא דצדיקיא";
                case "120_GDOLEY_HADOROT\\200_maase_avot.txt":
                    return "ספר מעשי אבות";
                case "120_GDOLEY_HADOROT\\300_david_hamelech.txt":
                    return "דוד המלך ועוצמת התהילים";
                case "120_GDOLEY_HADOROT\\400_maroko.txt":
                    return "ספר קבלת חכמי מרוקו";
                case "120_GDOLEY_HADOROT\\500_iyov.txt":
                    return "אמונה והשגחה מספר איוב";
                case "125_SHUT\\101_NafshiBesheelati1.txt":
                    return "נפשי בשאלתי חלק א - שו''ת";
                case "125_SHUT\\101_NafshiBesheelati2.txt":
                    return "נפשי בשאלתי חלק ב - שו''ת";
                case "125_SHUT\\102_NafshiBesheelati3.txt":
                    return "נפשי בשאלתי חלק ג - שו''ת";
                case "125_SHUT\\150_YismachMoshe_L1.txt":
                    return "ישמח משה - שו''ת";
                case "125_SHUT\\190_VayaanEliyahu.txt":
                    return "ויען אליהו";
                case "125_SHUT\\220_BariachHatichon.txt":
                    return "בריח התיכון";
                case "125_SHUT\\221_MoadeiNissim.txt":
                    return "מועדי ניסים";
                case "125_SHUT\\230_ShutGamAniOdecha.txt":
                    return "שו''ת גם אני אודך - א";
                case "125_SHUT\\231_ShutGamAniOdecha2.txt":
                    return "שו''ת גם אני אודך - ב";
                case "125_SHUT\\232_ShutGamAniOdecha3.txt":
                    return "שו''ת גם אני אודך - ג";
                case "125_SHUT\\240_bechol_drachecha.txt":
                    return "שו''ת בכל דרכיך דעהו";
                case "125_SHUT\\250_ShaolShaal.txt":
                    return "שו''ת שאול שאל - חלק א";
                case "125_SHUT\\251_ShaolShaal_2.txt":
                    return "שו''ת שאול שאל - חלק ב";
                case "125_SHUT\\300_ShutNachalatLevi_1.txt":
                    return "שו''ת נחלת לוי - ח''ב";
                case "125_SHUT\\350_RavSilver1.txt":
                    return "שו''ת עם סגולה - חלק א";
                case "125_SHUT\\350_RavSilver2.txt":
                    return "שו''ת עם סגולה - חלק ב";
                case "125_SHUT\\350_RavSilver3.txt":
                    return "שו''ת עם סגולה - חלק ג";
                case "125_SHUT\\350_RavSilver4.txt":
                    return "שו''ת עם סגולה - חלק ד";
                case "130_HABITE\\700_KolHatanVkolKala.txt":
                    return "קול חתן וקול כלה";
                case "130_HABITE\\701_yavo_ezri.txt":
                    return "קונטרס יבוא עזרי";
                case "130_HABITE\\702_HAOSHER1.txt":
                    return "האושר שבנשואין - לגבר";
                case "130_HABITE\\703_HAOSHER2_L1.txt":
                    return "האושר שבנשואין - לאשה";
                case "130_HABITE\\704_hanhagot_habaite.txt":
                    return "קונטרס הנהגות הבית";
                case "130_HABITE\\705_vayelchu.txt":
                    return "וילכו שניהם יחדיו";
                case "130_HABITE\\706_HINUCH_L1.txt":
                    return "קונטרס - חינוך ילדים";
                case "130_HABITE\\707_ubeitcha_shalom.txt":
                    return "וביתך שלום";
                case "130_HABITE\\800_$_1927_sgulot_lezera_vatifkedenu.txt":
                    return "קונטרס ותפקדנו";
                case "130_HABITE\\810_OhalechaYaakov.txt":
                    return "אוהליך יעקב";
                case "130_HABITE\\820_ose_shalom.txt":
                    return "עושה שלום";
                case "130_HABITE\\830_my_son.txt":
                    return "בני בבת עיני";
                case "130_HABITE\\831_ani_vehanaar.txt":
                    return "אני והנער";
                case "130_HABITE\\832_kabalat_hatora.txt":
                    return "קונטרס קבלת התורה - אבות ובנים";
                case "140_CONTRAS\\500_KontrasLoLaavor.txt":
                    return "קונטרס - שלא לעבור כנגד המתפלל";
                case "140_CONTRAS\\501_KIDUSH_HASHEM_L1.txt":
                    return "קונטרס - המקדש שמו ברבים";
                case "140_CONTRAS\\600_derech_menucha.TXT":
                    return "דרך מנוחה - פירוש לאגרת הרמב''ן";
                case "140_CONTRAS\\720_korbanot.txt":
                    return "מעלת אמירת הקורבנות קודם שחרית";
                case "140_CONTRAS\\750_maalat_hamelamdim.txt":
                    return "קונטרס - מעלת המלמדים";
                case "140_CONTRAS\\801_KolKore.txt":
                    return "קונטרס קול קורא";
                case "140_CONTRAS\\802_lehavat_esh.txt":
                    return "להבת שלהבת קודש";
                case "140_CONTRAS\\820_beriti_shalom.txt":
                    return "קונטרס בריתי שלום";
                case "140_CONTRAS\\821_eyes.txt":
                    return "פסיכולוגיית העין";
                case "140_CONTRAS\\900_likut_kadish.txt":
                    return "קונטרס יתגדל ויתקדש";
                case "140_CONTRAS\\910_igeret_lebat.txt":
                    return "איגרת לבת ישראל היקרה";
                case "140_CONTRAS\\911_shir.txt":
                    return "אחות יקרה";
                case "140_CONTRAS\\930_zipita.txt":
                    return "מאמר צפית לישועה";
                case "140_CONTRAS\\935_levush.txt":
                    return "הלבוש והקישוט מזוית יהודית";
                case "140_CONTRAS\\936_cellular.txt":
                    return "הסלולרי מזוית יהודית";
                case "140_CONTRAS\\950_hidabek.txt":
                    return "מאמר הדבק בחכמים ובתלמידים";
                case "140_CONTRAS\\960_dor_acharon.txt":
                    return "תִּכָּתֶב זֹאת לְדוֹר אַחֲרוֹן";
                case "140_CONTRAS\\961_halevush_leor_hahalacha.txt":
                    return "הלבוש לאור ההלכה";
                case "140_CONTRAS\\962_patach_eliyahu.txt":
                    return "פירוש אור צח - על פתח אליהו";
                case "140_CONTRAS\\963_bikurei_yossef_laiver.txt":
                    return "קונטרס ביכורי יוסף - דברי הלכה ואגדה הנוגעים לעיוור";
                case "140_CONTRAS\\964_$_1927_sgulot_lezera_vatifkedenu.txt":
                    return "קונטרס ותפקדנו";
                case "140_CONTRAS\\965_ben_shtei_nashim.txt":
                    return "קונטרס בחוקותי תלכו";
                case "140_CONTRAS\\966_keri.txt":
                    return "קונטרס יקר בעיני ה'";
                case "140_CONTRAS\\967_vatekas.txt":
                    return "ותכס בצעיף";
                case "140_CONTRAS\\968_simla.txt":
                    return "קונטרס בגדי תפארתך";
                case "140_CONTRAS\\969_mishtamtim.txt":
                    return "המשתמטים";
                case "140_CONTRAS\\970_torato_omanuto.txt":
                    return "קונטרס תורתו אומנותו";
                case "140_CONTRAS\\971_the_best_doctor.txt":
                    return "קונטרס הטוב שברופאים";
                case "140_CONTRAS\\972_avoda_zara_bapea.txt":
                    return "אגלחך לשמים";
                case "145_HADERECH_LATORA\\100_tora_ve_mada1.txt":
                    return "תורה ומדע 1";
                case "145_HADERECH_LATORA\\150_scharan_shell_mitsvot.TXT":
                    return "שכרן של מצוות";
                case "145_HADERECH_LATORA\\200_ttsoar_laolam_hharedi.txt":
                    return "צוהר לארחות החרדי";
                case "145_HADERECH_LATORA\\400_LookingForTruth.txt":
                    return "מחפשים את האמת";
                case "145_HADERECH_LATORA\\410_MeNegedMe.txt":
                    return "מי נגד מי - דו שיח חרדי-חילוני";
                case "145_HADERECH_LATORA\\451_shaar_haemuna 2.txt":
                    return "שער האמונה";
                case "145_HADERECH_LATORA\\500_where_is_it.TXT":
                    return "היכן זה כתוב";
                case "145_HADERECH_LATORA\\552_hakuzari.txt":
                    return "ספר הכוזרי";
                case "145_HADERECH_LATORA\\580_BenChorin.txt":
                    return "מיהו בן חורין אמיתי";
                case "145_HADERECH_LATORA\\600_surprize.txt":
                    return "הפתעה - סיפור בעניין האבולוציה";
                case "145_HADERECH_LATORA\\601_shabat_rav_zamir.txt":
                    return "סוד השבת - אור הנשמה";
                case "145_HADERECH_LATORA\\603_OrHozer.txt":
                    return "אור חוזר";
                case "145_HADERECH_LATORA\\610_itinai_1.txt":
                    return "העיתונאי 1";
                case "145_HADERECH_LATORA\\611_itinai_2.txt":
                    return "העיתונאי 2";
                case "145_HADERECH_LATORA\\612_itinai_3.txt":
                    return "העיתונאי 3";
                case "145_HADERECH_LATORA\\613_itinai_4.txt":
                    return "העיתונאי 4";
                case "145_HADERECH_LATORA\\614_itinai_5.txt":
                    return "העיתונאי 5";
                case "145_HADERECH_LATORA\\615_itinai_6.txt":
                    return "העיתונאי 6";
                case "145_HADERECH_LATORA\\650_orot_shel_emet.txt":
                    return "אורות של אמת";
                case "145_HADERECH_LATORA\\651_hatachlit.txt":
                    return "התכלית";
                case "145_HADERECH_LATORA\\700_BANOT_MEDABROT.txt":
                    return "בנות מדברות על עצמן";
                case "145_HADERECH_LATORA\\701_NASHIM_MEDABROT.txt":
                    return "נשים מדברות על עצמן";
                case "145_HADERECH_LATORA\\702_fingers.txt":
                    return "אצבעותי למלחמה";
                case "145_HADERECH_LATORA\\710_the_3rd_power.txt":
                    return "הכוח השלישי";
                case "145_HADERECH_LATORA\\720_tachlit_hachaiim.txt":
                    return "תכלית החיים";
                case "145_HADERECH_LATORA\\730_mazleg.txt":
                    return "יהדות על קצה המזלג";
                case "145_HADERECH_LATORA\\740_hashem_nisi.txt":
                    return "ה' ניסי - ניסי ניסים";
                case "150_TFILOT_VESGULOT\\0002_sidur1.txt":
                    return "סידור תורת אמת";
                case "150_TFILOT_VESGULOT\\0002_sidur2.txt":
                    return "סידור זכר מנחם";
                case "150_TFILOT_VESGULOT\\0005_slichot.txt":
                    return "סדר סליחות והתרת נדרים";
                case "150_TFILOT_VESGULOT\\0010_Likutei_tfilot.txt":
                    return "לקט תפילות";
                case "150_TFILOT_VESGULOT\\0020_LimudLeiluiNishmat.txt":
                    return "סדר הלימוד לעילוי נשמה";
                case "150_TFILOT_VESGULOT\\0021_TikunHaclali.txt":
                    return "התיקון הכללי";
                case "150_TFILOT_VESGULOT\\0050_seder_maamadot.txt":
                    return "סדר מעמדות";
                case "150_TFILOT_VESGULOT\\0500_BeginEnd.txt":
                    return "פסוק המתחיל ומסתיים באות";
                case "150_TFILOT_VESGULOT\\0550_SgulotRavLugacy.txt":
                    return "ישראל לסגולתו";
                case "150_TFILOT_VESGULOT\\0600_KAMIA_AMITI.txt":
                    return "קמיע תורני אמיתי להצלחה כללית";
                case "150_TFILOT_VESGULOT\\0700_PirkeiShira.txt":
                    return "פרק שירה - שירת הבריאה";
                case "150_TFILOT_VESGULOT\\911_tfila_lebat.txt":
                    return "תפילה לבת ישראל";
                case "150_TFILOT_VESGULOT\\912_Tifkedenu.txt":
                    return "קונטרס ותפקדנו";
                case "150_TFILOT_VESGULOT\\913_hadran.txt":
                    return "נוסח סיום מסכת";
                case "157_HIDONIM\\HidonLashon.txt":
                    return "חידון שמירת הלשון - ע''פ ספר החפץ חיים";
                case "158_AHAVAT_ISRAEL\\050_ahavat_chesed.txt":
                    return "אהבת חסד";
                case "158_AHAVAT_ISRAEL\\100_ahavat_israel.txt":
                    return "הנהגות אהבת ישראל";
                case "158_AHAVAT_ISRAEL\\200_BarLevav.txt":
                    return "בר לבב - אהבת ישראל";
                case "158_AHAVAT_ISRAEL\\300_madrich.txt":
                    return "מדריך מעשי כיצד לדון לכף זכות";
                case "158_AHAVAT_ISRAEL\\400_veahavta.txt":
                    return "מאמר ואהבת לרעך כמוך";
                case "158_AHAVAT_ISRAEL\\500_kneset_israel.txt":
                    return "כנסת ישראל";

                case "160_MISC\\0000_for_WORD.txt":
                    return "יצור לוורד";
                case "160_MISC\\0600_nisim.txt":
                    return "סיפורי ניסים";
                case "160_MISC\\501_mavo_chemdat_yamim.txt":
                    return "ספר חמדת ימים - מבוא";
                case "160_MISC\\502_key_for_tanach.txt":
                    return "מפתח ענייני התנ''ך";
                case "160_MISC\\50_message1.txt":
                    return "הודעה";
                case "160_MISC\\51_message2.txt":
                    return "הודעה";
                case "160_MISC\\AllTora.txt":
                    return "בראשית שמות ויקרא במדבר דברים";
                case "160_MISC\\BereshitX5.txt":
                    return "בראשית בראשית בראשית בראשית בראשית";
                case "160_MISC\\BriutKahalacha.txt":
                    return "חיים בריאים כהלכה";
                case "160_MISC\\BriutKahalachaNoSigars.txt":
                    return "חיים ללא עישון";
                case "160_MISC\\PirkeiDerabiEliezer.txt":
                    return "פרקי דרבי אליעזר";
                case "160_MISC\\PirkeiDerechErets.txt":
                    return "פרקי דרך ארץ - סדר אליהו זוטא ט''ז - י''ח";
                case "160_MISC\\drashot_laavelim.txt":
                    return "דרשות לאזכרות ולבתי אבלים";
                case "170_GROUPS\\100_$_1596_shabat_kahalach.txt":
                    return "שבת כהלכה";
                case "170_GROUPS\\300_GROUP_SHABAT\\101_$_1819_shabat_bahalacha_naki.txt":
                    return "השבת בהלכה ובאגדה";
                case "170_GROUPS\\300_GROUP_SHABAT\\102_$_713_hanhagot_shabat1.txt":
                    return "הנהגות לשבת קודש - חלק א";
                case "170_GROUPS\\300_GROUP_SHABAT\\103_$_1783_hanhagot_shabat2.txt":
                    return "הנהגות לשבת קודש - חלק ב";
                case "170_GROUPS\\300_GROUP_SHABAT\\104_$_1830_chemdat_yamim_shabat.txt":
                    return "ספר חמדת ימים - חלק א - שבת";
                case "170_GROUPS\\301_GROUP_TAHARA":
                    return "הטהרה בהלכה ובאגדה";
                case "170_GROUPS\\301_GROUP_TAHARA\\101_$_1595_tahara_herayon_veleda.txt":
                    return "טהרה הריון ולידה כהלכה";
                case "170_GROUPS\\301_GROUP_TAHARA\\102_$_1105_shaar_hazahav_latahara.txt":
                    return "שער הזהב לטהרה";
                case "170_GROUPS\\301_GROUP_TAHARA\\103_$_1791_nesuin_veishut.txt":
                    return "נשואין ואישות";
                case "170_GROUPS\\301_GROUP_TAHARA\\104_$_1044_yore_dea_tahara.txt":
                    return "שלחן ערוך - יורה דעה - הלכות טהרה";
                case "170_GROUPS\\302_GROUP_TSNIUT":
                    return "ספר גדר עולם";
                case "170_GROUPS\\302_GROUP_TSNIUT\\100_$_1594_marot_tsovot_2.txt":
                    return "מראות הצובאות";
                case "170_GROUPS\\302_GROUP_TSNIUT\\101_$_1818_halevush_leor_hahalacha.txt":
                    return "הלבוש לאור ההלכה";
                case "170_GROUPS\\302_GROUP_TSNIUT\\102_$_1798_igeret_lebat_israel.txt":
                    return "אגרת לבת ישראל היקרה";
                case "170_GROUPS\\302_GROUP_TSNIUT\\103_$_1012_anshei_kodesh.txt":
                    return "אנשי קודש";
                case "170_GROUPS\\302_GROUP_TSNIUT\\103_$_1784_machanecha_kadosh.txt":
                    return "ספר מחניך קדוש";
                case "170_GROUPS\\302_GROUP_TSNIUT\\103_$_1789_kol__kore.txt":
                    return "קונטרס קול קורא";
                case "170_GROUPS\\302_GROUP_TSNIUT\\104_$_1682_lahevet_shalhevet.txt":
                    return "להבת שלהבת קודש";
                case "170_GROUPS\\302_GROUP_TSNIUT\\105_$_1941_vaterkas.txt":
                    return "ותכס בצעיף";


                case "170_GROUPS\\302_GROUP_TSNIUT\\108_$_2541_banot.txt":
                    return "בנות מדברות על עצמן";

                case "170_GROUPS\\302_GROUP_TSNIUT\\120_tevorach_menashim.txt":
                    return "תבורך מנשים";
                case "170_GROUPS\\303_GROUP_KASHRUT":
                    return "כשרות המטבח";
                case "170_GROUPS\\303_GROUP_KASHRUT\\001_$_1677_kedoshim_tihiyu.txt":
                    return "הלכות תולעים - קדושים תהיו";
                case "170_GROUPS\\303_GROUP_KASHRUT\\002_$_1599_tvilat_kelim.txt":
                    return "הלכות טבילת כלים";
                case "170_GROUPS\\303_GROUP_KASHRUT\\003_$_1598_bishulei_goiim.txt":
                    return "הלכות פת ובישולי גוים - פתבג המלך";
                case "170_GROUPS\\303_GROUP_KASHRUT\\004_$_1897_hagaalat_kelim.txt":
                    return "הלכות הגעלת כלים לפסח - פסקי משה";
                case "400_NOTES\\0700_notes.txt":
                    return "פנקס ההערות שלי - 1";
                case "400_NOTES\\0701_notes.txt":
                    return "פנקס ההערות שלי - 2";
                case "400_NOTES\\0702_notes.txt":
                    return "פנקס ההערות שלי - 3";
                case "400_NOTES\\0703_notes.txt":
                    return "פנקס ההערות שלי - 4";
                case "400_NOTES\\0704_notes.txt":
                    return "פנקס ההערות שלי - 5";
                case "400_NOTES\\0705_notes.txt":
                    return "פנקס ההערות שלי - 6";
                case "400_NOTES\\0706_notes.txt":
                    return "פנקס ההערות שלי - 7";
                case "400_NOTES\\0707_notes.txt":
                    return "פנקס ההערות שלי - 8";
                case "400_NOTES\\0708_notes.txt":
                    return "פנקס ההערות שלי - 9";
                case "400_NOTES\\0709_notes.txt":
                    return "פנקס ההערות שלי - 10";
                case "400_NOTES\\0710_notes.txt":
                    return "פנקס ההערות שלי - 11";
                case "400_NOTES\\0711_notes.txt":
                    return "פנקס ההערות שלי - 12";
                case "400_NOTES\\0712_notes.txt":
                    return "פנקס ההערות שלי - 13";
                case "400_NOTES\\0713_notes.txt":
                    return "פנקס ההערות שלי - 14";
                case "400_NOTES\\0714_notes.txt":
                    return "פנקס ההערות שלי - 15";
                case "400_NOTES\\0715_notes.txt":
                    return "פנקס ההערות שלי - 16";
                case "400_NOTES\\0716_notes.txt":
                    return "פנקס ההערות שלי - 17";
                case "400_NOTES\\0717_notes.txt":
                    return "פנקס ההערות שלי - 18";
                case "400_NOTES\\0718_notes.txt":
                    return "פנקס ההערות שלי - 19";
                case "400_NOTES\\0719_notes.txt":
                    return "פנקס ההערות שלי - 20";
                case "042_HALACHA2\\107_KitsurHafetsHaim.txt":
                    return "קיצור הלכות שמירת הלשון - מבוסס על ספר החפץ חיים";
                case "042_HALACHA2\\443_midot4.txt":
                    return "שלחן ערוך המדות - קונטרס אונאת דברים";
                case "100_MUSAR\\612_yitgaber_kaari.txt":
                    return "יתגבר כארי";
                case "500_MY_BOOKS":
                    return "dummy_dont_remove.text";


                case "106_KABALA\\000020_ZOHAR0-hakdama_L1.txt":
                    return "הקדמת הזוהר";
                case "110_CHASIDUT\\045_taniya_1.txt":
                    return "ליקוטי אמרים תניא";
                case "112_HANHAGOT\\075_ANSHEI KODESH_L1.txt":
                    return "אנשי קודש";
                case "115_PARSHA\\180_AvodaShebaleveVaikra.txt":
                    return "עבודה שבלב ויקרא";
                case "115_PARSHA\\181_MaagalHachaiimVaikra.txt":
                    return "מעגל החיים - ויקרא";
                case "125_SHUT\\100_NafshiBesheelati1.txt":
                    return "נפשי בשאלתי";
                case "125_SHUT\\253_ShaolShaal_3.txt":
                    return "שו''ת שאול שאל - חלק ג";
                case "125_SHUT\\253_ShaolShaal_4.txt":
                    return "שו''ת שאול שאל - חלק ד";
                case "150_TFILOT_VESGULOT\\0001_sidur.txt":
                    return "סידור תורת אמת - ספרדים ועדות המזרח";
                case "160_MISC\\0000_TESTS.txt":
                    return "מבחנים";
                case "170_GROUPS\\300_GROUP_SHABAT\\100_$_1596_shabat_kahalach.txt":
                    return "שבת כהלכה";
                case "170_GROUPS\\301_GROUP_TAHARA\\100_$_1826_tahara_naki.txt":
                    return "הטהרה בהלכה ובאגדה";
                case "170_GROUPS\\302_GROUP_TSNIUT\\099_$_2539_geder_olam.txt":
                    return "גדר עולם";
                case "170_GROUPS\\302_GROUP_TSNIUT\\106_$_1943_bigdei_tifartech.txt":
                    return "בגדי תפארתך";
                case "170_GROUPS\\302_GROUP_TSNIUT\\107_$_1942_shir.txt":
                    return "שיר - אחות יקרה";
                case "170_GROUPS\\302_GROUP_TSNIUT\\109_$_5100_nashim_medabrot.txt":
                    return "נשים מדברות על עצמן";
                case "170_GROUPS\\302_GROUP_TSNIUT\\110_$_5097_avoda_zara_pea.txt":
                    return "אגלחך לשמים - תקרובת ע''ז בפאות";
                case "170_GROUPS\\303_GROUP_KASHRUT\\000_$_1822_kashrut.txt":
                    return "כשרות המטבח";
                default:
                    return Path.GetFileNameWithoutExtension(originalFilename); // Return original filename if no translation found
            }
        }
    }
}