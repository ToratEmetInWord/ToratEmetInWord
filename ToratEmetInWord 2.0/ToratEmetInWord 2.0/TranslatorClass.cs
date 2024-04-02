using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToratEmetInWord_2._0
{
    public class TranslatorClass
    {
        public static string TranslateFolderName(string originalFolderName)
        {
            // Find the index of the first underscore character
            int underscoreIndex = originalFolderName.IndexOf('_');

            if (underscoreIndex >= 0)
            {
                // Extract the substring after the underscore
                originalFolderName = originalFolderName.Substring(underscoreIndex + 1);
            }

            // translation logic using C# switch statements
            switch (originalFolderName)
            {
                case "ACCESORIES":
                    return "עזרים שונים";
                case "HORADOT":
                    return "ספרים להורדה";
                case "TORA":
                    return "תורה";
                case "NAVI":
                    return "נביאים";
                case "KTUVIM":
                    return "כתובים";
                case "MISHNA":
                    return "משנה";
                case "BAVLI":
                    return "תלמוד בבלי";
                case "RAMBAM":
                    return "משנה תורה להרמב''ם";
                case "HALACHA1":
                    return "הלכה 1";
                case "HALACHA2":
                    return "הלכה 2";
                case "IYUNIM":
                    return "עיונים בהלכה ובש''ס";
                case "MUSAR":
                    return "מוסר";
                case "KABALA":
                    return "קבלה";
                case "CHASIDUT":
                    return "חסידות";
                case "HANHAGOT":
                    return "הנהגות";
                case "PARSHA":
                    return "פרשת השבוע";
                case "HAGIM":
                    return "חגי ומועדי ישראל";
                case "GDOLEY_HADOROT":
                    return "גדולי הדורות";
                case "SHUT":
                    return "שאלות ותשובות";
                case "HABITE":
                    return "הבית היהודי";
                case "CONTRAS":
                    return "קונטרסים";
                case "HADERECH_LATORA":
                    return "הדרך לתורה";
                case "TFILOT_VESGULOT":
                    return "תפילות וסגולות";
                case "HIDONIM":
                    return "חידונים";
                case "AHAVAT_ISRAEL":
                    return "אהבת ישראל";
                case "MISC":
                    return "שונות";
                case "GROUPS":
                    return "קבוצות";
                case "NOTES":
                    return "פנקסי ההערות שלי";
                case "MY_BOOKS":
                    return "הספרים שלי";
                case "TUR":
                    return "טור";
                case "YERUSHALMI":
                    return "תלמוד ירושלמי";
                case "RAMBAM_ON_MISHNA":
                    return "רמב''ם על המשנה";
                case "SHIMONI":
                    return "ילקוט שמעוני";
                case "BERESHIT":
                    return "בראשית";
                case "SHEMOT":
                    return "שמות";
                case "VAIKRA":
                    return "ויקרא";
                case "BAMIDBAR":
                    return "במדבר";
                case "DEVARIM":
                    return "דברים";
                case "YEHOSUA":
                    return "יהושע";
                case "SHOFETIM":
                    return "שופטים";
                case "SHEMUEL_A":
                    return "שמואל א";
                case "SHEMUEL_B":
                    return "שמואל ב";
                case "MELACIM_A":
                    return "מלכים א";
                case "MELACIM_B":
                    return "מלכים ב";
                case "YISHAYA":
                    return "ישעיה";
                case "YERMIYA":
                    return "ירמיה";
                case "YEHEZKEL":
                    return "יחזקאל";
                case "HOSEA":
                    return "הושע";
                case "YOEL":
                    return "יואל";
                case "AMOS":
                    return "עמוס";
                case "OVADYA":
                    return "עובדיה";
                case "YONA":
                    return "יונה";
                case "MICHA":
                    return "מיכה";
                case "NAHUM":
                    return "נחום";
                case "HAVAKUK":
                    return "חבקוק";
                case "ZFANYA":
                    return "צפניה";
                case "HAGAY":
                    return "חגי";
                case "ZECHARYA":
                    return "זכריה";
                case "MALACHI":
                    return "מלאכי";
                case "TEHILIM":
                    return "תהילים";
                case "MISHLEI":
                    return "משלי";
                case "IYOV":
                    return "איוב";
                case "SHIR_HASHIRIM":
                    return "שיר השירים";
                case "RUTH":
                    return "רות";
                case "EICHA":
                    return "איכה";
                case "KOHELET":
                    return "קהלת";
                case "ESTER":
                    return "אסתר";
                case "DANIEL":
                    return "דניאל";
                case "EZRA":
                    return "עזרא";
                case "NECHEMYA":
                    return "נחמיה";
                case "DIVRE_A":
                    return "דברי הימים א";
                case "DIVRE_B":
                    return "דברי הימים ב";
                case "SEDER_ZRAIM":
                    return "סדר זרעים";
                case "SEDER_MOED":
                    return "סדר מועד";
                case "SEDER_NASHIM":
                    return "סדר נשים";
                case "SEDER_NEZIKIN":
                    return "סדר נזיקין";
                case "SEDER_KADASHIM":
                    return "סדר קדשים";
                case "SEDER_TAHAROT":
                    return "סדר טהרות";
                case "MAS_BRACHOT":
                    return "מסכת ברכות";
                case "MAS_PEA":
                    return "מסכת פאה";
                case "MAS_DEMAI":
                    return "מסכת דמאי";
                case "MAS_KILAIIM":
                    return "מסכת כלאים";
                case "MAS_SHEVIIT":
                    return "מסכת שביעית";
                case "MAS_TRUMOT":
                    return "מסכת תרומות";
                case "MAS_MAASROT":
                    return "מסכת מעשרות";
                case "MAS_MAASER_SHENI":
                    return "מסכת מעשר שני";
                case "MAS_CHALA":
                    return "מסכת חלה";
                case "MAS_ORLA":
                    return "מסכת ערלה";
                case "MAS_BIKURIM":
                    return "מסכת ביכורים";
                case "MAS_SHABAT":
                    return "מסכת שבת";
                case "MAS_ERUVIN":
                    return "מסכת עירובין";
                case "MAS_PSACHIM":
                    return "מסכת פסחים";
                case "MAS_SHKALIM":
                    return "מסכת שקלים";
                case "MAS_ROSH":
                    return "מסכת ראש השנה";
                case "MAS_YOMA":
                    return "מסכת יומא";
                case "MAS_SUCA":
                    return "מסכת סוכה";
                case "MAS_BEITSA":
                    return "מסכת ביצה";
                case "MAS_TAANIT":
                    return "מסכת תענית";
                case "MAS_MEGILA":
                    return "מסכת מגילה";
                case "MAS_MOED_KATAN":
                    return "מסכת מועד קטן";
                case "MAS_HAGIGA":
                    return "מסכת חגיגה";
                case "MAS_YEVAMOT":
                    return "מסכת יבמות";
                case "MAS_KTUBOT":
                    return "מסכת כתובות";
                case "MAS_NEDARIM":
                    return "מסכת נדרים";
                case "MAS_NAZIR":
                    return "מסכת נזיר";
                case "MAS_SOTA":
                    return "מסכת סוטה";
                case "MAS_GITIN":
                    return "מסכת גיטין";
                case "MAS_KIDUSHIN":
                    return "מסכת קידושין";
                case "MAS_KAMA":
                    return "מסכת בבא קמא";
                case "MAS_METSIA":
                    return "מסכת בבא מציעא";
                case "MAS_BATRA":
                    return "מסכת בבא בתרא";
                case "MAS_SANHEDRIN":
                    return "מסכת סנהדרין";
                case "MAS_MAKOT":
                    return "מסכת מכות";
                case "MAS_SHVUOT":
                    return "מסכת שבועות";
                case "MAS_AVODA_ZARA":
                    return "מסכת עבודה זרה";
                case "MAS_AVOT":
                    return "מסכת אבות";
                case "MAS_HORAYOT":
                    return "מסכת הוריות";
                case "MAS_EDUYOT":
                    return "מסכת עדיות";
                case "MAS_ZEVACHIM":
                    return "מסכת זבחים";
                case "MAS_MENACHOT":
                    return "מסכת מנחות";
                case "MAS_CHULIN":
                    return "מסכת חולין";
                case "MAS_BECHOROT":
                    return "מסכת בכורות";
                case "MAS_ARACHIN":
                    return "מסכת ערכין";
                case "MAS_TEMURA":
                    return "מסכת תמורה";
                case "MAS_KRETOT":
                    return "מסכת כריתות";
                case "MAS_MEILA":
                    return "מסכת מעילה";
                case "MAS_TAMID":
                    return "מסכת תמיד";
                case "MAS_MIDOT":
                    return "מסכת מדות";
                case "MAS_KANIM":
                    return "מסכת קנים";
                case "MAS_KELIM":
                    return "מסכת כלים";
                case "MAS_AHALOT":
                    return "מסכת אהלות";
                case "MAS_NEGAIIM":
                    return "מסכת נגעים";
                case "MAS_PARA":
                    return "מסכת פרה";
                case "MAS_TAHAROT":
                    return "מסכת טהרות";
                case "MAS_MIKVAOT":
                    return "מסכת מקואות";
                case "MAS_NIDA":
                    return "מסכת נדה";
                case "MAS_MACHSHIRIN":
                    return "מסכת מכשירין";
                case "MAS_ZAVIM":
                    return "מסכת זבים";
                case "MAS_TEVUL_YOM":
                    return "מסכת טבול יום";
                case "MAS_YADAIIM":
                    return "מסכת ידים";
                case "MAS_OKATSIN":
                    return "מסכת עוקצין";
                case "GROUP_SHABAT":
                    return "קבוצת שבת קודש";
                case "GROUP_TAHARA":
                    return "קבוצת טהרת המשפחה";
                case "GROUP_TSNIUT":
                    return "קבוצת צניעות האשה";
                case "GROUP_KASHRUT":
                    return "קבוצת כשרות המטבח";

                default:
                    return originalFolderName; // Return original folder name if no translation found
            }
        }

        public static string TranslateFilename(string originalFilename)
        {
            // Replicate the VBA translation logic using C# switch statements
            switch (originalFilename)
            {
                case "Books\\000_ACCESORIES\\0011_!help.htm":
                    return "0011_!help.htm";
                case "Books\\000_ACCESORIES\\0012_daily.txt":
                    return "הלימוד היומי";
                case "Books\\000_ACCESORIES\\0013_daily_info.txt":
                    return "מידע יומי";
                case "Books\\000_ACCESORIES\\0014_contents.txt":
                    return "תוכן עניינים מותאם אישית";
                case "Books\\000_ACCESORIES\\0015_stat.txt":
                    return "מעקב לימוד";
                case "Books\\000_ACCESORIES\\0016_mare.txt":
                    return "מארי דחושבנא";
                case "Books\\000_HORADOT\\100_TUR\\010_tur_orach_chaim_merged.txt":
                    return "טור - אורח חיים";
                case "Books\\000_HORADOT\\100_TUR\\011_tur_yore_deaa_merged.txt":
                    return "טור - יורה דעה";
                case "Books\\000_HORADOT\\100_TUR\\012_tur_even_haezer_merged.txt":
                    return "טור - אבן העזר";
                case "Books\\000_HORADOT\\100_TUR\\013_tur_choshen_mishpat_merged.txt":
                    return "טור - חשן משפט";
                case "Books\\000_HORADOT\\100_TUR\\100_tur_orach_chaiim_tur.txt":
                    return "טור - אורח חיים - טור";
                case "Books\\000_HORADOT\\100_TUR\\101_tur_orach_chaiim_beit_yosef.txt":
                    return "טור - אורח חיים - בית יוסף";
                case "Books\\000_HORADOT\\100_TUR\\102_tur_orach_chaiim_bach.txt":
                    return "טור - אורח חיים - בית חדש";
                case "Books\\000_HORADOT\\100_TUR\\103_tur_orach_chaiim_darkei_moshe.txt":
                    return "טור - אורח חיים - דרכי משה";
                case "Books\\000_HORADOT\\100_TUR\\104_tur_orach_chaiim_drisha.txt":
                    return "טור - אורח חיים - דרישה";
                case "Books\\000_HORADOT\\100_TUR\\105_tur_orach_chaiim_prisha.txt":
                    return "טור - אורח חיים - פרישה";
                case "Books\\000_HORADOT\\100_TUR\\106_tur_orach_chaiim_hagahot.txt":
                    return "טור - אורח חיים - חידושי הגהות";
                case "Books\\000_HORADOT\\100_TUR\\107_tur_orach_chaiim_notes.txt":
                    return "טור - אורח חיים - הערות";
                case "Books\\000_HORADOT\\100_TUR\\120_tur_yore_dea_tur.txt":
                    return "טור - יורה דעה - טור";
                case "Books\\000_HORADOT\\100_TUR\\121_tur_yore_dea_beit_yosef.txt":
                    return "טור - יורה דעה - בית יוסף";
                case "Books\\000_HORADOT\\100_TUR\\122_tur_yore_dea_bach.txt":
                    return "טור - יורה דעה - בית חדש";
                case "Books\\000_HORADOT\\100_TUR\\123_tur_yore_dea_darkei_moshe.txt":
                    return "טור - יורה דעה - דרכי משה";
                case "Books\\000_HORADOT\\100_TUR\\124_tur_yore_dea_drisha.txt":
                    return "טור - יורה דעה - דרישה";
                case "Books\\000_HORADOT\\100_TUR\\125_tur_yore_dea_prisha.txt":
                    return "טור - יורה דעה - פרישה";
                case "Books\\000_HORADOT\\100_TUR\\126_tur_yore_dea_hagahot.txt":
                    return "טור - יורה דעה - חידושי הגהות";
                case "Books\\000_HORADOT\\100_TUR\\127_tur_yore_dea_notes.txt":
                    return "טור - יורה דעה - הערות";
                case "Books\\000_HORADOT\\100_TUR\\140_tur_even_haezer_tur.txt":
                    return "טור - אבן העזר - טור";
                case "Books\\000_HORADOT\\100_TUR\\141_tur_even_haezer_beit_yosef.txt":
                    return "טור - אבן העזר - בית יוסף";
                case "Books\\000_HORADOT\\100_TUR\\142_tur_even_haezer_bach.txt":
                    return "טור - אבן העזר - בית חדש";
                case "Books\\000_HORADOT\\100_TUR\\143_tur_even_haezer_darkei_moshe.txt":
                    return "טור - אבן העזר - דרכי משה";
                case "Books\\000_HORADOT\\100_TUR\\144_tur_even_haezer_drisha.txt":
                    return "טור - אבן העזר - דרישה";
                case "Books\\000_HORADOT\\100_TUR\\145_tur_even_haezer_prisha.txt":
                    return "טור - אבן העזר - פרישה";
                case "Books\\000_HORADOT\\100_TUR\\146_tur_even_haezer_hagahot.txt":
                    return "טור - אבן העזר - חידושי הגהות";
                case "Books\\000_HORADOT\\100_TUR\\147_tur_even_haezer_notes.txt":
                    return "טור - אבן העזר - הערות";
                case "Books\\000_HORADOT\\100_TUR\\160_tur_choshen_mishpat_tur.txt":
                    return "טור - חושן משפט - טור";
                case "Books\\000_HORADOT\\100_TUR\\161_tur_choshen_mishpat_beit_yosef.txt":
                    return "טור - חושן משפט - בית יוסף";
                case "Books\\000_HORADOT\\100_TUR\\162_tur_choshen_mishpat_bach.txt":
                    return "טור - חושן משפט - בית חדש";
                case "Books\\000_HORADOT\\100_TUR\\163_tur_choshen_mishpat_darkei_moshe.txt":
                    return "טור - חושן משפט - דרכי משה";
                case "Books\\000_HORADOT\\100_TUR\\164_tur_choshen_mishpat_drisha.txt":
                    return "טור - חושן משפט - דרישה";
                case "Books\\000_HORADOT\\100_TUR\\165_tur_choshen_mishpat_prisha.txt":
                    return "טור - חושן משפט - פרישה";
                case "Books\\000_HORADOT\\100_TUR\\166_tur_choshen_mishpat_hagahot.txt":
                    return "טור - חושן משפט - חידושי הגהות";
                case "Books\\000_HORADOT\\100_TUR\\167_tur_choshen_mishpat_notes.txt":
                    return "טור - חושן משפט - הערות";
                case "Books\\000_HORADOT\\200_PARSHA\\dummy.dat":
                    return "dummy.dat";
                case "Books\\000_HORADOT\\250_SHIMONI\\001_shimoni_bereshit.txt":
                    return " ילקוט שמעוני - בראשית";
                case "Books\\000_HORADOT\\250_SHIMONI\\002_shimoni_shemot.txt":
                    return " ילקוט שמעוני - שמות";
                case "Books\\000_HORADOT\\250_SHIMONI\\003_shimoni_vaikra.txt":
                    return "ילקוט שמעוני - ויקרא ";
                case "Books\\000_HORADOT\\250_SHIMONI\\004_shimoni_bamidbar.txt":
                    return "ילקוט שמעוני - במדבר ";
                case "Books\\000_HORADOT\\250_SHIMONI\\005_shimoni_devarim.txt":
                    return "ילקוט שמעוני - דברים ";
                case "Books\\000_HORADOT\\250_SHIMONI\\006_shimoni_yehoshua.txt":
                    return "ילקוט שמעוני - יהושע";
                case "Books\\000_HORADOT\\250_SHIMONI\\007_shimoni_shofetim.txt":
                    return "ילקוט שמעוני - שופטים";
                case "Books\\000_HORADOT\\250_SHIMONI\\008_shimoni_shmuel_a.txt":
                    return "ילקוט שמעוני - שמואל א";
                case "Books\\000_HORADOT\\250_SHIMONI\\009_shimoni_shmuel_b.txt":
                    return "ילקוט שמעוני - שמואל ב";
                case "Books\\000_HORADOT\\250_SHIMONI\\010_shimoni_melachim_a.txt":
                    return "ילקוט שמעוני - מלכים א";
                case "Books\\000_HORADOT\\250_SHIMONI\\011_shimoni_melachim_b.txt":
                    return "ילקוט שמעוני - מלכים ב";
                case "Books\\000_HORADOT\\250_SHIMONI\\012_shimoni_yishaya.txt":
                    return "ילקוט שמעוני - ישעיה";
                case "Books\\000_HORADOT\\250_SHIMONI\\013_shimoni_yermiya.txt":
                    return "ילקוט שמעוני - ירמיה";
                case "Books\\000_HORADOT\\250_SHIMONI\\014_shimoni_yechezkel.txt":
                    return "ילקוט שמעוני - יחזקאל";
                case "Books\\000_HORADOT\\250_SHIMONI\\015_shimoni_hoshea.txt":
                    return "ילקוט שמעוני - הושע";
                case "Books\\000_HORADOT\\250_SHIMONI\\016_shimoni_yoel.txt":
                    return "ילקוט שמעוני - יואל";
                case "Books\\000_HORADOT\\250_SHIMONI\\017_shimoni_amos.txt":
                    return "ילקוט שמעוני - עמוס";
                case "Books\\000_HORADOT\\250_SHIMONI\\018_shimoni_ovadya.txt":
                    return "ילקוט שמעוני - עובדיה";
                case "Books\\000_HORADOT\\250_SHIMONI\\019_shimoni_yona.txt":
                    return "ילקוט שמעוני - יונה";
                case "Books\\000_HORADOT\\250_SHIMONI\\020_shimoni_micha.txt":
                    return "ילקוט שמעוני - מיכה";
                case "Books\\000_HORADOT\\250_SHIMONI\\021_shimoni_nachum.txt":
                    return "ילקוט שמעוני - נחום";
                case "Books\\000_HORADOT\\250_SHIMONI\\022_shimoni_havakuk.txt":
                    return "ילקוט שמעוני - חבקוק";
                case "Books\\000_HORADOT\\250_SHIMONI\\023_shimoni_zefanya.txt":
                    return "ילקוט שמעוני - צפניה";
                case "Books\\000_HORADOT\\250_SHIMONI\\024_shimoni_hagay.txt":
                    return "ילקוט שמעוני - חגי";
                case "Books\\000_HORADOT\\250_SHIMONI\\025_shimoni_zecharya.txt":
                    return "ילקוט שמעוני - זכריה";
                case "Books\\000_HORADOT\\250_SHIMONI\\026_shimoni_malachi.txt":
                    return "ילקוט שמעוני - מלאכי";
                case "Books\\000_HORADOT\\250_SHIMONI\\027_shimoni_tehilim.txt":
                    return "ילקוט שמעוני - תהילים";
                case "Books\\000_HORADOT\\250_SHIMONI\\028_shimoni_mishley.txt":
                    return "ילקוט שמעוני - משלי";
                case "Books\\000_HORADOT\\250_SHIMONI\\029_shimoni_iyov.txt":
                    return "ילקוט שמעוני - איוב";
                case "Books\\000_HORADOT\\250_SHIMONI\\030_shimoni_shir_hashirim.txt":
                    return "ילקוט שמעוני - שיר השירים";
                case "Books\\000_HORADOT\\250_SHIMONI\\031_shimoni_ruth.txt":
                    return "ילקוט שמעוני - רות";
                case "Books\\000_HORADOT\\250_SHIMONI\\032_shimoni_eicha.txt":
                    return "ילקוט שמעוני - איכה";
                case "Books\\000_HORADOT\\250_SHIMONI\\033_shimoni_kohelet.txt":
                    return "ילקוט שמעוני - קהלת";
                case "Books\\000_HORADOT\\250_SHIMONI\\034_shimoni_ester.txt":
                    return "ילקוט שמעוני - אסתר";
                case "Books\\000_HORADOT\\250_SHIMONI\\035_shimoni_daniel.txt":
                    return "ילקוט שמעוני - דניאל";
                case "Books\\000_HORADOT\\250_SHIMONI\\036_shimoni_ezra.txt":
                    return "ילקוט שמעוני - עזרא";
                case "Books\\000_HORADOT\\250_SHIMONI\\037_shimoni_nechemya.txt":
                    return "ילקוט שמעוני - נחמיה";
                case "Books\\000_HORADOT\\250_SHIMONI\\038_shimoni_divrei_a.txt":
                    return "ילקוט שמעוני - דברי הימים א";
                case "Books\\000_HORADOT\\250_SHIMONI\\039_shimoni_divrei_b.txt":
                    return "ילקוט שמעוני - דברי הימים ב";
                case "Books\\000_HORADOT\\250_SHIMONI\\dummy.dat":
                    return "dummy.dat";
                case "Books\\001_TORA\\01_BERESHIT\\a01__Genesis.txt":
                    return "בראשית - עם טעמים";
                case "Books\\001_TORA\\01_BERESHIT\\a01_Genesis.txt":
                    return "בראשית - עם ניקוד";

                case "Books\\001_TORA\\01_BERESHIT\\b01_Genesis.txt":
                    return "בראשית - ללא ניקוד";
                case "Books\\001_TORA\\01_BERESHIT\\c_RASHI_BERESHIT_L1.txt":
                    return "בראשית - רש''י";
                case "Books\\001_TORA\\01_BERESHIT\\c_RASHI_BERESHIT_OLD.txt":
                    return "בראשית - רש''י (ב)";
                case "Books\\001_TORA\\01_BERESHIT\\c_siftei_1.txt":
                    return "בראשית - שפתי חכמים";
                case "Books\\001_TORA\\01_BERESHIT\\d_ramban_bereshit.txt":
                    return "בראשית - רמב''ן";
                case "Books\\001_TORA\\01_BERESHIT\\e01_Genesis.txt":
                    return "בראשית - תרגום יונתן";
                case "Books\\001_TORA\\01_BERESHIT\\f_OrHachaim.txt":
                    return "בראשית - אור החיים";
                case "Books\\001_TORA\\01_BERESHIT\\g_EbenEzra.txt":
                    return "בראשית - אבן עזרא";
                case "Books\\001_TORA\\01_BERESHIT\\h_BaalHaturim.txt":
                    return "בראשית - בעל הטורים";
                case "Books\\001_TORA\\01_BERESHIT\\i_onqelus.txt":
                    return "בראשית - תרגום אונקלוס";
                case "Books\\001_TORA\\01_BERESHIT\\j_sforno.txt":
                    return "בראשית - ספורנו";
                case "Books\\001_TORA\\01_BERESHIT\\k_keli_yakar1.txt":
                    return "בראשית - כלי יקר";
                case "Books\\001_TORA\\01_BERESHIT\\m_daatzkenim1.txt":
                    return "בראשית - דעת זקנים";
                case "Books\\001_TORA\\01_BERESHIT\\w_raba1.txt":
                    return "מדרש רבה - חומש בראשית";
                case "Books\\001_TORA\\01_BERESHIT\\w_tanchuma1.txt":
                    return "מדרש תנחומא - בראשית";
                case "Books\\001_TORA\\01_BERESHIT\\w_ts_shimoni_bereshit.txt":
                    return "ילקוט שמעוני - בראשית";
                case "Books\\001_TORA\\01_BERESHIT\\x2_Interleave.txt":
                    return "בראשית - רש''י ושפתי חכמים";
                case "Books\\001_TORA\\01_BERESHIT\\x_Interleave.txt":
                    return "בראשית - מקרא ותרגום";
                case "Books\\001_TORA\\01_BERESHIT\\x_Interleave2.txt":
                    return "בראשית - מקרא ותרגום (ט)";
                case "Books\\001_TORA\\01_BERESHIT\\y_hok10.txt":
                    return "חק לישראל - בראשית";
                case "Books\\001_TORA\\01_BERESHIT\\y_hok11.txt":
                    return "חק לישראל - בראשית  (ט)";
                case "Books\\001_TORA\\01_BERESHIT\\z_Interleave.txt":
                    return "בראשית";
                case "Books\\001_TORA\\01_BERESHIT\\z_Interleave2.txt":
                    return "בראשית (ט)";
                case "Books\\001_TORA\\02_SHEMOT\\a02__Exodus.txt":
                    return "שמות  -עם טעמים";
                case "Books\\001_TORA\\02_SHEMOT\\a02_Exodus.txt":
                    return "שמות  -עם ניקוד";

                case "Books\\001_TORA\\02_SHEMOT\\b02_Exodus.txt":
                    return "שמות  - ללא ניקוד";
                case "Books\\001_TORA\\02_SHEMOT\\c_RASHI_SHEMOT_L1.txt":
                    return "שמות - רש''י";
                case "Books\\001_TORA\\02_SHEMOT\\c_RASHI_SHEMOT_OLD.txt":
                    return "שמות - רש''י (ב)";
                case "Books\\001_TORA\\02_SHEMOT\\c_siftei_2.txt":
                    return "שמות - שפתי חכמים";
                case "Books\\001_TORA\\02_SHEMOT\\d_ramban_shemot.txt":
                    return "שמות - רמב''ן";
                case "Books\\001_TORA\\02_SHEMOT\\e02_Exodus.txt":
                    return "שמות - תרגום יונתן";
                case "Books\\001_TORA\\02_SHEMOT\\f_OrHachaim.txt":
                    return "שמות - אור החיים";
                case "Books\\001_TORA\\02_SHEMOT\\g_EbenEzra.txt":
                    return "שמות - אבן עזרא";
                case "Books\\001_TORA\\02_SHEMOT\\h_BaalHaturim.txt":
                    return "שמות - בעל הטורים";
                case "Books\\001_TORA\\02_SHEMOT\\i_onqelus.txt":
                    return "שמות - תרגום אונקלוס";
                case "Books\\001_TORA\\02_SHEMOT\\j_sforno.txt":
                    return "שמות - ספורנו";
                case "Books\\001_TORA\\02_SHEMOT\\k_keli_yakar2.txt":
                    return "שמות - כלי יקר";
                case "Books\\001_TORA\\02_SHEMOT\\m_daatzkenim2.txt":
                    return "שמות - דעת זקנים";
                case "Books\\001_TORA\\02_SHEMOT\\w_raba2.txt":
                    return "מדרש רבה - חומש שמות";
                case "Books\\001_TORA\\02_SHEMOT\\w_tanchuma2.txt":
                    return "מדרש תנחומא - שמות";
                case "Books\\001_TORA\\02_SHEMOT\\w_ts_shimoni_shemot.txt":
                    return "ילקוט שמעוני - שמות";
                case "Books\\001_TORA\\02_SHEMOT\\x2_Interleave.txt":
                    return "שמות - רש''י ושפתי חכמים";
                case "Books\\001_TORA\\02_SHEMOT\\x_Interleave.txt":
                    return "שמות - מקרא ותרגום";
                case "Books\\001_TORA\\02_SHEMOT\\x_Interleave2.txt":
                    return "שמות - מקרא ותרגום (ט)";
                case "Books\\001_TORA\\02_SHEMOT\\y_hok20.txt":
                    return "חק לישראל - שמות";
                case "Books\\001_TORA\\02_SHEMOT\\y_hok21.txt":
                    return "חק לישראל - שמות  (ט)";
                case "Books\\001_TORA\\02_SHEMOT\\z_Interleave.txt":
                    return "שמות";
                case "Books\\001_TORA\\02_SHEMOT\\z_Interleave2.txt":
                    return "שמות (ט)";
                case "Books\\001_TORA\\03_VAIKRA\\a03__Leviticus.txt":
                    return "ויקרא - עם טעמים";
                case "Books\\001_TORA\\03_VAIKRA\\a03_Leviticus.txt":
                    return "ויקרא - עם ניקוד";

                case "Books\\001_TORA\\03_VAIKRA\\b03_Leviticus.txt":
                    return "ויקרא  - ללא ניקוד";
                case "Books\\001_TORA\\03_VAIKRA\\c_RASHI_VAYIKRA_L1.txt":
                    return "ויקרא - רש''י";
                case "Books\\001_TORA\\03_VAIKRA\\c_RASHI_VAYIKRA_OLD.txt":
                    return "ויקרא - רש''י (ב)";
                case "Books\\001_TORA\\03_VAIKRA\\c_siftei_3.txt":
                    return "ויקרא - שפתי חכמים";
                case "Books\\001_TORA\\03_VAIKRA\\d_ramban_vayikra.txt":
                    return "ויקרא - רמב''ן";
                case "Books\\001_TORA\\03_VAIKRA\\e03_Leviticus.txt":
                    return "ויקרא - תרגום יונתן";
                case "Books\\001_TORA\\03_VAIKRA\\f_OrHachaim.txt":
                    return "ויקרא אור החיים";
                case "Books\\001_TORA\\03_VAIKRA\\g_EbenEzra.txt":
                    return "ויקרא - אבן עזרא";
                case "Books\\001_TORA\\03_VAIKRA\\h_BaalHaturim.txt":
                    return "ויקרא - בעל הטורים";
                case "Books\\001_TORA\\03_VAIKRA\\i_onqelus.txt":
                    return "ויקרא - תרגום אונקלוס";
                case "Books\\001_TORA\\03_VAIKRA\\j_sforno.txt":
                    return "ויקרא - ספורנו";
                case "Books\\001_TORA\\03_VAIKRA\\k_keli_yakar3.txt":
                    return "ויקרא - כלי יקר";
                case "Books\\001_TORA\\03_VAIKRA\\m_daatzkenim3.txt":
                    return "ויקרא - דעת זקנים";
                case "Books\\001_TORA\\03_VAIKRA\\w_raba3.txt":
                    return "מדרש רבה - חומש ויקרא";
                case "Books\\001_TORA\\03_VAIKRA\\w_tanchuma3.txt":
                    return "מדרש תנחומא - ויקרא";
                case "Books\\001_TORA\\03_VAIKRA\\w_ts_shimoni_vayikra.txt":
                    return "ילקוט שמעוני - ויקרא";
                case "Books\\001_TORA\\03_VAIKRA\\x2_Interleave.txt":
                    return "ויקרא - רש''י ושפתי חכמים";
                case "Books\\001_TORA\\03_VAIKRA\\x_Interleave.txt":
                    return "ויקרא - מקרא ותרגום";
                case "Books\\001_TORA\\03_VAIKRA\\x_Interleave2.txt":
                    return "ויקרא - מקרא ותרגום (ט)";
                case "Books\\001_TORA\\03_VAIKRA\\y_hok30.txt":
                    return "חק לישראל - ויקרא";
                case "Books\\001_TORA\\03_VAIKRA\\y_hok31.txt":
                    return "חק לישראל - ויקרא  (ט)";
                case "Books\\001_TORA\\03_VAIKRA\\z_Interleave.txt":
                    return "ויקרא";
                case "Books\\001_TORA\\03_VAIKRA\\z_Interleave2.txt":
                    return "ויקרא (ט)";

                case "Books\\001_TORA\\04_BAMIDBAR\\a04__Numbers.txt":
                    return "במדבר - עם טעמים";
                case "Books\\001_TORA\\04_BAMIDBAR\\a04_Numbers.txt":
                    return "במדבר - עם ניקוד";

                case "Books\\001_TORA\\04_BAMIDBAR\\b04_Numbers.txt":
                    return "במדבר - ללא ניקוד";
                case "Books\\001_TORA\\04_BAMIDBAR\\c_RASHI_BAMIDBAR_L1.txt":
                    return "במדבר - רש''י";
                case "Books\\001_TORA\\04_BAMIDBAR\\c_RASHI_BAMIDBAR_OLD.txt":
                    return "במדבר - רש''י (ב)";
                case "Books\\001_TORA\\04_BAMIDBAR\\c_siftei_4.txt":
                    return "במדבר - שפתי חכמים";
                case "Books\\001_TORA\\04_BAMIDBAR\\d_ramban_bamidbar.txt":
                    return "במדבר - רמב''ן";
                case "Books\\001_TORA\\04_BAMIDBAR\\e04_Numbers.txt":
                    return "במדבר - תרגום יונתן";
                case "Books\\001_TORA\\04_BAMIDBAR\\f_OrHachaim.txt":
                    return "במדבר אור החיים";
                case "Books\\001_TORA\\04_BAMIDBAR\\g_EbenEzra.txt":
                    return "במדבר - אבן עזרא";
                case "Books\\001_TORA\\04_BAMIDBAR\\h_BaalHaturim.txt":
                    return "במדבר - בעל הטורים";
                case "Books\\001_TORA\\04_BAMIDBAR\\i_onqelus.txt":
                    return "במדבר - תרגום אונקלוס";
                case "Books\\001_TORA\\04_BAMIDBAR\\j_sforno.txt":
                    return "במדבר - ספורנו";
                case "Books\\001_TORA\\04_BAMIDBAR\\k_keli_yakar4.txt":
                    return "במדבר - כלי יקר";
                case "Books\\001_TORA\\04_BAMIDBAR\\m_daatzkenim4.txt":
                    return "במדבר - דעת זקנים";
                case "Books\\001_TORA\\04_BAMIDBAR\\w_raba4.txt":
                    return "מדרש רבה - חומש במדבר";
                case "Books\\001_TORA\\04_BAMIDBAR\\w_tanchuma4.txt":
                    return "מדרש תנחומא - במדבר";
                case "Books\\001_TORA\\04_BAMIDBAR\\w_ts_shimoni_bamidbar.txt":
                    return "ילקוט שמעוני - במדבר";
                case "Books\\001_TORA\\04_BAMIDBAR\\x2_Interleave.txt":
                    return "במדבר - רש''י ושפתי חכמים";
                case "Books\\001_TORA\\04_BAMIDBAR\\x_Interleave.txt":
                    return "במדבר - מקרא ותרגום";
                case "Books\\001_TORA\\04_BAMIDBAR\\x_Interleave2.txt":
                    return "במדבר - מקרא ותרגום (ט)";
                case "Books\\001_TORA\\04_BAMIDBAR\\y_hok40.txt":
                    return "חק לישראל - במדבר";
                case "Books\\001_TORA\\04_BAMIDBAR\\y_hok41.txt":
                    return "חק לישראל - במדבר  (ט)";
                case "Books\\001_TORA\\04_BAMIDBAR\\z_Interleave.txt":
                    return "במדבר";
                case "Books\\001_TORA\\04_BAMIDBAR\\z_Interleave2.txt":
                    return "במדבר (ט)";
                case "Books\\001_TORA\\05_DEVARIM\\a05__Deuteronomy.txt":
                    return "דברים - עם טעמים";
                case "Books\\001_TORA\\05_DEVARIM\\a05_Deuteronomy.txt":
                    return "דברים - עם ניקוד";

                case "Books\\001_TORA\\05_DEVARIM\\b05_Deuteronomy.txt":
                    return "דברים - ללא ניקוד";
                case "Books\\001_TORA\\05_DEVARIM\\c_RASHI_DVARIM_L1.txt":
                    return "דברים - רש''י";
                case "Books\\001_TORA\\05_DEVARIM\\c_RASHI_DVARIM_OLD.txt":
                    return "דברים - רש''י (ב)";
                case "Books\\001_TORA\\05_DEVARIM\\c_siftei_5.txt":
                    return "דברים - שפתי חכמים";
                case "Books\\001_TORA\\05_DEVARIM\\d_ramban_dvarim.txt":
                    return "דברים - רמב''ן";
                case "Books\\001_TORA\\05_DEVARIM\\e05_Deuteronomy.txt":
                    return "דברים - תרגום יונתן";
                case "Books\\001_TORA\\05_DEVARIM\\f_OrHachaim.txt":
                    return "דברים אור החיים";
                case "Books\\001_TORA\\05_DEVARIM\\g_EbenEzra.txt":
                    return "דברים - אבן עזרא";
                case "Books\\001_TORA\\05_DEVARIM\\h_BaalHaturim.txt":
                    return "דברים - בעל הטורים";
                case "Books\\001_TORA\\05_DEVARIM\\i_onqelus.txt":
                    return "דברים - תרגום אונקלוס";
                case "Books\\001_TORA\\05_DEVARIM\\j_sforno.txt":
                    return "דברים - ספורנו";
                case "Books\\001_TORA\\05_DEVARIM\\k_keli_yakar5.txt":
                    return "דברים - כלי יקר";
                case "Books\\001_TORA\\05_DEVARIM\\m_daatzkenim5.txt":
                    return "דברים - דעת זקנים";
                case "Books\\001_TORA\\05_DEVARIM\\w_raba5.txt":
                    return "מדרש רבה - חומש דברים";
                case "Books\\001_TORA\\05_DEVARIM\\w_tanchuma5.txt":
                    return "מדרש תנחומא - דברים";
                case "Books\\001_TORA\\05_DEVARIM\\w_ts_shimoni_devarim.txt":
                    return "ילקוט שמעוני - דברים";
                case "Books\\001_TORA\\05_DEVARIM\\x2_Interleave.txt":
                    return "דברים - רש''י ושפתי חכמים";
                case "Books\\001_TORA\\05_DEVARIM\\x_Interleave.txt":
                    return "דברים - מקרא ותרגום";
                case "Books\\001_TORA\\05_DEVARIM\\x_Interleave2.txt":
                    return "דברים - מקרא ותרגום (ט)";
                case "Books\\001_TORA\\05_DEVARIM\\y_hok50.txt":
                    return "חק לישראל - דברים";
                case "Books\\001_TORA\\05_DEVARIM\\y_hok51.txt":
                    return "חק לישראל - דברים  (ט)";
                case "Books\\001_TORA\\05_DEVARIM\\z_Interleave.txt":
                    return "דברים";
                case "Books\\001_TORA\\05_DEVARIM\\z_Interleave2.txt":
                    return "דברים (ט)";
                case "Books\\002_NAVI":
                    return "יהושע";
                case "Books\\002_NAVI\\06_YEHOSUA\\a06__Joshua.txt":
                    return "יהושע - עם טעמים";
                case "Books\\002_NAVI\\06_YEHOSUA\\a06_Joshua.txt":
                    return "יהושע - עם ניקוד";

                case "Books\\002_NAVI\\06_YEHOSUA\\b06_Joshua.txt":
                    return "יהושע - ללא ניקוד";
                case "Books\\002_NAVI\\06_YEHOSUA\\eNA_YEHOSUA_L1.txt":
                    return "יהושע - רש''י";
                case "Books\\002_NAVI\\06_YEHOSUA\\fNA_YEHOSUA_L1.txt":
                    return "יהושע - מצודת דוד";
                case "Books\\002_NAVI\\06_YEHOSUA\\gNA_YEHOSUA_L1.txt":
                    return "יהושע - מצודת ציון";
                case "Books\\002_NAVI\\06_YEHOSUA\\gNA_YEHOSUA_L1_2.txt":
                    return "יהושע - רלב''ג";
                case "Books\\002_NAVI\\06_YEHOSUA\\h_Interleave.txt":
                    return "יהושע";
                case "Books\\002_NAVI\\06_YEHOSUA\\h_Interleave2.txt":
                    return "יהושע (ט)";
                case "Books\\002_NAVI\\07_SHOFETIM":
                    return "שופטים";
                case "Books\\002_NAVI\\07_SHOFETIM\\a07__Judges.txt":
                    return "שופטים - עם טעמים";
                case "Books\\002_NAVI\\07_SHOFETIM\\a07_Judges.txt":
                    return "שופטים - עם ניקוד";

                case "Books\\002_NAVI\\07_SHOFETIM\\b07_Judges.txt":
                    return "שופטים - ללא ניקוד";
                case "Books\\002_NAVI\\07_SHOFETIM\\eNA_SHOFTIM_L1.txt":
                    return "שופטים - רש''י";
                case "Books\\002_NAVI\\07_SHOFETIM\\fNA_SHOFTIM_L2.txt":
                    return "שופטים - מצודת דוד";
                case "Books\\002_NAVI\\07_SHOFETIM\\gNA_SHOFTIM_L1.txt":
                    return "שופטים - מצודת ציון";
                case "Books\\002_NAVI\\07_SHOFETIM\\gNA_SHOFTIM_L1_2.txt":
                    return "שופטים - רלב''ג";
                case "Books\\002_NAVI\\07_SHOFETIM\\h_Interleave.txt":
                    return "שופטים";
                case "Books\\002_NAVI\\07_SHOFETIM\\h_Interleave2.txt":
                    return "שופטים (ט)";
                case "Books\\002_NAVI\\08_SHEMUEL_A":
                    return "שמואל א";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\a08_Samuel__1.txt":
                    return "שמואל א - עם טעמים";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\a08_Samuel_1.txt":
                    return "שמואל א - עם ניקוד";

                case "Books\\002_NAVI\\08_SHEMUEL_A\\b08_Samuel_1.txt":
                    return "שמואל א - ללא ניקוד";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\eNA_SHMUEL_A_L1.txt":
                    return "שמואל א - רש''י";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\fNA_SHMUEL_A_L1.txt":
                    return "שמואל א - מצודת דוד";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L1.txt":
                    return "שמואל א - מצודת ציון";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L1_2.txt":
                    return "שמואל א - רלב''ג";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L3_MALBIM.txt":
                    return "שמואל א - מלבי''ם";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\h_Interleave.txt":
                    return "שמואל א";
                case "Books\\002_NAVI\\08_SHEMUEL_A\\h_Interleave2.txt":
                    return "שמואל א (ט)";
                case "Books\\002_NAVI\\09_SHEMUEL_B":
                    return "שמואל ב";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\a09_Samuel__2.txt":
                    return "שמואל ב - עם טעמים";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\a09_Samuel_2.txt":
                    return "שמואל ב - עם ניקוד";

                case "Books\\002_NAVI\\09_SHEMUEL_B\\b09_Samuel_2.txt":
                    return "שמואל ב - ללא ניקוד";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\eNA_SHMUEL_B_L1.txt":
                    return "שמואל ב - רש''י";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\fNA_SHMUEL_B_L1.txt":
                    return "שמואל ב - מצודת דוד";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L1.txt":
                    return "שמואל ב - מצודת ציון";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L1_2.txt":
                    return "שמואל ב - רלב''ג";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L3_MALBIM.txt":
                    return "שמואל ב - מלבי''ם";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\h_Interleave.txt":
                    return "שמואל ב";
                case "Books\\002_NAVI\\09_SHEMUEL_B\\h_Interleave2.txt":
                    return "שמואל ב (ט)";
                case "Books\\002_NAVI\\10_MELACIM_A":
                    return "מלכים א";
                case "Books\\002_NAVI\\10_MELACIM_A\\a10_Kings__1.txt":
                    return "מלכים א - עם טעמים";
                case "Books\\002_NAVI\\10_MELACIM_A\\a10_Kings_1.txt":
                    return "מלכים א - עם ניקוד";

                case "Books\\002_NAVI\\10_MELACIM_A\\b10_Kings_1.txt":
                    return "מלכים א - ללא ניקוד";
                case "Books\\002_NAVI\\10_MELACIM_A\\eNA_MELACHIM_A_L1.txt":
                    return "מלכים א - רש''י";
                case "Books\\002_NAVI\\10_MELACIM_A\\fNA_MELACHIM_A_L1.txt":
                    return "מלכים א - מצודת דוד";
                case "Books\\002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1.txt":
                    return "מלכים א - מצודת ציון";
                case "Books\\002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1_2.txt":
                    return "מלכים א - רלב''ג";
                case "Books\\002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1_MALBIM.txt":
                    return "מלכים א - מלבי''ם";
                case "Books\\002_NAVI\\10_MELACIM_A\\h_Interleave.txt":
                    return "מלכים א";
                case "Books\\002_NAVI\\10_MELACIM_A\\h_Interleave2.txt":
                    return "מלכים א (ט)";
                case "Books\\002_NAVI\\11_MELACIM_B":
                    return "מלכים ב";
                case "Books\\002_NAVI\\11_MELACIM_B\\a11_Kings__2.txt":
                    return "מלכים ב - עם טעמים";
                case "Books\\002_NAVI\\11_MELACIM_B\\a11_Kings_2.txt":
                    return "מלכים ב - עם ניקוד";

                case "Books\\002_NAVI\\11_MELACIM_B\\b11_Kings_2.txt":
                    return "מלכים ב - ללא ניקוד";
                case "Books\\002_NAVI\\11_MELACIM_B\\eNA_MELACHIM_B_L1.txt":
                    return "מלכים ב - רש''י";
                case "Books\\002_NAVI\\11_MELACIM_B\\fNA_MELACHIM_B_L1.txt":
                    return "מלכים ב - מצודת דוד";
                case "Books\\002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1.txt":
                    return "מלכים ב - מצודת ציון";
                case "Books\\002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1_2.txt":
                    return "מלכים ב - רלב''ג";
                case "Books\\002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1_MALBIM.txt":
                    return "מלכים ב - מלבי''ם";
                case "Books\\002_NAVI\\11_MELACIM_B\\h_Interleave.txt":
                    return "מלכים ב";
                case "Books\\002_NAVI\\11_MELACIM_B\\h_Interleave2.txt":
                    return "מלכים ב (ט)";
                case "Books\\002_NAVI\\12_YISHAYA":
                    return "ישעיה";
                case "Books\\002_NAVI\\12_YISHAYA\\a12__Isaiah.txt":
                    return "ישעיה - עם טעמים";
                case "Books\\002_NAVI\\12_YISHAYA\\a12_Isaiah.txt":
                    return "ישעיה - עם ניקוד";

                case "Books\\002_NAVI\\12_YISHAYA\\b12_Isaiah.txt":
                    return "ישעיה - ללא ניקוד";
                case "Books\\002_NAVI\\12_YISHAYA\\eNA_YISHAYA_L1.txt":
                    return "ישעיה - רש''י";
                case "Books\\002_NAVI\\12_YISHAYA\\fNA_YISHAYA_L1.txt":
                    return "ישעיה - מצודת דוד";
                case "Books\\002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L1.txt":
                    return "ישעיה - מצודת ציון";
                case "Books\\002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L1_MALBIM.txt":
                    return "ישעיה - מלבי''ם - ב. הענין";
                case "Books\\002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L2_MALBIM.txt":
                    return "ישעיה - מלבי''ם - ב. המילת";
                case "Books\\002_NAVI\\12_YISHAYA\\h_Interleave.txt":
                    return "ישעיה";
                case "Books\\002_NAVI\\12_YISHAYA\\h_Interleave2.txt":
                    return "ישעיה (ט)";
                case "Books\\002_NAVI\\13_YERMIYA":
                    return "ירמיה";
                case "Books\\002_NAVI\\13_YERMIYA\\a13__Jeremiah.txt":
                    return "ירמיה - עם טעמים";
                case "Books\\002_NAVI\\13_YERMIYA\\a13_Jeremiah.txt":
                    return "ירמיה - עם ניקוד";

                case "Books\\002_NAVI\\13_YERMIYA\\b13_Jeremiah.txt":
                    return "ירמיה - ללא ניקוד";
                case "Books\\002_NAVI\\13_YERMIYA\\eNA_YERMIYA_L1.txt":
                    return "ירמיה - רש''י";
                case "Books\\002_NAVI\\13_YERMIYA\\fNA_YERMIYA_L1.txt":
                    return "ירמיה - מצודת דוד";
                case "Books\\002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L1.txt":
                    return "ירמיה - מצודת ציון";
                case "Books\\002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L1_MALBIM.txt":
                    return "ירמיה- מלבי''ם - ב. הענין";
                case "Books\\002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L2_MALBIM.txt":
                    return "ירמיה - מלבי''ם - ב. המילת";
                case "Books\\002_NAVI\\13_YERMIYA\\h_Interleave.txt":
                    return "ירמיה";
                case "Books\\002_NAVI\\13_YERMIYA\\h_Interleave2.txt":
                    return "ירמיה (ט)";
                case "Books\\002_NAVI\\14_YEHEZKEL":
                    return "יחזקאל";
                case "Books\\002_NAVI\\14_YEHEZKEL\\a14__Ezekiel.txt":
                    return "יחזקאל - עם טעמים";
                case "Books\\002_NAVI\\14_YEHEZKEL\\a14_Ezekiel.txt":
                    return "יחזקאל - עם ניקוד";

                case "Books\\002_NAVI\\14_YEHEZKEL\\b14_Ezekiel.txt":
                    return "יחזקאל - ללא ניקוד";
                case "Books\\002_NAVI\\14_YEHEZKEL\\eNA_YEHEZKEL_L1.txt":
                    return "יחזקאל - רש''י";
                case "Books\\002_NAVI\\14_YEHEZKEL\\fNA_YEHEZKEL_L1.txt":
                    return "יחזקאל - מצודת דוד";
                case "Books\\002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L1.txt":
                    return "יחזקאל - מצודת ציון";
                case "Books\\002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L1_MALBIM.txt":
                    return "יחזקאל - מלבי''ם - ב. הענין";
                case "Books\\002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L2_MALBIM.txt":
                    return "[2] יחזקאל - מלבי''ם - ב. הענין";
                case "Books\\002_NAVI\\14_YEHEZKEL\\h_Interleave.txt":
                    return "יחזקאל";
                case "Books\\002_NAVI\\14_YEHEZKEL\\h_Interleave2.txt":
                    return "יחזקאל (ט)";
                case "Books\\002_NAVI\\15_HOSEA":
                    return "הושע";
                case "Books\\002_NAVI\\15_HOSEA\\a15__Hosea.txt":
                    return "הושע - עם טעמים";
                case "Books\\002_NAVI\\15_HOSEA\\a15_Hosea.txt":
                    return "הושע - עם ניקוד";

                case "Books\\002_NAVI\\15_HOSEA\\b15_Hosea.txt":
                    return "הושע - ללא ניקוד";
                case "Books\\002_NAVI\\15_HOSEA\\eNA_HOSEA_L1.txt":
                    return "הושע - רש''י";
                case "Books\\002_NAVI\\15_HOSEA\\fNA_HOSEA_L1.txt":
                    return "הושע - מצודת דוד";
                case "Books\\002_NAVI\\15_HOSEA\\gNA_HOSEA_L1.txt":
                    return "הושע - מצודת ציון";
                case "Books\\002_NAVI\\15_HOSEA\\h_Interleave.txt":
                    return "הושע";
                case "Books\\002_NAVI\\15_HOSEA\\h_Interleave2.txt":
                    return "הושע (ט)";
                case "Books\\002_NAVI\\16_YOEL":
                    return "יואל";
                case "Books\\002_NAVI\\16_YOEL\\a16__Joel.txt":
                    return "יואל - עם טעמים";
                case "Books\\002_NAVI\\16_YOEL\\a16_Joel.txt":
                    return "יואל - עם ניקוד";

                case "Books\\002_NAVI\\16_YOEL\\b16_Joel.txt":
                    return "יואל - ללא ניקוד";
                case "Books\\002_NAVI\\16_YOEL\\eNA_YOEL_L1.txt":
                    return "יואל - רש''י";
                case "Books\\002_NAVI\\16_YOEL\\fNA_YOEL_L1.txt":
                    return "יואל - מצודת דוד";
                case "Books\\002_NAVI\\16_YOEL\\gNA_YOEL_L1.txt":
                    return "יואל - מצודת ציון";
                case "Books\\002_NAVI\\16_YOEL\\h_Interleave.txt":
                    return "יואל";
                case "Books\\002_NAVI\\16_YOEL\\h_Interleave2.txt":
                    return "יואל (ט)";
                case "Books\\002_NAVI\\17_AMOS":
                    return "עמוס";
                case "Books\\002_NAVI\\17_AMOS\\a17__Amos.txt":
                    return "עמוס - עם טעמים";
                case "Books\\002_NAVI\\17_AMOS\\a17_Amos.txt":
                    return "עמוס - עם ניקוד";

                case "Books\\002_NAVI\\17_AMOS\\b17_Amos.txt":
                    return "עמוס - ללא ניקוד";
                case "Books\\002_NAVI\\17_AMOS\\eNA_AMOS_L1.txt":
                    return "עמוס - רש''י";
                case "Books\\002_NAVI\\17_AMOS\\fNA_AMOS_L2.txt":
                    return "עמוס - מצודת דוד";
                case "Books\\002_NAVI\\17_AMOS\\gNA_AMOS_L1.txt":
                    return "עמוס - מצודת ציון";
                case "Books\\002_NAVI\\17_AMOS\\h_Interleave.txt":
                    return "עמוס";
                case "Books\\002_NAVI\\17_AMOS\\h_Interleave2.txt":
                    return "עמוס (ט)";
                case "Books\\002_NAVI\\18_OVADYA":
                    return "עובדיה";
                case "Books\\002_NAVI\\18_OVADYA\\a18__Obadiah.txt":
                    return "עובדיה - עם טעמים";
                case "Books\\002_NAVI\\18_OVADYA\\a18_Obadiah.txt":
                    return "עובדיה - עם ניקוד";

                case "Books\\002_NAVI\\18_OVADYA\\b18_Obadiah.txt":
                    return "עובדיה - ללא ניקוד";
                case "Books\\002_NAVI\\18_OVADYA\\eNA_OVADYA_L1.txt":
                    return "עובדיה - רש''י";
                case "Books\\002_NAVI\\18_OVADYA\\fNA_OVADYA_L1.txt":
                    return "עובדיה - מצודת דוד";
                case "Books\\002_NAVI\\18_OVADYA\\gNA_OVADYA_L1.txt":
                    return "עובדיה - מצודת ציון";
                case "Books\\002_NAVI\\18_OVADYA\\h_Interleave.txt":
                    return "עובדיה";
                case "Books\\002_NAVI\\18_OVADYA\\h_Interleave2.txt":
                    return "עובדיה (ט)";
                case "Books\\002_NAVI\\19_YONA":
                    return "יונה";
                case "Books\\002_NAVI\\19_YONA\\a19__Jonah.txt":
                    return "יונה - עם טעמים";
                case "Books\\002_NAVI\\19_YONA\\a19_Jonah.txt":
                    return "יונה - עם ניקוד";

                case "Books\\002_NAVI\\19_YONA\\b19_Jonah.txt":
                    return "יונה - ללא ניקוד";
                case "Books\\002_NAVI\\19_YONA\\eNA_YONA_L1.txt":
                    return "יונה - רש''י";
                case "Books\\002_NAVI\\19_YONA\\fNA_YONA_L1.txt":
                    return "יונה - מצודת דוד";
                case "Books\\002_NAVI\\19_YONA\\gNA_YONA_L1.txt":
                    return "יונה - מצודת ציון";
                case "Books\\002_NAVI\\19_YONA\\h_Interleave.txt":
                    return "יונה";
                case "Books\\002_NAVI\\19_YONA\\h_Interleave2.txt":
                    return "יונה (ט)";
                case "Books\\002_NAVI\\20_MICHA":
                    return "מיכה";
                case "Books\\002_NAVI\\20_MICHA\\a20__Micah.txt":
                    return "מיכה - עם טעמים";
                case "Books\\002_NAVI\\20_MICHA\\a20_Micah.txt":
                    return "מיכה - עם ניקוד";

                case "Books\\002_NAVI\\20_MICHA\\b20_Micah.txt":
                    return "מיכה - ללא ניקוד";
                case "Books\\002_NAVI\\20_MICHA\\eNA_MICHA_L1.txt":
                    return "מיכה - רש''י";
                case "Books\\002_NAVI\\20_MICHA\\fNA_MICHA_L1.txt":
                    return "מיכה - מצודת דוד";
                case "Books\\002_NAVI\\20_MICHA\\gNA_MICHA_L1.txt":
                    return "מיכה - מצודת ציון";
                case "Books\\002_NAVI\\20_MICHA\\h_Interleave.txt":
                    return "מיכה";
                case "Books\\002_NAVI\\20_MICHA\\h_Interleave2.txt":
                    return "מיכה (ט)";
                case "Books\\002_NAVI\\21_NAHUM":
                    return "נחום";
                case "Books\\002_NAVI\\21_NAHUM\\a21__Nahum.txt":
                    return "נחום - עם טעמים";
                case "Books\\002_NAVI\\21_NAHUM\\a21_Nahum.txt":
                    return "נחום - עם ניקוד";

                case "Books\\002_NAVI\\21_NAHUM\\b21_Nahum.txt":
                    return "נחום - ללא ניקוד";
                case "Books\\002_NAVI\\21_NAHUM\\eNA_NAHUM_L1.txt":
                    return "נחום - רש''י";
                case "Books\\002_NAVI\\21_NAHUM\\fNA_NAHUM_L1.txt":
                    return "נחום - מצודת דוד";
                case "Books\\002_NAVI\\21_NAHUM\\gNA_NAHUM_L1.txt":
                    return "נחום - מצודת ציון";
                case "Books\\002_NAVI\\21_NAHUM\\h_Interleave.txt":
                    return "נחום";
                case "Books\\002_NAVI\\21_NAHUM\\h_Interleave2.txt":
                    return "נחום (ט)";
                case "Books\\002_NAVI\\22_HAVAKUK":
                    return "חבקוק";
                case "Books\\002_NAVI\\22_HAVAKUK\\a22__Habakkuk.txt":
                    return "חבקוק - עם טעמים";
                case "Books\\002_NAVI\\22_HAVAKUK\\a22_Habakkuk.txt":
                    return "חבקוק - עם ניקוד";

                case "Books\\002_NAVI\\22_HAVAKUK\\b22_Habakkuk.txt":
                    return "חבקוק - ללא ניקוד";
                case "Books\\002_NAVI\\22_HAVAKUK\\eNA_HAVAKUK_L1.txt":
                    return "חבקוק - רש''י";
                case "Books\\002_NAVI\\22_HAVAKUK\\fNA_HAVAKUK_L1.txt":
                    return "חבקוק - מצודת דוד";
                case "Books\\002_NAVI\\22_HAVAKUK\\gNA_HAVAKUK_L1.txt":
                    return "חבקוק - מצודת ציון";
                case "Books\\002_NAVI\\22_HAVAKUK\\h_Interleave.txt":
                    return "חבקוק";
                case "Books\\002_NAVI\\22_HAVAKUK\\h_Interleave2.txt":
                    return "חבקוק (ט)";
                case "Books\\002_NAVI\\23_ZFANYA":
                    return "צפניה";
                case "Books\\002_NAVI\\23_ZFANYA\\a23__Zephaniah.txt":
                    return "צפניה - עם טעמים";
                case "Books\\002_NAVI\\23_ZFANYA\\a23_Zephaniah.txt":
                    return "צפניה - עם ניקוד";

                case "Books\\002_NAVI\\23_ZFANYA\\b23_Zephaniah.txt":
                    return "צפניה - ללא ניקוד";
                case "Books\\002_NAVI\\23_ZFANYA\\eNA_ZFANYA_L1.txt":
                    return "צפניה - רש''י";
                case "Books\\002_NAVI\\23_ZFANYA\\fNA_ZFANYA_L1.txt":
                    return "צפניה - מצודת דוד";
                case "Books\\002_NAVI\\23_ZFANYA\\gNA_ZFANYA_L1.txt":
                    return "צפניה - מצודת ציון";
                case "Books\\002_NAVI\\23_ZFANYA\\h_Interleave.txt":
                    return "צפניה";
                case "Books\\002_NAVI\\23_ZFANYA\\h_Interleave2.txt":
                    return "צפניה (ט)";
                case "Books\\002_NAVI\\24_HAGAY":
                    return "חגי";
                case "Books\\002_NAVI\\24_HAGAY\\a24__Haggai.txt":
                    return "חגי - עם טעמים";
                case "Books\\002_NAVI\\24_HAGAY\\a24_Haggai.txt":
                    return "חגי - עם ניקוד";

                case "Books\\002_NAVI\\24_HAGAY\\b24_Haggai.txt":
                    return "חגי - ללא ניקוד";
                case "Books\\002_NAVI\\24_HAGAY\\eNA_HAGAY_L1.txt":
                    return "חגי - רש''י";
                case "Books\\002_NAVI\\24_HAGAY\\fNA_HAGAY_L1.txt":
                    return "חגי - מצודת דוד";
                case "Books\\002_NAVI\\24_HAGAY\\gNA_HAGAY_L1.txt":
                    return "חגי - מצודת ציון";
                case "Books\\002_NAVI\\24_HAGAY\\h_Interleave.txt":
                    return "חגי";
                case "Books\\002_NAVI\\24_HAGAY\\h_Interleave2.txt":
                    return "חגי (ט)";
                case "Books\\002_NAVI\\25_ZECHARYA":
                    return "זכריה";
                case "Books\\002_NAVI\\25_ZECHARYA\\a25__Zechariah.txt":
                    return "זכריה - עם טעמים";
                case "Books\\002_NAVI\\25_ZECHARYA\\a25_Zechariah.txt":
                    return "זכריה - עם ניקוד";

                case "Books\\002_NAVI\\25_ZECHARYA\\b25_Zechariah.txt":
                    return "זכריה - ללא ניקוד";
                case "Books\\002_NAVI\\25_ZECHARYA\\eNA_ZECHARYA_L1.txt":
                    return "זכריה - רש''י";
                case "Books\\002_NAVI\\25_ZECHARYA\\fNA_ZECHARYA_L1.txt":
                    return "זכריה - מצודת דוד";
                case "Books\\002_NAVI\\25_ZECHARYA\\gNA_ZECHARYA_L1.txt":
                    return "זכריה - מצודת ציון";
                case "Books\\002_NAVI\\25_ZECHARYA\\h_Interleave.txt":
                    return "זכריה";
                case "Books\\002_NAVI\\25_ZECHARYA\\h_Interleave2.txt":
                    return "זכריה (ט)";
                case "Books\\002_NAVI\\26_MALACHI":
                    return "מלאכי";
                case "Books\\002_NAVI\\26_MALACHI\\a26__Malachi.txt":
                    return "מלאכי - עם טעמים";
                case "Books\\002_NAVI\\26_MALACHI\\a26_Malachi.txt":
                    return "מלאכי - עם ניקוד";

                case "Books\\002_NAVI\\26_MALACHI\\b26_Malachi.txt":
                    return "מלאכי - ללא ניקוד";
                case "Books\\002_NAVI\\26_MALACHI\\eNA_MALACHI_L1.txt":
                    return "מלאכי - רש''י";
                case "Books\\002_NAVI\\26_MALACHI\\fNA_MALACHI_L1.txt":
                    return "מלאכי - מצודת דוד";
                case "Books\\002_NAVI\\26_MALACHI\\gNA_MALACHI_L1.txt":
                    return "מלאכי - מצודת ציון";
                case "Books\\002_NAVI\\26_MALACHI\\h_Interleave.txt":
                    return "מלאכי";
                case "Books\\002_NAVI\\26_MALACHI\\h_Interleave2.txt":
                    return "מלאכי (ט)";
                case "Books\\003_KTUVIM":
                    return "תהילים";
                case "Books\\003_KTUVIM\\27_TEHILIM\\a27__Psalms.txt":
                    return "תהילים - עם טעמים";
                case "Books\\003_KTUVIM\\27_TEHILIM\\a27_Psalms.txt":
                    return "תהילים - עם ניקוד";

                case "Books\\003_KTUVIM\\27_TEHILIM\\b27_Psalms.txt":
                    return "תהילים - ללא ניקוד";
                case "Books\\003_KTUVIM\\27_TEHILIM\\eNA_TEHILIM_L1.txt":
                    return "תהילים - רש''י";
                case "Books\\003_KTUVIM\\27_TEHILIM\\fNA_TEHILIM_L1.txt":
                    return "תהילים - מצודת דוד";
                case "Books\\003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L1.txt":
                    return "תהילים - מצודת ציון";
                case "Books\\003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L1_MALBIM.txt":
                    return "תהילים - מלבי''ם - ב. הענין";
                case "Books\\003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L2_MALBIM.txt":
                    return "תהילים - מלבי''ם - ב. המלות";
                case "Books\\003_KTUVIM\\27_TEHILIM\\h_Interleave.txt":
                    return "תהילים";
                case "Books\\003_KTUVIM\\27_TEHILIM\\h_Interleave2.txt":
                    return "תהילים (ט)";
                case "Books\\003_KTUVIM\\27_TEHILIM\\i_div1.txt":
                    return "תהילים - מחולק לספרים";
                case "Books\\003_KTUVIM\\27_TEHILIM\\i_div2.txt":
                    return "תהילים - מחולק לימי השבוע";
                case "Books\\003_KTUVIM\\27_TEHILIM\\i_div3.txt":
                    return "תהילים - מחולק לימי החודש";
                case "Books\\003_KTUVIM\\28_MISHLEI":
                    return "משלי";
                case "Books\\003_KTUVIM\\28_MISHLEI\\a28__Proverbs.txt":
                    return "משלי - עם טעמים";
                case "Books\\003_KTUVIM\\28_MISHLEI\\a28_Proverbs.txt":
                    return "משלי - עם ניקוד";

                case "Books\\003_KTUVIM\\28_MISHLEI\\b28_Proverbs.txt":
                    return "משלי - ללא ניקוד";
                case "Books\\003_KTUVIM\\28_MISHLEI\\eNA_MISHLEI_L1.txt":
                    return "משלי - רש''י";
                case "Books\\003_KTUVIM\\28_MISHLEI\\fNA_MISHLEI_L1.txt":
                    return "משלי - מצודת דוד";
                case "Books\\003_KTUVIM\\28_MISHLEI\\gNA_MISHLEI_L1.txt":
                    return "משלי - מצודת ציון";
                case "Books\\003_KTUVIM\\28_MISHLEI\\gNA_MISHLEI_L1_2.txt":
                    return "משלי - רלב''ג";
                case "Books\\003_KTUVIM\\28_MISHLEI\\h_Interleave.txt":
                    return "משלי";
                case "Books\\003_KTUVIM\\28_MISHLEI\\h_Interleave2.txt":
                    return "משלי (ט)";
                case "Books\\003_KTUVIM\\29_IYOV":
                    return "איוב";
                case "Books\\003_KTUVIM\\29_IYOV\\a29__Job.txt":
                    return "איוב - עם טעמים";
                case "Books\\003_KTUVIM\\29_IYOV\\a29_Job.txt":
                    return "איוב - עם ניקוד";

                case "Books\\003_KTUVIM\\29_IYOV\\b29_Job.txt":
                    return "איוב - ללא ניקוד";
                case "Books\\003_KTUVIM\\29_IYOV\\eNA_IYOV_L1.txt":
                    return "איוב - רש''י";
                case "Books\\003_KTUVIM\\29_IYOV\\fNA_IYOV_L1.txt":
                    return "איוב - מצודת דוד";
                case "Books\\003_KTUVIM\\29_IYOV\\gNA_IYOV_L1.txt":
                    return "איוב - מצודת ציון";
                case "Books\\003_KTUVIM\\29_IYOV\\gNA_IYOV_L1_2.txt":
                    return "איוב - רלב''ג";
                case "Books\\003_KTUVIM\\29_IYOV\\h_Interleave.txt":
                    return "איוב";
                case "Books\\003_KTUVIM\\29_IYOV\\h_Interleave2.txt":
                    return "איוב (ט)";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM":
                    return "שיר השירים";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\a30_Song_of__Songs.txt":
                    return "שיר השירים - עם טעמים";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\a30_Song_of_Songs.txt":
                    return "שיר השירים - עם ניקוד";

                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\b30_Song_of_Songs.txt":
                    return "שיר השירים - ללא ניקוד";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\eNA_SHIR_HASHIRIM_L1.txt":
                    return "שיר השירים - רש''י";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\fNA_SHIR_HASHIRIM_L1.txt":
                    return "שיר השירים - מצודת דוד";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\gNA_SHIR_HASHIRIM_L1.txt":
                    return "שיר השירים - מצודת ציון";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\x_raba.txt":
                    return "מדרש רבה - שיר השירים רבה";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\z_Interleave.txt":
                    return "שיר השירים";
                case "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\z_Interleave2.txt":
                    return "שיר השירים (ט)";
                case "Books\\003_KTUVIM\\31_RUTH":
                    return "רות";
                case "Books\\003_KTUVIM\\31_RUTH\\a31__Ruth.txt":
                    return "רות - עם טעמים";
                case "Books\\003_KTUVIM\\31_RUTH\\a31_Ruth.txt":
                    return "רות - עם ניקוד";

                case "Books\\003_KTUVIM\\31_RUTH\\b31_Ruth.txt":
                    return "רות - ללא ניקוד";
                case "Books\\003_KTUVIM\\31_RUTH\\eNA_RUTH_L1.txt":
                    return "רות - רש''י";
                case "Books\\003_KTUVIM\\31_RUTH\\x_raba.txt":
                    return "מדרש רבה - רות רבה";
                case "Books\\003_KTUVIM\\31_RUTH\\z_Interleave.txt":
                    return "רות";
                case "Books\\003_KTUVIM\\31_RUTH\\z_Interleave2.txt":
                    return "רות (ט)";
                case "Books\\003_KTUVIM\\32_EICHA":
                    return "איכה";
                case "Books\\003_KTUVIM\\32_EICHA\\a32__Lamentations.txt":
                    return "איכה - עם טעמים";
                case "Books\\003_KTUVIM\\32_EICHA\\a32_Lamentations.txt":
                    return "איכה - עם ניקוד";

                case "Books\\003_KTUVIM\\32_EICHA\\b32_Lamentations.txt":
                    return "איכה - ללא ניקוד";
                case "Books\\003_KTUVIM\\32_EICHA\\eNA_EICHA_L1.txt":
                    return "איכה - רש''י";
                case "Books\\003_KTUVIM\\32_EICHA\\x_raba.txt":
                    return "מדרש רבה - איכה רבתי";
                case "Books\\003_KTUVIM\\32_EICHA\\z_Interleave.txt":
                    return "איכה";
                case "Books\\003_KTUVIM\\32_EICHA\\z_Interleave2.txt":
                    return "איכה (ט)";
                case "Books\\003_KTUVIM\\33_KOHELET":
                    return "קהלת";
                case "Books\\003_KTUVIM\\33_KOHELET\\a33__Ecclesiastes.txt":
                    return "קהלת - עם טעמים";
                case "Books\\003_KTUVIM\\33_KOHELET\\a33_Ecclesiastes.txt":
                    return "קהלת - עם ניקוד";

                case "Books\\003_KTUVIM\\33_KOHELET\\b33_Ecclesiastes.txt":
                    return "קהלת - ללא ניקוד";
                case "Books\\003_KTUVIM\\33_KOHELET\\eNA_KOHELET_L1.txt":
                    return "קהלת - רש''י";
                case "Books\\003_KTUVIM\\33_KOHELET\\fNA_KOHELET_L1.txt":
                    return "קהלת - מצודת דוד";
                case "Books\\003_KTUVIM\\33_KOHELET\\gNA_KOHELET_L1.txt":
                    return "קהלת - מצודת ציון";
                case "Books\\003_KTUVIM\\33_KOHELET\\x_raba.txt":
                    return "מדרש רבה - קהלת רבה";
                case "Books\\003_KTUVIM\\33_KOHELET\\z_Interleave.txt":
                    return "קהלת";
                case "Books\\003_KTUVIM\\33_KOHELET\\z_Interleave2.txt":
                    return "קהלת (ט)";
                case "Books\\003_KTUVIM\\34_ESTER":
                    return "אסתר";
                case "Books\\003_KTUVIM\\34_ESTER\\a34__Esther.txt":
                    return "אסתר - עם טעמים";
                case "Books\\003_KTUVIM\\34_ESTER\\a34_Esther.txt":
                    return "אסתר - עם ניקוד";

                case "Books\\003_KTUVIM\\34_ESTER\\b34_Esther.txt":
                    return "אסתר - ללא ניקוד";
                case "Books\\003_KTUVIM\\34_ESTER\\eNA_ESTER_L1.txt":
                    return "אסתר - רש''י";
                case "Books\\003_KTUVIM\\34_ESTER\\f_MALBIM_ESTER.txt":
                    return "אסתר - מלבי''ם";
                case "Books\\003_KTUVIM\\34_ESTER\\x_raba.txt":
                    return "מדרש רבה - אסתר רבה";
                case "Books\\003_KTUVIM\\34_ESTER\\z_Interleave.txt":
                    return "אסתר";
                case "Books\\003_KTUVIM\\34_ESTER\\z_Interleave2.txt":
                    return "אסתר (ט)";
                case "Books\\003_KTUVIM\\35_DANIEL":
                    return "דניאל";
                case "Books\\003_KTUVIM\\35_DANIEL\\a35__Daniel.txt":
                    return "דניאל - עם טעמים";
                case "Books\\003_KTUVIM\\35_DANIEL\\a35_Daniel.txt":
                    return "דניאל - עם ניקוד";

                case "Books\\003_KTUVIM\\35_DANIEL\\b35_Daniel.txt":
                    return "דניאל - ללא ניקוד";
                case "Books\\003_KTUVIM\\35_DANIEL\\eNA_DANIEL_L1.txt":
                    return "דניאל - רש''י";
                case "Books\\003_KTUVIM\\35_DANIEL\\fNA_DANIEL_L1.txt":
                    return "דניאל - מצודת דוד";
                case "Books\\003_KTUVIM\\35_DANIEL\\gNA_DANIEL_L1.txt":
                    return "דניאל - מצודת ציון";
                case "Books\\003_KTUVIM\\35_DANIEL\\h_Interleave.txt":
                    return "דניאל";
                case "Books\\003_KTUVIM\\35_DANIEL\\h_Interleave2.txt":
                    return "דניאל (ט)";
                case "Books\\003_KTUVIM\\36_EZRA":
                    return "עזרא";
                case "Books\\003_KTUVIM\\36_EZRA\\a36__Ezra.txt":
                    return "עזרא - עם טעמים";
                case "Books\\003_KTUVIM\\36_EZRA\\a36_Ezra.txt":
                    return "עזרא - עם ניקוד";

                case "Books\\003_KTUVIM\\36_EZRA\\b36_Ezra.txt":
                    return "עזרא - ללא ניקוד";
                case "Books\\003_KTUVIM\\36_EZRA\\eNA_EZRA_L1.txt":
                    return "עזרא - רש''י";
                case "Books\\003_KTUVIM\\36_EZRA\\fNA_EZRA_L1.txt":
                    return "עזרא - מצודת דוד";
                case "Books\\003_KTUVIM\\36_EZRA\\gNA_EZRA_L1.txt":
                    return "עזרא - מצודת ציון";
                case "Books\\003_KTUVIM\\36_EZRA\\gNA_EZRA_L1_2.txt":
                    return "עזרא - רלב''ג";
                case "Books\\003_KTUVIM\\36_EZRA\\h_Interleave.txt":
                    return "עזרא";
                case "Books\\003_KTUVIM\\36_EZRA\\h_Interleave2.txt":
                    return "עזרא (ט)";
                case "Books\\003_KTUVIM\\37_NECHEMYA":
                    return "נחמיה";
                case "Books\\003_KTUVIM\\37_NECHEMYA\\a37__Nehemiah.txt":
                    return "נחמיה - עם טעמים";
                case "Books\\003_KTUVIM\\37_NECHEMYA\\a37_Nehemiah.txt":
                    return "נחמיה - עם ניקוד";

                case "Books\\003_KTUVIM\\37_NECHEMYA\\b37_Nehemiah.txt":
                    return "נחמיה - ללא ניקוד";
                case "Books\\003_KTUVIM\\37_NECHEMYA\\eNA_NECHEMYA_L1.txt":
                    return "נחמיה - רש''י";
                case "Books\\003_KTUVIM\\37_NECHEMYA\\fNA_NECHEMYA_L1.txt":
                    return "נחמיה - מצודת דוד";
                case "Books\\003_KTUVIM\\37_NECHEMYA\\gNA_NECHEMYA_L1.txt":
                    return "נחמיה - מצודת ציון";
                case "Books\\003_KTUVIM\\37_NECHEMYA\\gNA_NECHEMYA_L1_2.txt":
                    return "נחמיה - רלב''ג";
                case "Books\\003_KTUVIM\\37_NECHEMYA\\h_Interleave.txt":
                    return "נחמיה";
                case "Books\\003_KTUVIM\\37_NECHEMYA\\h_Interleave2.txt":
                    return "נחמיה (ט)";
                case "Books\\003_KTUVIM\\38_DIVRE_A":
                    return "דברי הימים א";
                case "Books\\003_KTUVIM\\38_DIVRE_A\\a38_Chronicles__1.txt":
                    return "דברי הימים א - עם טעמים";
                case "Books\\003_KTUVIM\\38_DIVRE_A\\a38_Chronicles_1.txt":
                    return "דברי הימים א - עם ניקוד";

                case "Books\\003_KTUVIM\\38_DIVRE_A\\b38_Chronicles_1.txt":
                    return "דברי הימים א - ללא ניקוד";
                case "Books\\003_KTUVIM\\38_DIVRE_A\\eNA_DIVRE_A_L1.txt":
                    return "דברי הימים א - רש''י";
                case "Books\\003_KTUVIM\\38_DIVRE_A\\fNA_DIVRE_A_L1.txt":
                    return "דברי הימים א - מצודת דוד";
                case "Books\\003_KTUVIM\\38_DIVRE_A\\gNA_DIVRE_A_L1.txt":
                    return "דברי הימים א - מצודת ציון";
                case "Books\\003_KTUVIM\\38_DIVRE_A\\gNA_DIVRE_A_L1_2.txt":
                    return "דברי הימים א - רלב''ג";
                case "Books\\003_KTUVIM\\38_DIVRE_A\\h_Interleave.txt":
                    return "דברי הימים א";
                case "Books\\003_KTUVIM\\38_DIVRE_A\\h_Interleave2.txt":
                    return "דברי הימים א (ט)";
                case "Books\\003_KTUVIM\\39_DIVRE_B":
                    return "דברי הימים ב";
                case "Books\\003_KTUVIM\\39_DIVRE_B\\a39_Chronicles__2.txt":
                    return "דברי הימים ב - עם טעמים";
                case "Books\\003_KTUVIM\\39_DIVRE_B\\a39_Chronicles_2.txt":
                    return "דברי הימים ב - עם ניקוד";

                case "Books\\003_KTUVIM\\39_DIVRE_B\\b39_Chronicles_2.txt":
                    return "דברי הימים ב - ללא ניקוד";
                case "Books\\003_KTUVIM\\39_DIVRE_B\\eNA_DIVRE_B_L1.txt":
                    return "דברי הימים ב - רש''י";
                case "Books\\003_KTUVIM\\39_DIVRE_B\\fNA_DIVRE_B_L1.txt":
                    return "דברי הימים ב - מצודת דוד";
                case "Books\\003_KTUVIM\\39_DIVRE_B\\gNA_DIVRE_B_L1.txt":
                    return "דברי הימים ב - מצודת ציון";
                case "Books\\003_KTUVIM\\39_DIVRE_B\\gNA_DIVRE_B_L1_2.txt":
                    return "דברי הימים ב - רלב''ג";
                case "Books\\003_KTUVIM\\39_DIVRE_B\\h_Interleave.txt":
                    return "דברי הימים ב";
                case "Books\\003_KTUVIM\\39_DIVRE_B\\h_Interleave2.txt":
                    return "דברי הימים ב (ט)";
                case "Books\\020_MISHNA":
                    return "משנה - ברכות";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L2.txt":
                    return "משנה - ברכות - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L1.txt":
                    return "משנה - ברכות";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L3.txt":
                    return "משנה - ברכות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L5.txt":
                    return "משנה - ברכות - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\ZDebugMix.txt":
                    return "משנה מסכת ברכות";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA":
                    return "משנה - פאה";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L2.txt":
                    return "משנה - פאה - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L1.txt":
                    return "משנה - פאה";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L3.txt":
                    return "משנה - פאה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L5.txt":
                    return "משנה - פאה - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\ZDebugMix.txt":
                    return "משנה מסכת פאה";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI":
                    return "משנה - דמאי";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L2.txt":
                    return "משנה - דמאי - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L1.txt":
                    return "משנה - דמאי";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L3.txt":
                    return "משנה - דמאי - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L5.txt":
                    return "משנה - דמאי - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\ZDebugMix.txt":
                    return "משנה מסכת דמאי";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM":
                    return "משנה - כלאים";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L2.txt":
                    return "משנה - כלאים - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L1.txt":
                    return "משנה - כלאים";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L3.txt":
                    return "משנה - כלאים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L5.txt":
                    return "משנה - כלאים - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\ZDebugMix.txt":
                    return "משנה מסכת כלאים";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT":
                    return "משנה - שביעית";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L2.txt":
                    return "משנה - שביעית - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L1.txt":
                    return "משנה - שביעית";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L3.txt":
                    return "משנה - שביעית - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L5.txt":
                    return "משנה - שביעית - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\ZDebugMix.txt":
                    return "משנה מסכת שביעית";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT":
                    return "משנה - תרומות";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L2.txt":
                    return "משנה - תרומות - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L1.txt":
                    return "משנה - תרומות";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L3.txt":
                    return "משנה - תרומות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L5.txt":
                    return "משנה - תרומות - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\ZDebugMix.txt":
                    return "משנה מסכת תרומות";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT":
                    return "משנה - מעשרות";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L2.txt":
                    return "משנה - מעשרות - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L1.txt":
                    return "משנה - מעשרות";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L3.txt":
                    return "משנה - מעשרות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L5.txt":
                    return "משנה - מעשרות - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\ZDebugMix.txt":
                    return "משנה מסכת מעשרות";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI":
                    return "משנה - מעשר שני";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L2.txt":
                    return "משנה - מעשר שני - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L1.txt":
                    return "משנה - מעשר שני";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L3.txt":
                    return "משנה - מעשר שני - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L5.txt":
                    return "משנה - מעשר שני - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\ZDebugMix.txt":
                    return "משנה מסכת מעשר שני";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA":
                    return "משנה - חלה";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L2.txt":
                    return "משנה - חלה - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L1.txt":
                    return "משנה - חלה";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L3.txt":
                    return "משנה - חלה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L5.txt":
                    return "משנה - חלה - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\ZDebugMix.txt":
                    return "משנה מסכת חלה";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA":
                    return "משנה - ערלה";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L2.txt":
                    return "משנה - ערלה - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L1.txt":
                    return "משנה - ערלה";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L3.txt":
                    return "משנה - ערלה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L5.txt":
                    return "משנה - ערלה - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\ZDebugMix.txt":
                    return "משנה מסכת ערלה";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM":
                    return "משנה - ביכורים";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L2.txt":
                    return "משנה - ביכורים - רע''ב";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L1.txt":
                    return "משנה - ביכורים";

                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L3.txt":
                    return "משנה - ביכורים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L5.txt":
                    return "משנה - ביכורים - רמב''ם";
                case "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\ZDebugMix.txt":
                    return "משנה מסכת ביכורים";
                case "Books\\020_MISHNA\\101_SEDER_MOED":
                    return "משנה - שבת";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L2.txt":
                    return "משנה - שבת - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L1.txt":
                    return "משנה - שבת";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L3.txt":
                    return "משנה - שבת - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L5.txt":
                    return "משנה - שבת - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\ZDebugMix.txt":
                    return "משנה מסכת שבת";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN":
                    return "משנה - עירובין";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L2.txt":
                    return "משנה - עירובין - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L1.txt":
                    return "משנה - עירובין";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L3.txt":
                    return "משנה - עירובין - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L5.txt":
                    return "משנה - עירובין - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\ZDebugMix.txt":
                    return "משנה מסכת עירובין";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM":
                    return "משנה - פסחים";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L2.txt":
                    return "משנה - פסחים - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L1.txt":
                    return "משנה - פסחים";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L3.txt":
                    return "משנה - פסחים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L5.txt":
                    return "משנה - פסחים - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\ZDebugMix.txt":
                    return "משנה מסכת פסחים";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM":
                    return "משנה - שקלים";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L2.txt":
                    return "משנה - שקלים - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L1.txt":
                    return "משנה - שקלים";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L3.txt":
                    return "משנה - שקלים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\ZDebugMix.txt":
                    return "משנה מסכת שקלים";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA":
                    return "משנה - יומא";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L2.txt":
                    return "משנה - יומא - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L1.txt":
                    return "משנה - יומא";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L3.txt":
                    return "משנה - יומא - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L5.txt":
                    return "משנה - יומא - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\ZDebugMix.txt":
                    return "משנה מסכת יומא";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA":
                    return "משנה - סוכה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L2.txt":
                    return "משנה - סוכה - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L1.txt":
                    return "משנה - סוכה";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L3.txt":
                    return "משנה - סוכה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L5.txt":
                    return "משנה - סוכה - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\ZDebugMix.txt":
                    return "משנה מסכת סוכה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA":
                    return "משנה - ביצה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L2.txt":
                    return "משנה - ביצה - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L1.txt":
                    return "משנה - ביצה";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L3.txt":
                    return "משנה - ביצה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L5.txt":
                    return "משנה - ביצה - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\ZDebugMix.txt":
                    return "משנה מסכת ביצה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH":
                    return "משנה - ראש השנה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L2.txt":
                    return "משנה - ראש השנה - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L1.txt":
                    return "משנה - ראש השנה";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L3.txt":
                    return "משנה - ראש השנה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L5.txt":
                    return "משנה - ראש_השנה - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\ZDebugMix.txt":
                    return "משנה מסכת ראש השנה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT":
                    return "משנה - תענית";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L2.txt":
                    return "משנה - תענית - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L1.txt":
                    return "משנה - תענית";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L3.txt":
                    return "משנה - תענית - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L5.txt":
                    return "משנה - תענית - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\ZDebugMix.txt":
                    return "משנה מסכת תענית";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA":
                    return "משנה - מגילה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L2.txt":
                    return "משנה - מגילה - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L1.txt":
                    return "משנה - מגילה";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L3.txt":
                    return "משנה - מגילה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L5.txt":
                    return "משנה - מגילה - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\ZDebugMix.txt":
                    return "משנה מסכת מגילה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN":
                    return "משנה - מועד קטן";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L2.txt":
                    return "משנה - מועד קטן - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L1.txt":
                    return "משנה - מועד קטן";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L3.txt":
                    return "משנה - מועד קטן - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L5.txt":
                    return "משנה - מועד_קטן - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\ZDebugMix.txt":
                    return "משנה מסכת מועד קטן";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA":
                    return "משנה - חגיגה";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L2.txt":
                    return "משנה - חגיגה - רע''ב";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L1.txt":
                    return "משנה - חגיגה";

                case "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L3.txt":
                    return "משנה - חגיגה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L5.txt":
                    return "משנה - חגיגה - רמב''ם";
                case "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\ZDebugMix.txt":
                    return "משנה מסכת חגיגה";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM":
                    return "משנה - יבמות";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L2.txt":
                    return "משנה - יבמות - רע''ב";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L1.txt":
                    return "משנה - יבמות";

                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L3.txt":
                    return "משנה - יבמות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L5.txt":
                    return "משנה - יבמות - רמב''ם";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\ZDebugMix.txt":
                    return "משנה מסכת יבמות";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT":
                    return "משנה - כתובות";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L2.txt":
                    return "משנה - כתובות - רע''ב";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L1.txt":
                    return "משנה - כתובות";

                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L3.txt":
                    return "משנה - כתובות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L5.txt":
                    return "משנה - כתובות - רמב''ם";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\ZDebugMix.txt":
                    return "משנה מסכת כתובות";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM":
                    return "משנה - נדרים";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L2.txt":
                    return "משנה - נדרים - רע''ב";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L1.txt":
                    return "משנה - נדרים";

                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L3.txt":
                    return "משנה - נדרים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L5.txt":
                    return "משנה - נדרים - רמב''ם";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\ZDebugMix.txt":
                    return "משנה מסכת נדרים";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR":
                    return "משנה - נזיר";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L2.txt":
                    return "משנה - נזיר - רע''ב";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L1.txt":
                    return "משנה - נזיר";

                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L3.txt":
                    return "משנה - נזיר - עיקר תוי''ט";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L5.txt":
                    return "משנה - נזיר - רמב''ם";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\ZDebugMix.txt":
                    return "משנה מסכת נזיר";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA":
                    return "משנה - סוטה";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L2.txt":
                    return "משנה - סוטה - רע''ב";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L1.txt":
                    return "משנה - סוטה";

                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L3.txt":
                    return "משנה - סוטה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L5.txt":
                    return "משנה - סוטה - רמב''ם";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\ZDebugMix.txt":
                    return "משנה מסכת סוטה";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN":
                    return "משנה - גיטין";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L2.txt":
                    return "משנה - גיטין - רע''ב";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L1.txt":
                    return "משנה - גיטין";

                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L3.txt":
                    return "משנה - גיטין - עיקר תוי''ט";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L5.txt":
                    return "משנה - גיטין - רמב''ם";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\ZDebugMix.txt":
                    return "משנה מסכת גיטין";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN":
                    return "משנה - קידושין";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L2.txt":
                    return "משנה - קידושין - רע''ב";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L1.txt":
                    return "משנה - קידושין";

                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L3.txt":
                    return "משנה - קידושין - עיקר תוי''ט";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L5.txt":
                    return "משנה - קידושין - רמב''ם";
                case "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\ZDebugMix.txt":
                    return "משנה מסכת קידושין";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN":
                    return "משנה - בבא קמא";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L2.txt":
                    return "משנה - בבא קמא - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L1.txt":
                    return "משנה - בבא קמא";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L3.txt":
                    return "משנה - בבא קמא - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L5.txt":
                    return "משנה - בבא_קמא - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\ZDebugMix.txt":
                    return "משנה מסכת בבא קמא";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA":
                    return "משנה - בבא מציעא";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L2.txt":
                    return "משנה - בבא מציעא - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L1.txt":
                    return "משנה - בבא מציעא";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L3.txt":
                    return "משנה - בבא מציעא - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L5.txt":
                    return "משנה - בבא_מציעא - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\ZDebugMix.txt":
                    return "משנה מסכת בבא מציעא";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA":
                    return "משנה - בבא בתרא";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L2.txt":
                    return "משנה - בבא בתרא - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L1.txt":
                    return "משנה - בבא בתרא";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L3.txt":
                    return "משנה - בבא בתרא - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L5.txt":
                    return "משנה - בבא_בתרא - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\ZDebugMix.txt":
                    return "משנה מסכת בבא בתרא";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN":
                    return "משנה - סנהדרין";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L2.txt":
                    return "משנה - סנהדרין - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L1.txt":
                    return "משנה - סנהדרין";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L3.txt":
                    return "משנה - סנהדרין - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L5.txt":
                    return "משנה - סנהדרין - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\ZDebugMix.txt":
                    return "משנה מסכת סנהדרין";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT":
                    return "משנה - מכות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L2.txt":
                    return "משנה - מכות - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L1.txt":
                    return "משנה - מכות";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L3.txt":
                    return "משנה - מכות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L5.txt":
                    return "משנה - מכות - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\ZDebugMix.txt":
                    return "משנה מסכת מכות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT":
                    return "משנה - שבועות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L2.txt":
                    return "משנה - שבועות - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L1.txt":
                    return "משנה - שבועות";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L3.txt":
                    return "משנה - שבועות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L5.txt":
                    return "משנה - שבועות - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\ZDebugMix.txt":
                    return "משנה מסכת שבועות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT":
                    return "משנה - עדיות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L2.txt":
                    return "משנה - עדיות - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L1.txt":
                    return "משנה - עדיות";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L3.txt":
                    return "משנה - עדיות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L5.txt":
                    return "משנה - עדיות - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\ZDebugMix.txt":
                    return "משנה מסכת עדיות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA":
                    return "משנה - עבודה זרה";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L2.txt":
                    return "משנה - עבודה זרה - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L1.txt":
                    return "משנה - עבודה זרה";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L3.txt":
                    return "משנה - עבודה זרה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L5.txt":
                    return "משנה - עבודה_זרה - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\ZDebugMix.txt":
                    return "משנה מסכת עבודה זרה";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT":
                    return "משנה - אבות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L2.txt":
                    return "משנה - אבות - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L1.txt":
                    return "משנה - אבות";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L3.txt":
                    return "משנה - אבות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L4.txt":
                    return "משנה - אבות - רש''י";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L5.txt":
                    return "משנה - אבות - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\ZDebugMix.txt":
                    return "משנה מסכת אבות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT":
                    return "משנה - הוריות";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L2.txt":
                    return "משנה - הוריות - רע''ב";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L1.txt":
                    return "משנה - הוריות";

                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L3.txt":
                    return "משנה - הוריות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L5.txt":
                    return "משנה - הוריות - רמב''ם";
                case "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\ZDebugMix.txt":
                    return "משנה מסכת הוריות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM":
                    return "משנה - זבחים";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L2.txt":
                    return "משנה - זבחים - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L1.txt":
                    return "משנה - זבחים";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L3.txt":
                    return "משנה - זבחים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L5.txt":
                    return "משנה - זבחים - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\ZDebugMix.txt":
                    return "משנה מסכת זבחים";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT":
                    return "משנה - מנחות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L2.txt":
                    return "משנה - מנחות - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L1.txt":
                    return "משנה - מנחות";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L3.txt":
                    return "משנה - מנחות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L5.txt":
                    return "משנה - מנחות - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\ZDebugMix.txt":
                    return "משנה מסכת מנחות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN":
                    return "משנה - חולין";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L2.txt":
                    return "משנה - חולין - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L1.txt":
                    return "משנה - חולין";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L3.txt":
                    return "משנה - חולין - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L5.txt":
                    return "משנה - חולין - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\ZDebugMix.txt":
                    return "משנה מסכת חולין";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT":
                    return "משנה - בכורות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L2.txt":
                    return "משנה - בכורות - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L1.txt":
                    return "משנה - בכורות";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L3.txt":
                    return "משנה - בכורות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L5.txt":
                    return "משנה - בכורות - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\ZDebugMix.txt":
                    return "משנה מסכת בכורות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN":
                    return "משנה - ערכין";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L2.txt":
                    return "משנה - ערכין - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L1.txt":
                    return "משנה - ערכין";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L3.txt":
                    return "משנה - ערכין - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L5.txt":
                    return "משנה - ערכין - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\ZDebugMix.txt":
                    return "משנה מסכת ערכין";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA":
                    return "משנה - תמורה";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L2.txt":
                    return "משנה - תמורה - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L1.txt":
                    return "משנה - תמורה";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L3.txt":
                    return "משנה - תמורה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L5.txt":
                    return "משנה - תמורה - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\ZDebugMix.txt":
                    return "משנה מסכת תמורה";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT":
                    return "משנה - כריתות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L2.txt":
                    return "משנה - כריתות - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L1.txt":
                    return "משנה - כריתות";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L3.txt":
                    return "משנה - כריתות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L5.txt":
                    return "משנה - כריתות - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\ZDebugMix.txt":
                    return "משנה מסכת כריתות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA":
                    return "משנה - מעילה";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L2.txt":
                    return "משנה - מעילה - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L1.txt":
                    return "משנה - מעילה";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L3.txt":
                    return "משנה - מעילה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L5.txt":
                    return "משנה - מעילה - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\ZDebugMix.txt":
                    return "משנה מסכת מעילה";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID":
                    return "משנה - תמיד";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L2.txt":
                    return "משנה - תמיד - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L1.txt":
                    return "משנה - תמיד";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L3.txt":
                    return "משנה - תמיד - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L5.txt":
                    return "משנה - תמיד - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\ZDebugMix.txt":
                    return "משנה מסכת תמיד";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT":
                    return "משנה - מדות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L2.txt":
                    return "משנה - מדות - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L1.txt":
                    return "משנה - מדות";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L3.txt":
                    return "משנה - מדות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L5.txt":
                    return "משנה - מדות - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\ZDebugMix.txt":
                    return "משנה מסכת מדות";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM":
                    return "משנה - קנים";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L2.txt":
                    return "משנה - קנים - רע''ב";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L1.txt":
                    return "משנה - קנים";

                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L3.txt":
                    return "משנה - קנים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L5.txt":
                    return "משנה - קנים - רמב''ם";
                case "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\ZDebugMix.txt":
                    return "משנה מסכת קנים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT":
                    return "משנה - כלים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L2.txt":
                    return "משנה - כלים - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L1.txt":
                    return "משנה - כלים";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L3.txt":
                    return "משנה - כלים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L5.txt":
                    return "משנה - כלים - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\ZDebugMix.txt":
                    return "משנה מסכת כלים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT":
                    return "משנה - אהלות";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L2.txt":
                    return "משנה - אהלות - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L1.txt":
                    return "משנה - אהלות";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L3.txt":
                    return "משנה - אהלות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L5.txt":
                    return "משנה - אהלות - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\ZDebugMix.txt":
                    return "משנה מסכת אהלות";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM":
                    return "משנה - נגעים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L2.txt":
                    return "משנה - נגעים - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L1.txt":
                    return "משנה - נגעים";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L3.txt":
                    return "משנה - נגעים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L5.txt":
                    return "משנה - נגעים - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\ZDebugMix.txt":
                    return "משנה מסכת נגעים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA":
                    return "משנה - פרה";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L2.txt":
                    return "משנה - פרה - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L1.txt":
                    return "משנה - פרה";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L3.txt":
                    return "משנה - פרה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L5.txt":
                    return "משנה - פרה - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\ZDebugMix.txt":
                    return "משנה מסכת פרה";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT":
                    return "משנה - טהרות";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L2.txt":
                    return "משנה - טהרות - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L1.txt":
                    return "משנה - טהרות";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L3.txt":
                    return "משנה - טהרות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L5.txt":
                    return "משנה - טהרות - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\ZDebugMix.txt":
                    return "משנה מסכת טהרות";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT":
                    return "משנה - מקואות";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L2.txt":
                    return "משנה - מקואות - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L1.txt":
                    return "משנה - מקואות";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L3.txt":
                    return "משנה - מקואות - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L5.txt":
                    return "משנה - מקואות - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\ZDebugMix.txt":
                    return "משנה מסכת מקוואות";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA":
                    return "משנה - נדה";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L2.txt":
                    return "משנה - נדה - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L1.txt":
                    return "משנה - נדה";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L3.txt":
                    return "משנה - נדה - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L5.txt":
                    return "משנה - נדה - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\ZDebugMix.txt":
                    return "משנה מסכת נדה";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN":
                    return "משנה - מכשירין";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L2.txt":
                    return "משנה - מכשירין - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L1.txt":
                    return "משנה - מכשירין";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L3.txt":
                    return "משנה - מכשירין - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L5.txt":
                    return "משנה - מכשירין - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\ZDebugMix.txt":
                    return "משנה מסכת מכשירין";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM":
                    return "משנה - זבים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L2.txt":
                    return "משנה - זבים - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L1.txt":
                    return "משנה - זבים";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L3.txt":
                    return "משנה - זבים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L5.txt":
                    return "משנה - זבים - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\ZDebugMix.txt":
                    return "משנה מסכת זבים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM":
                    return "משנה - טבול יום";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L2.txt":
                    return "משנה - טבול יום - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L1.txt":
                    return "משנה - טבול יום";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L3.txt":
                    return "משנה - טבול יום - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L5.txt":
                    return "משנה - טבול_יום - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\ZDebugMix.txt":
                    return "משנה מסכת טבול יום";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM":
                    return "משנה - ידים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L2.txt":
                    return "משנה - ידים - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L1.txt":
                    return "משנה - ידים";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L3.txt":
                    return "משנה - ידים - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L5.txt":
                    return "משנה - ידים - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\ZDebugMix.txt":
                    return "משנה מסכת ידים";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN":
                    return "משנה - עוקצין";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L2.txt":
                    return "משנה - עוקצין - רע''ב";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L1.txt":
                    return "משנה - עוקצין";

                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L3.txt":
                    return "משנה - עוקצין - עיקר תוי''ט";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L5.txt":
                    return "משנה - עוקצין - רמב''ם";
                case "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\ZDebugMix.txt":
                    return "משנה מסכת עוקצין";
                case "Books\\030_BAVLI":
                    return "תלמוד בבלי - ברכות";
                case "Books\\030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L2.txt":
                    return "תלמוד בבלי - ברכות - רש''י";
                case "Books\\030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L1.txt":
                    return "תלמוד בבלי - ברכות";

                case "Books\\030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L3.txt":
                    return "תלמוד בבלי - ברכות - תוספות";
                case "Books\\030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L6_rashba.txt":
                    return "רשב''א - מסכת ברכות";
                case "Books\\030_BAVLI\\01_MAS_BRACHOT\\DebugMix.txt":
                    return "מסכת ברכות";
                case "Books\\030_BAVLI\\01_MAS_BRACHOT\\HavAll.txt":
                    return "חברותא - ברכות";
                case "Books\\030_BAVLI\\01_MAS_BRACHOT\\HavTempNoNotes.txt":
                    return "חברותא - ברכות - בלי הערות";
                case "Books\\030_BAVLI\\01_MAS_BRACHOT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\02_MAS_SHABAT":
                    return "תלמוד בבלי - שבת";
                case "Books\\030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L2.txt":
                    return "תלמוד בבלי - שבת - רש''י";
                case "Books\\030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L1.txt":
                    return "תלמוד בבלי - שבת";

                case "Books\\030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L3.txt":
                    return "תלמוד בבלי - שבת - תוספות";
                case "Books\\030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L6_rashba.txt":
                    return "רשב''א - מסכת שבת";
                case "Books\\030_BAVLI\\02_MAS_SHABAT\\DebugMix.txt":
                    return "מסכת שבת";
                case "Books\\030_BAVLI\\02_MAS_SHABAT\\HavAll.txt":
                    return "חברותא - שבת";
                case "Books\\030_BAVLI\\02_MAS_SHABAT\\HavTempNoNotes.txt":
                    return "חברותא - שבת - בלי הערות";
                case "Books\\030_BAVLI\\02_MAS_SHABAT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\03_MAS_ERUVIN":
                    return "תלמוד בבלי - עירובין";
                case "Books\\030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L2.txt":
                    return "תלמוד בבלי - עירובין - רש''י";
                case "Books\\030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L1.txt":
                    return "תלמוד בבלי - עירובין";

                case "Books\\030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L3.txt":
                    return "תלמוד בבלי - עירובין - תוספות";
                case "Books\\030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L6_rashba.txt":
                    return "רשב''א - מסכת עירובין";
                case "Books\\030_BAVLI\\03_MAS_ERUVIN\\DebugMix.txt":
                    return "מסכת עירובין";
                case "Books\\030_BAVLI\\03_MAS_ERUVIN\\HavAll.txt":
                    return "חברותא - עירובין";
                case "Books\\030_BAVLI\\03_MAS_ERUVIN\\HavTempNoNotes.txt":
                    return "חברותא - עירובין - בלי הערות";
                case "Books\\030_BAVLI\\03_MAS_ERUVIN\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\04_MAS_PSACHIM":
                    return "תלמוד בבלי - פסחים";
                case "Books\\030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L2.txt":
                    return "תלמוד בבלי - פסחים - רש''י";
                case "Books\\030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L1.txt":
                    return "תלמוד בבלי - פסחים";

                case "Books\\030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L3.txt":
                    return "תלמוד בבלי - פסחים - תוספות";
                case "Books\\030_BAVLI\\04_MAS_PSACHIM\\Bav PSAHIM_L4.txt":
                    return "תלמוד בבלי - פסחים - רשב''ם";
                case "Books\\030_BAVLI\\04_MAS_PSACHIM\\DebugMix.txt":
                    return "מסכת פסחים";
                case "Books\\030_BAVLI\\04_MAS_PSACHIM\\HavAll.txt":
                    return "חברותא - פסחים";
                case "Books\\030_BAVLI\\04_MAS_PSACHIM\\HavTempNoNotes.txt":
                    return "חברותא - פסחים - בלי הערות";
                case "Books\\030_BAVLI\\04_MAS_PSACHIM\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\05_MAS_SHKALIM":
                    return "תלמוד ירושלמי - שקלים";
                case "Books\\030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L2.txt":
                    return "[2] תלמוד ירושלמי - שקלים - קרבן העדה";
                case "Books\\030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L1.txt":
                    return "[1] תלמוד ירושלמי - שקלים - קרבן העדה";

                case "Books\\030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L3.txt":
                    return "תלמוד ירושלמי - שקלים - ריבב''ן";
                case "Books\\030_BAVLI\\05_MAS_SHKALIM\\DebugMix.txt":
                    return "מסכת שקלים";
                case "Books\\030_BAVLI\\05_MAS_SHKALIM\\HavAll.txt":
                    return "חברותא - שקלים";
                case "Books\\030_BAVLI\\05_MAS_SHKALIM\\HavTempNoNotes.txt":
                    return "חברותא - שקלים - בלי הערות";
                case "Books\\030_BAVLI\\05_MAS_SHKALIM\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\06_MAS_ROSH":
                    return "תלמוד בבלי - ראש השנה";
                case "Books\\030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L2.txt":
                    return "תלמוד בבלי - ראש השנה - רש''י";
                case "Books\\030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L1.txt":
                    return "תלמוד בבלי - ראש השנה";

                case "Books\\030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L3.txt":
                    return "תלמוד בבלי - ראש השנה - תוספות";
                case "Books\\030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L6_rashba.txt":
                    return "רשב''א - מסכת ראש השנה";
                case "Books\\030_BAVLI\\06_MAS_ROSH\\DebugMix.txt":
                    return "מסכת ראש השנה";
                case "Books\\030_BAVLI\\06_MAS_ROSH\\HavAll.txt":
                    return "חברותא - ראש השנה";
                case "Books\\030_BAVLI\\06_MAS_ROSH\\HavTempNoNotes.txt":
                    return "חברותא - ראש השנה - בלי הערות";
                case "Books\\030_BAVLI\\06_MAS_ROSH\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\07_MAS_YOMA":
                    return "תלמוד בבלי - יומא";
                case "Books\\030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L2.txt":
                    return "תלמוד בבלי - יומא - רש''י";
                case "Books\\030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L1.txt":
                    return "תלמוד בבלי - יומא";

                case "Books\\030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L3.txt":
                    return "תלמוד בבלי - יומא - תוספות";
                case "Books\\030_BAVLI\\07_MAS_YOMA\\DebugMix.txt":
                    return "מסכת יומא";
                case "Books\\030_BAVLI\\07_MAS_YOMA\\HavAll.txt":
                    return "חברותא - יומא";
                case "Books\\030_BAVLI\\07_MAS_YOMA\\HavTempNoNotes.txt":
                    return "חברותא - יומא - בלי הערות";
                case "Books\\030_BAVLI\\07_MAS_YOMA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\08_MAS_SUCA":
                    return "תלמוד בבלי - סוכה";
                case "Books\\030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L2.txt":
                    return "תלמוד בבלי - סוכה - רש''י";
                case "Books\\030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L1.txt":
                    return "תלמוד בבלי - סוכה";

                case "Books\\030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L3.txt":
                    return "תלמוד בבלי - סוכה - תוספות";
                case "Books\\030_BAVLI\\08_MAS_SUCA\\DebugMix.txt":
                    return "מסכת סוכה";
                case "Books\\030_BAVLI\\08_MAS_SUCA\\HavAll.txt":
                    return "חברותא - סוכה";
                case "Books\\030_BAVLI\\08_MAS_SUCA\\HavTempNoNotes.txt":
                    return "חברותא - סוכה - בלי הערות";
                case "Books\\030_BAVLI\\08_MAS_SUCA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\09_MAS_BEITSA":
                    return "תלמוד בבלי - ביצה";
                case "Books\\030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L2.txt":
                    return "תלמוד בבלי - ביצה - רש''י";
                case "Books\\030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L1.txt":
                    return "תלמוד בבלי - ביצה";

                case "Books\\030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L3.txt":
                    return "תלמוד בבלי - ביצה - תוספות";
                case "Books\\030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L6_rashba.txt":
                    return "רשב''א - מסכת ביצה";
                case "Books\\030_BAVLI\\09_MAS_BEITSA\\DebugMix.txt":
                    return "מסכת ביצה";
                case "Books\\030_BAVLI\\09_MAS_BEITSA\\HavAll.txt":
                    return "חברותא - ביצה";
                case "Books\\030_BAVLI\\09_MAS_BEITSA\\HavTempNoNotes.txt":
                    return "חברותא - ביצה - בלי הערות";
                case "Books\\030_BAVLI\\09_MAS_BEITSA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\10_MAS_TAANIT":
                    return "תלמוד בבלי - תענית";
                case "Books\\030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L2.txt":
                    return "תלמוד בבלי - תענית - רש''י";
                case "Books\\030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L1.txt":
                    return "תלמוד בבלי - תענית";

                case "Books\\030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L3.txt":
                    return "תלמוד בבלי - תענית - תוספות";
                case "Books\\030_BAVLI\\10_MAS_TAANIT\\DebugMix.txt":
                    return "מסכת תענית";
                case "Books\\030_BAVLI\\10_MAS_TAANIT\\HavAll.txt":
                    return "חברותא - תענית";
                case "Books\\030_BAVLI\\10_MAS_TAANIT\\HavTempNoNotes.txt":
                    return "חברותא - תענית - בלי הערות";
                case "Books\\030_BAVLI\\10_MAS_TAANIT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\11_MAS_MEGILA":
                    return "תלמוד בבלי - מגילה";
                case "Books\\030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L2.txt":
                    return "תלמוד בבלי - מגילה - רש''י";
                case "Books\\030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L1.txt":
                    return "תלמוד בבלי - מגילה";

                case "Books\\030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L3.txt":
                    return "תלמוד בבלי - מגילה - תוספות";
                case "Books\\030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L6_rashba.txt":
                    return "רשב''א - מסכת מגילה";
                case "Books\\030_BAVLI\\11_MAS_MEGILA\\DebugMix.txt":
                    return "מסכת מגילה";
                case "Books\\030_BAVLI\\11_MAS_MEGILA\\HavAll.txt":
                    return "חברותא - מגילה";
                case "Books\\030_BAVLI\\11_MAS_MEGILA\\HavTempNoNotes.txt":
                    return "חברותא - מגילה - בלי הערות";
                case "Books\\030_BAVLI\\11_MAS_MEGILA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\12_MAS_MOED_KATAN":
                    return "תלמוד בבלי - מועד קטן";
                case "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L2.txt":
                    return "תלמוד בבלי - מועד קטן - רש''י";
                case "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L1.txt":
                    return "תלמוד בבלי - מועד קטן";

                case "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L3.txt":
                    return "תלמוד בבלי - מועד קטן - תוספות";
                case "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\DebugMix.txt":
                    return "מסכת מועד קטן";
                case "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\HavAll.txt":
                    return "חברותא - מועד קטן";
                case "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\HavTempNoNotes.txt":
                    return "חברותא - מועד קטן - בלי הערות";
                case "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\13_MAS_HAGIGA":
                    return "תלמוד בבלי - חגיגה";
                case "Books\\030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L2.txt":
                    return "תלמוד בבלי - חגיגה - רש''י";
                case "Books\\030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L1.txt":
                    return "תלמוד בבלי - חגיגה";

                case "Books\\030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L3.txt":
                    return "תלמוד בבלי - חגיגה - תוספות";
                case "Books\\030_BAVLI\\13_MAS_HAGIGA\\DebugMix.txt":
                    return "מסכת חגיגה";
                case "Books\\030_BAVLI\\13_MAS_HAGIGA\\HavAll.txt":
                    return "חברותא - חגיגה";
                case "Books\\030_BAVLI\\13_MAS_HAGIGA\\HavTempNoNotes.txt":
                    return "חברותא - חגיגה - בלי הערות";
                case "Books\\030_BAVLI\\13_MAS_HAGIGA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\14_MAS_YEVAMOT":
                    return "תלמוד בבלי - יבמות";
                case "Books\\030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L2.txt":
                    return "תלמוד בבלי - יבמות - רש''י";
                case "Books\\030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L1.txt":
                    return "תלמוד בבלי - יבמות";

                case "Books\\030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L3.txt":
                    return "תלמוד בבלי - יבמות - תוספות";
                case "Books\\030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L6_rashba.txt":
                    return "רשב''א - מסכת יבמות";
                case "Books\\030_BAVLI\\14_MAS_YEVAMOT\\DebugMix.txt":
                    return "מסכת יבמות";
                case "Books\\030_BAVLI\\14_MAS_YEVAMOT\\HavAll.txt":
                    return "חברותא - יבמות";
                case "Books\\030_BAVLI\\14_MAS_YEVAMOT\\HavTempNoNotes.txt":
                    return "חברותא - יבמות - בלי הערות";
                case "Books\\030_BAVLI\\14_MAS_YEVAMOT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\15_MAS_KTUBOT":
                    return "תלמוד בבלי - כתובות";
                case "Books\\030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L2.txt":
                    return "תלמוד בבלי - כתובות - רש''י";
                case "Books\\030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L1.txt":
                    return "תלמוד בבלי - כתובות";

                case "Books\\030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L3.txt":
                    return "תלמוד בבלי - כתובות - תוספות";
                case "Books\\030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L6_rashba.txt":
                    return "רשב''א - מסכת כתובות";
                case "Books\\030_BAVLI\\15_MAS_KTUBOT\\DebugMix.txt":
                    return "מסכת כתובות";
                case "Books\\030_BAVLI\\15_MAS_KTUBOT\\HavAll.txt":
                    return "חברותא - כתובות";
                case "Books\\030_BAVLI\\15_MAS_KTUBOT\\HavTempNoNotes.txt":
                    return "חברותא - כתובות - בלי הערות";
                case "Books\\030_BAVLI\\15_MAS_KTUBOT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM":
                    return "תלמוד בבלי - נדרים";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L2.txt":
                    return "תלמוד בבלי - נדרים - רש''י";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L1.txt":
                    return "תלמוד בבלי - נדרים";

                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L3.txt":
                    return "תלמוד בבלי - נדרים - תוספות";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L4.txt":
                    return "תלמוד בבלי - נדרים - ר''נ";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L6_rashba.txt":
                    return "רשב''א - מסכת נדרים";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\DebugMix.txt":
                    return "מסכת נדרים";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\HavAll.txt":
                    return "חברותא - נדרים";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\HavTempNoNotes.txt":
                    return "חברותא - נדרים - בלי הערות";
                case "Books\\030_BAVLI\\16_MAS_NEDARIM\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\17_MAS_NAZIR":
                    return "תלמוד בבלי - נזיר";
                case "Books\\030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L2.txt":
                    return "תלמוד בבלי - נזיר - רש''י";
                case "Books\\030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L1.txt":
                    return "תלמוד בבלי - נזיר";

                case "Books\\030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L3.txt":
                    return "תלמוד בבלי - נזיר - תוספות";
                case "Books\\030_BAVLI\\17_MAS_NAZIR\\DebugMix.txt":
                    return "מסכת נזיר";
                case "Books\\030_BAVLI\\17_MAS_NAZIR\\HavAll.txt":
                    return "חברותא - נזיר";
                case "Books\\030_BAVLI\\17_MAS_NAZIR\\HavTempNoNotes.txt":
                    return "חברותא - נזיר - בלי הערות";
                case "Books\\030_BAVLI\\17_MAS_NAZIR\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\18_MAS_SOTA":
                    return "תלמוד בבלי - סוטה";
                case "Books\\030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L2.txt":
                    return "תלמוד בבלי - סוטה - רש''י";
                case "Books\\030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L1.txt":
                    return "תלמוד בבלי - סוטה";

                case "Books\\030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L3.txt":
                    return "תלמוד בבלי - סוטה - תוספות";
                case "Books\\030_BAVLI\\18_MAS_SOTA\\DebugMix.txt":
                    return "מסכת סוטה";
                case "Books\\030_BAVLI\\18_MAS_SOTA\\HavAll.txt":
                    return "חברותא - סוטה";
                case "Books\\030_BAVLI\\18_MAS_SOTA\\HavTempNoNotes.txt":
                    return "חברותא - סוטה - בלי הערות";
                case "Books\\030_BAVLI\\18_MAS_SOTA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\19_MAS_GITIN":
                    return "תלמוד בבלי - גיטין";
                case "Books\\030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L2.txt":
                    return "תלמוד בבלי - גיטין - רש''י";
                case "Books\\030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L1.txt":
                    return "תלמוד בבלי - גיטין";

                case "Books\\030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L3.txt":
                    return "תלמוד בבלי - גיטין - תוספות";
                case "Books\\030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L6_rashba.txt":
                    return "רשב''א - מסכת גיטין";
                case "Books\\030_BAVLI\\19_MAS_GITIN\\DebugMix.txt":
                    return "מסכת גיטין";
                case "Books\\030_BAVLI\\19_MAS_GITIN\\HavAll.txt":
                    return "חברותא - גיטין";
                case "Books\\030_BAVLI\\19_MAS_GITIN\\HavTempNoNotes.txt":
                    return "חברותא - גיטין - בלי הערות";
                case "Books\\030_BAVLI\\19_MAS_GITIN\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN":
                    return "תלמוד בבלי - קידושין";
                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L2.txt":
                    return "תלמוד בבלי - קידושין - רש''י";
                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L1.txt":
                    return "תלמוד בבלי - קידושין";

                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L3.txt":
                    return "תלמוד בבלי - קידושין - תוספות";
                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L6_rashba.txt":
                    return "רשב''א - מסכת קידושין";
                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\DebugMix.txt":
                    return "מסכת קידושין";
                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\HavAll.txt":
                    return "חברותא - קידושין";
                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\HavTempNoNotes.txt":
                    return "חברותא - קידושין - בלי הערות";
                case "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\21_MAS_KAMA":
                    return "תלמוד בבלי - בבא קמא";
                case "Books\\030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L2.txt":
                    return "תלמוד בבלי - בבא קמא - רש''י";
                case "Books\\030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L1.txt":
                    return "תלמוד בבלי - בבא קמא";

                case "Books\\030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L3.txt":
                    return "תלמוד בבלי - בבא קמא - תוספות";
                case "Books\\030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L6_rashba.txt":
                    return "רשב''א - מסכת בבא קמא";
                case "Books\\030_BAVLI\\21_MAS_KAMA\\DebugMix.txt":
                    return "מסכת בבא קמא";
                case "Books\\030_BAVLI\\21_MAS_KAMA\\HavAll.txt":
                    return "חברותא - בבא קמא";
                case "Books\\030_BAVLI\\21_MAS_KAMA\\HavTempNoNotes.txt":
                    return "חברותא - בבא קמא - בלי הערות";
                case "Books\\030_BAVLI\\21_MAS_KAMA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\22_MAS_METSIA":
                    return "תלמוד בבלי - בבא מציעא";
                case "Books\\030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L2.txt":
                    return "תלמוד בבלי - בבא מציעא - רש''י";
                case "Books\\030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L1.txt":
                    return "תלמוד בבלי - בבא מציעא";

                case "Books\\030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L3.txt":
                    return "תלמוד בבלי - בבא מציעא - תוספות";
                case "Books\\030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L6_rashba.txt":
                    return "רשב''א - מסכת בבא מציעא";
                case "Books\\030_BAVLI\\22_MAS_METSIA\\DebugMix.txt":
                    return "מסכת בבא מציעא";
                case "Books\\030_BAVLI\\22_MAS_METSIA\\HavAll.txt":
                    return "חברותא - בבא מציעא";
                case "Books\\030_BAVLI\\22_MAS_METSIA\\HavTempNoNotes.txt":
                    return "חברותא - בבא מציעא - בלי הערות";
                case "Books\\030_BAVLI\\22_MAS_METSIA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\23_MAS_BATRA":
                    return "תלמוד בבלי - בבא בתרא";
                case "Books\\030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L2.txt":
                    return "תלמוד בבלי - בבא בתרא - רש''י";
                case "Books\\030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L1.txt":
                    return "תלמוד בבלי - בבא בתרא";

                case "Books\\030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L3.txt":
                    return "תלמוד בבלי - בבא בתרא - תוספות";
                case "Books\\030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L6_rashba.txt":
                    return "רשב''א - מסכת בבא בתרא";
                case "Books\\030_BAVLI\\23_MAS_BATRA\\DebugMix.txt":
                    return "מסכת בבא בתרא";
                case "Books\\030_BAVLI\\23_MAS_BATRA\\HavAll.txt":
                    return "חברותא - בבא בתרא";
                case "Books\\030_BAVLI\\23_MAS_BATRA\\HavTempNoNotes.txt":
                    return "חברותא - בבא בתרא - בלי הערות";
                case "Books\\030_BAVLI\\23_MAS_BATRA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\24_MAS_SANHEDRIN":
                    return "תלמוד בבלי - סנהדרין";
                case "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L2.txt":
                    return "תלמוד בבלי - סנהדרין - רש''י";
                case "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L1.txt":
                    return "תלמוד בבלי - סנהדרין";

                case "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L3.txt":
                    return "תלמוד בבלי - סנהדרין - תוספות";
                case "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\DebugMix.txt":
                    return "מסכת סנהדרין";
                case "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\HavAll.txt":
                    return "חברותא - סנהדרין";
                case "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\HavTempNoNotes.txt":
                    return "חברותא - סנהדרין - בלי הערות";
                case "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\25_MAS_MAKOT":
                    return "תלמוד בבלי - מכות";
                case "Books\\030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L2.txt":
                    return "תלמוד בבלי - מכות - רש''י";
                case "Books\\030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L1.txt":
                    return "תלמוד בבלי - מכות";

                case "Books\\030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L3.txt":
                    return "תלמוד בבלי - מכות - תוספות";
                case "Books\\030_BAVLI\\25_MAS_MAKOT\\DebugMix.txt":
                    return "מסכת מכות";
                case "Books\\030_BAVLI\\25_MAS_MAKOT\\HavAll.txt":
                    return "חברותא - מכות";
                case "Books\\030_BAVLI\\25_MAS_MAKOT\\HavTempNoNotes.txt":
                    return "חברותא - מכות - בלי הערות";
                case "Books\\030_BAVLI\\25_MAS_MAKOT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\26_MAS_SHVUOT":
                    return "תלמוד בבלי - שבועות";
                case "Books\\030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L2.txt":
                    return "תלמוד בבלי - שבועות - רש''י";
                case "Books\\030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L1.txt":
                    return "תלמוד בבלי - שבועות";

                case "Books\\030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L3.txt":
                    return "תלמוד בבלי - שבועות - תוספות";
                case "Books\\030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L6_rashba.txt":
                    return "רשב''א - מסכת שבועות";
                case "Books\\030_BAVLI\\26_MAS_SHVUOT\\DebugMix.txt":
                    return "מסכת שבועות";
                case "Books\\030_BAVLI\\26_MAS_SHVUOT\\HavAll.txt":
                    return "חברותא - שבועות";
                case "Books\\030_BAVLI\\26_MAS_SHVUOT\\HavTempNoNotes.txt":
                    return "חברותא - שבועות - בלי הערות";
                case "Books\\030_BAVLI\\26_MAS_SHVUOT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA":
                    return "תלמוד בבלי - עבודה זרה";
                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L2.txt":
                    return "תלמוד בבלי - עבודה זרה - רש''י";
                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L1.txt":
                    return "תלמוד בבלי - עבודה זרה";

                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L3.txt":
                    return "תלמוד בבלי - עבודה זרה - תוספות";
                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L6_rashba.txt":
                    return "רשב''א - מסכת עבודה זרה";
                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\DebugMix.txt":
                    return "מסכת עבודה זרה";
                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\HavAll.txt":
                    return "חברותא - עבודה זרה";
                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\HavTempNoNotes.txt":
                    return "חברותא - עבודה זרה - בלי הערות";
                case "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\28_MAS_HORAYOT":
                    return "תלמוד בבלי - הוריות";
                case "Books\\030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L2.txt":
                    return "תלמוד בבלי - הוריות - רש''י";
                case "Books\\030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L1.txt":
                    return "תלמוד בבלי - הוריות";

                case "Books\\030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L3.txt":
                    return "תלמוד בבלי - הוריות - תוספות";
                case "Books\\030_BAVLI\\28_MAS_HORAYOT\\DebugMix.txt":
                    return "מסכת הוריות";
                case "Books\\030_BAVLI\\28_MAS_HORAYOT\\HavAll.txt":
                    return "חברותא - הוריות";
                case "Books\\030_BAVLI\\28_MAS_HORAYOT\\HavTempNoNotes.txt":
                    return "חברותא - הוריות - בלי הערות";
                case "Books\\030_BAVLI\\28_MAS_HORAYOT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\29_MAS_EDUYOT":
                    return "תלמוד בבלי - עדיות";
                case "Books\\030_BAVLI\\30_MAS_ZEVACHIM":
                    return "תלמוד בבלי - זבחים";
                case "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L2.txt":
                    return "תלמוד בבלי - זבחים - רש''י";
                case "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L1.txt":
                    return "תלמוד בבלי - זבחים";

                case "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L3.txt":
                    return "תלמוד בבלי - זבחים - תוספות";
                case "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\DebugMix.txt":
                    return "מסכת זבחים";
                case "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\HavAll.txt":
                    return "חברותא - זבחים";
                case "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\HavTempNoNotes.txt":
                    return "חברותא - זבחים - בלי הערות";
                case "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\31_MAS_MENACHOT":
                    return "תלמוד בבלי - מנחות";
                case "Books\\030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L2.txt":
                    return "תלמוד בבלי - מנחות - רש''י";
                case "Books\\030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L1.txt":
                    return "תלמוד בבלי - מנחות";

                case "Books\\030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L3.txt":
                    return "תלמוד בבלי - מנחות - תוספות";
                case "Books\\030_BAVLI\\31_MAS_MENACHOT\\DebugMix.txt":
                    return "מסכת מנחות";
                case "Books\\030_BAVLI\\31_MAS_MENACHOT\\HavAll.txt":
                    return "חברותא - מנחות";
                case "Books\\030_BAVLI\\31_MAS_MENACHOT\\HavTempNoNotes.txt":
                    return "חברותא - מנחות - בלי הערות";
                case "Books\\030_BAVLI\\31_MAS_MENACHOT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\32_MAS_CHULIN":
                    return "תלמוד בבלי - חולין";
                case "Books\\030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L2.txt":
                    return "תלמוד בבלי - חולין - רש''י";
                case "Books\\030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L1.txt":
                    return "תלמוד בבלי - חולין";

                case "Books\\030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L3.txt":
                    return "תלמוד בבלי - חולין - תוספות";
                case "Books\\030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L6_rashba.txt":
                    return "רשב''א - מסכת חולין";
                case "Books\\030_BAVLI\\32_MAS_CHULIN\\DebugMix.txt":
                    return "מסכת חולין";
                case "Books\\030_BAVLI\\32_MAS_CHULIN\\HavAll.txt":
                    return "חברותא - חולין";
                case "Books\\030_BAVLI\\32_MAS_CHULIN\\HavTempNoNotes.txt":
                    return "חברותא - חולין - בלי הערות";
                case "Books\\030_BAVLI\\32_MAS_CHULIN\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\33_MAS_BECHOROT":
                    return "תלמוד בבלי - בכורות";
                case "Books\\030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L2.txt":
                    return "תלמוד בבלי - בכורות - רש''י";
                case "Books\\030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L1.txt":
                    return "תלמוד בבלי - בכורות";

                case "Books\\030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L3.txt":
                    return "תלמוד בבלי - בכורות - תוספות";
                case "Books\\030_BAVLI\\33_MAS_BECHOROT\\DebugMix.txt":
                    return "מסכת בכורות";
                case "Books\\030_BAVLI\\33_MAS_BECHOROT\\HavAll.txt":
                    return "חברותא - בכורות";
                case "Books\\030_BAVLI\\33_MAS_BECHOROT\\HavTempNoNotes.txt":
                    return "חברותא - בכורות - בלי הערות";
                case "Books\\030_BAVLI\\33_MAS_BECHOROT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\34_MAS_ARACHIN":
                    return "תלמוד בבלי - ערכין";
                case "Books\\030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L2.txt":
                    return "תלמוד בבלי - ערכין - רש''י";
                case "Books\\030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L1.txt":
                    return "תלמוד בבלי - ערכין";

                case "Books\\030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L3.txt":
                    return "תלמוד בבלי - ערכין - תוספות";
                case "Books\\030_BAVLI\\34_MAS_ARACHIN\\DebugMix.txt":
                    return "מסכת ערכין";
                case "Books\\030_BAVLI\\34_MAS_ARACHIN\\HavAll.txt":
                    return "חברותא - ערכין";
                case "Books\\030_BAVLI\\34_MAS_ARACHIN\\HavTempNoNotes.txt":
                    return "חברותא - ערכין - בלי הערות";
                case "Books\\030_BAVLI\\34_MAS_ARACHIN\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\35_MAS_TEMURA":
                    return "תלמוד בבלי - תמורה";
                case "Books\\030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L2.txt":
                    return "תלמוד בבלי - תמורה - רש''י";
                case "Books\\030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L1.txt":
                    return "תלמוד בבלי - תמורה";

                case "Books\\030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L3.txt":
                    return "תלמוד בבלי - תמורה - תוספות";
                case "Books\\030_BAVLI\\35_MAS_TEMURA\\DebugMix.txt":
                    return "מסכת תמורה";
                case "Books\\030_BAVLI\\35_MAS_TEMURA\\HavAll.txt":
                    return "חברותא - תמורה";
                case "Books\\030_BAVLI\\35_MAS_TEMURA\\HavTempNoNotes.txt":
                    return "חברותא - תמורה - בלי הערות";
                case "Books\\030_BAVLI\\35_MAS_TEMURA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\36_MAS_KRETOT":
                    return "תלמוד בבלי - כריתות";
                case "Books\\030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L2.txt":
                    return "תלמוד בבלי - כריתות - רש''י";
                case "Books\\030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L1.txt":
                    return "תלמוד בבלי - כריתות";

                case "Books\\030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L3.txt":
                    return "תלמוד בבלי - כריתות - תוספות";
                case "Books\\030_BAVLI\\36_MAS_KRETOT\\DebugMix.txt":
                    return "מסכת כריתות";
                case "Books\\030_BAVLI\\36_MAS_KRETOT\\HavAll.txt":
                    return "חברותא - כריתות";
                case "Books\\030_BAVLI\\36_MAS_KRETOT\\HavTempNoNotes.txt":
                    return "חברותא - כריתות - בלי הערות";
                case "Books\\030_BAVLI\\36_MAS_KRETOT\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\37_MAS_MEILA":
                    return "תלמוד בבלי - מעילה";
                case "Books\\030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L2.txt":
                    return "תלמוד בבלי - מעילה - רש''י";
                case "Books\\030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L1.txt":
                    return "תלמוד בבלי - מעילה";

                case "Books\\030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L3.txt":
                    return "תלמוד בבלי - מעילה - תוספות";
                case "Books\\030_BAVLI\\37_MAS_MEILA\\DebugMix.txt":
                    return "מסכת מעילה";
                case "Books\\030_BAVLI\\37_MAS_MEILA\\HavAll.txt":
                    return "חברותא - מעילה";
                case "Books\\030_BAVLI\\37_MAS_MEILA\\HavTempNoNotes.txt":
                    return "חברותא - מעילה - בלי הערות";
                case "Books\\030_BAVLI\\37_MAS_MEILA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\38_MAS_TAMID":
                    return "תלמוד בבלי - תמיד";
                case "Books\\030_BAVLI\\38_MAS_TAMID\\BAV TAMID_L2.txt":
                    return "[2] תלמוד בבלי - תמיד - פירוש";
                case "Books\\030_BAVLI\\38_MAS_TAMID\\BAV TAMID_L1.txt":
                    return "[1] תלמוד בבלי - תמיד - פירוש";

                case "Books\\030_BAVLI\\38_MAS_TAMID\\DebugMix.txt":
                    return "מסכת תמיד";
                case "Books\\030_BAVLI\\38_MAS_TAMID\\HavAll.txt":
                    return "חברותא - תמיד";
                case "Books\\030_BAVLI\\38_MAS_TAMID\\HavTempNoNotes.txt":
                    return "חברותא - תמיד - בלי הערות";
                case "Books\\030_BAVLI\\38_MAS_TAMID\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\39_MAS_NIDA":
                    return "תלמוד בבלי - נדה";
                case "Books\\030_BAVLI\\39_MAS_NIDA\\Bav Nida_L2.txt":
                    return "תלמוד בבלי - נדה - רש''י";
                case "Books\\030_BAVLI\\39_MAS_NIDA\\Bav Nida_L1.txt":
                    return "תלמוד בבלי - נדה";

                case "Books\\030_BAVLI\\39_MAS_NIDA\\Bav Nida_L3.txt":
                    return "תלמוד בבלי - נדה - תוספות";
                case "Books\\030_BAVLI\\39_MAS_NIDA\\Bav Nida_L6_rashba.txt":
                    return "רשב''א - מסכת נדה";
                case "Books\\030_BAVLI\\39_MAS_NIDA\\DebugMix.txt":
                    return "מסכת נדה";
                case "Books\\030_BAVLI\\39_MAS_NIDA\\HavAll.txt":
                    return "חברותא - נידה";
                case "Books\\030_BAVLI\\39_MAS_NIDA\\HavTempNoNotes.txt":
                    return "חברותא - נידה - בלי הערות";
                case "Books\\030_BAVLI\\39_MAS_NIDA\\HavTempNotes.txt":
                    return "חברותא - זמני - הערות";
                case "Books\\030_BAVLI\\29_MAS_EDUYOT\\Bav EDUYOT_L1.txt":
                    return "תלמוד בבלי - עדיות";
                case "Books\040_HALACHA1\030_orach_chaim_merged.txt":
                    return "שלחן ערוך - אורח חיים";


                case "Books\\035_RAMBAM\\00000_RAMBAM-MRG_NEW.txt":
                    return "הקדמת הרמב''ם למשנה תורה";
                case "Books\\035_RAMBAM\\00001_RAMBAM-MRG_L1.txt":
                    return "משנה תורה - ספר המצוות";
                case "Books\\035_RAMBAM\\00002_mada_merged.txt":
                    return "משנה תורה - ספר מדע";
                case "Books\\035_RAMBAM\\00003_ahava_merged.txt":
                    return "משנה תורה - ספר אהבה";
                case "Books\\035_RAMBAM\\00004_zmanim_merged.txt":
                    return "משנה תורה - ספר זמנים";
                case "Books\\035_RAMBAM\\00005_nashim_merged.txt":
                    return "משנה תורה - ספר נשים";
                case "Books\\035_RAMBAM\\00006_kdusha_merged.txt":
                    return "משנה תורה - ספר קדושה";
                case "Books\\035_RAMBAM\\00007_haflaa_merged.txt":
                    return "משנה תורה - ספר הפלאה";
                case "Books\\035_RAMBAM\\00008_zraiim_merged.txt":
                    return "משנה תורה - ספר זרעים";
                case "Books\\035_RAMBAM\\00009_avoda_merged.txt":
                    return "משנה תורה - ספר עבודה";
                case "Books\\035_RAMBAM\\00010_korbanot_merged.txt":
                    return "משנה תורה - ספר קרבנות";
                case "Books\\035_RAMBAM\\00011_tahara_merged.txt":
                    return "משנה תורה - ספר טהרה";
                case "Books\\035_RAMBAM\\00012_nezikin_merged.txt":
                    return "משנה תורה - ספר נזיקין";
                case "Books\\035_RAMBAM\\00013_kinyan_merged.txt":
                    return "משנה תורה - ספר קנין";
                case "Books\\035_RAMBAM\\00014_mishpatim_merged.txt":
                    return "משנה תורה - ספר משפטים";
                case "Books\\035_RAMBAM\\00015_shoftim_merged.txt":
                    return "משנה תורה - ספר שופטים";
                case "Books\\035_RAMBAM\\0020_RAMBAM-MRG_L0.txt":
                    return "הקדמת הרמב''ם למשנה תורה";

                case "Books\\035_RAMBAM\\0040_RAMBAM AHAVA_L1.txt":
                    return "[1] - משנה תורה - ספר אהבה";
                case "Books\\035_RAMBAM\\0050_RAMBAM-ZMANIM_L1.txt":
                    return "[1] - משנה תורה - ספר זמנים";
                case "Books\\035_RAMBAM\\0060_RAMBAM-NASHIM_L1.txt":
                    return "[1] - משנה תורה - ספר נשים";
                case "Books\\035_RAMBAM\\0070_RAMBAM KDUSHA_L1.txt":
                    return "[1] - משנה תורה - ספר קדושה";
                case "Books\\035_RAMBAM\\0080_RAMBAM-HAFLAA_L1.txt":
                    return "[1] - משנה תורה - ספר הפלאה";
                case "Books\\035_RAMBAM\\0090_RAMBAM_ZRAIIM_L1.txt":
                    return "[1] - משנה תורה - ספר זרעים";
                case "Books\\035_RAMBAM\\0100_RAMBAM AVODA_L1.txt":
                    return "[1] - משנה תורה - ספר עבודה";
                case "Books\\035_RAMBAM\\0110_RAMBAM KORBANOT_L1.txt":
                    return "[1] - משנה תורה - ספר הקרבנות";
                case "Books\\035_RAMBAM\\0120_RAMBAM TAHARA_L1.txt":
                    return "[1] - משנה תורה - ספר טהרה";
                case "Books\\035_RAMBAM\\0130_RAMBAM NEZIKIN_L1.txt":
                    return "[1] - משנה תורה - ספר נזיקין";
                case "Books\\035_RAMBAM\\0140_RAMBAM_KINYAN_L1.txt":
                    return "[1] - משנה תורה - ספר קנין";
                case "Books\\035_RAMBAM\\0150_RAMBAM_MISPATIM_L1.txt":
                    return "[1] - משנה תורה - ספר משפטים";
                case "Books\\035_RAMBAM\\0160_RAMBAM_SHOFTIM_L1.txt":
                    return "[1] - משנה תורה - ספר שופטים";
                case "Books\\035_RAMBAM\\0030_RAMBAM_MADA_L1.txt":
                    return "[1] - משנה תורה - ספר מדע";
                case "Books\\035_RAMBAM\\90002_mada.txt":
                    return "משנה תורה - ספר מדע";
                case "Books\\035_RAMBAM\\90002_mada_kesef.txt":
                    return "כסף משנה - מדע";
                case "Books\\035_RAMBAM\\90002_mada_lechem.txt":
                    return "לחם משנה - מדע";
                case "Books\\035_RAMBAM\\90002_mada_perush.txt":
                    return "פירוש - ספר מדע";
                case "Books\\035_RAMBAM\\90002_mada_raavad.txt":
                    return "השגות הראבד - מדע";
                case "Books\\035_RAMBAM\\90003_ahava.txt":
                    return "משנה תורה - ספר אהבה";
                case "Books\\035_RAMBAM\\90003_ahava_kesef.txt":
                    return "כסף משנה - אהבה";
                case "Books\\035_RAMBAM\\90003_ahava_lechem.txt":
                    return "לחם משנה - אהבה";
                case "Books\\035_RAMBAM\\90003_ahava_raavad.txt":
                    return "השגות הראבד - אהבה";
                case "Books\\035_RAMBAM\\90004_zmanim.txt":
                    return "משנה תורה - ספר זמנים";
                case "Books\\035_RAMBAM\\90004_zmanim_haviv.txt":
                    return "מהר''ל נ' חביב - זמנים";
                case "Books\\035_RAMBAM\\90004_zmanim_kesef.txt":
                    return "כסף משנה - זמנים";
                case "Books\\035_RAMBAM\\90004_zmanim_lechem.txt":
                    return "לחם משנה - זמנים";
                case "Books\\035_RAMBAM\\90004_zmanim_magid.txt":
                    return "מגיד משנה - זמנים";
                case "Books\\035_RAMBAM\\90004_zmanim_perush.txt":
                    return "פירוש - זמנים";
                case "Books\\035_RAMBAM\\90004_zmanim_raavad.txt":
                    return "השגות הראבד - זמנים";
                case "Books\\035_RAMBAM\\90005_nashim.txt":
                    return "משנה תורה - ספר נשים";
                case "Books\\035_RAMBAM\\90005_nashim_kesef.txt":
                    return "כסף משנה - נשים";
                case "Books\\035_RAMBAM\\90005_nashim_lechem.txt":
                    return "לחם משנה - נשים";
                case "Books\\035_RAMBAM\\90005_nashim_magid.txt":
                    return "מגיד משנה - נשים";
                case "Books\\035_RAMBAM\\90005_nashim_raavad.txt":
                    return "השגות הראבד - נשים";
                case "Books\\035_RAMBAM\\90006_kdusha.txt":
                    return "משנה תורה - ספר קדושה";
                case "Books\\035_RAMBAM\\90006_kdusha_kesef.txt":
                    return "כסף משנה - קדושה";
                case "Books\\035_RAMBAM\\90006_kdusha_lechem.txt":
                    return "לחם משנה - קדושה";
                case "Books\\035_RAMBAM\\90006_kdusha_magid.txt":
                    return "מגיד משנה - קדושה";
                case "Books\\035_RAMBAM\\90006_kdusha_raavad.txt":
                    return "השגות הראבד - קדושה";
                case "Books\\035_RAMBAM\\90007_haflaa.txt":
                    return "משנה תורה - ספר הפלאה";
                case "Books\\035_RAMBAM\\90007_haflaa_kesef.txt":
                    return "כסף משנה - הפלאה";
                case "Books\\035_RAMBAM\\90007_haflaa_lechem.txt":
                    return "לחם משנה - הפלאה";
                case "Books\\035_RAMBAM\\90007_haflaa_raavad.txt":
                    return "השגות הראבד - הפלאה";
                case "Books\\035_RAMBAM\\90008_zraiim.txt":
                    return "משנה תורה - ספר זרעים";
                case "Books\\035_RAMBAM\\90008_zraiim_kesef.txt":
                    return "כסף משנה - זרעים";
                case "Books\\035_RAMBAM\\90008_zraiim_raavad.txt":
                    return "השגות הראבד - זרעים";
                case "Books\\035_RAMBAM\\90009_avoda.txt":
                    return "משנה תורה - ספר עבודה";
                case "Books\\035_RAMBAM\\90009_avoda_kesef.txt":
                    return "כסף משנה - עבודה";
                case "Books\\035_RAMBAM\\90009_avoda_raavad.txt":
                    return "השגות הראבד - עבודה";
                case "Books\\035_RAMBAM\\90010_korbanot.txt":
                    return "משנה תורה - ספר קרבנות";
                case "Books\\035_RAMBAM\\90010_korbanot_kesef.txt":
                    return "כסף משנה - קרבנות";
                case "Books\\035_RAMBAM\\90010_korbanot_raavad.txt":
                    return "השגות הראבד - קרבנות";
                case "Books\\035_RAMBAM\\90011_tahara.txt":
                    return "משנה תורה - ספר טהרה";
                case "Books\\035_RAMBAM\\90011_tahara_kesef.txt":
                    return "כסף משנה - ספר טהרה";
                case "Books\\035_RAMBAM\\90011_tahara_raavad.txt":
                    return "השגות הראבד - טהרה";
                case "Books\\035_RAMBAM\\90012_nezikin.txt":
                    return "משנה תורה - ספר נזיקין";
                case "Books\\035_RAMBAM\\90012_nezikin_kesef.txt":
                    return "כסף משנה-ספר נזיקין";
                case "Books\\035_RAMBAM\\90012_nezikin_magid.txt":
                    return "מגיד משנה - ספר נזיקין";
                case "Books\\035_RAMBAM\\90012_nezikin_raavad.txt":
                    return "השגות הראבד - נזיקין";
                case "Books\\035_RAMBAM\\90013_kinyan.txt":
                    return "משנה תורה - ספר קנין";
                case "Books\\035_RAMBAM\\90013_kinyan_kesef.txt":
                    return "כסף משנה - קנין";
                case "Books\\035_RAMBAM\\90013_kinyan_magid.txt":
                    return "מגיד משנה - ספר קנין";
                case "Books\\035_RAMBAM\\90013_kinyan_raavad.txt":
                    return "השגות הראבד - קנין";
                case "Books\\035_RAMBAM\\90014_mishpatim.txt":
                    return "משנה תורה - ספר משפטים";
                case "Books\\035_RAMBAM\\90014_mishpatim_kesef.txt":
                    return "כסף משנה - משפטים";
                case "Books\\035_RAMBAM\\90014_mishpatim_magid.txt":
                    return "מגיד משנה - משפטים";
                case "Books\\035_RAMBAM\\90014_mishpatim_raavad.txt":
                    return "השגות הראבד - משפטים";
                case "Books\\035_RAMBAM\\90015_shoftim.txt":
                    return "משנה תורה - ספר שופטים";
                case "Books\\035_RAMBAM\\90015_shoftim_kesef.txt":
                    return "כסף משנה-שופטים";
                case "Books\\035_RAMBAM\\90015_shoftim_raavad.txt":
                    return "השגות הראבד - שופטים";
                case "Books\\035_RAMBAM\\99999_00001_RAMBAM-MRG_NEW.txt":
                    return "משנה תורה - ספר המצוות";
                case "Books\\040_HALACHA1":
                    return "שלחן ערוך - אורח חיים";
                case "Books\\040_HALACHA1\\031_yore_deaa_merged.txt":
                    return "שלחן ערוך - יורה דעה";
                case "Books\\040_HALACHA1\\032_even_haezer_merged.txt":
                    return "שלחן ערוך - אבן העזר";
                case "Books\\040_HALACHA1\\033_choshen_mishpat_merged.txt":
                    return "שלחן ערוך - חשן משפט";
                case "Books\\040_HALACHA1\\040_orach_chaim_menukad.txt":
                    return "שלחן ערוך - אורח חיים - מנוקד";
                case "Books\\040_HALACHA1\\041_yore_deaa_menukad.txt":
                    return "שלחן ערוך - יורה דעה - מנוקד";
                case "Books\\040_HALACHA1\\042_even_haezer_menukad.txt":
                    return "שלחן ערוך - אבן העזר - מנוקד";
                case "Books\\040_HALACHA1\\043_choshen_mishpat_menukad.txt":
                    return "שלחן ערוך - חשן משפט - מנוקד";
                case "Books\\040_HALACHA1\\050_orach_chaim_baer_heitev.txt":
                    return "שלחן ערוך או''ח - באר היטב";
                case "Books\\040_HALACHA1\\051_yore_deaa_baer_heitev.txt":
                    return "שלחן ערוך יו''ד - באר היטב";
                case "Books\\040_HALACHA1\\052_even_haezer_baer_heitev.txt":
                    return "שלחן ערוך אה''ע - באר היטב";
                case "Books\\040_HALACHA1\\053_choshen_mishpat_baer_heitev.txt":
                    return "שלחן ערוך חו''מ - באר היטב";
                case "Books\\040_HALACHA1\\060_orach_chaim.txt":
                    return "שלחן ערוך - אורח חיים - לא מנוקד";
                case "Books\\040_HALACHA1\\061_yore_deaa.txt":
                    return "שלחן ערוך - יורה דעה - לא מנוקד";
                case "Books\\040_HALACHA1\\063_choshen_mishpat.txt":
                    return "שלחן ערוך - חשן משפט - לא מנוקד";
                case "Books\\040_HALACHA1\\080_hinuch.txt":
                    return "ספר החינוך";
                case "Books\\040_HALACHA1\\081_aruch_hasulchan1.txt":
                    return "ערוך השולחן - אורח חיים";
                case "Books\\040_HALACHA1\\082_mishna_brura_merged.txt":
                    return "משנה ברורה";
                case "Books\\040_HALACHA1\\083_mishna_brura.txt":
                    return "משנה ברורה";
                case "Books\\040_HALACHA1\\084_mishna_brura_beur_halacha.txt":
                    return "ביאור הלכה";
                case "Books\\040_HALACHA1\\085_mishna_brura_maran_rama.txt":
                    return "משנה ברורה - מרן ורמא";
                case "Books\\040_HALACHA1\\105_kitzur.txt":
                    return "קיצור שולחן ערוך";
                case "Books\\040_HALACHA1\\106_0_0_hh_L1.txt":
                    return "חפץ חיים";
                case "Books\\000_HORADOT\\200_PARSHA\\050_ben_ish_chai.txt":
                    return "בן איש חי";
                case "Books\\040_HALACHA1\\106_0_1_geder_olam.txt":
                    return "ספר גדר עולם";
                case "Books\\040_HALACHA1\\106_1_KITZUR_YALKUT_YOSEF.txt":
                    return "קיצור ש''ע ילקוט יוסף";
                case "Books\\040_HALACHA1\\106_2_OTSAR_DINIM.txt":
                    return "אוצר דינים לאשה ולבת";
                case "Books\\042_HALACHA2":
                    return "ספר החיים";
                case "Books\\042_HALACHA2\\109_shaar_hazahav_latahara.txt":
                    return "שער הזהב לטהרה";
                case "Books\\042_HALACHA2\\110_1_nesuin_ve_ishut.txt":
                    return "נשואין ואישות";
                case "Books\\042_HALACHA2\\110_2_tahara2.txt":
                    return "טהרה הריון ולידה כהלכה";
                case "Books\\042_HALACHA2\\111_yikra_dechayei.txt":
                    return "הלכות ביקור חולים ואבלות - יקרא דחיי";
                case "Books\\042_HALACHA2\\112_yikra_dechayei - notes.txt":
                    return "מראה מקומות והערות לספר יקרא דחיי";
                case "Books\\042_HALACHA2\\115_piske_moshe_hanuka.txt":
                    return "הלכות חנוכה - פסקי משה";
                case "Books\\042_HALACHA2\\116_PatBag.txt":
                    return "פתבג המלך";
                case "Books\\042_HALACHA2\\117_TaharatKelim.txt":
                    return "טהרת כלים";
                case "Books\\042_HALACHA2\\170_kol_eliyahu.txt":
                    return "ספר קול אליהו";
                case "Books\\042_HALACHA2\\180_MarotHatsovot.txt":
                    return "מראות הצובאות";
                case "Books\\042_HALACHA2\\181_machanecha_kadosh.txt":
                    return "ספר מחניך קדוש";
                case "Books\\042_HALACHA2\\201_shabat.txt":
                    return "שבת כהלכה";
                case "Books\\042_HALACHA2\\202_yeladim.txt":
                    return "ילדים כהלכה";
                case "Books\\042_HALACHA2\\203_NashimBahalacha.txt":
                    return "נשים בהלכה";
                case "Books\\042_HALACHA2\\204_ShmiratEnaiim.txt":
                    return "שמירת עיניים כהלכה";
                case "Books\\042_HALACHA2\\205_veaavta_kahalacha.txt":
                    return "ואהבת כהלכה";
                case "Books\\042_HALACHA2\\220_VeenLamoTora.txt":
                    return "ואין למו מכשול - הלכות תלמוד תורה";
                case "Books\\042_HALACHA2\\221_VeenLamoChesed.txt":
                    return "ואין למו מכשול - הלכות גמילות חסדים";
                case "Books\\042_HALACHA2\\223_VeenLamoTshuva.txt":
                    return "ואין למו מכשול - חלק י'";
                case "Books\\042_HALACHA2\\224_VeenLamoLifneiIver.txt":
                    return "ואין למו מכשול - חלק ה'";
                case "Books\\042_HALACHA2\\230_neki_kapaiim.txt":
                    return "נקי כפים";
                case "Books\\042_HALACHA2\\231_tolaiim.txt":
                    return "קדושים תהיו על הלכות תולעים";
                case "Books\\042_HALACHA2\\299_kashrut_gamitbach.txt":
                    return "כשרות המטבח";
                case "Books\\042_HALACHA2\\300_bahalacha_ubaagada_kibid_horim.txt":
                    return "כבוד אב ואם - בהלכה ובאגדה";
                case "Books\\042_HALACHA2\\301_bahalacha_ubaagada_mitsvot_haarets.txt":
                    return "מצוות הארץ - בהלכה ובאגדה";
                case "Books\\042_HALACHA2\\301_bahalacha_ubaagada_shabat.txt":
                    return "השבת בהלכה ובאגדה";
                case "Books\\042_HALACHA2\\302_bahalacha_ubaagada_tahara.txt":
                    return "הטהרה בהלכה ובאגדה";
                case "Books\\042_HALACHA2\\303_hilchot_seuda.txt":
                    return "הלכות סעודה";
                case "Books\\042_HALACHA2\\304_seder_hayom.txt":
                    return "סדר היום בהלכה ובאגדה";
                case "Books\\042_HALACHA2\\305_rosh_hodesh_bahalacha_ubaagada.txt":
                    return "ראש חודש בהלכה ובאגדה";
                case "Books\\042_HALACHA2\\400_piskei_moshe_hagaala_lepesach.txt":
                    return "הלכות הגעלת כלים לפסח";
                case "Books\\042_HALACHA2\\400_piskei_moshe_hagaala_lepesach.txt.notes.txt":
                    return "הערות פסקי משה - הלכות הגעלת כלים לפסח";
                case "Books\\042_HALACHA2\\401_mishna_brura_smicha_lerabanut.txt":
                    return "משנה ברורה";
                case "Books\\042_HALACHA2\\410_beyom_hashabat.txt":
                    return "וביום השבת";
                case "Books\\042_HALACHA2\\420_shay_basar_bechalav.txt":
                    return "מנחת שי - הלכות בשר בחלב";
                case "Books\\042_HALACHA2\\421_shay_tvilat_kelim.txt":
                    return "מנחת שי - הלכות טבילת כלים";
                case "Books\\042_HALACHA2\\430_holchot_yichud.txt":
                    return "גן נעול - על הלכות ייחוד";
                case "Books\\042_HALACHA2\\430_holchot_yichud.txt.notes.txt":
                    return "הערות להלכות יחוד";
                case "Books\\042_HALACHA2\\440_midot.txt":
                    return "שלחן ערוך המדות - א";
                case "Books\\042_HALACHA2\\441_midot2.txt":
                    return "שלחן ערוך המדות - ב";
                case "Books\\042_HALACHA2\\442_midot3.txt":
                    return "שלחן ערוך המדות - ג";
                case "Books\\042_IYUNIM\\028_vekane.txt":
                    return "וקָנֶה לך חבר";
                case "Books\\042_IYUNIM\\029_ShaarAsher.txt":
                    return "שער אשר - הלכות נדה";
                case "Books\\042_IYUNIM\\030_RavZilber1.txt":
                    return "בעניין מספר הפסוקים התיבות והאותיות בתורה";
                case "Books\\042_IYUNIM\\040_nachalot.txt":
                    return "בעניין הנחלות בארץ ישראל";
                case "Books\\042_IYUNIM\\050_BeerYaakovHavurot.txt":
                    return "באר יעקב - חבורות";
                case "Books\\042_IYUNIM\\051_BeerYaakovAgadot.txt":
                    return "ספר באר יעקב - אגדות הש''ס";
                case "Books\\042_IYUNIM\\070_YosefLekachMishlei.txt":
                    return "יוסף לקח - משלי";
                case "Books\\042_IYUNIM\\080_sheiya.txt":
                    return "קונטרס בגדרי שהייה וחזרה";
                case "Books\\042_IYUNIM\\090_machsevet_cohen.txt":
                    return "מחשבת כהן";
                case "Books\\042_IYUNIM\\100_minhat_shay_tfila_ad_brachot.txt":
                    return "מנחת שי - הלכות";
                case "Books\\042_IYUNIM\\100_minhat_shay_yom_tov.txt":
                    return "מנחת שי - הלכות יום טוב";
                case "Books\\042_IYUNIM\\110_birchat_israel.txt":
                    return "ספר ברכת ישראל";
                case "Books\\042_IYUNIM\\120_YadHaleviMetsia.txt":
                    return "יד הלוי - מסכת בבא מציעא";
                case "Books\\042_IYUNIM\\230_minchat_israel.txt":
                    return "ספר מנחת ישראל";
                case "Books\\042_IYUNIM\\240_maor_moadim.txt":
                    return "מאור המועדים";
                case "Books\\100_MUSAR\\010_mesilat_yesharim.TXT":
                    return "מסילת ישרים";
                case "Books\\100_MUSAR\\011_orchot_tsadikim.TXT":
                    return "אורחות צדיקים";
                case "Books\\100_MUSAR\\012_ShaareiTeshuva.txt":
                    return "שערי תשובה";
                case "Books\\100_MUSAR\\012_chovot_halevavot.txt":
                    return "חובות הלבבות";
                case "Books\\100_MUSAR\\013_TomerDevora.txt":
                    return "תומר דבורה";
                case "Books\\100_MUSAR\\014_derech_hashem.txt":
                    return "דרך השם";
                case "Books\\100_MUSAR\\015_SeferHayashar.txt":
                    return "ספר הישר";
                case "Books\\100_MUSAR\\020_igeret_haramban.TXT":
                    return "אגרת הרמב''ן";
                case "Books\\100_MUSAR\\023_igeret_teiman.txt":
                    return "אגרת תימן להרמב''ם ז''ל";
                case "Books\\100_MUSAR\\024_ShmiratHalashon_L1.txt":
                    return "שמירת הלשון";
                case "Books\\100_MUSAR\\025_NEFESH_HAHAIM_L1.txt":
                    return "נפש החיים";
                case "Books\\100_MUSAR\\035_pele.txt":
                    return "פלא יועץ";
                case "Books\\100_MUSAR\\070_EvedHashem_L1.txt":
                    return "עבד השם";
                case "Books\\100_MUSAR\\070_emuna_maasit.txt":
                    return "קובץ אמונה מעשית";
                case "Books\\100_MUSAR\\071_bilvavi1.txt":
                    return "בלבבי משכן אבנה - א";
                case "Books\\100_MUSAR\\072_bilvavi2.txt":
                    return "בלבבי משכן אבנה - ב";
                case "Books\\100_MUSAR\\073_bilvavi3.txt":
                    return "בלבבי משכן אבנה - ג";
                case "Books\\100_MUSAR\\073_bilvavi4.txt":
                    return "בלבבי משכן אבנה - ד";
                case "Books\\100_MUSAR\\076_bilvavi6.txt":
                    return "בלבבי משכן אבנה - ו";
                case "Books\\100_MUSAR\\079_bilvavi9.txt":
                    return "בלבבי משכן אבנה - ט";
                case "Books\\100_MUSAR\\090_NerLeragli.txt":
                    return "נר לרגלי";
                case "Books\\100_MUSAR\\091_OrLintivati.txt":
                    return "אור לנתיבתי";
                case "Books\\100_MUSAR\\095_BikvetaDimsiha.txt":
                    return "בעיקבתא דמשיחא";
                case "Books\\100_MUSAR\\096_BerumoShelOlam.txt":
                    return "ברומו של עולם - על התפילה";
                case "Books\\100_MUSAR\\097_ShuvaIsrael.txt":
                    return "שובה ישראל";
                case "Books\\100_MUSAR\\110_BINYAMIN_L1.txt":
                    return "בני בנימין - על מסכת אבות";
                case "Books\\100_MUSAR\\115_ShuviNafshi.txt":
                    return "שובי נפשי";
                case "Books\\100_MUSAR\\130_machane_shechina.TXT":
                    return "מחנה שכינה";
                case "Books\\100_MUSAR\\200_ANAVA_L1.txt":
                    return "ואנכי עפר ואפר - מעלות הענווה";
                case "Books\\100_MUSAR\\300_menorat_hamaor.txt":
                    return "מנורת המאור";
                case "Books\\100_MUSAR\\310_Avot_Israel.txt":
                    return "אבות ישראל - על פרקי אבות";
                case "Books\\100_MUSAR\\320_imrei_yechezkel.txt":
                    return "אמרי יחזקאל";
                case "Books\\100_MUSAR\\321_imeri_yechezkel_maagal_hachaiim.txt":
                    return "אמרי יחזקאל - מעגל החיים";
                case "Books\\100_MUSAR\\400_pardes_rimonim_1.txt":
                    return "פרדס רמונים - חלק א";
                case "Books\\100_MUSAR\\401_pardes_rimonim_2.txt":
                    return "פרדס רימונים - חלק ב";
                case "Books\\100_MUSAR\\500_chai_1.txt":
                    return "חי באמונה א - חי באמונה";
                case "Books\\100_MUSAR\\501_chai_2.txt":
                    return "חי באמונה ב - אהבת עולם אהבתנו";
                case "Books\\100_MUSAR\\502_chai_3.txt":
                    return "חי באמונה ג  -  ישמח ישראל";
                case "Books\\100_MUSAR\\503_chai_4.txt":
                    return "חי באמונה ד  -  אוצר החיים";
                case "Books\\100_MUSAR\\504_chai_5.txt":
                    return "חי באמונה ה  -  כל עכבה לטובה";
                case "Books\\100_MUSAR\\505_chai_betoda.txt":
                    return "חי בתודה";
                case "Books\\100_MUSAR\\510_chaya_beemuna.txt":
                    return "חיה באמונה";
                case "Books\\100_MUSAR\\600_vayetse_itschak.txt":
                    return "ויצא יצחק לשוח - א";
                case "Books\\100_MUSAR\\610_amal_israel.txt":
                    return "ספר עמל ישראל";
                case "Books\\106_KABALA\\000025_Hakdamot.txt":
                    return "הקדמת ספר הזוהר";
                case "Books\\106_KABALA\\000021_ZOHAR1_L1.txt":
                    return "הזוהר הקדוש - ספר בראשית";
                case "Books\\106_KABALA\\000021_ZOHAR2_L1.txt":
                    return "הזוהר הקדוש - ספר שמות";
                case "Books\\106_KABALA\\000021_ZOHAR3_L1.txt":
                    return "הזוהר הקדוש - ספר ויקרא";
                case "Books\\106_KABALA\\000021_ZOHAR4_L1.txt":
                    return "הזוהר הקדוש - ספר במדבר";
                case "Books\\106_KABALA\\000021_ZOHAR5_L1.txt":
                    return "הזוהר הקדוש - ספר דברים";
                case "Books\\106_KABALA\\000022_ZOHAR6-tikunim_L1.txt":
                    return "תיקוני הזוהר";
                case "Books\\106_KABALA\\000022_ZOHAR7-hadash_L1.txt":
                    return "זוהר חדש";
                case "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-0.txt":
                    return "הזוהר המתורגם - הקדמת ספר הזוהר";
                case "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-1.txt":
                    return "הזוהר המתורגם - ספר בראשית";
                case "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-2.txt":
                    return "הזוהר המתורגם - ספר שמות";
                case "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-3.txt":
                    return "הזוהר המתורגם - ספר ויקרא";
                case "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-4.txt":
                    return "הזוהר המתורגם - ספר במדבר";
                case "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-5.txt":
                    return "הזוהר המתורגם - ספר דברים";
                case "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-6.txt":
                    return "הזוהר המתורגם - תיקוני הזוהר";
                case "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-7.txt":
                    return "הזוהר המתורגם - זוהר חדש";
                case "Books\\106_KABALA\\000024_MaamarHaIkarim.txt":
                    return "מאמר העיקרים";
                case "Books\\106_KABALA\\000024_drashat_haramban.txt":
                    return "דרשת הרמב''ן";

                case "Books\\106_KABALA\\000026_PtichaLakabala.txt":
                    return "פתיחה לחכמת הקבלה";
                case "Books\\106_KABALA\\000027_MavoLazohar.txt":
                    return "מבוא לספר הזהר";
                case "Books\\106_KABALA\\006_sefer_hapliaa.txt":
                    return "ספר הפליאה";
                case "Books\\106_KABALA\\010_shaar_hakaavnot.TXT":
                    return "שער הכוונות";
                case "Books\\106_KABALA\\011_magid_meisharim.TXT":
                    return "ספר מגיד מישרים";
                case "Books\\106_KABALA\\012_sefer_habahir.TXT":
                    return "ספר הבהיר";
                case "Books\\106_KABALA\\013_sefer_hachashmal.TXT":
                    return "ספר החשמל";
                case "Books\\106_KABALA\\014_sefer_yezira.TXT":
                    return "ספר יצירה";
                case "Books\\106_KABALA\\015_p_ramban_sefer_yezira.TXT":
                    return "פירוש הרמב''ן לספר יצירה";
                case "Books\\106_KABALA\\016_p_ramak_sefer_yezira.txt":
                    return "פירוש הרמ''ק לספר יצירה";
                case "Books\\106_KABALA\\017_sifra_detsniuta.txt":
                    return "ספרא דצניעותא";
                case "Books\\106_KABALA\\018_shaarei_kedusha.TXT":
                    return "ספר שערי קדושה";
                case "Books\\106_KABALA\\020_DAAT_TVUNOT.txt":
                    return "ספר שקל הקדש";
                case "Books\\106_KABALA\\020_shla.TXT":
                    return "ספר תולדות אדם";
                case "Books\\106_KABALA\\021_DaatTvunot.txt":
                    return "דעת תבונות";
                case "Books\\106_KABALA\\052_MatanToraRavAshlag.txt":
                    return "מתן תורה";
                case "Books\\106_KABALA\\053_TenPrakinLaRanchal.txt":
                    return "עשרה פרקים להרמח''ל";
                case "Books\\110_CHASIDUT":
                    return "לִקּוּטֵי אֲמָרִים תַּנְיָא";
                case "Books\\110_CHASIDUT\\046_taniya_3.txt":
                    return "ספר התניא - אגרת התשובה";
                case "Books\\110_CHASIDUT\\070_LikuteiMuharan_A_BreslevOrg.txt":
                    return "ליקוטי מוהר''ן - חלק א";
                case "Books\\110_CHASIDUT\\070_LikuteiMuharan_B_BreslevOrg.txt":
                    return "ליקוטי מוהר''ן - חלק ב";
                case "Books\\110_CHASIDUT\\070_moharan_1.txt":
                    return "ליקוטי מוהר''ן - חלק א";
                case "Books\\110_CHASIDUT\\071_moharan_2.txt":
                    return "ליקוטי מוהר''ן - חלק ב";
                case "Books\\110_CHASIDUT\\072_midot.txt":
                    return "ספר המידות";
                case "Books\\110_CHASIDUT\\073_meshivat_nefesh.txt":
                    return "משיבת נפש";
                case "Books\\110_CHASIDUT\\100_kitsur_likutei.txt":
                    return "קיצור ליקוטי מוהר''ן השלם";
                case "Books\\112_HANHAGOT":
                    return "אנשי קודש";
                case "Books\\112_HANHAGOT\\0_OrchotHaiim.txt":
                    return "ארחות חיים";
                case "Books\\112_HANHAGOT\\1_hanagot_yom_yom.TXT":
                    return "הנהגות יום יום";
                case "Books\\112_HANHAGOT\\2_hanhagot_aiin_tova.TXT":
                    return "הנהגות עין טובה";
                case "Books\\112_HANHAGOT\\3_hanhagot_leshabat_kodesh.TXT":
                    return "הנהגות לשבת קודש";
                case "Books\\112_HANHAGOT\\4_kontras_shabat_kodesk.TXT":
                    return "קונטרס שבת קודש";
                case "Books\\112_HANHAGOT\\5_zohar_shabat_kodesh.TXT":
                    return "פניני הזוהר לשבת קודש";
                case "Books\\112_HANHAGOT\\6_hanhagot_leshabat_kodesh_2.txt":
                    return "הנהגות לשבת קודש - חלק ב";
                case "Books\\112_HANHAGOT\\7_avelim.txt":
                    return "הנהגות ועצות מעשיות לאבלים";
                case "Books\\112_HANHAGOT\\8_emula_maasit.txt":
                    return "הנהגות אמונה מעשית";
                case "Books\\112_HANHAGOT\\SAVIV_L1.txt":
                    return "סביב למשפחה";
                case "Books\\112_HANHAGOT\\elul.txt":
                    return "הנהגות חודש אלול וימים נוראים";
                case "Books\\112_HANHAGOT\\igeret_leben_tora.txt":
                    return "קונטרס - אגרת לבן תורה";
                case "Books\\115_PARSHA\\008_bd1.txt":
                    return "בים דרך - בראשית";
                case "Books\\115_PARSHA\\008_bd2.txt":
                    return "בים דרך - שמות";
                case "Books\\115_PARSHA\\008_bd3.txt":
                    return "בים דרך - ויקרא";
                case "Books\\115_PARSHA\\008_bd4.txt":
                    return "בים דרך - במדבר";
                case "Books\\115_PARSHA\\008_bd5.txt":
                    return "בים דרך - דברים";
                case "Books\\115_PARSHA\\010_TIFERET_L1.txt":
                    return "תפארת ישראל";
                case "Books\\115_PARSHA\\050_NerTamidHaravBrener.txt":
                    return "נר תמיד - על פרשת השבוע";
                case "Books\\115_PARSHA\\070_PriHanan1.txt":
                    return "פרי חנן על התורה - בראשית";
                case "Books\\115_PARSHA\\070_PriHanan2.txt":
                    return "פרי חנן על התורה - שמות";
                case "Books\\115_PARSHA\\080_YagelYaakovTora.txt":
                    return "יגל יעקב - על פרשת השבוע";
                case "Books\\115_PARSHA\\090_bacharta_bachaiim.txt":
                    return "ובחרת בחיים";
                case "Books\\115_PARSHA\\100_BeerYaakovTora.txt":
                    return "באר יעקב על התורה";
                case "Books\\115_PARSHA\\101_SipurMinHahaftara1.txt":
                    return "סיפור מן ההפטרה - בראשית";
                case "Books\\115_PARSHA\\102_SipurMinHahaftara2.txt":
                    return "סיפור מן ההפטרה - שמות";
                case "Books\\115_PARSHA\\103_SipurMinHahaftara3.txt":
                    return "סיפור מן ההפטרה - ויקרא";
                case "Books\\115_PARSHA\\104_SipurMinHahaftara4.txt":
                    return "סיפור מן ההפטרה - במדבר";
                case "Books\\115_PARSHA\\105_SipurMinHahaftara5.txt":
                    return "סיפור מן ההפטרה - דברים";
                case "Books\\115_PARSHA\\106_PneiDavid.txt":
                    return "פני דוד - על התורה";
                case "Books\\115_PARSHA\\110_dovev.txt":
                    return "דובב שפתי ישנים";
                case "Books\\115_PARSHA\\120_pninei_ynon_veeliyahu.txt":
                    return "פניני ינון ואליהו - על הפרשה";
                case "Books\\115_PARSHA\\130_maase_avot.txt":
                    return "באר יעקב - מעשי אבות - בראשית";
                case "Books\\115_PARSHA\\140_afikey.txt":
                    return "אפיקי אליהו על התורה";
                case "Books\\115_PARSHA\\150_shulchan_melachim_al_hatora.txt":
                    return "מיד מלכים - על התורה";
                case "Books\\115_PARSHA\\160_siman_levanim.txt":
                    return "סימן לבנים - שמות";
                case "Books\\115_PARSHA\\170_miyad_melachim_tora.txt":
                    return "ספר מיד מלכים - על התורה";
                case "Books\\118_HAGIM\\080_MISHPETE_L1.txt":
                    return "משפטי ישראל - על חגי ומועדי ישראל";
                case "Books\\118_HAGIM\\090_beer_yaakov_moadim.txt":
                    return "באר יעקב - מועדים";
                case "Books\\118_HAGIM\\100_arba_taaniot_naki.txt":
                    return "ארבע התעניות ובין המצרים";
                case "Books\\118_HAGIM\\101_yamim_noraiim_kaki.txt":
                    return "הימים הנוראים בהלכה ובאגדה";
                case "Books\\118_HAGIM\\102_sukot_naki.txt":
                    return "חג הסוכות בהלכה ובאגדה";
                case "Books\\118_HAGIM\\103_hanuka_naki.txt":
                    return "ימי החנוכה בהלכה ובאגדה";
                case "Books\\118_HAGIM\\104_kurim_naki.txt":
                    return "ימי הפורים בהלכה ובאגדה";
                case "Books\\118_HAGIM\\105_pesach_naki.txt":
                    return "חג הפסח בהלכה והאגדה";
                case "Books\\118_HAGIM\\106_shvuot_naki.txt":
                    return "חג השבועות בהלכה ובאגדה";
                case "Books\\118_HAGIM\\111_chemdat_yamim_1.txt":
                    return "ספר חמדת ימים - חלק א";
                case "Books\\118_HAGIM\\111_chemdat_yamim_2.txt":
                    return "ספר חמדת ימים - חלק ב";
                case "Books\\118_HAGIM\\111_chemdat_yamim_3.txt":
                    return "ספר חמדת ימים - חלק ג";
                case "Books\\118_HAGIM\\190_HAGADA_L1.txt":
                    return "הגדה של פסח - למען תספר";
                case "Books\\118_HAGIM\\191_HAGADA2.txt":
                    return "הגדה של פסח - נוסח אשכנז";
                case "Books\\118_HAGIM\\192_HagadaOrDaniel.txt":
                    return "הגדה של פסח - אור דניאל";
                case "Books\\118_HAGIM\\193_$_1002_piske_moshe_chanuka.txt":
                    return "הלכות חנוכה - פסקי משה";
                case "Books\\118_HAGIM\\200_megilat_hester.txt":
                    return "מגילת הסתר - נס בכל פסוק במגילת אסתר";
                case "Books\\118_HAGIM\\440_seder_israel.txt":
                    return "קונטרס סדר ישראל";
                case "Books\\118_HAGIM\\520_miyad_melachim_moadim.txt":
                    return "מיד מלכים - שער המועדים";
                case "Books\\118_HAGIM\\hagada_for_beit_mikdash.htm":
                    return "hagada_for_beit_mikdash.htm";
                case "Books\\120_GDOLEY_HADOROT\\100_seder_hadorot.txt":
                    return "סדר הדורות המקוצר";
                case "Books\\120_GDOLEY_HADOROT\\150_hilula.txt":
                    return "ימי הילולא דצדיקיא";
                case "Books\\120_GDOLEY_HADOROT\\200_maase_avot.txt":
                    return "ספר מעשי אבות";
                case "Books\\120_GDOLEY_HADOROT\\300_david_hamelech.txt":
                    return "דוד המלך ועוצמת התהילים";
                case "Books\\120_GDOLEY_HADOROT\\400_maroko.txt":
                    return "ספר קבלת חכמי מרוקו";
                case "Books\\120_GDOLEY_HADOROT\\500_iyov.txt":
                    return "אמונה והשגחה מספר איוב";
                case "Books\\125_SHUT\\101_NafshiBesheelati1.txt":
                    return "נפשי בשאלתי חלק א - שו''ת";
                case "Books\\125_SHUT\\101_NafshiBesheelati2.txt":
                    return "נפשי בשאלתי חלק ב - שו''ת";
                case "Books\\125_SHUT\\102_NafshiBesheelati3.txt":
                    return "נפשי בשאלתי חלק ג - שו''ת";
                case "Books\\125_SHUT\\150_YismachMoshe_L1.txt":
                    return "ישמח משה - שו''ת";
                case "Books\\125_SHUT\\190_VayaanEliyahu.txt":
                    return "ויען אליהו";
                case "Books\\125_SHUT\\220_BariachHatichon.txt":
                    return "בריח התיכון";
                case "Books\\125_SHUT\\221_MoadeiNissim.txt":
                    return "מועדי ניסים";
                case "Books\\125_SHUT\\230_ShutGamAniOdecha.txt":
                    return "שו''ת גם אני אודך - א";
                case "Books\\125_SHUT\\231_ShutGamAniOdecha2.txt":
                    return "שו''ת גם אני אודך - ב";
                case "Books\\125_SHUT\\232_ShutGamAniOdecha3.txt":
                    return "שו''ת גם אני אודך - ג";
                case "Books\\125_SHUT\\240_bechol_drachecha.txt":
                    return "שו''ת בכל דרכיך דעהו";
                case "Books\\125_SHUT\\250_ShaolShaal.txt":
                    return "שו''ת שאול שאל - חלק א";
                case "Books\\125_SHUT\\251_ShaolShaal_2.txt":
                    return "שו''ת שאול שאל - חלק ב";
                case "Books\\125_SHUT\\300_ShutNachalatLevi_1.txt":
                    return "שו''ת נחלת לוי - ח''ב";
                case "Books\\125_SHUT\\350_RavSilver1.txt":
                    return "שו''ת עם סגולה - חלק א";
                case "Books\\125_SHUT\\350_RavSilver2.txt":
                    return "שו''ת עם סגולה - חלק ב";
                case "Books\\125_SHUT\\350_RavSilver3.txt":
                    return "שו''ת עם סגולה - חלק ג";
                case "Books\\125_SHUT\\350_RavSilver4.txt":
                    return "שו''ת עם סגולה - חלק ד";
                case "Books\\130_HABITE\\700_KolHatanVkolKala.txt":
                    return "קול חתן וקול כלה";
                case "Books\\130_HABITE\\701_yavo_ezri.txt":
                    return "קונטרס יבוא עזרי";
                case "Books\\130_HABITE\\702_HAOSHER1.txt":
                    return "האושר שבנשואין - לגבר";
                case "Books\\130_HABITE\\703_HAOSHER2_L1.txt":
                    return "האושר שבנשואין - לאשה";
                case "Books\\130_HABITE\\704_hanhagot_habaite.txt":
                    return "קונטרס הנהגות הבית";
                case "Books\\130_HABITE\\705_vayelchu.txt":
                    return "וילכו שניהם יחדיו";
                case "Books\\130_HABITE\\706_HINUCH_L1.txt":
                    return "קונטרס - חינוך ילדים";
                case "Books\\130_HABITE\\707_ubeitcha_shalom.txt":
                    return "וביתך שלום";
                case "Books\\130_HABITE\\800_$_1927_sgulot_lezera_vatifkedenu.txt":
                    return "קונטרס ותפקדנו";
                case "Books\\130_HABITE\\810_OhalechaYaakov.txt":
                    return "אוהליך יעקב";
                case "Books\\130_HABITE\\820_ose_shalom.txt":
                    return "עושה שלום";
                case "Books\\130_HABITE\\830_my_son.txt":
                    return "בני בבת עיני";
                case "Books\\130_HABITE\\831_ani_vehanaar.txt":
                    return "אני והנער";
                case "Books\\130_HABITE\\832_kabalat_hatora.txt":
                    return "קונטרס קבלת התורה - אבות ובנים";
                case "Books\\140_CONTRAS\\500_KontrasLoLaavor.txt":
                    return "קונטרס - שלא לעבור כנגד המתפלל";
                case "Books\\140_CONTRAS\\501_KIDUSH_HASHEM_L1.txt":
                    return "קונטרס - המקדש שמו ברבים";
                case "Books\\140_CONTRAS\\600_derech_menucha.TXT":
                    return "דרך מנוחה - פירוש לאגרת הרמב''ן";
                case "Books\\140_CONTRAS\\720_korbanot.txt":
                    return "מעלת אמירת הקורבנות קודם שחרית";
                case "Books\\140_CONTRAS\\750_maalat_hamelamdim.txt":
                    return "קונטרס - מעלת המלמדים";
                case "Books\\140_CONTRAS\\801_KolKore.txt":
                    return "קונטרס קול קורא";
                case "Books\\140_CONTRAS\\802_lehavat_esh.txt":
                    return "להבת שלהבת קודש";
                case "Books\\140_CONTRAS\\820_beriti_shalom.txt":
                    return "קונטרס בריתי שלום";
                case "Books\\140_CONTRAS\\821_eyes.txt":
                    return "פסיכולוגיית העין";
                case "Books\\140_CONTRAS\\900_likut_kadish.txt":
                    return "קונטרס יתגדל ויתקדש";
                case "Books\\140_CONTRAS\\910_igeret_lebat.txt":
                    return "איגרת לבת ישראל היקרה";
                case "Books\\140_CONTRAS\\911_shir.txt":
                    return "אחות יקרה";
                case "Books\\140_CONTRAS\\930_zipita.txt":
                    return "מאמר צפית לישועה";
                case "Books\\140_CONTRAS\\935_levush.txt":
                    return "הלבוש והקישוט מזוית יהודית";
                case "Books\\140_CONTRAS\\936_cellular.txt":
                    return "הסלולרי מזוית יהודית";
                case "Books\\140_CONTRAS\\950_hidabek.txt":
                    return "מאמר הדבק בחכמים ובתלמידים";
                case "Books\\140_CONTRAS\\960_dor_acharon.txt":
                    return "תִּכָּתֶב זֹאת לְדוֹר אַחֲרוֹן";
                case "Books\\140_CONTRAS\\961_halevush_leor_hahalacha.txt":
                    return "הלבוש לאור ההלכה";
                case "Books\\140_CONTRAS\\962_patach_eliyahu.txt":
                    return "פירוש אור צח - על פתח אליהו";
                case "Books\\140_CONTRAS\\963_bikurei_yossef_laiver.txt":
                    return "קונטרס ביכורי יוסף - דברי הלכה ואגדה הנוגעים לעיוור";
                case "Books\\140_CONTRAS\\964_$_1927_sgulot_lezera_vatifkedenu.txt":
                    return "קונטרס ותפקדנו";
                case "Books\\140_CONTRAS\\965_ben_shtei_nashim.txt":
                    return "קונטרס בחוקותי תלכו";
                case "Books\\140_CONTRAS\\966_keri.txt":
                    return "קונטרס יקר בעיני ה'";
                case "Books\\140_CONTRAS\\967_vatekas.txt":
                    return "ותכס בצעיף";
                case "Books\\140_CONTRAS\\968_simla.txt":
                    return "קונטרס בגדי תפארתך";
                case "Books\\140_CONTRAS\\969_mishtamtim.txt":
                    return "המשתמטים";
                case "Books\\140_CONTRAS\\970_torato_omanuto.txt":
                    return "קונטרס תורתו אומנותו";
                case "Books\\140_CONTRAS\\971_the_best_doctor.txt":
                    return "קונטרס הטוב שברופאים";
                case "Books\\140_CONTRAS\\972_avoda_zara_bapea.txt":
                    return "אגלחך לשמים";
                case "Books\\145_HADERECH_LATORA\\100_tora_ve_mada1.txt":
                    return "תורה ומדע 1";
                case "Books\\145_HADERECH_LATORA\\150_scharan_shell_mitsvot.TXT":
                    return "שכרן של מצוות";
                case "Books\\145_HADERECH_LATORA\\200_ttsoar_laolam_hharedi.txt":
                    return "צוהר לארחות החרדי";
                case "Books\\145_HADERECH_LATORA\\400_LookingForTruth.txt":
                    return "מחפשים את האמת";
                case "Books\\145_HADERECH_LATORA\\410_MeNegedMe.txt":
                    return "מי נגד מי - דו שיח חרדי-חילוני";
                case "Books\\145_HADERECH_LATORA\\451_shaar_haemuna 2.txt":
                    return "שער האמונה";
                case "Books\\145_HADERECH_LATORA\\500_where_is_it.TXT":
                    return "היכן זה כתוב";
                case "Books\\145_HADERECH_LATORA\\552_hakuzari.txt":
                    return "ספר הכוזרי";
                case "Books\\145_HADERECH_LATORA\\580_BenChorin.txt":
                    return "מיהו בן חורין אמיתי";
                case "Books\\145_HADERECH_LATORA\\600_surprize.txt":
                    return "הפתעה - סיפור בעניין האבולוציה";
                case "Books\\145_HADERECH_LATORA\\601_shabat_rav_zamir.txt":
                    return "סוד השבת - אור הנשמה";
                case "Books\\145_HADERECH_LATORA\\603_OrHozer.txt":
                    return "אור חוזר";
                case "Books\\145_HADERECH_LATORA\\610_itinai_1.txt":
                    return "העיתונאי 1";
                case "Books\\145_HADERECH_LATORA\\611_itinai_2.txt":
                    return "העיתונאי 2";
                case "Books\\145_HADERECH_LATORA\\612_itinai_3.txt":
                    return "העיתונאי 3";
                case "Books\\145_HADERECH_LATORA\\613_itinai_4.txt":
                    return "העיתונאי 4";
                case "Books\\145_HADERECH_LATORA\\614_itinai_5.txt":
                    return "העיתונאי 5";
                case "Books\\145_HADERECH_LATORA\\615_itinai_6.txt":
                    return "העיתונאי 6";
                case "Books\\145_HADERECH_LATORA\\650_orot_shel_emet.txt":
                    return "אורות של אמת";
                case "Books\\145_HADERECH_LATORA\\651_hatachlit.txt":
                    return "התכלית";
                case "Books\\145_HADERECH_LATORA\\700_BANOT_MEDABROT.txt":
                    return "בנות מדברות על עצמן";
                case "Books\\145_HADERECH_LATORA\\701_NASHIM_MEDABROT.txt":
                    return "נשים מדברות על עצמן";
                case "Books\\145_HADERECH_LATORA\\702_fingers.txt":
                    return "אצבעותי למלחמה";
                case "Books\\145_HADERECH_LATORA\\710_the_3rd_power.txt":
                    return "הכוח השלישי";
                case "Books\\145_HADERECH_LATORA\\720_tachlit_hachaiim.txt":
                    return "תכלית החיים";
                case "Books\\145_HADERECH_LATORA\\730_mazleg.txt":
                    return "יהדות על קצה המזלג";
                case "Books\\145_HADERECH_LATORA\\740_hashem_nisi.txt":
                    return "ה' ניסי - ניסי ניסים";
                case "Books\\150_TFILOT_VESGULOT\\0002_sidur1.txt":
                    return "סידור תורת אמת";
                case "Books\\150_TFILOT_VESGULOT\\0002_sidur2.txt":
                    return "סידור זכר מנחם";
                case "Books\\150_TFILOT_VESGULOT\\0005_slichot.txt":
                    return "סדר סליחות והתרת נדרים";
                case "Books\\150_TFILOT_VESGULOT\\0010_Likutei_tfilot.txt":
                    return "לקט תפילות";
                case "Books\\150_TFILOT_VESGULOT\\0020_LimudLeiluiNishmat.txt":
                    return "סדר הלימוד לעילוי נשמה";
                case "Books\\150_TFILOT_VESGULOT\\0021_TikunHaclali.txt":
                    return "התיקון הכללי";
                case "Books\\150_TFILOT_VESGULOT\\0050_seder_maamadot.txt":
                    return "סדר מעמדות";
                case "Books\\150_TFILOT_VESGULOT\\0500_BeginEnd.txt":
                    return "פסוק המתחיל ומסתיים באות";
                case "Books\\150_TFILOT_VESGULOT\\0550_SgulotRavLugacy.txt":
                    return "ישראל לסגולתו";
                case "Books\\150_TFILOT_VESGULOT\\0600_KAMIA_AMITI.txt":
                    return "קמיע תורני אמיתי להצלחה כללית";
                case "Books\\150_TFILOT_VESGULOT\\0700_PirkeiShira.txt":
                    return "פרק שירה - שירת הבריאה";
                case "Books\\150_TFILOT_VESGULOT\\911_tfila_lebat.txt":
                    return "תפילה לבת ישראל";
                case "Books\\150_TFILOT_VESGULOT\\912_Tifkedenu.txt":
                    return "קונטרס ותפקדנו";
                case "Books\\150_TFILOT_VESGULOT\\913_hadran.txt":
                    return "נוסח סיום מסכת";
                case "Books\\157_HIDONIM\\HidonLashon.txt":
                    return "חידון שמירת הלשון - ע''פ ספר החפץ חיים";
                case "Books\\158_AHAVAT_ISRAEL\\050_ahavat_chesed.txt":
                    return "אהבת חסד";
                case "Books\\158_AHAVAT_ISRAEL\\100_ahavat_israel.txt":
                    return "הנהגות אהבת ישראל";
                case "Books\\158_AHAVAT_ISRAEL\\200_BarLevav.txt":
                    return "בר לבב - אהבת ישראל";
                case "Books\\158_AHAVAT_ISRAEL\\300_madrich.txt":
                    return "מדריך מעשי כיצד לדון לכף זכות";
                case "Books\\158_AHAVAT_ISRAEL\\400_veahavta.txt":
                    return "מאמר ואהבת לרעך כמוך";
                case "Books\\158_AHAVAT_ISRAEL\\500_kneset_israel.txt":
                    return "כנסת ישראל";

                case "Books\\160_MISC\\0000_for_WORD.txt":
                    return "יצור לוורד";
                case "Books\\160_MISC\\0600_nisim.txt":
                    return "סיפורי ניסים";
                case "Books\\160_MISC\\501_mavo_chemdat_yamim.txt":
                    return "ספר חמדת ימים - מבוא";
                case "Books\\160_MISC\\502_key_for_tanach.txt":
                    return "מפתח ענייני התנ''ך";
                case "Books\\160_MISC\\50_message1.txt":
                    return "הודעה";
                case "Books\\160_MISC\\51_message2.txt":
                    return "הודעה";
                case "Books\\160_MISC\\AllTora.txt":
                    return "בראשית שמות ויקרא במדבר דברים";
                case "Books\\160_MISC\\BereshitX5.txt":
                    return "בראשית בראשית בראשית בראשית בראשית";
                case "Books\\160_MISC\\BriutKahalacha.txt":
                    return "חיים בריאים כהלכה";
                case "Books\\160_MISC\\BriutKahalachaNoSigars.txt":
                    return "חיים ללא עישון";
                case "Books\\160_MISC\\PirkeiDerabiEliezer.txt":
                    return "פרקי דרבי אליעזר";
                case "Books\\160_MISC\\PirkeiDerechErets.txt":
                    return "פרקי דרך ארץ - סדר אליהו זוטא ט''ז - י''ח";
                case "Books\\160_MISC\\drashot_laavelim.txt":
                    return "דרשות לאזכרות ולבתי אבלים";
                case "Books\\170_GROUPS\\100_$_1596_shabat_kahalach.txt":
                    return "שבת כהלכה";
                case "Books\\170_GROUPS\\300_GROUP_SHABAT\\101_$_1819_shabat_bahalacha_naki.txt":
                    return "השבת בהלכה ובאגדה";
                case "Books\\170_GROUPS\\300_GROUP_SHABAT\\102_$_713_hanhagot_shabat1.txt":
                    return "הנהגות לשבת קודש - חלק א";
                case "Books\\170_GROUPS\\300_GROUP_SHABAT\\103_$_1783_hanhagot_shabat2.txt":
                    return "הנהגות לשבת קודש - חלק ב";
                case "Books\\170_GROUPS\\300_GROUP_SHABAT\\104_$_1830_chemdat_yamim_shabat.txt":
                    return "ספר חמדת ימים - חלק א - שבת";
                case "Books\\170_GROUPS\\301_GROUP_TAHARA":
                    return "הטהרה בהלכה ובאגדה";
                case "Books\\170_GROUPS\\301_GROUP_TAHARA\\101_$_1595_tahara_herayon_veleda.txt":
                    return "טהרה הריון ולידה כהלכה";
                case "Books\\170_GROUPS\\301_GROUP_TAHARA\\102_$_1105_shaar_hazahav_latahara.txt":
                    return "שער הזהב לטהרה";
                case "Books\\170_GROUPS\\301_GROUP_TAHARA\\103_$_1791_nesuin_veishut.txt":
                    return "נשואין ואישות";
                case "Books\\170_GROUPS\\301_GROUP_TAHARA\\104_$_1044_yore_dea_tahara.txt":
                    return "שלחן ערוך - יורה דעה - הלכות טהרה";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT":
                    return "ספר גדר עולם";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\100_$_1594_marot_tsovot_2.txt":
                    return "מראות הצובאות";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\101_$_1818_halevush_leor_hahalacha.txt":
                    return "הלבוש לאור ההלכה";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\102_$_1798_igeret_lebat_israel.txt":
                    return "אגרת לבת ישראל היקרה";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\103_$_1012_anshei_kodesh.txt":
                    return "אנשי קודש";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\103_$_1784_machanecha_kadosh.txt":
                    return "ספר מחניך קדוש";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\103_$_1789_kol__kore.txt":
                    return "קונטרס קול קורא";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\104_$_1682_lahevet_shalhevet.txt":
                    return "להבת שלהבת קודש";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\105_$_1941_vaterkas.txt":
                    return "ותכס בצעיף";


                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\108_$_2541_banot.txt":
                    return "בנות מדברות על עצמן";

                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\120_tevorach_menashim.txt":
                    return "תבורך מנשים";
                case "Books\\170_GROUPS\\303_GROUP_KASHRUT":
                    return "כשרות המטבח";
                case "Books\\170_GROUPS\\303_GROUP_KASHRUT\\001_$_1677_kedoshim_tihiyu.txt":
                    return "הלכות תולעים - קדושים תהיו";
                case "Books\\170_GROUPS\\303_GROUP_KASHRUT\\002_$_1599_tvilat_kelim.txt":
                    return "הלכות טבילת כלים";
                case "Books\\170_GROUPS\\303_GROUP_KASHRUT\\003_$_1598_bishulei_goiim.txt":
                    return "הלכות פת ובישולי גוים - פתבג המלך";
                case "Books\\170_GROUPS\\303_GROUP_KASHRUT\\004_$_1897_hagaalat_kelim.txt":
                    return "הלכות הגעלת כלים לפסח - פסקי משה";
                case "Books\\400_NOTES\\0700_notes.txt":
                    return "פנקס ההערות שלי - 1";
                case "Books\\400_NOTES\\0701_notes.txt":
                    return "פנקס ההערות שלי - 2";
                case "Books\\400_NOTES\\0702_notes.txt":
                    return "פנקס ההערות שלי - 3";
                case "Books\\400_NOTES\\0703_notes.txt":
                    return "פנקס ההערות שלי - 4";
                case "Books\\400_NOTES\\0704_notes.txt":
                    return "פנקס ההערות שלי - 5";
                case "Books\\400_NOTES\\0705_notes.txt":
                    return "פנקס ההערות שלי - 6";
                case "Books\\400_NOTES\\0706_notes.txt":
                    return "פנקס ההערות שלי - 7";
                case "Books\\400_NOTES\\0707_notes.txt":
                    return "פנקס ההערות שלי - 8";
                case "Books\\400_NOTES\\0708_notes.txt":
                    return "פנקס ההערות שלי - 9";
                case "Books\\400_NOTES\\0709_notes.txt":
                    return "פנקס ההערות שלי - 10";
                case "Books\\400_NOTES\\0710_notes.txt":
                    return "פנקס ההערות שלי - 11";
                case "Books\\400_NOTES\\0711_notes.txt":
                    return "פנקס ההערות שלי - 12";
                case "Books\\400_NOTES\\0712_notes.txt":
                    return "פנקס ההערות שלי - 13";
                case "Books\\400_NOTES\\0713_notes.txt":
                    return "פנקס ההערות שלי - 14";
                case "Books\\400_NOTES\\0714_notes.txt":
                    return "פנקס ההערות שלי - 15";
                case "Books\\400_NOTES\\0715_notes.txt":
                    return "פנקס ההערות שלי - 16";
                case "Books\\400_NOTES\\0716_notes.txt":
                    return "פנקס ההערות שלי - 17";
                case "Books\\400_NOTES\\0717_notes.txt":
                    return "פנקס ההערות שלי - 18";
                case "Books\\400_NOTES\\0718_notes.txt":
                    return "פנקס ההערות שלי - 19";
                case "Books\\400_NOTES\\0719_notes.txt":
                    return "פנקס ההערות שלי - 20";
                case "Books\\042_HALACHA2\\107_KitsurHafetsHaim.txt":
                    return "קיצור הלכות שמירת הלשון - מבוסס על ספר החפץ חיים";
                case "Books\\042_HALACHA2\\443_midot4.txt":
                    return "שלחן ערוך המדות - קונטרס אונאת דברים";
                case "Books\\100_MUSAR\\612_yitgaber_kaari.txt":
                    return "יתגבר כארי";
                case "Books\\500_MY_BOOKS":
                    return "dummy_dont_remove.text";


                case "Books\\106_KABALA\\000020_ZOHAR0-hakdama_L1.txt":
                    return "הקדמת הזוהר";                
                case "Books\\110_CHASIDUT\\045_taniya_1.txt":
                    return "ליקוטי אמרים תניא";
                case "Books\\112_HANHAGOT\\075_ANSHEI KODESH_L1.txt":
                    return "אנשי קודש";
                case "Books\\115_PARSHA\\180_AvodaShebaleveVaikra.txt":
                    return "עבודה שבלב ויקרא";
                case "Books\\115_PARSHA\\181_MaagalHachaiimVaikra.txt":
                    return "מעגל החיים - ויקרא";
                case "Books\\125_SHUT\\100_NafshiBesheelati1.txt":
                    return "נפשי בשאלתי";
                case "Books\\125_SHUT\\253_ShaolShaal_3.txt":
                    return "שו\"ת שאול שאל - חלק ג";
                case "Books\\125_SHUT\\253_ShaolShaal_4.txt":
                    return "שו\"ת שאול שאל - חלק ד";
                case "Books\\150_TFILOT_VESGULOT\\0001_sidur.txt":
                    return "סידור תורת אמת - ספרדים ועדות המזרח";
                case "Books\\160_MISC\\0000_TESTS.txt":
                    return "מבחנים";
                case "Books\\170_GROUPS\\300_GROUP_SHABAT\\100_$_1596_shabat_kahalach.txt":
                    return "שבת כהלכה";
                case "Books\\170_GROUPS\\301_GROUP_TAHARA\\100_$_1826_tahara_naki.txt":
                    return "הטהרה בהלכה ובאגדה";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\099_$_2539_geder_olam.txt":
                    return "גדר עולם";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\106_$_1943_bigdei_tifartech.txt":
                    return "בגדי תפארתך";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\107_$_1942_shir.txt":
                    return "שיר - אחות יקרה";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\109_$_5100_nashim_medabrot.txt":
                    return "נשים מדברות על עצמן";
                case "Books\\170_GROUPS\\302_GROUP_TSNIUT\\110_$_5097_avoda_zara_pea.txt":
                    return "אגלחך לשמים - תקרובת ע''ז בפאות";
                case "Books\\170_GROUPS\\303_GROUP_KASHRUT\\000_$_1822_kashrut.txt":
                    return "כשרות המטבח";




                // Add more cases for each translation
                default:
                    return originalFilename; // Return original filename if no translation found
            }
        }

        public static string TranslateFilenameToPath(string originalFilename)
        {
            // Replicate the VBA translation logic using C# switch statements
            switch (originalFilename)
            {
                case "0011_!help.htm":
                    return "Books\\000_ACCESORIES\\0011_!help.htm";
                case "הלימוד היומי":
                    return "Books\\000_ACCESORIES\\0012_daily.txt";
                case "מידע יומי":
                    return "Books\\000_ACCESORIES\\0013_daily_info.txt";
                case "תוכן עניינים מותאם אישית":
                    return "Books\\000_ACCESORIES\\0014_contents.txt";
                case "מעקב לימוד":
                    return "Books\\000_ACCESORIES\\0015_stat.txt";
                case "מארי דחושבנא":
                    return "Books\\000_ACCESORIES\\0016_mare.txt";
                case "טור - אורח חיים":
                    return "Books\\000_HORADOT\\100_TUR\\010_tur_orach_chaim_merged.txt";
                case "טור - יורה דעה":
                    return "Books\\000_HORADOT\\100_TUR\\011_tur_yore_deaa_merged.txt";
                case "טור - אבן העזר":
                    return "Books\\000_HORADOT\\100_TUR\\012_tur_even_haezer_merged.txt";
                case "טור - חשן משפט":
                    return "Books\\000_HORADOT\\100_TUR\\013_tur_choshen_mishpat_merged.txt";
                case "טור - אורח חיים - טור":
                    return "Books\\000_HORADOT\\100_TUR\\100_tur_orach_chaiim_tur.txt";
                case "טור - אורח חיים - בית יוסף":
                    return "Books\\000_HORADOT\\100_TUR\\101_tur_orach_chaiim_beit_yosef.txt";
                case "טור - אורח חיים - בית חדש":
                    return "Books\\000_HORADOT\\100_TUR\\102_tur_orach_chaiim_bach.txt";
                case "טור - אורח חיים - דרכי משה":
                    return "Books\\000_HORADOT\\100_TUR\\103_tur_orach_chaiim_darkei_moshe.txt";
                case "טור - אורח חיים - דרישה":
                    return "Books\\000_HORADOT\\100_TUR\\104_tur_orach_chaiim_drisha.txt";
                case "טור - אורח חיים - פרישה":
                    return "Books\\000_HORADOT\\100_TUR\\105_tur_orach_chaiim_prisha.txt";
                case "טור - אורח חיים - חידושי הגהות":
                    return "Books\\000_HORADOT\\100_TUR\\106_tur_orach_chaiim_hagahot.txt";
                case "טור - אורח חיים - הערות":
                    return "Books\\000_HORADOT\\100_TUR\\107_tur_orach_chaiim_notes.txt";
                case "טור - יורה דעה - טור":
                    return "Books\\000_HORADOT\\100_TUR\\120_tur_yore_dea_tur.txt";
                case "טור - יורה דעה - בית יוסף":
                    return "Books\\000_HORADOT\\100_TUR\\121_tur_yore_dea_beit_yosef.txt";
                case "טור - יורה דעה - בית חדש":
                    return "Books\\000_HORADOT\\100_TUR\\122_tur_yore_dea_bach.txt";
                case "טור - יורה דעה - דרכי משה":
                    return "Books\\000_HORADOT\\100_TUR\\123_tur_yore_dea_darkei_moshe.txt";
                case "טור - יורה דעה - דרישה":
                    return "Books\\000_HORADOT\\100_TUR\\124_tur_yore_dea_drisha.txt";
                case "טור - יורה דעה - פרישה":
                    return "Books\\000_HORADOT\\100_TUR\\125_tur_yore_dea_prisha.txt";
                case "טור - יורה דעה - חידושי הגהות":
                    return "Books\\000_HORADOT\\100_TUR\\126_tur_yore_dea_hagahot.txt";
                case "טור - יורה דעה - הערות":
                    return "Books\\000_HORADOT\\100_TUR\\127_tur_yore_dea_notes.txt";
                case "טור - אבן העזר - טור":
                    return "Books\\000_HORADOT\\100_TUR\\140_tur_even_haezer_tur.txt";
                case "טור - אבן העזר - בית יוסף":
                    return "Books\\000_HORADOT\\100_TUR\\141_tur_even_haezer_beit_yosef.txt";
                case "טור - אבן העזר - בית חדש":
                    return "Books\\000_HORADOT\\100_TUR\\142_tur_even_haezer_bach.txt";
                case "טור - אבן העזר - דרכי משה":
                    return "Books\\000_HORADOT\\100_TUR\\143_tur_even_haezer_darkei_moshe.txt";
                case "טור - אבן העזר - דרישה":
                    return "Books\\000_HORADOT\\100_TUR\\144_tur_even_haezer_drisha.txt";
                case "טור - אבן העזר - פרישה":
                    return "Books\\000_HORADOT\\100_TUR\\145_tur_even_haezer_prisha.txt";
                case "טור - אבן העזר - חידושי הגהות":
                    return "Books\\000_HORADOT\\100_TUR\\146_tur_even_haezer_hagahot.txt";
                case "טור - אבן העזר - הערות":
                    return "Books\\000_HORADOT\\100_TUR\\147_tur_even_haezer_notes.txt";
                case "טור - חושן משפט - טור":
                    return "Books\\000_HORADOT\\100_TUR\\160_tur_choshen_mishpat_tur.txt";
                case "טור - חושן משפט - בית יוסף":
                    return "Books\\000_HORADOT\\100_TUR\\161_tur_choshen_mishpat_beit_yosef.txt";
                case "טור - חושן משפט - בית חדש":
                    return "Books\\000_HORADOT\\100_TUR\\162_tur_choshen_mishpat_bach.txt";
                case "טור - חושן משפט - דרכי משה":
                    return "Books\\000_HORADOT\\100_TUR\\163_tur_choshen_mishpat_darkei_moshe.txt";
                case "טור - חושן משפט - דרישה":
                    return "Books\\000_HORADOT\\100_TUR\\164_tur_choshen_mishpat_drisha.txt";
                case "טור - חושן משפט - פרישה":
                    return "Books\\000_HORADOT\\100_TUR\\165_tur_choshen_mishpat_prisha.txt";
                case "טור - חושן משפט - חידושי הגהות":
                    return "Books\\000_HORADOT\\100_TUR\\166_tur_choshen_mishpat_hagahot.txt";
                case "טור - חושן משפט - הערות":
                    return "Books\\000_HORADOT\\100_TUR\\167_tur_choshen_mishpat_notes.txt";
                case "בן איש חי":
                    return "Books\\000_HORADOT\\200_PARSHA\\050_ben_ish_chai.txt";
                case "dummy.dat":
                    return "Books\\000_HORADOT\\200_PARSHA\\dummy.dat";
                case "ילקוט שמעוני - בראשית ":
                    return "Books\\000_HORADOT\\250_SHIMONI";
                case "ילקוט שמעוני - שמות ":
                    return "Books\\000_HORADOT\\250_SHIMONI\\002_shimoni_shemot.txt";
                case "ילקוט שמעוני - ויקרא ":
                    return "Books\\000_HORADOT\\250_SHIMONI\\003_shimoni_vaikra.txt";
                case "ילקוט שמעוני - במדבר ":
                    return "Books\\000_HORADOT\\250_SHIMONI\\004_shimoni_bamidbar.txt";
                case "ילקוט שמעוני - דברים ":
                    return "Books\\000_HORADOT\\250_SHIMONI\\005_shimoni_devarim.txt";
                case "ילקוט שמעוני - יהושע":
                    return "Books\\000_HORADOT\\250_SHIMONI\\006_shimoni_yehoshua.txt";
                case "ילקוט שמעוני - שופטים":
                    return "Books\\000_HORADOT\\250_SHIMONI\\007_shimoni_shofetim.txt";
                case "ילקוט שמעוני - שמואל א":
                    return "Books\\000_HORADOT\\250_SHIMONI\\008_shimoni_shmuel_a.txt";
                case "ילקוט שמעוני - שמואל ב":
                    return "Books\\000_HORADOT\\250_SHIMONI\\009_shimoni_shmuel_b.txt";
                case "ילקוט שמעוני - מלכים א":
                    return "Books\\000_HORADOT\\250_SHIMONI\\010_shimoni_melachim_a.txt";
                case "ילקוט שמעוני - מלכים ב":
                    return "Books\\000_HORADOT\\250_SHIMONI\\011_shimoni_melachim_b.txt";
                case "ילקוט שמעוני - ישעיה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\012_shimoni_yishaya.txt";
                case "ילקוט שמעוני - ירמיה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\013_shimoni_yermiya.txt";
                case "ילקוט שמעוני - יחזקאל":
                    return "Books\\000_HORADOT\\250_SHIMONI\\014_shimoni_yechezkel.txt";
                case "ילקוט שמעוני - הושע":
                    return "Books\\000_HORADOT\\250_SHIMONI\\015_shimoni_hoshea.txt";
                case "ילקוט שמעוני - יואל":
                    return "Books\\000_HORADOT\\250_SHIMONI\\016_shimoni_yoel.txt";
                case "ילקוט שמעוני - עמוס":
                    return "Books\\000_HORADOT\\250_SHIMONI\\017_shimoni_amos.txt";
                case "ילקוט שמעוני - עובדיה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\018_shimoni_ovadya.txt";
                case "ילקוט שמעוני - יונה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\019_shimoni_yona.txt";
                case "ילקוט שמעוני - מיכה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\020_shimoni_micha.txt";
                case "ילקוט שמעוני - נחום":
                    return "Books\\000_HORADOT\\250_SHIMONI\\021_shimoni_nachum.txt";
                case "ילקוט שמעוני - חבקוק":
                    return "Books\\000_HORADOT\\250_SHIMONI\\022_shimoni_havakuk.txt";
                case "ילקוט שמעוני - צפניה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\023_shimoni_zefanya.txt";
                case "ילקוט שמעוני - חגי":
                    return "Books\\000_HORADOT\\250_SHIMONI\\024_shimoni_hagay.txt";
                case "ילקוט שמעוני - זכריה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\025_shimoni_zecharya.txt";
                case "ילקוט שמעוני - מלאכי":
                    return "Books\\000_HORADOT\\250_SHIMONI\\026_shimoni_malachi.txt";
                case "ילקוט שמעוני - תהילים":
                    return "Books\\000_HORADOT\\250_SHIMONI\\027_shimoni_tehilim.txt";
                case "ילקוט שמעוני - משלי":
                    return "Books\\000_HORADOT\\250_SHIMONI\\028_shimoni_mishley.txt";
                case "ילקוט שמעוני - איוב":
                    return "Books\\000_HORADOT\\250_SHIMONI\\029_shimoni_iyov.txt";
                case "ילקוט שמעוני - שיר השירים":
                    return "Books\\000_HORADOT\\250_SHIMONI\\030_shimoni_shir_hashirim.txt";
                case "ילקוט שמעוני - רות":
                    return "Books\\000_HORADOT\\250_SHIMONI\\031_shimoni_ruth.txt";
                case "ילקוט שמעוני - איכה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\032_shimoni_eicha.txt";
                case "ילקוט שמעוני - קהלת":
                    return "Books\\000_HORADOT\\250_SHIMONI\\033_shimoni_kohelet.txt";
                case "ילקוט שמעוני - אסתר":
                    return "Books\\000_HORADOT\\250_SHIMONI\\034_shimoni_ester.txt";
                case "ילקוט שמעוני - דניאל":
                    return "Books\\000_HORADOT\\250_SHIMONI\\035_shimoni_daniel.txt";
                case "ילקוט שמעוני - עזרא":
                    return "Books\\000_HORADOT\\250_SHIMONI\\036_shimoni_ezra.txt";
                case "ילקוט שמעוני - נחמיה":
                    return "Books\\000_HORADOT\\250_SHIMONI\\037_shimoni_nechemya.txt";
                case "ילקוט שמעוני - דברי הימים א":
                    return "Books\\000_HORADOT\\250_SHIMONI\\038_shimoni_divrei_a.txt";
                case "ילקוט שמעוני - דברי הימים ב":
                    return "Books\\000_HORADOT\\250_SHIMONI\\039_shimoni_divrei_b.txt";
                //case "dummy.dat":
                //    return "Books\\000_HORADOT\\250_SHIMONI\\dummy.dat";
                case "בראשית - עם טעמים":
                    return "Books\\001_TORA\\01_BERESHIT\\a01__Genesis.txt";
                case "בראשית - עם ניקוד":
                    return "Books\\001_TORA\\01_BERESHIT\\a01_Genesis.txt";

                case "בראשית - ללא ניקוד":
                    return "Books\\001_TORA\\01_BERESHIT\\b01_Genesis.txt";
                case "בראשית - רש''י":
                    return "Books\\001_TORA\\01_BERESHIT\\c_RASHI_BERESHIT_L1.txt";
                case "בראשית - רש''י (ב)":
                    return "Books\\001_TORA\\01_BERESHIT\\c_RASHI_BERESHIT_OLD.txt";
                case "בראשית - שפתי חכמים":
                    return "Books\\001_TORA\\01_BERESHIT\\c_siftei_1.txt";
                case "בראשית - רמב''ן":
                    return "Books\\001_TORA\\01_BERESHIT\\d_ramban_bereshit.txt";
                case "בראשית - תרגום יונתן":
                    return "Books\\001_TORA\\01_BERESHIT\\e01_Genesis.txt";
                case "בראשית - אור החיים":
                    return "Books\\001_TORA\\01_BERESHIT\\f_OrHachaim.txt";
                case "בראשית - אבן עזרא":
                    return "Books\\001_TORA\\01_BERESHIT\\g_EbenEzra.txt";
                case "בראשית - בעל הטורים":
                    return "Books\\001_TORA\\01_BERESHIT\\h_BaalHaturim.txt";
                case "בראשית - תרגום אונקלוס":
                    return "Books\\001_TORA\\01_BERESHIT\\i_onqelus.txt";
                case "בראשית - ספורנו":
                    return "Books\\001_TORA\\01_BERESHIT\\j_sforno.txt";
                case "בראשית - כלי יקר":
                    return "Books\\001_TORA\\01_BERESHIT\\k_keli_yakar1.txt";
                case "בראשית - דעת זקנים":
                    return "Books\\001_TORA\\01_BERESHIT\\m_daatzkenim1.txt";
                case "מדרש רבה - חומש בראשית":
                    return "Books\\001_TORA\\01_BERESHIT\\w_raba1.txt";
                case "מדרש תנחומא - בראשית":
                    return "Books\\001_TORA\\01_BERESHIT\\w_tanchuma1.txt";
                case "ילקוט שמעוני - בראשית":
                    return "Books\\001_TORA\\01_BERESHIT\\w_ts_shimoni_bereshit.txt";
                case "בראשית - רש''י ושפתי חכמים":
                    return "Books\\001_TORA\\01_BERESHIT\\x2_Interleave.txt";
                case "בראשית - מקרא ותרגום":
                    return "Books\\001_TORA\\01_BERESHIT\\x_Interleave.txt";
                case "בראשית - מקרא ותרגום (ט)":
                    return "Books\\001_TORA\\01_BERESHIT\\x_Interleave2.txt";
                case "חק לישראל - בראשית":
                    return "Books\\001_TORA\\01_BERESHIT\\y_hok10.txt";
                case "חק לישראל - בראשית  (ט)":
                    return "Books\\001_TORA\\01_BERESHIT\\y_hok11.txt";
                case "בראשית":
                    return "Books\\001_TORA\\01_BERESHIT\\z_Interleave.txt";
                case "בראשית (ט)":
                    return "Books\\001_TORA\\01_BERESHIT\\z_Interleave2.txt";
                case "שמות  -עם טעמים":
                    return "Books\\001_TORA\\02_SHEMOT\\a02__Exodus.txt";
                case "שמות  -עם ניקוד":
                    return "Books\\001_TORA\\02_SHEMOT\\a02_Exodus.txt";

                case "שמות  - ללא ניקוד":
                    return "Books\\001_TORA\\02_SHEMOT\\b02_Exodus.txt";
                case "שמות - רש''י":
                    return "Books\\001_TORA\\02_SHEMOT\\c_RASHI_SHEMOT_L1.txt";
                case "שמות - רש''י (ב)":
                    return "Books\\001_TORA\\02_SHEMOT\\c_RASHI_SHEMOT_OLD.txt";
                case "שמות - שפתי חכמים":
                    return "Books\\001_TORA\\02_SHEMOT\\c_siftei_2.txt";
                case "שמות - רמב''ן":
                    return "Books\\001_TORA\\02_SHEMOT\\d_ramban_shemot.txt";
                case "שמות - תרגום יונתן":
                    return "Books\\001_TORA\\02_SHEMOT\\e02_Exodus.txt";
                case "שמות - אור החיים":
                    return "Books\\001_TORA\\02_SHEMOT\\f_OrHachaim.txt";
                case "שמות - אבן עזרא":
                    return "Books\\001_TORA\\02_SHEMOT\\g_EbenEzra.txt";
                case "שמות - בעל הטורים":
                    return "Books\\001_TORA\\02_SHEMOT\\h_BaalHaturim.txt";
                case "שמות - תרגום אונקלוס":
                    return "Books\\001_TORA\\02_SHEMOT\\i_onqelus.txt";
                case "שמות - ספורנו":
                    return "Books\\001_TORA\\02_SHEMOT\\j_sforno.txt";
                case "שמות - כלי יקר":
                    return "Books\\001_TORA\\02_SHEMOT\\k_keli_yakar2.txt";
                case "שמות - דעת זקנים":
                    return "Books\\001_TORA\\02_SHEMOT\\m_daatzkenim2.txt";
                case "מדרש רבה - חומש שמות":
                    return "Books\\001_TORA\\02_SHEMOT\\w_raba2.txt";
                case "מדרש תנחומא - שמות":
                    return "Books\\001_TORA\\02_SHEMOT\\w_tanchuma2.txt";
                case "ילקוט שמעוני - שמות":
                    return "Books\\001_TORA\\02_SHEMOT\\w_ts_shimoni_shemot.txt";
                case "שמות - רש''י ושפתי חכמים":
                    return "Books\\001_TORA\\02_SHEMOT\\x2_Interleave.txt";
                case "שמות - מקרא ותרגום":
                    return "Books\\001_TORA\\02_SHEMOT\\x_Interleave.txt";
                case "שמות - מקרא ותרגום (ט)":
                    return "Books\\001_TORA\\02_SHEMOT\\x_Interleave2.txt";
                case "חק לישראל - שמות":
                    return "Books\\001_TORA\\02_SHEMOT\\y_hok20.txt";
                case "חק לישראל - שמות  (ט)":
                    return "Books\\001_TORA\\02_SHEMOT\\y_hok21.txt";
                case "שמות":
                    return "Books\\001_TORA\\02_SHEMOT\\z_Interleave.txt";
                case "שמות (ט)":
                    return "Books\\001_TORA\\02_SHEMOT\\z_Interleave2.txt";
                case "ויקרא - עם טעמים":
                    return "Books\\001_TORA\\03_VAIKRA\\a03__Leviticus.txt";
                case "ויקרא - עם ניקוד":
                    return "Books\\001_TORA\\03_VAIKRA\\a03_Leviticus.txt";

                case "ויקרא  - ללא ניקוד":
                    return "Books\\001_TORA\\03_VAIKRA\\b03_Leviticus.txt";
                case "ויקרא - רש''י":
                    return "Books\\001_TORA\\03_VAIKRA\\c_RASHI_VAYIKRA_L1.txt";
                case "ויקרא - רש''י (ב)":
                    return "Books\\001_TORA\\03_VAIKRA\\c_RASHI_VAYIKRA_OLD.txt";
                case "ויקרא - שפתי חכמים":
                    return "Books\\001_TORA\\03_VAIKRA\\c_siftei_3.txt";
                case "ויקרא - רמב''ן":
                    return "Books\\001_TORA\\03_VAIKRA\\d_ramban_vayikra.txt";
                case "ויקרא - תרגום יונתן":
                    return "Books\\001_TORA\\03_VAIKRA\\e03_Leviticus.txt";
                case "ויקרא אור החיים":
                    return "Books\\001_TORA\\03_VAIKRA\\f_OrHachaim.txt";
                case "ויקרא - אבן עזרא":
                    return "Books\\001_TORA\\03_VAIKRA\\g_EbenEzra.txt";
                case "ויקרא - בעל הטורים":
                    return "Books\\001_TORA\\03_VAIKRA\\h_BaalHaturim.txt";
                case "ויקרא - תרגום אונקלוס":
                    return "Books\\001_TORA\\03_VAIKRA\\i_onqelus.txt";
                case "ויקרא - ספורנו":
                    return "Books\\001_TORA\\03_VAIKRA\\j_sforno.txt";
                case "ויקרא - כלי יקר":
                    return "Books\\001_TORA\\03_VAIKRA\\k_keli_yakar3.txt";
                case "ויקרא - דעת זקנים":
                    return "Books\\001_TORA\\03_VAIKRA\\m_daatzkenim3.txt";
                case "מדרש רבה - חומש ויקרא":
                    return "Books\\001_TORA\\03_VAIKRA\\w_raba3.txt";
                case "מדרש תנחומא - ויקרא":
                    return "Books\\001_TORA\\03_VAIKRA\\w_tanchuma3.txt";
                case "ילקוט שמעוני - ויקרא":
                    return "Books\\001_TORA\\03_VAIKRA\\w_ts_shimoni_vayikra.txt";
                case "ויקרא - רש''י ושפתי חכמים":
                    return "Books\\001_TORA\\03_VAIKRA\\x2_Interleave.txt";
                case "ויקרא - מקרא ותרגום":
                    return "Books\\001_TORA\\03_VAIKRA\\x_Interleave.txt";
                case "ויקרא - מקרא ותרגום (ט)":
                    return "Books\\001_TORA\\03_VAIKRA\\x_Interleave2.txt";
                case "חק לישראל - ויקרא":
                    return "Books\\001_TORA\\03_VAIKRA\\y_hok30.txt";
                case "חק לישראל - ויקרא  (ט)":
                    return "Books\\001_TORA\\03_VAIKRA\\y_hok31.txt";
                case "ויקרא":
                    return "Books\\001_TORA\\03_VAIKRA\\z_Interleave.txt";
                case "ויקרא (ט)":
                    return "Books\\001_TORA\\03_VAIKRA\\z_Interleave2.txt";

                case "במדבר - עם טעמים":
                    return "Books\\001_TORA\\04_BAMIDBAR\\a04__Numbers.txt";
                case "במדבר - עם ניקוד":
                    return "Books\\001_TORA\\04_BAMIDBAR\\a04_Numbers.txt";

                case "במדבר - ללא ניקוד":
                    return "Books\\001_TORA\\04_BAMIDBAR\\b04_Numbers.txt";
                case "במדבר - רש''י":
                    return "Books\\001_TORA\\04_BAMIDBAR\\c_RASHI_BAMIDBAR_L1.txt";
                case "במדבר - רש''י (ב)":
                    return "Books\\001_TORA\\04_BAMIDBAR\\c_RASHI_BAMIDBAR_OLD.txt";
                case "במדבר - שפתי חכמים":
                    return "Books\\001_TORA\\04_BAMIDBAR\\c_siftei_4.txt";
                case "במדבר - רמב''ן":
                    return "Books\\001_TORA\\04_BAMIDBAR\\d_ramban_bamidbar.txt";
                case "במדבר - תרגום יונתן":
                    return "Books\\001_TORA\\04_BAMIDBAR\\e04_Numbers.txt";
                case "במדבר אור החיים":
                    return "Books\\001_TORA\\04_BAMIDBAR\\f_OrHachaim.txt";
                case "במדבר - אבן עזרא":
                    return "Books\\001_TORA\\04_BAMIDBAR\\g_EbenEzra.txt";
                case "במדבר - בעל הטורים":
                    return "Books\\001_TORA\\04_BAMIDBAR\\h_BaalHaturim.txt";
                case "במדבר - תרגום אונקלוס":
                    return "Books\\001_TORA\\04_BAMIDBAR\\i_onqelus.txt";
                case "במדבר - ספורנו":
                    return "Books\\001_TORA\\04_BAMIDBAR\\j_sforno.txt";
                case "במדבר - כלי יקר":
                    return "Books\\001_TORA\\04_BAMIDBAR\\k_keli_yakar4.txt";
                case "במדבר - דעת זקנים":
                    return "Books\\001_TORA\\04_BAMIDBAR\\m_daatzkenim4.txt";
                case "מדרש רבה - חומש במדבר":
                    return "Books\\001_TORA\\04_BAMIDBAR\\w_raba4.txt";
                case "מדרש תנחומא - במדבר":
                    return "Books\\001_TORA\\04_BAMIDBAR\\w_tanchuma4.txt";
                case "ילקוט שמעוני - במדבר":
                    return "Books\\001_TORA\\04_BAMIDBAR\\w_ts_shimoni_bamidbar.txt";
                case "במדבר - רש''י ושפתי חכמים":
                    return "Books\\001_TORA\\04_BAMIDBAR\\x2_Interleave.txt";
                case "במדבר - מקרא ותרגום":
                    return "Books\\001_TORA\\04_BAMIDBAR\\x_Interleave.txt";
                case "במדבר - מקרא ותרגום (ט)":
                    return "Books\\001_TORA\\04_BAMIDBAR\\x_Interleave2.txt";
                case "חק לישראל - במדבר":
                    return "Books\\001_TORA\\04_BAMIDBAR\\y_hok40.txt";
                case "חק לישראל - במדבר  (ט)":
                    return "Books\\001_TORA\\04_BAMIDBAR\\y_hok41.txt";
                case "במדבר":
                    return "Books\\001_TORA\\04_BAMIDBAR\\z_Interleave.txt";
                case "במדבר (ט)":
                    return "Books\\001_TORA\\04_BAMIDBAR\\z_Interleave2.txt";
                case "דברים - עם טעמים":
                    return "Books\\001_TORA\\05_DEVARIM\\a05__Deuteronomy.txt";
                case "דברים - עם ניקוד":
                    return "Books\\001_TORA\\05_DEVARIM\\a05_Deuteronomy.txt";

                case "דברים - ללא ניקוד":
                    return "Books\\001_TORA\\05_DEVARIM\\b05_Deuteronomy.txt";
                case "דברים - רש''י":
                    return "Books\\001_TORA\\05_DEVARIM\\c_RASHI_DVARIM_L1.txt";
                case "דברים - רש''י (ב)":
                    return "Books\\001_TORA\\05_DEVARIM\\c_RASHI_DVARIM_OLD.txt";
                case "דברים - שפתי חכמים":
                    return "Books\\001_TORA\\05_DEVARIM\\c_siftei_5.txt";
                case "דברים - רמב''ן":
                    return "Books\\001_TORA\\05_DEVARIM\\d_ramban_dvarim.txt";
                case "דברים - תרגום יונתן":
                    return "Books\\001_TORA\\05_DEVARIM\\e05_Deuteronomy.txt";
                case "דברים אור החיים":
                    return "Books\\001_TORA\\05_DEVARIM\\f_OrHachaim.txt";
                case "דברים - אבן עזרא":
                    return "Books\\001_TORA\\05_DEVARIM\\g_EbenEzra.txt";
                case "דברים - בעל הטורים":
                    return "Books\\001_TORA\\05_DEVARIM\\h_BaalHaturim.txt";
                case "דברים - תרגום אונקלוס":
                    return "Books\\001_TORA\\05_DEVARIM\\i_onqelus.txt";
                case "דברים - ספורנו":
                    return "Books\\001_TORA\\05_DEVARIM\\j_sforno.txt";
                case "דברים - כלי יקר":
                    return "Books\\001_TORA\\05_DEVARIM\\k_keli_yakar5.txt";
                case "דברים - דעת זקנים":
                    return "Books\\001_TORA\\05_DEVARIM\\m_daatzkenim5.txt";
                case "מדרש רבה - חומש דברים":
                    return "Books\\001_TORA\\05_DEVARIM\\w_raba5.txt";
                case "מדרש תנחומא - דברים":
                    return "Books\\001_TORA\\05_DEVARIM\\w_tanchuma5.txt";
                case "ילקוט שמעוני - דברים":
                    return "Books\\001_TORA\\05_DEVARIM\\w_ts_shimoni_devarim.txt";
                case "דברים - רש''י ושפתי חכמים":
                    return "Books\\001_TORA\\05_DEVARIM\\x2_Interleave.txt";
                case "דברים - מקרא ותרגום":
                    return "Books\\001_TORA\\05_DEVARIM\\x_Interleave.txt";
                case "דברים - מקרא ותרגום (ט)":
                    return "Books\\001_TORA\\05_DEVARIM\\x_Interleave2.txt";
                case "חק לישראל - דברים":
                    return "Books\\001_TORA\\05_DEVARIM\\y_hok50.txt";
                case "חק לישראל - דברים  (ט)":
                    return "Books\\001_TORA\\05_DEVARIM\\y_hok51.txt";
                case "דברים":
                    return "Books\\001_TORA\\05_DEVARIM\\z_Interleave.txt";
                case "דברים (ט)":
                    return "Books\\001_TORA\\05_DEVARIM\\z_Interleave2.txt";

                case "יהושע - עם טעמים":
                    return "Books\\002_NAVI\\06_YEHOSUA\\a06__Joshua.txt";
                case "יהושע - עם ניקוד":
                    return "Books\\002_NAVI\\06_YEHOSUA\\a06_Joshua.txt";

                case "יהושע - ללא ניקוד":
                    return "Books\\002_NAVI\\06_YEHOSUA\\b06_Joshua.txt";
                case "יהושע - רש''י":
                    return "Books\\002_NAVI\\06_YEHOSUA\\eNA_YEHOSUA_L1.txt";
                case "יהושע - מצודת דוד":
                    return "Books\\002_NAVI\\06_YEHOSUA\\fNA_YEHOSUA_L1.txt";
                case "יהושע - מצודת ציון":
                    return "Books\\002_NAVI\\06_YEHOSUA\\gNA_YEHOSUA_L1.txt";
                case "יהושע - רלב''ג":
                    return "Books\\002_NAVI\\06_YEHOSUA\\gNA_YEHOSUA_L1_2.txt";
                //case "יהושע":
                //    return "Books\\002_NAVI\\06_YEHOSUA\\h_Interleave.txt";
                case "יהושע (ט)":
                    return "Books\\002_NAVI\\06_YEHOSUA\\h_Interleave2.txt";

                case "שופטים - עם טעמים":
                    return "Books\\002_NAVI\\07_SHOFETIM\\a07__Judges.txt";
                case "שופטים - עם ניקוד":
                    return "Books\\002_NAVI\\07_SHOFETIM\\a07_Judges.txt";

                case "שופטים - ללא ניקוד":
                    return "Books\\002_NAVI\\07_SHOFETIM\\b07_Judges.txt";
                case "שופטים - רש''י":
                    return "Books\\002_NAVI\\07_SHOFETIM\\eNA_SHOFTIM_L1.txt";
                case "שופטים - מצודת דוד":
                    return "Books\\002_NAVI\\07_SHOFETIM\\fNA_SHOFTIM_L2.txt";
                case "שופטים - מצודת ציון":
                    return "Books\\002_NAVI\\07_SHOFETIM\\gNA_SHOFTIM_L1.txt";
                case "שופטים - רלב''ג":
                    return "Books\\002_NAVI\\07_SHOFETIM\\gNA_SHOFTIM_L1_2.txt";
                //case "שופטים":
                //    return "Books\\002_NAVI\\07_SHOFETIM\\h_Interleave.txt";
                case "שופטים (ט)":
                    return "Books\\002_NAVI\\07_SHOFETIM\\h_Interleave2.txt";

                case "שמואל א - עם טעמים":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\a08_Samuel__1.txt";
                case "שמואל א - עם ניקוד":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\a08_Samuel_1.txt";

                case "שמואל א - ללא ניקוד":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\b08_Samuel_1.txt";
                case "שמואל א - רש''י":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\eNA_SHMUEL_A_L1.txt";
                case "שמואל א - מצודת דוד":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\fNA_SHMUEL_A_L1.txt";
                case "שמואל א - מצודת ציון":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L1.txt";
                case "שמואל א - רלב''ג":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L1_2.txt";
                case "שמואל א - מלבי''ם":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\gNA_SHMUEL_A_L3_MALBIM.txt";
                //case "שמואל א":
                //    return "Books\\002_NAVI\\08_SHEMUEL_A\\h_Interleave.txt";
                case "שמואל א (ט)":
                    return "Books\\002_NAVI\\08_SHEMUEL_A\\h_Interleave2.txt";

                case "שמואל ב - עם טעמים":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\a09_Samuel__2.txt";
                case "שמואל ב - עם ניקוד":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\a09_Samuel_2.txt";

                case "שמואל ב - ללא ניקוד":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\b09_Samuel_2.txt";
                case "שמואל ב - רש''י":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\eNA_SHMUEL_B_L1.txt";
                case "שמואל ב - מצודת דוד":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\fNA_SHMUEL_B_L1.txt";
                case "שמואל ב - מצודת ציון":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L1.txt";
                case "שמואל ב - רלב''ג":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L1_2.txt";
                case "שמואל ב - מלבי''ם":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\gNA_SHMUEL_B_L3_MALBIM.txt";
                //case "שמואל ב":
                //    return "Books\\002_NAVI\\09_SHEMUEL_B\\h_Interleave.txt";
                case "שמואל ב (ט)":
                    return "Books\\002_NAVI\\09_SHEMUEL_B\\h_Interleave2.txt";

                case "מלכים א - עם טעמים":
                    return "Books\\002_NAVI\\10_MELACIM_A\\a10_Kings__1.txt";
                case "מלכים א - עם ניקוד":
                    return "Books\\002_NAVI\\10_MELACIM_A\\a10_Kings_1.txt";

                case "מלכים א - ללא ניקוד":
                    return "Books\\002_NAVI\\10_MELACIM_A\\b10_Kings_1.txt";
                case "מלכים א - רש''י":
                    return "Books\\002_NAVI\\10_MELACIM_A\\eNA_MELACHIM_A_L1.txt";
                case "מלכים א - מצודת דוד":
                    return "Books\\002_NAVI\\10_MELACIM_A\\fNA_MELACHIM_A_L1.txt";
                case "מלכים א - מצודת ציון":
                    return "Books\\002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1.txt";
                case "מלכים א - רלב''ג":
                    return "Books\\002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1_2.txt";
                case "מלכים א - מלבי''ם":
                    return "Books\\002_NAVI\\10_MELACIM_A\\gNA_MELACHIM_A_L1_MALBIM.txt";
                //case "מלכים א":
                //    return "Books\\002_NAVI\\10_MELACIM_A\\h_Interleave.txt";
                case "מלכים א (ט)":
                    return "Books\\002_NAVI\\10_MELACIM_A\\h_Interleave2.txt";

                case "מלכים ב - עם טעמים":
                    return "Books\\002_NAVI\\11_MELACIM_B\\a11_Kings__2.txt";
                case "מלכים ב - עם ניקוד":
                    return "Books\\002_NAVI\\11_MELACIM_B\\a11_Kings_2.txt";

                case "מלכים ב - ללא ניקוד":
                    return "Books\\002_NAVI\\11_MELACIM_B\\b11_Kings_2.txt";
                case "מלכים ב - רש''י":
                    return "Books\\002_NAVI\\11_MELACIM_B\\eNA_MELACHIM_B_L1.txt";
                case "מלכים ב - מצודת דוד":
                    return "Books\\002_NAVI\\11_MELACIM_B\\fNA_MELACHIM_B_L1.txt";
                case "מלכים ב - מצודת ציון":
                    return "Books\\002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1.txt";
                case "מלכים ב - רלב''ג":
                    return "Books\\002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1_2.txt";
                case "מלכים ב - מלבי''ם":
                    return "Books\\002_NAVI\\11_MELACIM_B\\gNA_MELACHIM_B_L1_MALBIM.txt";
                //case "מלכים ב":
                //    return "Books\\002_NAVI\\11_MELACIM_B\\h_Interleave.txt";
                case "מלכים ב (ט)":
                    return "Books\\002_NAVI\\11_MELACIM_B\\h_Interleave2.txt";

                case "ישעיה - עם טעמים":
                    return "Books\\002_NAVI\\12_YISHAYA\\a12__Isaiah.txt";
                case "ישעיה - עם ניקוד":
                    return "Books\\002_NAVI\\12_YISHAYA\\a12_Isaiah.txt";

                case "ישעיה - ללא ניקוד":
                    return "Books\\002_NAVI\\12_YISHAYA\\b12_Isaiah.txt";
                case "ישעיה - רש''י":
                    return "Books\\002_NAVI\\12_YISHAYA\\eNA_YISHAYA_L1.txt";
                case "ישעיה - מצודת דוד":
                    return "Books\\002_NAVI\\12_YISHAYA\\fNA_YISHAYA_L1.txt";
                case "ישעיה - מצודת ציון":
                    return "Books\\002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L1.txt";
                case "ישעיה - מלבי''ם - ב. הענין":
                    return "Books\\002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L1_MALBIM.txt";
                case "ישעיה - מלבי''ם - ב. המילת":
                    return "Books\\002_NAVI\\12_YISHAYA\\gNA_YISHAYA_L2_MALBIM.txt";
                //case "ישעיה":
                //    return "Books\\002_NAVI\\12_YISHAYA\\h_Interleave.txt";
                case "ישעיה (ט)":
                    return "Books\\002_NAVI\\12_YISHAYA\\h_Interleave2.txt";

                case "ירמיה - עם טעמים":
                    return "Books\\002_NAVI\\13_YERMIYA\\a13__Jeremiah.txt";
                case "ירמיה - עם ניקוד":
                    return "Books\\002_NAVI\\13_YERMIYA\\a13_Jeremiah.txt";

                case "ירמיה - ללא ניקוד":
                    return "Books\\002_NAVI\\13_YERMIYA\\b13_Jeremiah.txt";
                case "ירמיה - רש''י":
                    return "Books\\002_NAVI\\13_YERMIYA\\eNA_YERMIYA_L1.txt";
                case "ירמיה - מצודת דוד":
                    return "Books\\002_NAVI\\13_YERMIYA\\fNA_YERMIYA_L1.txt";
                case "ירמיה - מצודת ציון":
                    return "Books\\002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L1.txt";
                case "ירמיה- מלבי''ם - ב. הענין":
                    return "Books\\002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L1_MALBIM.txt";
                case "ירמיה - מלבי''ם - ב. המילת":
                    return "Books\\002_NAVI\\13_YERMIYA\\gNA_YERMIYA_L2_MALBIM.txt";
                //case "ירמיה":
                //    return "Books\\002_NAVI\\13_YERMIYA\\h_Interleave.txt";
                case "ירמיה (ט)":
                    return "Books\\002_NAVI\\13_YERMIYA\\h_Interleave2.txt";

                case "יחזקאל - עם טעמים":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\a14__Ezekiel.txt";
                case "יחזקאל - עם ניקוד":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\a14_Ezekiel.txt";

                case "יחזקאל - ללא ניקוד":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\b14_Ezekiel.txt";
                case "יחזקאל - רש''י":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\eNA_YEHEZKEL_L1.txt";
                case "יחזקאל - מצודת דוד":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\fNA_YEHEZKEL_L1.txt";
                case "יחזקאל - מצודת ציון":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L1.txt";
                case "יחזקאל - מלבי''ם - ב. הענין":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L1_MALBIM.txt";
                case "[2] יחזקאל - מלבי''ם - ב. הענין":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\gNA_YEHEZKEL_L2_MALBIM.txt";
                case "יחזקאל":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\h_Interleave.txt";
                case "יחזקאל (ט)":
                    return "Books\\002_NAVI\\14_YEHEZKEL\\h_Interleave2.txt";

                case "הושע - עם טעמים":
                    return "Books\\002_NAVI\\15_HOSEA\\a15__Hosea.txt";
                case "הושע - עם ניקוד":
                    return "Books\\002_NAVI\\15_HOSEA\\a15_Hosea.txt";

                case "הושע - ללא ניקוד":
                    return "Books\\002_NAVI\\15_HOSEA\\b15_Hosea.txt";
                case "הושע - רש''י":
                    return "Books\\002_NAVI\\15_HOSEA\\eNA_HOSEA_L1.txt";
                case "הושע - מצודת דוד":
                    return "Books\\002_NAVI\\15_HOSEA\\fNA_HOSEA_L1.txt";
                case "הושע - מצודת ציון":
                    return "Books\\002_NAVI\\15_HOSEA\\gNA_HOSEA_L1.txt";
                case "הושע":
                    return "Books\\002_NAVI\\15_HOSEA\\h_Interleave.txt";
                case "הושע (ט)":
                    return "Books\\002_NAVI\\15_HOSEA\\h_Interleave2.txt";

                case "יואל - עם טעמים":
                    return "Books\\002_NAVI\\16_YOEL\\a16__Joel.txt";
                case "יואל - עם ניקוד":
                    return "Books\\002_NAVI\\16_YOEL\\a16_Joel.txt";

                case "יואל - ללא ניקוד":
                    return "Books\\002_NAVI\\16_YOEL\\b16_Joel.txt";
                case "יואל - רש''י":
                    return "Books\\002_NAVI\\16_YOEL\\eNA_YOEL_L1.txt";
                case "יואל - מצודת דוד":
                    return "Books\\002_NAVI\\16_YOEL\\fNA_YOEL_L1.txt";
                case "יואל - מצודת ציון":
                    return "Books\\002_NAVI\\16_YOEL\\gNA_YOEL_L1.txt";
                case "יואל":
                    return "Books\\002_NAVI\\16_YOEL\\h_Interleave.txt";
                case "יואל (ט)":
                    return "Books\\002_NAVI\\16_YOEL\\h_Interleave2.txt";

                case "עמוס - עם טעמים":
                    return "Books\\002_NAVI\\17_AMOS\\a17__Amos.txt";
                case "עמוס - עם ניקוד":
                    return "Books\\002_NAVI\\17_AMOS\\a17_Amos.txt";

                case "עמוס - ללא ניקוד":
                    return "Books\\002_NAVI\\17_AMOS\\b17_Amos.txt";
                case "עמוס - רש''י":
                    return "Books\\002_NAVI\\17_AMOS\\eNA_AMOS_L1.txt";
                case "עמוס - מצודת דוד":
                    return "Books\\002_NAVI\\17_AMOS\\fNA_AMOS_L2.txt";
                case "עמוס - מצודת ציון":
                    return "Books\\002_NAVI\\17_AMOS\\gNA_AMOS_L1.txt";
                case "עמוס":
                    return "Books\\002_NAVI\\17_AMOS\\h_Interleave.txt";
                case "עמוס (ט)":
                    return "Books\\002_NAVI\\17_AMOS\\h_Interleave2.txt";
                case "עובדיה":
                    return "Books\\002_NAVI\\18_OVADYA";
                case "עובדיה - עם טעמים":
                    return "Books\\002_NAVI\\18_OVADYA\\a18__Obadiah.txt";
                case "עובדיה - עם ניקוד":
                    return "Books\\002_NAVI\\18_OVADYA\\a18_Obadiah.txt";

                case "עובדיה - ללא ניקוד":
                    return "Books\\002_NAVI\\18_OVADYA\\b18_Obadiah.txt";
                case "עובדיה - רש''י":
                    return "Books\\002_NAVI\\18_OVADYA\\eNA_OVADYA_L1.txt";
                case "עובדיה - מצודת דוד":
                    return "Books\\002_NAVI\\18_OVADYA\\fNA_OVADYA_L1.txt";
                case "עובדיה - מצודת ציון":
                    return "Books\\002_NAVI\\18_OVADYA\\gNA_OVADYA_L1.txt";

                case "עובדיה (ט)":
                    return "Books\\002_NAVI\\18_OVADYA\\h_Interleave2.txt";

                case "יונה - עם טעמים":
                    return "Books\\002_NAVI\\19_YONA\\a19__Jonah.txt";
                case "יונה - עם ניקוד":
                    return "Books\\002_NAVI\\19_YONA\\a19_Jonah.txt";

                case "יונה - ללא ניקוד":
                    return "Books\\002_NAVI\\19_YONA\\b19_Jonah.txt";
                case "יונה - רש''י":
                    return "Books\\002_NAVI\\19_YONA\\eNA_YONA_L1.txt";
                case "יונה - מצודת דוד":
                    return "Books\\002_NAVI\\19_YONA\\fNA_YONA_L1.txt";
                case "יונה - מצודת ציון":
                    return "Books\\002_NAVI\\19_YONA\\gNA_YONA_L1.txt";
                case "יונה":
                    return "Books\\002_NAVI\\19_YONA\\h_Interleave.txt";
                case "יונה (ט)":
                    return "Books\\002_NAVI\\19_YONA\\h_Interleave2.txt";

                case "מיכה - עם טעמים":
                    return "Books\\002_NAVI\\20_MICHA\\a20__Micah.txt";
                case "מיכה - עם ניקוד":
                    return "Books\\002_NAVI\\20_MICHA\\a20_Micah.txt";

                case "מיכה - ללא ניקוד":
                    return "Books\\002_NAVI\\20_MICHA\\b20_Micah.txt";
                case "מיכה - רש''י":
                    return "Books\\002_NAVI\\20_MICHA\\eNA_MICHA_L1.txt";
                case "מיכה - מצודת דוד":
                    return "Books\\002_NAVI\\20_MICHA\\fNA_MICHA_L1.txt";
                case "מיכה - מצודת ציון":
                    return "Books\\002_NAVI\\20_MICHA\\gNA_MICHA_L1.txt";
                case "מיכה":
                    return "Books\\002_NAVI\\20_MICHA\\h_Interleave.txt";
                case "מיכה (ט)":
                    return "Books\\002_NAVI\\20_MICHA\\h_Interleave2.txt";

                case "נחום - עם טעמים":
                    return "Books\\002_NAVI\\21_NAHUM\\a21__Nahum.txt";
                case "נחום - עם ניקוד":
                    return "Books\\002_NAVI\\21_NAHUM\\a21_Nahum.txt";

                case "נחום - ללא ניקוד":
                    return "Books\\002_NAVI\\21_NAHUM\\b21_Nahum.txt";
                case "נחום - רש''י":
                    return "Books\\002_NAVI\\21_NAHUM\\eNA_NAHUM_L1.txt";
                case "נחום - מצודת דוד":
                    return "Books\\002_NAVI\\21_NAHUM\\fNA_NAHUM_L1.txt";
                case "נחום - מצודת ציון":
                    return "Books\\002_NAVI\\21_NAHUM\\gNA_NAHUM_L1.txt";
                case "נחום":
                    return "Books\\002_NAVI\\21_NAHUM\\h_Interleave.txt";
                case "נחום (ט)":
                    return "Books\\002_NAVI\\21_NAHUM\\h_Interleave2.txt";

                case "חבקוק - עם טעמים":
                    return "Books\\002_NAVI\\22_HAVAKUK\\a22__Habakkuk.txt";
                case "חבקוק - עם ניקוד":
                    return "Books\\002_NAVI\\22_HAVAKUK\\a22_Habakkuk.txt";

                case "חבקוק - ללא ניקוד":
                    return "Books\\002_NAVI\\22_HAVAKUK\\b22_Habakkuk.txt";
                case "חבקוק - רש''י":
                    return "Books\\002_NAVI\\22_HAVAKUK\\eNA_HAVAKUK_L1.txt";
                case "חבקוק - מצודת דוד":
                    return "Books\\002_NAVI\\22_HAVAKUK\\fNA_HAVAKUK_L1.txt";
                case "חבקוק - מצודת ציון":
                    return "Books\\002_NAVI\\22_HAVAKUK\\gNA_HAVAKUK_L1.txt";
                case "חבקוק":
                    return "Books\\002_NAVI\\22_HAVAKUK\\h_Interleave.txt";
                case "חבקוק (ט)":
                    return "Books\\002_NAVI\\22_HAVAKUK\\h_Interleave2.txt";

                case "צפניה - עם טעמים":
                    return "Books\\002_NAVI\\23_ZFANYA\\a23__Zephaniah.txt";
                case "צפניה - עם ניקוד":
                    return "Books\\002_NAVI\\23_ZFANYA\\a23_Zephaniah.txt";

                case "צפניה - ללא ניקוד":
                    return "Books\\002_NAVI\\23_ZFANYA\\b23_Zephaniah.txt";
                case "צפניה - רש''י":
                    return "Books\\002_NAVI\\23_ZFANYA\\eNA_ZFANYA_L1.txt";
                case "צפניה - מצודת דוד":
                    return "Books\\002_NAVI\\23_ZFANYA\\fNA_ZFANYA_L1.txt";
                case "צפניה - מצודת ציון":
                    return "Books\\002_NAVI\\23_ZFANYA\\gNA_ZFANYA_L1.txt";
                case "צפניה":
                    return "Books\\002_NAVI\\23_ZFANYA\\h_Interleave.txt";
                case "צפניה (ט)":
                    return "Books\\002_NAVI\\23_ZFANYA\\h_Interleave2.txt";

                case "חגי - עם טעמים":
                    return "Books\\002_NAVI\\24_HAGAY\\a24__Haggai.txt";
                case "חגי - עם ניקוד":
                    return "Books\\002_NAVI\\24_HAGAY\\a24_Haggai.txt";

                case "חגי - ללא ניקוד":
                    return "Books\\002_NAVI\\24_HAGAY\\b24_Haggai.txt";
                case "חגי - רש''י":
                    return "Books\\002_NAVI\\24_HAGAY\\eNA_HAGAY_L1.txt";
                case "חגי - מצודת דוד":
                    return "Books\\002_NAVI\\24_HAGAY\\fNA_HAGAY_L1.txt";
                case "חגי - מצודת ציון":
                    return "Books\\002_NAVI\\24_HAGAY\\gNA_HAGAY_L1.txt";
                case "חגי":
                    return "Books\\002_NAVI\\24_HAGAY\\h_Interleave.txt";
                case "חגי (ט)":
                    return "Books\\002_NAVI\\24_HAGAY\\h_Interleave2.txt";

                case "זכריה - עם טעמים":
                    return "Books\\002_NAVI\\25_ZECHARYA\\a25__Zechariah.txt";
                case "זכריה - עם ניקוד":
                    return "Books\\002_NAVI\\25_ZECHARYA\\a25_Zechariah.txt";

                case "זכריה - ללא ניקוד":
                    return "Books\\002_NAVI\\25_ZECHARYA\\b25_Zechariah.txt";
                case "זכריה - רש''י":
                    return "Books\\002_NAVI\\25_ZECHARYA\\eNA_ZECHARYA_L1.txt";
                case "זכריה - מצודת דוד":
                    return "Books\\002_NAVI\\25_ZECHARYA\\fNA_ZECHARYA_L1.txt";
                case "זכריה - מצודת ציון":
                    return "Books\\002_NAVI\\25_ZECHARYA\\gNA_ZECHARYA_L1.txt";
                case "זכריה":
                    return "Books\\002_NAVI\\25_ZECHARYA\\h_Interleave.txt";
                case "זכריה (ט)":
                    return "Books\\002_NAVI\\25_ZECHARYA\\h_Interleave2.txt";

                case "מלאכי - עם טעמים":
                    return "Books\\002_NAVI\\26_MALACHI\\a26__Malachi.txt";
                case "מלאכי - עם ניקוד":
                    return "Books\\002_NAVI\\26_MALACHI\\a26_Malachi.txt";

                case "מלאכי - ללא ניקוד":
                    return "Books\\002_NAVI\\26_MALACHI\\b26_Malachi.txt";
                case "מלאכי - רש''י":
                    return "Books\\002_NAVI\\26_MALACHI\\eNA_MALACHI_L1.txt";
                case "מלאכי - מצודת דוד":
                    return "Books\\002_NAVI\\26_MALACHI\\fNA_MALACHI_L1.txt";
                case "מלאכי - מצודת ציון":
                    return "Books\\002_NAVI\\26_MALACHI\\gNA_MALACHI_L1.txt";
                case "מלאכי":
                    return "Books\\002_NAVI\\26_MALACHI\\h_Interleave.txt";
                case "מלאכי (ט)":
                    return "Books\\002_NAVI\\26_MALACHI\\h_Interleave2.txt";

                case "תהילים - עם טעמים":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\a27__Psalms.txt";
                case "תהילים - עם ניקוד":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\a27_Psalms.txt";

                case "תהילים - ללא ניקוד":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\b27_Psalms.txt";
                case "תהילים - רש''י":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\eNA_TEHILIM_L1.txt";
                case "תהילים - מצודת דוד":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\fNA_TEHILIM_L1.txt";
                case "תהילים - מצודת ציון":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L1.txt";
                case "תהילים - מלבי''ם - ב. הענין":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L1_MALBIM.txt";
                case "תהילים - מלבי''ם - ב. המלות":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\gNA_TEHILIM_L2_MALBIM.txt";
                case "תהילים":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\h_Interleave.txt";
                case "תהילים (ט)":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\h_Interleave2.txt";
                case "תהילים - מחולק לספרים":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\i_div1.txt";
                case "תהילים - מחולק לימי השבוע":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\i_div2.txt";
                case "תהילים - מחולק לימי החודש":
                    return "Books\\003_KTUVIM\\27_TEHILIM\\i_div3.txt";
                case "משלי":
                    return "Books\\003_KTUVIM\\28_MISHLEI";
                case "משלי - עם טעמים":
                    return "Books\\003_KTUVIM\\28_MISHLEI\\a28__Proverbs.txt";
                case "משלי - עם ניקוד":
                    return "Books\\003_KTUVIM\\28_MISHLEI\\a28_Proverbs.txt";

                case "משלי - ללא ניקוד":
                    return "Books\\003_KTUVIM\\28_MISHLEI\\b28_Proverbs.txt";
                case "משלי - רש''י":
                    return "Books\\003_KTUVIM\\28_MISHLEI\\eNA_MISHLEI_L1.txt";
                case "משלי - מצודת דוד":
                    return "Books\\003_KTUVIM\\28_MISHLEI\\fNA_MISHLEI_L1.txt";
                case "משלי - מצודת ציון":
                    return "Books\\003_KTUVIM\\28_MISHLEI\\gNA_MISHLEI_L1.txt";
                case "משלי - רלב''ג":
                    return "Books\\003_KTUVIM\\28_MISHLEI\\gNA_MISHLEI_L1_2.txt";

                case "משלי (ט)":
                    return "Books\\003_KTUVIM\\28_MISHLEI\\h_Interleave2.txt";
                case "איוב":
                    return "Books\\003_KTUVIM\\29_IYOV";
                case "איוב - עם טעמים":
                    return "Books\\003_KTUVIM\\29_IYOV\\a29__Job.txt";
                case "איוב - עם ניקוד":
                    return "Books\\003_KTUVIM\\29_IYOV\\a29_Job.txt";

                case "איוב - ללא ניקוד":
                    return "Books\\003_KTUVIM\\29_IYOV\\b29_Job.txt";
                case "איוב - רש''י":
                    return "Books\\003_KTUVIM\\29_IYOV\\eNA_IYOV_L1.txt";
                case "איוב - מצודת דוד":
                    return "Books\\003_KTUVIM\\29_IYOV\\fNA_IYOV_L1.txt";
                case "איוב - מצודת ציון":
                    return "Books\\003_KTUVIM\\29_IYOV\\gNA_IYOV_L1.txt";
                case "איוב - רלב''ג":
                    return "Books\\003_KTUVIM\\29_IYOV\\gNA_IYOV_L1_2.txt";

                case "איוב (ט)":
                    return "Books\\003_KTUVIM\\29_IYOV\\h_Interleave2.txt";
                case "שיר השירים":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM";
                case "שיר השירים - עם טעמים":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\a30_Song_of__Songs.txt";
                case "שיר השירים - עם ניקוד":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\a30_Song_of_Songs.txt";

                case "שיר השירים - ללא ניקוד":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\b30_Song_of_Songs.txt";
                case "שיר השירים - רש''י":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\eNA_SHIR_HASHIRIM_L1.txt";
                case "שיר השירים - מצודת דוד":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\fNA_SHIR_HASHIRIM_L1.txt";
                case "שיר השירים - מצודת ציון":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\gNA_SHIR_HASHIRIM_L1.txt";
                case "מדרש רבה - שיר השירים רבה":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\x_raba.txt";

                case "שיר השירים (ט)":
                    return "Books\\003_KTUVIM\\30_SHIR_HASHIRIM\\z_Interleave2.txt";
                case "רות":
                    return "Books\\003_KTUVIM\\31_RUTH";
                case "רות - עם טעמים":
                    return "Books\\003_KTUVIM\\31_RUTH\\a31__Ruth.txt";
                case "רות - עם ניקוד":
                    return "Books\\003_KTUVIM\\31_RUTH\\a31_Ruth.txt";

                case "רות - ללא ניקוד":
                    return "Books\\003_KTUVIM\\31_RUTH\\b31_Ruth.txt";
                case "רות - רש''י":
                    return "Books\\003_KTUVIM\\31_RUTH\\eNA_RUTH_L1.txt";
                case "מדרש רבה - רות רבה":
                    return "Books\\003_KTUVIM\\31_RUTH\\x_raba.txt";

                case "רות (ט)":
                    return "Books\\003_KTUVIM\\31_RUTH\\z_Interleave2.txt";
                case "איכה":
                    return "Books\\003_KTUVIM\\32_EICHA";
                case "איכה - עם טעמים":
                    return "Books\\003_KTUVIM\\32_EICHA\\a32__Lamentations.txt";
                case "איכה - עם ניקוד":
                    return "Books\\003_KTUVIM\\32_EICHA\\a32_Lamentations.txt";

                case "איכה - ללא ניקוד":
                    return "Books\\003_KTUVIM\\32_EICHA\\b32_Lamentations.txt";
                case "איכה - רש''י":
                    return "Books\\003_KTUVIM\\32_EICHA\\eNA_EICHA_L1.txt";
                case "מדרש רבה - איכה רבתי":
                    return "Books\\003_KTUVIM\\32_EICHA\\x_raba.txt";

                case "איכה (ט)":
                    return "Books\\003_KTUVIM\\32_EICHA\\z_Interleave2.txt";
                case "קהלת":
                    return "Books\\003_KTUVIM\\33_KOHELET";
                case "קהלת - עם טעמים":
                    return "Books\\003_KTUVIM\\33_KOHELET\\a33__Ecclesiastes.txt";
                case "קהלת - עם ניקוד":
                    return "Books\\003_KTUVIM\\33_KOHELET\\a33_Ecclesiastes.txt";

                case "קהלת - ללא ניקוד":
                    return "Books\\003_KTUVIM\\33_KOHELET\\b33_Ecclesiastes.txt";
                case "קהלת - רש''י":
                    return "Books\\003_KTUVIM\\33_KOHELET\\eNA_KOHELET_L1.txt";
                case "קהלת - מצודת דוד":
                    return "Books\\003_KTUVIM\\33_KOHELET\\fNA_KOHELET_L1.txt";
                case "קהלת - מצודת ציון":
                    return "Books\\003_KTUVIM\\33_KOHELET\\gNA_KOHELET_L1.txt";
                case "מדרש רבה - קהלת רבה":
                    return "Books\\003_KTUVIM\\33_KOHELET\\x_raba.txt";

                case "קהלת (ט)":
                    return "Books\\003_KTUVIM\\33_KOHELET\\z_Interleave2.txt";
                case "אסתר":
                    return "Books\\003_KTUVIM\\34_ESTER";
                case "אסתר - עם טעמים":
                    return "Books\\003_KTUVIM\\34_ESTER\\a34__Esther.txt";
                case "אסתר - עם ניקוד":
                    return "Books\\003_KTUVIM\\34_ESTER\\a34_Esther.txt";

                case "אסתר - ללא ניקוד":
                    return "Books\\003_KTUVIM\\34_ESTER\\b34_Esther.txt";
                case "אסתר - רש''י":
                    return "Books\\003_KTUVIM\\34_ESTER\\eNA_ESTER_L1.txt";
                case "אסתר - מלבי''ם":
                    return "Books\\003_KTUVIM\\34_ESTER\\f_MALBIM_ESTER.txt";
                case "מדרש רבה - אסתר רבה":
                    return "Books\\003_KTUVIM\\34_ESTER\\x_raba.txt";

                case "אסתר (ט)":
                    return "Books\\003_KTUVIM\\34_ESTER\\z_Interleave2.txt";
                case "דניאל":
                    return "Books\\003_KTUVIM\\35_DANIEL";
                case "דניאל - עם טעמים":
                    return "Books\\003_KTUVIM\\35_DANIEL\\a35__Daniel.txt";
                case "דניאל - עם ניקוד":
                    return "Books\\003_KTUVIM\\35_DANIEL\\a35_Daniel.txt";

                case "דניאל - ללא ניקוד":
                    return "Books\\003_KTUVIM\\35_DANIEL\\b35_Daniel.txt";
                case "דניאל - רש''י":
                    return "Books\\003_KTUVIM\\35_DANIEL\\eNA_DANIEL_L1.txt";
                case "דניאל - מצודת דוד":
                    return "Books\\003_KTUVIM\\35_DANIEL\\fNA_DANIEL_L1.txt";
                case "דניאל - מצודת ציון":
                    return "Books\\003_KTUVIM\\35_DANIEL\\gNA_DANIEL_L1.txt";

                case "דניאל (ט)":
                    return "Books\\003_KTUVIM\\35_DANIEL\\h_Interleave2.txt";
                case "עזרא":
                    return "Books\\003_KTUVIM\\36_EZRA";
                case "עזרא - עם טעמים":
                    return "Books\\003_KTUVIM\\36_EZRA\\a36__Ezra.txt";
                case "עזרא - עם ניקוד":
                    return "Books\\003_KTUVIM\\36_EZRA\\a36_Ezra.txt";

                case "עזרא - ללא ניקוד":
                    return "Books\\003_KTUVIM\\36_EZRA\\b36_Ezra.txt";
                case "עזרא - רש''י":
                    return "Books\\003_KTUVIM\\36_EZRA\\eNA_EZRA_L1.txt";
                case "עזרא - מצודת דוד":
                    return "Books\\003_KTUVIM\\36_EZRA\\fNA_EZRA_L1.txt";
                case "עזרא - מצודת ציון":
                    return "Books\\003_KTUVIM\\36_EZRA\\gNA_EZRA_L1.txt";
                case "עזרא - רלב''ג":
                    return "Books\\003_KTUVIM\\36_EZRA\\gNA_EZRA_L1_2.txt";

                case "עזרא (ט)":
                    return "Books\\003_KTUVIM\\36_EZRA\\h_Interleave2.txt";
                case "נחמיה":
                    return "Books\\003_KTUVIM\\37_NECHEMYA";
                case "נחמיה - עם טעמים":
                    return "Books\\003_KTUVIM\\37_NECHEMYA\\a37__Nehemiah.txt";
                case "נחמיה - עם ניקוד":
                    return "Books\\003_KTUVIM\\37_NECHEMYA\\a37_Nehemiah.txt";

                case "נחמיה - ללא ניקוד":
                    return "Books\\003_KTUVIM\\37_NECHEMYA\\b37_Nehemiah.txt";
                case "נחמיה - רש''י":
                    return "Books\\003_KTUVIM\\37_NECHEMYA\\eNA_NECHEMYA_L1.txt";
                case "נחמיה - מצודת דוד":
                    return "Books\\003_KTUVIM\\37_NECHEMYA\\fNA_NECHEMYA_L1.txt";
                case "נחמיה - מצודת ציון":
                    return "Books\\003_KTUVIM\\37_NECHEMYA\\gNA_NECHEMYA_L1.txt";
                case "נחמיה - רלב''ג":
                    return "Books\\003_KTUVIM\\37_NECHEMYA\\gNA_NECHEMYA_L1_2.txt";

                case "נחמיה (ט)":
                    return "Books\\003_KTUVIM\\37_NECHEMYA\\h_Interleave2.txt";
                case "דברי הימים א":
                    return "Books\\003_KTUVIM\\38_DIVRE_A";
                case "דברי הימים א - עם טעמים":
                    return "Books\\003_KTUVIM\\38_DIVRE_A\\a38_Chronicles__1.txt";
                case "דברי הימים א - עם ניקוד":
                    return "Books\\003_KTUVIM\\38_DIVRE_A\\a38_Chronicles_1.txt";

                case "דברי הימים א - ללא ניקוד":
                    return "Books\\003_KTUVIM\\38_DIVRE_A\\b38_Chronicles_1.txt";
                case "דברי הימים א - רש''י":
                    return "Books\\003_KTUVIM\\38_DIVRE_A\\eNA_DIVRE_A_L1.txt";
                case "דברי הימים א - מצודת דוד":
                    return "Books\\003_KTUVIM\\38_DIVRE_A\\fNA_DIVRE_A_L1.txt";
                case "דברי הימים א - מצודת ציון":
                    return "Books\\003_KTUVIM\\38_DIVRE_A\\gNA_DIVRE_A_L1.txt";
                case "דברי הימים א - רלב''ג":
                    return "Books\\003_KTUVIM\\38_DIVRE_A\\gNA_DIVRE_A_L1_2.txt";

                case "דברי הימים א (ט)":
                    return "Books\\003_KTUVIM\\38_DIVRE_A\\h_Interleave2.txt";
                case "דברי הימים ב":
                    return "Books\\003_KTUVIM\\39_DIVRE_B";
                case "דברי הימים ב - עם טעמים":
                    return "Books\\003_KTUVIM\\39_DIVRE_B\\a39_Chronicles__2.txt";
                case "דברי הימים ב - עם ניקוד":
                    return "Books\\003_KTUVIM\\39_DIVRE_B\\a39_Chronicles_2.txt";

                case "דברי הימים ב - ללא ניקוד":
                    return "Books\\003_KTUVIM\\39_DIVRE_B\\b39_Chronicles_2.txt";
                case "דברי הימים ב - רש''י":
                    return "Books\\003_KTUVIM\\39_DIVRE_B\\eNA_DIVRE_B_L1.txt";
                case "דברי הימים ב - מצודת דוד":
                    return "Books\\003_KTUVIM\\39_DIVRE_B\\fNA_DIVRE_B_L1.txt";
                case "דברי הימים ב - מצודת ציון":
                    return "Books\\003_KTUVIM\\39_DIVRE_B\\gNA_DIVRE_B_L1.txt";
                case "דברי הימים ב - רלב''ג":
                    return "Books\\003_KTUVIM\\39_DIVRE_B\\gNA_DIVRE_B_L1_2.txt";

                case "דברי הימים ב (ט)":
                    return "Books\\003_KTUVIM\\39_DIVRE_B\\h_Interleave2.txt";

                case "משנה - ברכות - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L2.txt";
                case "משנה - ברכות":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L1.txt";

                case "משנה - ברכות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L3.txt";
                case "משנה - ברכות - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\MZ_BRAHOT_L5.txt";
                case "משנה מסכת ברכות":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\01_MAS_BRACHOT\\ZDebugMix.txt";
                case "משנה - פאה - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L2.txt";
                case "משנה - פאה":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L1.txt";

                case "משנה - פאה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L3.txt";
                case "משנה - פאה - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\MZ_PEAA_L5.txt";
                case "משנה מסכת פאה":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\02_MAS_PEA\\ZDebugMix.txt";
                case "משנה - דמאי - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L2.txt";
                case "משנה - דמאי":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L1.txt";

                case "משנה - דמאי - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L3.txt";
                case "משנה - דמאי - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\MZ_DEMAY_L5.txt";
                case "משנה מסכת דמאי":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\03_MAS_DEMAI\\ZDebugMix.txt";
                case "משנה - כלאים - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L2.txt";
                case "משנה - כלאים":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L1.txt";

                case "משנה - כלאים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L3.txt";
                case "משנה - כלאים - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\MZ_KILAIIM_L5.txt";
                case "משנה מסכת כלאים":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\04_MAS_KILAIIM\\ZDebugMix.txt";
                case "משנה - שביעית - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L2.txt";
                case "משנה - שביעית":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L1.txt";

                case "משנה - שביעית - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L3.txt";
                case "משנה - שביעית - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\MZ_SHVIIT_L5.txt";
                case "משנה מסכת שביעית":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\05_MAS_SHEVIIT\\ZDebugMix.txt";
                case "משנה - תרומות - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L2.txt";
                case "משנה - תרומות":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L1.txt";

                case "משנה - תרומות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L3.txt";
                case "משנה - תרומות - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\MZ_TRUMOT_L5.txt";
                case "משנה מסכת תרומות":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\06_MAS_TRUMOT\\ZDebugMix.txt";
                case "משנה - מעשרות - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L2.txt";
                case "משנה - מעשרות":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L1.txt";

                case "משנה - מעשרות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L3.txt";
                case "משנה - מעשרות - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\MZ_MEASROT_L5.txt";
                case "משנה מסכת מעשרות":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\07_MAS_MAASROT\\ZDebugMix.txt";
                case "משנה - מעשר שני - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L2.txt";
                case "משנה - מעשר שני":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L1.txt";

                case "משנה - מעשר שני - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L3.txt";
                case "משנה - מעשר שני - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\MZ_MEASER_SHENI_L5.txt";
                case "משנה מסכת מעשר שני":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\08_MAS_MAASER_SHENI\\ZDebugMix.txt";
                case "משנה - חלה - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L2.txt";
                case "משנה - חלה":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L1.txt";

                case "משנה - חלה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L3.txt";
                case "משנה - חלה - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\MZ_HALA_L5.txt";
                case "משנה מסכת חלה":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\09_MAS_CHALA\\ZDebugMix.txt";
                case "משנה - ערלה - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L2.txt";
                case "משנה - ערלה":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L1.txt";

                case "משנה - ערלה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L3.txt";
                case "משנה - ערלה - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\MZ_ORLA_L5.txt";
                case "משנה מסכת ערלה":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\10_MAS_ORLA\\ZDebugMix.txt";
                case "משנה - ביכורים - רע''ב":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L2.txt";
                case "משנה - ביכורים":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L1.txt";

                case "משנה - ביכורים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L3.txt";
                case "משנה - ביכורים - רמב''ם":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\MZ_BIKURIM_L5.txt";
                case "משנה מסכת ביכורים":
                    return "Books\\020_MISHNA\\100_SEDER_ZRAIM\\11_MAS_BIKURIM\\ZDebugMix.txt";

                case "משנה - שבת - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L2.txt";
                case "משנה - שבת":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L1.txt";

                case "משנה - שבת - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L3.txt";
                case "משנה - שבת - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\MZ2-SHABAT_L5.txt";
                case "משנה מסכת שבת":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\12_MAS_SHABAT\\ZDebugMix.txt";

                case "משנה - עירובין - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L2.txt";
                case "משנה - עירובין":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L1.txt";

                case "משנה - עירובין - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L3.txt";
                case "משנה - עירובין - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\MZ2_ERUVIN_L5.txt";
                case "משנה מסכת עירובין":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\13_MAS_ERUVIN\\ZDebugMix.txt";

                case "משנה - פסחים - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L2.txt";
                case "משנה - פסחים":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L1.txt";

                case "משנה - פסחים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L3.txt";
                case "משנה - פסחים - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\MZ2_PSAIIM_L5.txt";
                case "משנה מסכת פסחים":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\14_MAS_PSACHIM\\ZDebugMix.txt";

                case "משנה - שקלים - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L2.txt";
                case "משנה - שקלים":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L1.txt";

                case "משנה - שקלים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\MZ2-SHKALIM_L3.txt";
                case "משנה מסכת שקלים":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\15_MAS_SHKALIM\\ZDebugMix.txt";

                case "משנה - יומא - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L2.txt";
                case "משנה - יומא":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L1.txt";

                case "משנה - יומא - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L3.txt";
                case "משנה - יומא - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\MZ2-YOMA_L5.txt";
                case "משנה מסכת יומא":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\16_MAS_YOMA\\ZDebugMix.txt";

                case "משנה - סוכה - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L2.txt";
                case "משנה - סוכה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L1.txt";

                case "משנה - סוכה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L3.txt";
                case "משנה - סוכה - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\MZ2-SUCA_L5.txt";
                case "משנה מסכת סוכה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\17_MAS_SUCA\\ZDebugMix.txt";

                case "משנה - ביצה - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L2.txt";
                case "משנה - ביצה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L1.txt";

                case "משנה - ביצה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L3.txt";
                case "משנה - ביצה - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\MZ2-BEITSA_L5.txt";
                case "משנה מסכת ביצה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\18_MAS_BEITSA\\ZDebugMix.txt";

                case "משנה - ראש השנה - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L2.txt";
                case "משנה - ראש השנה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L1.txt";

                case "משנה - ראש השנה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L3.txt";
                case "משנה - ראש_השנה - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\MZ2-ROSH HASHANA_L5.txt";
                case "משנה מסכת ראש השנה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\19_MAS_ROSH\\ZDebugMix.txt";

                case "משנה - תענית - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L2.txt";
                case "משנה - תענית":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L1.txt";

                case "משנה - תענית - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L3.txt";
                case "משנה - תענית - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\MZ2-TAANIT_L5.txt";
                case "משנה מסכת תענית":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\20_MAS_TAANIT\\ZDebugMix.txt";

                case "משנה - מגילה - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L2.txt";
                case "משנה - מגילה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L1.txt";

                case "משנה - מגילה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L3.txt";
                case "משנה - מגילה - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\MZ2-MEGILA_L5.txt";
                case "משנה מסכת מגילה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\21_MAS_MEGILA\\ZDebugMix.txt";

                case "משנה - מועד קטן - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L2.txt";
                case "משנה - מועד קטן":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L1.txt";

                case "משנה - מועד קטן - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L3.txt";
                case "משנה - מועד_קטן - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\MZ2-MOED-KATAN_L5.txt";
                case "משנה מסכת מועד קטן":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\22_MAS_MOED_KATAN\\ZDebugMix.txt";
                case "משנה - חגיגה - רע''ב":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L2.txt";
                case "משנה - חגיגה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L1.txt";

                case "משנה - חגיגה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L3.txt";
                case "משנה - חגיגה - רמב''ם":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\MZ2-HAGIGA_L5.txt";
                case "משנה מסכת חגיגה":
                    return "Books\\020_MISHNA\\101_SEDER_MOED\\23_MAS_HAGIGA\\ZDebugMix.txt";
                case "משנה - יבמות - רע''ב":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L2.txt";
                case "משנה - יבמות":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L1.txt";

                case "משנה - יבמות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L3.txt";
                case "משנה - יבמות - רמב''ם":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\MN_YEVAMOT_L5.txt";
                case "משנה מסכת יבמות":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\24_MAS_YEVAMOT\\ZDebugMix.txt";
                case "משנה - כתובות - רע''ב":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L2.txt";
                case "משנה - כתובות":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L1.txt";

                case "משנה - כתובות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L3.txt";
                case "משנה - כתובות - רמב''ם":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\MN_KTUBOT_L5.txt";
                case "משנה מסכת כתובות":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\25_MAS_KTUBOT\\ZDebugMix.txt";
                case "משנה - נדרים - רע''ב":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L2.txt";
                case "משנה - נדרים":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L1.txt";

                case "משנה - נדרים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L3.txt";
                case "משנה - נדרים - רמב''ם":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\MN_NEDARIM_L5.txt";
                case "משנה מסכת נדרים":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\26_MAS_NEDARIM\\ZDebugMix.txt";
                case "משנה - נזיר - רע''ב":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L2.txt";
                case "משנה - נזיר":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L1.txt";

                case "משנה - נזיר - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L3.txt";
                case "משנה - נזיר - רמב''ם":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\MN_NAZIR_L5.txt";
                case "משנה מסכת נזיר":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\27_MAS_NAZIR\\ZDebugMix.txt";
                case "משנה - סוטה - רע''ב":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L2.txt";
                case "משנה - סוטה":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L1.txt";

                case "משנה - סוטה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L3.txt";
                case "משנה - סוטה - רמב''ם":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\MN_SOTA_L5.txt";
                case "משנה מסכת סוטה":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\28_MAS_SOTA\\ZDebugMix.txt";
                case "משנה - גיטין - רע''ב":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L2.txt";
                case "משנה - גיטין":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L1.txt";

                case "משנה - גיטין - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L3.txt";
                case "משנה - גיטין - רמב''ם":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\MN_GITIN_L5.txt";
                case "משנה מסכת גיטין":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\29_MAS_GITIN\\ZDebugMix.txt";
                case "משנה - קידושין - רע''ב":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L2.txt";
                case "משנה - קידושין":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L1.txt";

                case "משנה - קידושין - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L3.txt";
                case "משנה - קידושין - רמב''ם":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\MN_KIDUSHIN_L5.txt";
                case "משנה מסכת קידושין":
                    return "Books\\020_MISHNA\\102_SEDER_NASHIM\\30_MAS_KIDUSHIN\\ZDebugMix.txt";
                case "משנה - בבא קמא - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L2.txt";
                case "משנה - בבא קמא":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L1.txt";

                case "משנה - בבא קמא - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L3.txt";
                case "משנה - בבא_קמא - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\MNE_BABA_KAMA_L5.txt";
                case "משנה מסכת בבא קמא":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\31_MAS_KAMA\\ZDebugMix.txt";
                case "משנה - בבא מציעא - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L2.txt";
                case "משנה - בבא מציעא":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L1.txt";

                case "משנה - בבא מציעא - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L3.txt";
                case "משנה - בבא_מציעא - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\MNE_BABA_METSIA_L5.txt";
                case "משנה מסכת בבא מציעא":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\32_MAS_METSIA\\ZDebugMix.txt";
                case "משנה - בבא בתרא - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L2.txt";
                case "משנה - בבא בתרא":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L1.txt";

                case "משנה - בבא בתרא - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L3.txt";
                case "משנה - בבא_בתרא - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\MNE_BABA_BATRA_L5.txt";
                case "משנה מסכת בבא בתרא":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\33_MAS_BATRA\\ZDebugMix.txt";
                case "משנה - סנהדרין - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L2.txt";
                case "משנה - סנהדרין":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L1.txt";

                case "משנה - סנהדרין - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L3.txt";
                case "משנה - סנהדרין - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\MNE_SANHEDRIN_L5.txt";
                case "משנה מסכת סנהדרין":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\34_MAS_SANHEDRIN\\ZDebugMix.txt";
                case "משנה - מכות - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L2.txt";
                case "משנה - מכות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L1.txt";

                case "משנה - מכות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L3.txt";
                case "משנה - מכות - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\MNE_MAKOT_L5.txt";
                case "משנה מסכת מכות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\35_MAS_MAKOT\\ZDebugMix.txt";
                case "משנה - שבועות - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L2.txt";
                case "משנה - שבועות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L1.txt";

                case "משנה - שבועות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L3.txt";
                case "משנה - שבועות - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\MNE_SHVUOT_L5.txt";
                case "משנה מסכת שבועות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\36_MAS_SHVUOT\\ZDebugMix.txt";
                case "משנה - עדיות - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L2.txt";
                case "משנה - עדיות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L1.txt";

                case "משנה - עדיות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L3.txt";
                case "משנה - עדיות - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\MN22_EDUYOT_L5.txt";
                case "משנה מסכת עדיות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\37_MAS_EDUYOT\\ZDebugMix.txt";
                case "משנה - עבודה זרה - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L2.txt";
                case "משנה - עבודה זרה":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L1.txt";

                case "משנה - עבודה זרה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L3.txt";
                case "משנה - עבודה_זרה - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\MN22_AVODA_ZARA_L5.txt";
                case "משנה מסכת עבודה זרה":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\38_MAS_AVODA_ZARA\\ZDebugMix.txt";
                case "משנה - אבות - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L2.txt";
                case "משנה - אבות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L1.txt";

                case "משנה - אבות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L3.txt";
                case "משנה - אבות - רש''י":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L4.txt";
                case "משנה - אבות - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\MN22_AVOT_L5.txt";
                case "משנה מסכת אבות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\39_MAS_AVOT\\ZDebugMix.txt";
                case "משנה - הוריות - רע''ב":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L2.txt";
                case "משנה - הוריות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L1.txt";

                case "משנה - הוריות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L3.txt";
                case "משנה - הוריות - רמב''ם":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\MN22_HORAYOT_L5.txt";
                case "משנה מסכת הוריות":
                    return "Books\\020_MISHNA\\103_SEDER_NEZIKIN\\40_MAS_HORAYOT\\ZDebugMix.txt";
                case "משנה - זבחים - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L2.txt";
                case "משנה - זבחים":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L1.txt";

                case "משנה - זבחים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L3.txt";
                case "משנה - זבחים - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\MK_ZVAHIM_L5.txt";
                case "משנה מסכת זבחים":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\41_MAS_ZEVACHIM\\ZDebugMix.txt";
                case "משנה - מנחות - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L2.txt";
                case "משנה - מנחות":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L1.txt";

                case "משנה - מנחות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L3.txt";
                case "משנה - מנחות - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\MK_MENAHOT_L5.txt";
                case "משנה מסכת מנחות":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\42_MAS_MENACHOT\\ZDebugMix.txt";
                case "משנה - חולין - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L2.txt";
                case "משנה - חולין":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L1.txt";

                case "משנה - חולין - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L3.txt";
                case "משנה - חולין - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\MK_HULIN_L5.txt";
                case "משנה מסכת חולין":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\43_MAS_CHULIN\\ZDebugMix.txt";
                case "משנה - בכורות - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L2.txt";
                case "משנה - בכורות":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L1.txt";

                case "משנה - בכורות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L3.txt";
                case "משנה - בכורות - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\MK_BECHOROT_L5.txt";
                case "משנה מסכת בכורות":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\44_MAS_BECHOROT\\ZDebugMix.txt";
                case "משנה - ערכין - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L2.txt";
                case "משנה - ערכין":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L1.txt";

                case "משנה - ערכין - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L3.txt";
                case "משנה - ערכין - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\MK_ARACHIN_L5.txt";
                case "משנה מסכת ערכין":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\45_MAS_ARACHIN\\ZDebugMix.txt";
                case "משנה - תמורה - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L2.txt";
                case "משנה - תמורה":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L1.txt";

                case "משנה - תמורה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L3.txt";
                case "משנה - תמורה - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\MK_TMURA_L5.txt";
                case "משנה מסכת תמורה":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\46_MAS_TEMURA\\ZDebugMix.txt";
                case "משנה - כריתות - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L2.txt";
                case "משנה - כריתות":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L1.txt";

                case "משנה - כריתות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L3.txt";
                case "משנה - כריתות - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\MK_KRETOT_L5.txt";
                case "משנה מסכת כריתות":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\47_MAS_KRETOT\\ZDebugMix.txt";
                case "משנה - מעילה - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L2.txt";
                case "משנה - מעילה":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L1.txt";

                case "משנה - מעילה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L3.txt";
                case "משנה - מעילה - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\MK_MEILA_L5.txt";
                case "משנה מסכת מעילה":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\48_MAS_MEILA\\ZDebugMix.txt";
                case "משנה - תמיד - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L2.txt";
                case "משנה - תמיד":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L1.txt";

                case "משנה - תמיד - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L3.txt";
                case "משנה - תמיד - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\MK_TAMID_L5.txt";
                case "משנה מסכת תמיד":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\49_MAS_TAMID\\ZDebugMix.txt";
                case "משנה - מדות - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L2.txt";
                case "משנה - מדות":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L1.txt";

                case "משנה - מדות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L3.txt";
                case "משנה - מדות - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\MK_MIDOT_L5.txt";
                case "משנה מסכת מדות":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\50_MAS_MIDOT\\ZDebugMix.txt";
                case "משנה - קנים - רע''ב":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L2.txt";
                case "משנה - קנים":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L1.txt";

                case "משנה - קנים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L3.txt";
                case "משנה - קנים - רמב''ם":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\MK_KANIM_L5.txt";
                case "משנה מסכת קנים":
                    return "Books\\020_MISHNA\\104_SEDER_KADASHIM\\51_MAS_KANIM\\ZDebugMix.txt";
                case "משנה - כלים - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L2.txt";
                case "משנה - כלים":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L1.txt";

                case "משנה - כלים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L3.txt";
                case "משנה - כלים - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\MT_KELIM_L5.txt";
                case "משנה מסכת כלים":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\52_MAS_KELIM\\ZDebugMix.txt";
                case "משנה - אהלות - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L2.txt";
                case "משנה - אהלות":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L1.txt";

                case "משנה - אהלות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L3.txt";
                case "משנה - אהלות - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\MT_AHALOT_L5.txt";
                case "משנה מסכת אהלות":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\53_MAS_AHALOT\\ZDebugMix.txt";
                case "משנה - נגעים - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L2.txt";
                case "משנה - נגעים":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L1.txt";

                case "משנה - נגעים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L3.txt";
                case "משנה - נגעים - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\MT_NEGAIIM_L5.txt";
                case "משנה מסכת נגעים":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\54_MAS_NEGAIIM\\ZDebugMix.txt";
                case "משנה - פרה - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L2.txt";
                case "משנה - פרה":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L1.txt";

                case "משנה - פרה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L3.txt";
                case "משנה - פרה - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\MT_PARA_L5.txt";
                case "משנה מסכת פרה":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\55_MAS_PARA\\ZDebugMix.txt";
                case "משנה - טהרות - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L2.txt";
                case "משנה - טהרות":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L1.txt";

                case "משנה - טהרות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L3.txt";
                case "משנה - טהרות - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\MT_TAHAROT_L5.txt";
                case "משנה מסכת טהרות":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\56_MAS_TAHAROT\\ZDebugMix.txt";
                case "משנה - מקואות - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L2.txt";
                case "משנה - מקואות":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L1.txt";

                case "משנה - מקואות - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L3.txt";
                case "משנה - מקואות - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\MT_MIKVAOT_L5.txt";
                case "משנה מסכת מקוואות":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\57_MAS_MIKVAOT\\ZDebugMix.txt";
                case "משנה - נדה - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L2.txt";
                case "משנה - נדה":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L1.txt";

                case "משנה - נדה - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L3.txt";
                case "משנה - נדה - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\MT_NIDA_L5.txt";
                case "משנה מסכת נדה":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\58_MAS_NIDA\\ZDebugMix.txt";
                case "משנה - מכשירין - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L2.txt";
                case "משנה - מכשירין":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L1.txt";

                case "משנה - מכשירין - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L3.txt";
                case "משנה - מכשירין - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\MT_MACHSHIRIN_L5.txt";
                case "משנה מסכת מכשירין":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\59_MAS_MACHSHIRIN\\ZDebugMix.txt";
                case "משנה - זבים - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L2.txt";
                case "משנה - זבים":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L1.txt";

                case "משנה - זבים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L3.txt";
                case "משנה - זבים - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\MT_ZAVIM_L5.txt";
                case "משנה מסכת זבים":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\60_MAS_ZAVIM\\ZDebugMix.txt";
                case "משנה - טבול יום - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L2.txt";
                case "משנה - טבול יום":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L1.txt";

                case "משנה - טבול יום - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L3.txt";
                case "משנה - טבול_יום - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\MT_TVULYOM_L5.txt";
                case "משנה מסכת טבול יום":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\61_MAS_TEVUL_YOM\\ZDebugMix.txt";
                case "משנה - ידים - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L2.txt";
                case "משנה - ידים":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L1.txt";

                case "משנה - ידים - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L3.txt";
                case "משנה - ידים - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\MT_YADAIIM_L5.txt";
                case "משנה מסכת ידים":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\62_MAS_YADAIIM\\ZDebugMix.txt";
                case "משנה - עוקצין - רע''ב":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L2.txt";
                case "משנה - עוקצין":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L1.txt";

                case "משנה - עוקצין - עיקר תוי''ט":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L3.txt";
                case "משנה - עוקצין - רמב''ם":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\MT_OKATSIN_L5.txt";
                case "משנה מסכת עוקצין":
                    return "Books\\020_MISHNA\\105_SEDER_TAHAROT\\63_MAS_OKATSIN\\ZDebugMix.txt";

                case "תלמוד בבלי - ברכות - רש''י":
                    return "Books\\030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L2.txt";
                case "תלמוד בבלי - ברכות":
                    return "Books\\030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L1.txt";

                case "תלמוד בבלי - ברכות - תוספות":
                    return "Books\\030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L3.txt";
                case "רשב''א - מסכת ברכות":
                    return "Books\\030_BAVLI\\01_MAS_BRACHOT\\01_Bav BRAHOT_L6_rashba.txt";
                case "מסכת ברכות":
                    return "Books\\030_BAVLI\\01_MAS_BRACHOT\\DebugMix.txt";
                case "חברותא - ברכות":
                    return "Books\\030_BAVLI\\01_MAS_BRACHOT\\HavAll.txt";
                case "חברותא - ברכות - בלי הערות":
                    return "Books\\030_BAVLI\\01_MAS_BRACHOT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 1":
                    return "Books\\030_BAVLI\\01_MAS_BRACHOT\\HavTempNotes.txt";
                case "תלמוד בבלי - שבת - רש''י":
                    return "Books\\030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L2.txt";
                case "תלמוד בבלי - שבת":
                    return "Books\\030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L1.txt";

                case "תלמוד בבלי - שבת - תוספות":
                    return "Books\\030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L3.txt";
                case "רשב''א - מסכת שבת":
                    return "Books\\030_BAVLI\\02_MAS_SHABAT\\02_Bav SHABAT_L6_rashba.txt";
                case "מסכת שבת":
                    return "Books\\030_BAVLI\\02_MAS_SHABAT\\DebugMix.txt";
                case "חברותא - שבת":
                    return "Books\\030_BAVLI\\02_MAS_SHABAT\\HavAll.txt";
                case "חברותא - שבת - בלי הערות":
                    return "Books\\030_BAVLI\\02_MAS_SHABAT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 2":
                    return "Books\\030_BAVLI\\02_MAS_SHABAT\\HavTempNotes.txt";
                case "תלמוד בבלי - עירובין - רש''י":
                    return "Books\\030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L2.txt";
                case "תלמוד בבלי - עירובין":
                    return "Books\\030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L1.txt";

                case "תלמוד בבלי - עירובין - תוספות":
                    return "Books\\030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L3.txt";
                case "רשב''א - מסכת עירובין":
                    return "Books\\030_BAVLI\\03_MAS_ERUVIN\\03_Bav ERUVIN_L6_rashba.txt";
                case "מסכת עירובין":
                    return "Books\\030_BAVLI\\03_MAS_ERUVIN\\DebugMix.txt";
                case "חברותא - עירובין":
                    return "Books\\030_BAVLI\\03_MAS_ERUVIN\\HavAll.txt";
                case "חברותא - עירובין - בלי הערות":
                    return "Books\\030_BAVLI\\03_MAS_ERUVIN\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 3":
                    return "Books\\030_BAVLI\\03_MAS_ERUVIN\\HavTempNotes.txt";
                case "תלמוד בבלי - פסחים - רש''י":
                    return "Books\\030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L2.txt";
                case "תלמוד בבלי - פסחים":
                    return "Books\\030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L1.txt";

                case "תלמוד בבלי - פסחים - תוספות":
                    return "Books\\030_BAVLI\\04_MAS_PSACHIM\\04_Bav PSAHIM_L3.txt";
                case "תלמוד בבלי - פסחים - רשב''ם":
                    return "Books\\030_BAVLI\\04_MAS_PSACHIM\\Bav PSAHIM_L4.txt";
                case "מסכת פסחים":
                    return "Books\\030_BAVLI\\04_MAS_PSACHIM\\DebugMix.txt";
                case "חברותא - פסחים":
                    return "Books\\030_BAVLI\\04_MAS_PSACHIM\\HavAll.txt";
                case "חברותא - פסחים - בלי הערות":
                    return "Books\\030_BAVLI\\04_MAS_PSACHIM\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 4":
                    return "Books\\030_BAVLI\\04_MAS_PSACHIM\\HavTempNotes.txt";
                case "[2] תלמוד ירושלמי - שקלים - קרבן העדה":
                    return "Books\\030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L2.txt";
                case "[1] תלמוד ירושלמי - שקלים - קרבן העדה":
                    return "Books\\030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L1.txt";

                case "תלמוד ירושלמי - שקלים - ריבב''ן":
                    return "Books\\030_BAVLI\\05_MAS_SHKALIM\\04_Bav SHKALIM (yer)_L3.txt";
                case "מסכת שקלים":
                    return "Books\\030_BAVLI\\05_MAS_SHKALIM\\DebugMix.txt";
                case "חברותא - שקלים":
                    return "Books\\030_BAVLI\\05_MAS_SHKALIM\\HavAll.txt";
                case "חברותא - שקלים - בלי הערות":
                    return "Books\\030_BAVLI\\05_MAS_SHKALIM\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 5":
                    return "Books\\030_BAVLI\\05_MAS_SHKALIM\\HavTempNotes.txt";
                case "תלמוד בבלי - ראש השנה - רש''י":
                    return "Books\\030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L2.txt";
                case "תלמוד בבלי - ראש השנה":
                    return "Books\\030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L1.txt";

                case "תלמוד בבלי - ראש השנה - תוספות":
                    return "Books\\030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L3.txt";
                case "רשב''א - מסכת ראש השנה":
                    return "Books\\030_BAVLI\\06_MAS_ROSH\\Bav ROSH HASHANA_L6_rashba.txt";
                case "מסכת ראש השנה":
                    return "Books\\030_BAVLI\\06_MAS_ROSH\\DebugMix.txt";
                case "חברותא - ראש השנה":
                    return "Books\\030_BAVLI\\06_MAS_ROSH\\HavAll.txt";
                case "חברותא - ראש השנה - בלי הערות":
                    return "Books\\030_BAVLI\\06_MAS_ROSH\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 6":
                    return "Books\\030_BAVLI\\06_MAS_ROSH\\HavTempNotes.txt";
                case "תלמוד בבלי - יומא - רש''י":
                    return "Books\\030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L2.txt";
                case "תלמוד בבלי - יומא":
                    return "Books\\030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L1.txt";

                case "תלמוד בבלי - יומא - תוספות":
                    return "Books\\030_BAVLI\\07_MAS_YOMA\\07_Bav YOMA_L3.txt";
                case "מסכת יומא":
                    return "Books\\030_BAVLI\\07_MAS_YOMA\\DebugMix.txt";
                case "חברותא - יומא":
                    return "Books\\030_BAVLI\\07_MAS_YOMA\\HavAll.txt";
                case "חברותא - יומא - בלי הערות":
                    return "Books\\030_BAVLI\\07_MAS_YOMA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 7":
                    return "Books\\030_BAVLI\\07_MAS_YOMA\\HavTempNotes.txt";
                case "תלמוד בבלי - סוכה - רש''י":
                    return "Books\\030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L2.txt";
                case "תלמוד בבלי - סוכה":
                    return "Books\\030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L1.txt";

                case "תלמוד בבלי - סוכה - תוספות":
                    return "Books\\030_BAVLI\\08_MAS_SUCA\\08_Bav SUCA_L3.txt";
                case "מסכת סוכה":
                    return "Books\\030_BAVLI\\08_MAS_SUCA\\DebugMix.txt";
                case "חברותא - סוכה":
                    return "Books\\030_BAVLI\\08_MAS_SUCA\\HavAll.txt";
                case "חברותא - סוכה - בלי הערות":
                    return "Books\\030_BAVLI\\08_MAS_SUCA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 8":
                    return "Books\\030_BAVLI\\08_MAS_SUCA\\HavTempNotes.txt";
                case "תלמוד בבלי - ביצה - רש''י":
                    return "Books\\030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L2.txt";
                case "תלמוד בבלי - ביצה":
                    return "Books\\030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L1.txt";

                case "תלמוד בבלי - ביצה - תוספות":
                    return "Books\\030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L3.txt";
                case "רשב''א - מסכת ביצה":
                    return "Books\\030_BAVLI\\09_MAS_BEITSA\\09_Bav BEITSA_L6_rashba.txt";
                case "מסכת ביצה":
                    return "Books\\030_BAVLI\\09_MAS_BEITSA\\DebugMix.txt";
                case "חברותא - ביצה":
                    return "Books\\030_BAVLI\\09_MAS_BEITSA\\HavAll.txt";
                case "חברותא - ביצה - בלי הערות":
                    return "Books\\030_BAVLI\\09_MAS_BEITSA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 9":
                    return "Books\\030_BAVLI\\09_MAS_BEITSA\\HavTempNotes.txt";
                case "תלמוד בבלי - תענית - רש''י":
                    return "Books\\030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L2.txt";
                case "תלמוד בבלי - תענית":
                    return "Books\\030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L1.txt";

                case "תלמוד בבלי - תענית - תוספות":
                    return "Books\\030_BAVLI\\10_MAS_TAANIT\\10_Bav TAANIT_L3.txt";
                case "מסכת תענית":
                    return "Books\\030_BAVLI\\10_MAS_TAANIT\\DebugMix.txt";
                case "חברותא - תענית":
                    return "Books\\030_BAVLI\\10_MAS_TAANIT\\HavAll.txt";
                case "חברותא - תענית - בלי הערות":
                    return "Books\\030_BAVLI\\10_MAS_TAANIT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 10":
                    return "Books\\030_BAVLI\\10_MAS_TAANIT\\HavTempNotes.txt";
                case "תלמוד בבלי - מגילה - רש''י":
                    return "Books\\030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L2.txt";
                case "תלמוד בבלי - מגילה":
                    return "Books\\030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L1.txt";

                case "תלמוד בבלי - מגילה - תוספות":
                    return "Books\\030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L3.txt";
                case "רשב''א - מסכת מגילה":
                    return "Books\\030_BAVLI\\11_MAS_MEGILA\\11_Bav MEGILA_L6_rashba.txt";
                case "מסכת מגילה":
                    return "Books\\030_BAVLI\\11_MAS_MEGILA\\DebugMix.txt";
                case "חברותא - מגילה":
                    return "Books\\030_BAVLI\\11_MAS_MEGILA\\HavAll.txt";
                case "חברותא - מגילה - בלי הערות":
                    return "Books\\030_BAVLI\\11_MAS_MEGILA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 11":
                    return "Books\\030_BAVLI\\11_MAS_MEGILA\\HavTempNotes.txt";
                case "תלמוד בבלי - מועד קטן - רש''י":
                    return "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L2.txt";
                case "תלמוד בבלי - מועד קטן":
                    return "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L1.txt";

                case "תלמוד בבלי - מועד קטן - תוספות":
                    return "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\12_Bav MOED KATAN_L3.txt";
                case "מסכת מועד קטן":
                    return "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\DebugMix.txt";
                case "חברותא - מועד קטן":
                    return "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\HavAll.txt";
                case "חברותא - מועד קטן - בלי הערות":
                    return "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 12":
                    return "Books\\030_BAVLI\\12_MAS_MOED_KATAN\\HavTempNotes.txt";
                case "תלמוד בבלי - חגיגה - רש''י":
                    return "Books\\030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L2.txt";
                case "תלמוד בבלי - חגיגה":
                    return "Books\\030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L1.txt";

                case "תלמוד בבלי - חגיגה - תוספות":
                    return "Books\\030_BAVLI\\13_MAS_HAGIGA\\Bav HAGIGA_L3.txt";
                case "מסכת חגיגה":
                    return "Books\\030_BAVLI\\13_MAS_HAGIGA\\DebugMix.txt";
                case "חברותא - חגיגה":
                    return "Books\\030_BAVLI\\13_MAS_HAGIGA\\HavAll.txt";
                case "חברותא - חגיגה - בלי הערות":
                    return "Books\\030_BAVLI\\13_MAS_HAGIGA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 13":
                    return "Books\\030_BAVLI\\13_MAS_HAGIGA\\HavTempNotes.txt";
                case "תלמוד בבלי - יבמות - רש''י":
                    return "Books\\030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L2.txt";
                case "תלמוד בבלי - יבמות":
                    return "Books\\030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L1.txt";

                case "תלמוד בבלי - יבמות - תוספות":
                    return "Books\\030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L3.txt";
                case "רשב''א - מסכת יבמות":
                    return "Books\\030_BAVLI\\14_MAS_YEVAMOT\\14_Bav YEVAMOT_L6_rashba.txt";
                case "מסכת יבמות":
                    return "Books\\030_BAVLI\\14_MAS_YEVAMOT\\DebugMix.txt";
                case "חברותא - יבמות":
                    return "Books\\030_BAVLI\\14_MAS_YEVAMOT\\HavAll.txt";
                case "חברותא - יבמות - בלי הערות":
                    return "Books\\030_BAVLI\\14_MAS_YEVAMOT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 14":
                    return "Books\\030_BAVLI\\14_MAS_YEVAMOT\\HavTempNotes.txt";
                case "תלמוד בבלי - כתובות - רש''י":
                    return "Books\\030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L2.txt";
                case "תלמוד בבלי - כתובות":
                    return "Books\\030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L1.txt";

                case "תלמוד בבלי - כתובות - תוספות":
                    return "Books\\030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L3.txt";
                case "רשב''א - מסכת כתובות":
                    return "Books\\030_BAVLI\\15_MAS_KTUBOT\\15_Bav KTUBOT_L6_rashba.txt";
                case "מסכת כתובות":
                    return "Books\\030_BAVLI\\15_MAS_KTUBOT\\DebugMix.txt";
                case "חברותא - כתובות":
                    return "Books\\030_BAVLI\\15_MAS_KTUBOT\\HavAll.txt";
                case "חברותא - כתובות - בלי הערות":
                    return "Books\\030_BAVLI\\15_MAS_KTUBOT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 15":
                    return "Books\\030_BAVLI\\15_MAS_KTUBOT\\HavTempNotes.txt";
                case "תלמוד בבלי - נדרים - רש''י":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L2.txt";
                case "תלמוד בבלי - נדרים":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L1.txt";

                case "תלמוד בבלי - נדרים - תוספות":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L3.txt";
                case "תלמוד בבלי - נדרים - ר''נ":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L4.txt";
                case "רשב''א - מסכת נדרים":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\16_Bav NEDARIM_L6_rashba.txt";
                case "מסכת נדרים":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\DebugMix.txt";
                case "חברותא - נדרים":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\HavAll.txt";
                case "חברותא - נדרים - בלי הערות":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 16":
                    return "Books\\030_BAVLI\\16_MAS_NEDARIM\\HavTempNotes.txt";
                case "תלמוד בבלי - נזיר - רש''י":
                    return "Books\\030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L2.txt";
                case "תלמוד בבלי - נזיר":
                    return "Books\\030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L1.txt";

                case "תלמוד בבלי - נזיר - תוספות":
                    return "Books\\030_BAVLI\\17_MAS_NAZIR\\17_Bav NAZIR_L3.txt";
                case "מסכת נזיר":
                    return "Books\\030_BAVLI\\17_MAS_NAZIR\\DebugMix.txt";
                case "חברותא - נזיר":
                    return "Books\\030_BAVLI\\17_MAS_NAZIR\\HavAll.txt";
                case "חברותא - נזיר - בלי הערות":
                    return "Books\\030_BAVLI\\17_MAS_NAZIR\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 17":
                    return "Books\\030_BAVLI\\17_MAS_NAZIR\\HavTempNotes.txt";
                case "תלמוד בבלי - סוטה - רש''י":
                    return "Books\\030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L2.txt";
                case "תלמוד בבלי - סוטה":
                    return "Books\\030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L1.txt";

                case "תלמוד בבלי - סוטה - תוספות":
                    return "Books\\030_BAVLI\\18_MAS_SOTA\\18_Bav SOTA_L3.txt";
                case "מסכת סוטה":
                    return "Books\\030_BAVLI\\18_MAS_SOTA\\DebugMix.txt";
                case "חברותא - סוטה":
                    return "Books\\030_BAVLI\\18_MAS_SOTA\\HavAll.txt";
                case "חברותא - סוטה - בלי הערות":
                    return "Books\\030_BAVLI\\18_MAS_SOTA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 18":
                    return "Books\\030_BAVLI\\18_MAS_SOTA\\HavTempNotes.txt";
                case "תלמוד בבלי - גיטין - רש''י":
                    return "Books\\030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L2.txt";
                case "תלמוד בבלי - גיטין":
                    return "Books\\030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L1.txt";

                case "תלמוד בבלי - גיטין - תוספות":
                    return "Books\\030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L3.txt";
                case "רשב''א - מסכת גיטין":
                    return "Books\\030_BAVLI\\19_MAS_GITIN\\19_Bav GITIN_L6_rashba.txt";
                case "מסכת גיטין":
                    return "Books\\030_BAVLI\\19_MAS_GITIN\\DebugMix.txt";
                case "חברותא - גיטין":
                    return "Books\\030_BAVLI\\19_MAS_GITIN\\HavAll.txt";
                case "חברותא - גיטין - בלי הערות":
                    return "Books\\030_BAVLI\\19_MAS_GITIN\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 19":
                    return "Books\\030_BAVLI\\19_MAS_GITIN\\HavTempNotes.txt";
                case "תלמוד בבלי - קידושין - רש''י":
                    return "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L2.txt";
                case "תלמוד בבלי - קידושין":
                    return "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L1.txt";

                case "תלמוד בבלי - קידושין - תוספות":
                    return "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L3.txt";
                case "רשב''א - מסכת קידושין":
                    return "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\20_Bav KIDUSHIN_L6_rashba.txt";
                case "מסכת קידושין":
                    return "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\DebugMix.txt";
                case "חברותא - קידושין":
                    return "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\HavAll.txt";
                case "חברותא - קידושין - בלי הערות":
                    return "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 20":
                    return "Books\\030_BAVLI\\20_MAS_KIDUSHIN\\HavTempNotes.txt";
                case "תלמוד בבלי - בבא קמא - רש''י":
                    return "Books\\030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L2.txt";
                case "תלמוד בבלי - בבא קמא":
                    return "Books\\030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L1.txt";

                case "תלמוד בבלי - בבא קמא - תוספות":
                    return "Books\\030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L3.txt";
                case "רשב''א - מסכת בבא קמא":
                    return "Books\\030_BAVLI\\21_MAS_KAMA\\Bav BABA KAMA_L6_rashba.txt";
                case "מסכת בבא קמא":
                    return "Books\\030_BAVLI\\21_MAS_KAMA\\DebugMix.txt";
                case "חברותא - בבא קמא":
                    return "Books\\030_BAVLI\\21_MAS_KAMA\\HavAll.txt";
                case "חברותא - בבא קמא - בלי הערות":
                    return "Books\\030_BAVLI\\21_MAS_KAMA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 21":
                    return "Books\\030_BAVLI\\21_MAS_KAMA\\HavTempNotes.txt";
                case "תלמוד בבלי - בבא מציעא - רש''י":
                    return "Books\\030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L2.txt";
                case "תלמוד בבלי - בבא מציעא":
                    return "Books\\030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L1.txt";

                case "תלמוד בבלי - בבא מציעא - תוספות":
                    return "Books\\030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L3.txt";
                case "רשב''א - מסכת בבא מציעא":
                    return "Books\\030_BAVLI\\22_MAS_METSIA\\22_Bav BABA METSIA_L6_rashba.txt";
                case "מסכת בבא מציעא":
                    return "Books\\030_BAVLI\\22_MAS_METSIA\\DebugMix.txt";
                case "חברותא - בבא מציעא":
                    return "Books\\030_BAVLI\\22_MAS_METSIA\\HavAll.txt";
                case "חברותא - בבא מציעא - בלי הערות":
                    return "Books\\030_BAVLI\\22_MAS_METSIA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 22":
                    return "Books\\030_BAVLI\\22_MAS_METSIA\\HavTempNotes.txt";
                case "תלמוד בבלי - בבא בתרא - רש''י":
                    return "Books\\030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L2.txt";
                case "תלמוד בבלי - בבא בתרא":
                    return "Books\\030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L1.txt";

                case "תלמוד בבלי - בבא בתרא - תוספות":
                    return "Books\\030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L3.txt";
                case "רשב''א - מסכת בבא בתרא":
                    return "Books\\030_BAVLI\\23_MAS_BATRA\\23_Bav BABA BATRA_L6_rashba.txt";
                case "מסכת בבא בתרא":
                    return "Books\\030_BAVLI\\23_MAS_BATRA\\DebugMix.txt";
                case "חברותא - בבא בתרא":
                    return "Books\\030_BAVLI\\23_MAS_BATRA\\HavAll.txt";
                case "חברותא - בבא בתרא - בלי הערות":
                    return "Books\\030_BAVLI\\23_MAS_BATRA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 23":
                    return "Books\\030_BAVLI\\23_MAS_BATRA\\HavTempNotes.txt";
                case "תלמוד בבלי - סנהדרין - רש''י":
                    return "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L2.txt";
                case "תלמוד בבלי - סנהדרין":
                    return "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L1.txt";

                case "תלמוד בבלי - סנהדרין - תוספות":
                    return "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\Bav SANHEDRIN_L3.txt";
                case "מסכת סנהדרין":
                    return "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\DebugMix.txt";
                case "חברותא - סנהדרין":
                    return "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\HavAll.txt";
                case "חברותא - סנהדרין - בלי הערות":
                    return "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 24":
                    return "Books\\030_BAVLI\\24_MAS_SANHEDRIN\\HavTempNotes.txt";
                case "תלמוד בבלי - מכות - רש''י":
                    return "Books\\030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L2.txt";
                case "תלמוד בבלי - מכות":
                    return "Books\\030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L1.txt";

                case "תלמוד בבלי - מכות - תוספות":
                    return "Books\\030_BAVLI\\25_MAS_MAKOT\\Bav MAKOT_L3.txt";
                case "מסכת מכות":
                    return "Books\\030_BAVLI\\25_MAS_MAKOT\\DebugMix.txt";
                case "חברותא - מכות":
                    return "Books\\030_BAVLI\\25_MAS_MAKOT\\HavAll.txt";
                case "חברותא - מכות - בלי הערות":
                    return "Books\\030_BAVLI\\25_MAS_MAKOT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 25":
                    return "Books\\030_BAVLI\\25_MAS_MAKOT\\HavTempNotes.txt";
                case "תלמוד בבלי - שבועות - רש''י":
                    return "Books\\030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L2.txt";
                case "תלמוד בבלי - שבועות":
                    return "Books\\030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L1.txt";

                case "תלמוד בבלי - שבועות - תוספות":
                    return "Books\\030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L3.txt";
                case "רשב''א - מסכת שבועות":
                    return "Books\\030_BAVLI\\26_MAS_SHVUOT\\Bav SHVUOT_L6_rashba.txt";
                case "מסכת שבועות":
                    return "Books\\030_BAVLI\\26_MAS_SHVUOT\\DebugMix.txt";
                case "חברותא - שבועות":
                    return "Books\\030_BAVLI\\26_MAS_SHVUOT\\HavAll.txt";
                case "חברותא - שבועות - בלי הערות":
                    return "Books\\030_BAVLI\\26_MAS_SHVUOT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 26":
                    return "Books\\030_BAVLI\\26_MAS_SHVUOT\\HavTempNotes.txt";
                case "תלמוד בבלי - עבודה זרה - רש''י":
                    return "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L2.txt";
                case "תלמוד בבלי - עבודה זרה":
                    return "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L1.txt";

                case "תלמוד בבלי - עבודה זרה - תוספות":
                    return "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L3.txt";
                case "רשב''א - מסכת עבודה זרה":
                    return "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\Bav AVODA ZARA_L6_rashba.txt";
                case "מסכת עבודה זרה":
                    return "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\DebugMix.txt";
                case "חברותא - עבודה זרה":
                    return "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\HavAll.txt";
                case "חברותא - עבודה זרה - בלי הערות":
                    return "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 27":
                    return "Books\\030_BAVLI\\27_MAS_AVODA_ZARA\\HavTempNotes.txt";
                case "תלמוד בבלי - הוריות - רש''י":
                    return "Books\\030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L2.txt";
                case "תלמוד בבלי - הוריות":
                    return "Books\\030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L1.txt";

                case "תלמוד בבלי - הוריות - תוספות":
                    return "Books\\030_BAVLI\\28_MAS_HORAYOT\\Bav HORAYOT_L3.txt";
                case "מסכת הוריות":
                    return "Books\\030_BAVLI\\28_MAS_HORAYOT\\DebugMix.txt";
                case "חברותא - הוריות":
                    return "Books\\030_BAVLI\\28_MAS_HORAYOT\\HavAll.txt";
                case "חברותא - הוריות - בלי הערות":
                    return "Books\\030_BAVLI\\28_MAS_HORAYOT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 28":
                    return "Books\\030_BAVLI\\28_MAS_HORAYOT\\HavTempNotes.txt";
                case "תלמוד בבלי - זבחים - רש''י":
                    return "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L2.txt";
                case "תלמוד בבלי - זבחים":
                    return "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L1.txt";

                case "תלמוד בבלי - זבחים - תוספות":
                    return "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\Bav ZVAHIM_L3.txt";
                case "מסכת זבחים":
                    return "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\DebugMix.txt";
                case "חברותא - זבחים":
                    return "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\HavAll.txt";
                case "חברותא - זבחים - בלי הערות":
                    return "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 29":
                    return "Books\\030_BAVLI\\30_MAS_ZEVACHIM\\HavTempNotes.txt";
                case "תלמוד בבלי - מנחות - רש''י":
                    return "Books\\030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L2.txt";
                case "תלמוד בבלי - מנחות":
                    return "Books\\030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L1.txt";

                case "תלמוד בבלי - מנחות - תוספות":
                    return "Books\\030_BAVLI\\31_MAS_MENACHOT\\Bav MENAHOT_L3.txt";
                case "מסכת מנחות":
                    return "Books\\030_BAVLI\\31_MAS_MENACHOT\\DebugMix.txt";
                case "חברותא - מנחות":
                    return "Books\\030_BAVLI\\31_MAS_MENACHOT\\HavAll.txt";
                case "חברותא - מנחות - בלי הערות":
                    return "Books\\030_BAVLI\\31_MAS_MENACHOT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 30":
                    return "Books\\030_BAVLI\\31_MAS_MENACHOT\\HavTempNotes.txt";
                case "תלמוד בבלי - חולין - רש''י":
                    return "Books\\030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L2.txt";
                case "תלמוד בבלי - חולין":
                    return "Books\\030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L1.txt";

                case "תלמוד בבלי - חולין - תוספות":
                    return "Books\\030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L3.txt";
                case "רשב''א - מסכת חולין":
                    return "Books\\030_BAVLI\\32_MAS_CHULIN\\Bav HULIN_L6_rashba.txt";
                case "מסכת חולין":
                    return "Books\\030_BAVLI\\32_MAS_CHULIN\\DebugMix.txt";
                case "חברותא - חולין":
                    return "Books\\030_BAVLI\\32_MAS_CHULIN\\HavAll.txt";
                case "חברותא - חולין - בלי הערות":
                    return "Books\\030_BAVLI\\32_MAS_CHULIN\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 31":
                    return "Books\\030_BAVLI\\32_MAS_CHULIN\\HavTempNotes.txt";
                case "תלמוד בבלי - בכורות - רש''י":
                    return "Books\\030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L2.txt";
                case "תלמוד בבלי - בכורות":
                    return "Books\\030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L1.txt";

                case "תלמוד בבלי - בכורות - תוספות":
                    return "Books\\030_BAVLI\\33_MAS_BECHOROT\\Bav BECHOROT_L3.txt";
                case "מסכת בכורות":
                    return "Books\\030_BAVLI\\33_MAS_BECHOROT\\DebugMix.txt";
                case "חברותא - בכורות":
                    return "Books\\030_BAVLI\\33_MAS_BECHOROT\\HavAll.txt";
                case "חברותא - בכורות - בלי הערות":
                    return "Books\\030_BAVLI\\33_MAS_BECHOROT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 32":
                    return "Books\\030_BAVLI\\33_MAS_BECHOROT\\HavTempNotes.txt";
                case "תלמוד בבלי - ערכין - רש''י":
                    return "Books\\030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L2.txt";
                case "תלמוד בבלי - ערכין":
                    return "Books\\030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L1.txt";

                case "תלמוד בבלי - ערכין - תוספות":
                    return "Books\\030_BAVLI\\34_MAS_ARACHIN\\Bav ARACHIN_L3.txt";
                case "מסכת ערכין":
                    return "Books\\030_BAVLI\\34_MAS_ARACHIN\\DebugMix.txt";
                case "חברותא - ערכין":
                    return "Books\\030_BAVLI\\34_MAS_ARACHIN\\HavAll.txt";
                case "חברותא - ערכין - בלי הערות":
                    return "Books\\030_BAVLI\\34_MAS_ARACHIN\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 33":
                    return "Books\\030_BAVLI\\34_MAS_ARACHIN\\HavTempNotes.txt";
                case "תלמוד בבלי - תמורה - רש''י":
                    return "Books\\030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L2.txt";
                case "תלמוד בבלי - תמורה":
                    return "Books\\030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L1.txt";

                case "תלמוד בבלי - תמורה - תוספות":
                    return "Books\\030_BAVLI\\35_MAS_TEMURA\\Bav TMURA_L3.txt";
                case "מסכת תמורה":
                    return "Books\\030_BAVLI\\35_MAS_TEMURA\\DebugMix.txt";
                case "חברותא - תמורה":
                    return "Books\\030_BAVLI\\35_MAS_TEMURA\\HavAll.txt";
                case "חברותא - תמורה - בלי הערות":
                    return "Books\\030_BAVLI\\35_MAS_TEMURA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 34":
                    return "Books\\030_BAVLI\\35_MAS_TEMURA\\HavTempNotes.txt";
                case "תלמוד בבלי - כריתות - רש''י":
                    return "Books\\030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L2.txt";
                case "תלמוד בבלי - כריתות":
                    return "Books\\030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L1.txt";

                case "תלמוד בבלי - כריתות - תוספות":
                    return "Books\\030_BAVLI\\36_MAS_KRETOT\\Bav KRETOT_L3.txt";
                case "מסכת כריתות":
                    return "Books\\030_BAVLI\\36_MAS_KRETOT\\DebugMix.txt";
                case "חברותא - כריתות":
                    return "Books\\030_BAVLI\\36_MAS_KRETOT\\HavAll.txt";
                case "חברותא - כריתות - בלי הערות":
                    return "Books\\030_BAVLI\\36_MAS_KRETOT\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 35":
                    return "Books\\030_BAVLI\\36_MAS_KRETOT\\HavTempNotes.txt";
                case "תלמוד בבלי - מעילה - רש''י":
                    return "Books\\030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L2.txt";
                case "תלמוד בבלי - מעילה":
                    return "Books\\030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L1.txt";

                case "תלמוד בבלי - מעילה - תוספות":
                    return "Books\\030_BAVLI\\37_MAS_MEILA\\Bav MEIILA_L3.txt";
                case "מסכת מעילה":
                    return "Books\\030_BAVLI\\37_MAS_MEILA\\DebugMix.txt";
                case "חברותא - מעילה":
                    return "Books\\030_BAVLI\\37_MAS_MEILA\\HavAll.txt";
                case "חברותא - מעילה - בלי הערות":
                    return "Books\\030_BAVLI\\37_MAS_MEILA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 36":
                    return "Books\\030_BAVLI\\37_MAS_MEILA\\HavTempNotes.txt";
                case "[2] תלמוד בבלי - תמיד - פירוש":
                    return "Books\\030_BAVLI\\38_MAS_TAMID\\BAV TAMID_L2.txt";
                case "[1] תלמוד בבלי - תמיד - פירוש":
                    return "Books\\030_BAVLI\\38_MAS_TAMID\\BAV TAMID_L1.txt";

                case "מסכת תמיד":
                    return "Books\\030_BAVLI\\38_MAS_TAMID\\DebugMix.txt";
                case "חברותא - תמיד":
                    return "Books\\030_BAVLI\\38_MAS_TAMID\\HavAll.txt";
                case "חברותא - תמיד - בלי הערות":
                    return "Books\\030_BAVLI\\38_MAS_TAMID\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 37":
                    return "Books\\030_BAVLI\\38_MAS_TAMID\\HavTempNotes.txt";
                case "תלמוד בבלי - נדה - רש''י":
                    return "Books\\030_BAVLI\\39_MAS_NIDA\\Bav Nida_L2.txt";
                case "תלמוד בבלי - נדה":
                    return "Books\\030_BAVLI\\39_MAS_NIDA\\Bav Nida_L1.txt";

                case "תלמוד בבלי - נדה - תוספות":
                    return "Books\\030_BAVLI\\39_MAS_NIDA\\Bav Nida_L3.txt";
                case "רשב''א - מסכת נדה":
                    return "Books\\030_BAVLI\\39_MAS_NIDA\\Bav Nida_L6_rashba.txt";
                case "מסכת נדה":
                    return "Books\\030_BAVLI\\39_MAS_NIDA\\DebugMix.txt";
                case "חברותא - נידה":
                    return "Books\\030_BAVLI\\39_MAS_NIDA\\HavAll.txt";
                case "חברותא - נידה - בלי הערות":
                    return "Books\\030_BAVLI\\39_MAS_NIDA\\HavTempNoNotes.txt";
                case "חברותא - זמני - הערות - 38":
                    return "Books\\030_BAVLI\\39_MAS_NIDA\\HavTempNotes.txt";
                case "הקדמת הרמב''ם למשנה תורה":
                    return "Books\\035_RAMBAM\\ 00000_RAMBAM-MRG_NEW.txt ";
                case "משנה תורה - ספר המצוות":
                    return "Books\\035_RAMBAM\\00001_RAMBAM-MRG_L1.txt";


                case "משנה תורה - ספר המדע":
                    return "Books\\035_RAMBAM\\0030_RAMBAM_MADA_L1.txt";
                case "[1] - משנה תורה - ספר אהבה":
                    return "Books\\035_RAMBAM\\0040_RAMBAM AHAVA_L1.txt";
                case "[1] - משנה תורה - ספר זמנים":
                    return "Books\\035_RAMBAM\\0050_RAMBAM-ZMANIM_L1.txt";
                case "[1] - משנה תורה - ספר נשים":
                    return "Books\\035_RAMBAM\\0060_RAMBAM-NASHIM_L1.txt";
                case "[1] - משנה תורה - ספר קדושה":
                    return "Books\\035_RAMBAM\\0070_RAMBAM KDUSHA_L1.txt";
                case "[1] - משנה תורה - ספר הפלאה":
                    return "Books\\035_RAMBAM\\0080_RAMBAM-HAFLAA_L1.txt";
                case "[1] - משנה תורה - ספר זרעים":
                    return "Books\\035_RAMBAM\\0090_RAMBAM_ZRAIIM_L1.txt";
                case "[1] - משנה תורה - ספר עבודה":
                    return "Books\\035_RAMBAM\\0100_RAMBAM AVODA_L1.txt";
                case "[1] - משנה תורה - ספר הקרבנות":
                    return "Books\\035_RAMBAM\\0110_RAMBAM KORBANOT_L1.txt";
                case "[1] - משנה תורה - ספר טהרה":
                    return "Books\\035_RAMBAM\\0120_RAMBAM TAHARA_L1.txt";
                case "[1] - משנה תורה - ספר נזיקין":
                    return "Books\\035_RAMBAM\\0130_RAMBAM NEZIKIN_L1.txt";
                case "[1] - משנה תורה - ספר קנין":
                    return "Books\\035_RAMBAM\\0140_RAMBAM_KINYAN_L1.txt";
                case "[1] - משנה תורה - ספר משפטים":
                    return "Books\\035_RAMBAM\\0150_RAMBAM_MISPATIM_L1.txt";
                case "[1] - משנה תורה - ספר שופטים":
                    return "Books\\035_RAMBAM\\0160_RAMBAM_SHOFTIM_L1.txt";
                case "[1] - משנה תורה - ספר מדע":
                    return "Books\\035_RAMBAM\\90002_mada.txt";
                case "כסף משנה - מדע":
                    return "Books\\035_RAMBAM\\90002_mada_kesef.txt";
                case "לחם משנה - מדע":
                    return "Books\\035_RAMBAM\\90002_mada_lechem.txt";
                case "פירוש - ספר מדע":
                    return "Books\\035_RAMBAM\\90002_mada_perush.txt";
                case "השגות הראבד - מדע":
                    return "Books\\035_RAMBAM\\90002_mada_raavad.txt";
                case "משנה תורה - ספר אהבה":
                    return "Books\\035_RAMBAM\\90003_ahava.txt";
                case "כסף משנה - אהבה":
                    return "Books\\035_RAMBAM\\90003_ahava_kesef.txt";
                case "לחם משנה - אהבה":
                    return "Books\\035_RAMBAM\\90003_ahava_lechem.txt";
                case "השגות הראבד - אהבה":
                    return "Books\\035_RAMBAM\\90003_ahava_raavad.txt";
                case "משנה תורה - ספר זמנים":
                    return "Books\\035_RAMBAM\\90004_zmanim.txt";
                case "מהר''ל נ' חביב - זמנים":
                    return "Books\\035_RAMBAM\\90004_zmanim_haviv.txt";
                case "כסף משנה - זמנים":
                    return "Books\\035_RAMBAM\\90004_zmanim_kesef.txt";
                case "לחם משנה - זמנים":
                    return "Books\\035_RAMBAM\\90004_zmanim_lechem.txt";
                case "מגיד משנה - זמנים":
                    return "Books\\035_RAMBAM\\90004_zmanim_magid.txt";
                case "פירוש - זמנים":
                    return "Books\\035_RAMBAM\\90004_zmanim_perush.txt";
                case "השגות הראבד - זמנים":
                    return "Books\\035_RAMBAM\\90004_zmanim_raavad.txt";
                case "משנה תורה - ספר נשים":
                    return "Books\\035_RAMBAM\\90005_nashim.txt";
                case "כסף משנה - נשים":
                    return "Books\\035_RAMBAM\\90005_nashim_kesef.txt";
                case "לחם משנה - נשים":
                    return "Books\\035_RAMBAM\\90005_nashim_lechem.txt";
                case "מגיד משנה - נשים":
                    return "Books\\035_RAMBAM\\90005_nashim_magid.txt";
                case "השגות הראבד - נשים":
                    return "Books\\035_RAMBAM\\90005_nashim_raavad.txt";
                case "משנה תורה - ספר קדושה":
                    return "Books\\035_RAMBAM\\90006_kdusha.txt";
                case "כסף משנה - קדושה":
                    return "Books\\035_RAMBAM\\90006_kdusha_kesef.txt";
                case "לחם משנה - קדושה":
                    return "Books\\035_RAMBAM\\90006_kdusha_lechem.txt";
                case "מגיד משנה - קדושה":
                    return "Books\\035_RAMBAM\\90006_kdusha_magid.txt";
                case "השגות הראבד - קדושה":
                    return "Books\\035_RAMBAM\\90006_kdusha_raavad.txt";
                case "משנה תורה - ספר הפלאה":
                    return "Books\\035_RAMBAM\\90007_haflaa.txt";
                case "כסף משנה - הפלאה":
                    return "Books\\035_RAMBAM\\90007_haflaa_kesef.txt";
                case "לחם משנה - הפלאה":
                    return "Books\\035_RAMBAM\\90007_haflaa_lechem.txt";
                case "השגות הראבד - הפלאה":
                    return "Books\\035_RAMBAM\\90007_haflaa_raavad.txt";
                case "משנה תורה - ספר זרעים":
                    return "Books\\035_RAMBAM\\90008_zraiim.txt";
                case "כסף משנה - זרעים":
                    return "Books\\035_RAMBAM\\90008_zraiim_kesef.txt";
                case "השגות הראבד - זרעים":
                    return "Books\\035_RAMBAM\\90008_zraiim_raavad.txt";
                case "משנה תורה - ספר עבודה":
                    return "Books\\035_RAMBAM\\90009_avoda.txt";
                case "כסף משנה - עבודה":
                    return "Books\\035_RAMBAM\\90009_avoda_kesef.txt";
                case "השגות הראבד - עבודה":
                    return "Books\\035_RAMBAM\\90009_avoda_raavad.txt";
                case "משנה תורה - ספר קרבנות":
                    return "Books\\035_RAMBAM\\90010_korbanot.txt";
                case "כסף משנה - קרבנות":
                    return "Books\\035_RAMBAM\\90010_korbanot_kesef.txt";
                case "השגות הראבד - קרבנות":
                    return "Books\\035_RAMBAM\\90010_korbanot_raavad.txt";
                case "משנה תורה - ספר טהרה":
                    return "Books\\035_RAMBAM\\90011_tahara.txt";
                case "כסף משנה - ספר טהרה":
                    return "Books\\035_RAMBAM\\90011_tahara_kesef.txt";
                case "השגות הראבד - טהרה":
                    return "Books\\035_RAMBAM\\90011_tahara_raavad.txt";
                case "משנה תורה - ספר נזיקין":
                    return "Books\\035_RAMBAM\\90012_nezikin.txt";
                case "כסף משנה-ספר נזיקין":
                    return "Books\\035_RAMBAM\\90012_nezikin_kesef.txt";
                case "מגיד משנה - ספר נזיקין":
                    return "Books\\035_RAMBAM\\90012_nezikin_magid.txt";
                case "השגות הראבד - נזיקין":
                    return "Books\\035_RAMBAM\\90012_nezikin_raavad.txt";
                case "משנה תורה - ספר קנין":
                    return "Books\\035_RAMBAM\\90013_kinyan.txt";
                case "כסף משנה - קנין":
                    return "Books\\035_RAMBAM\\90013_kinyan_kesef.txt";
                case "מגיד משנה - ספר קנין":
                    return "Books\\035_RAMBAM\\90013_kinyan_magid.txt";
                case "השגות הראבד - קנין":
                    return "Books\\035_RAMBAM\\90013_kinyan_raavad.txt";
                case "משנה תורה - ספר משפטים":
                    return "Books\\035_RAMBAM\\90014_mishpatim.txt";
                case "כסף משנה - משפטים":
                    return "Books\\035_RAMBAM\\90014_mishpatim_kesef.txt";
                case "מגיד משנה - משפטים":
                    return "Books\\035_RAMBAM\\90014_mishpatim_magid.txt";
                case "השגות הראבד - משפטים":
                    return "Books\\035_RAMBAM\\90014_mishpatim_raavad.txt";
                case "משנה תורה - ספר שופטים":
                    return "Books\\035_RAMBAM\\90015_shoftim.txt";
                case "כסף משנה-שופטים":
                    return "Books\\035_RAMBAM\\90015_shoftim_kesef.txt";
                case "השגות הראבד - שופטים":
                    return "Books\\035_RAMBAM\\90015_shoftim_raavad.txt";

                case "שלחן ערוך - אורח חיים":
                    return "Books\\040_HALACHA1\\030_orach_chaim_merged.txt ";
                case "שלחן ערוך - יורה דעה":
                    return "Books\\040_HALACHA1\\031_yore_deaa_merged.txt";
                case "שלחן ערוך - אבן העזר":
                    return "Books\\040_HALACHA1\\032_even_haezer_merged.txt";
                case "שלחן ערוך - חשן משפט":
                    return "Books\\040_HALACHA1\\033_choshen_mishpat_merged.txt";
                case "שלחן ערוך - אורח חיים - מנוקד":
                    return "Books\\040_HALACHA1\\040_orach_chaim_menukad.txt";
                case "שלחן ערוך - יורה דעה - מנוקד":
                    return "Books\\040_HALACHA1\\041_yore_deaa_menukad.txt";
                case "שלחן ערוך - אבן העזר - מנוקד":
                    return "Books\\040_HALACHA1\\042_even_haezer_menukad.txt";
                case "שלחן ערוך - חשן משפט - מנוקד":
                    return "Books\\040_HALACHA1\\043_choshen_mishpat_menukad.txt";
                case "שלחן ערוך או''ח - באר היטב":
                    return "Books\\040_HALACHA1\\050_orach_chaim_baer_heitev.txt";
                case "שלחן ערוך יו''ד - באר היטב":
                    return "Books\\040_HALACHA1\\051_yore_deaa_baer_heitev.txt";
                case "שלחן ערוך אה''ע - באר היטב":
                    return "Books\\040_HALACHA1\\052_even_haezer_baer_heitev.txt";
                case "שלחן ערוך חו''מ - באר היטב":
                    return "Books\\040_HALACHA1\\053_choshen_mishpat_baer_heitev.txt";
                case "שלחן ערוך - אורח חיים - לא מנוקד":
                    return "Books\\040_HALACHA1\\060_orach_chaim.txt";
                case "שלחן ערוך - יורה דעה - לא מנוקד":
                    return "Books\\040_HALACHA1\\061_yore_deaa.txt";
                case "שלחן ערוך - חשן משפט - לא מנוקד":
                    return "Books\\040_HALACHA1\\063_choshen_mishpat.txt";
                case "ספר החינוך":
                    return "Books\\040_HALACHA1\\080_hinuch.txt";
                case "ערוך השולחן - אורח חיים":
                    return "Books\\040_HALACHA1\\081_aruch_hasulchan1.txt";
                case "משנה ברורה":
                    return "Books\\040_HALACHA1\\082_mishna_brura_merged.txt";

                case "ביאור הלכה":
                    return "Books\\040_HALACHA1\\084_mishna_brura_beur_halacha.txt";
                case "משנה ברורה - מרן ורמא":
                    return "Books\\040_HALACHA1\\085_mishna_brura_maran_rama.txt";
                case "קיצור שולחן ערוך":
                    return "Books\\040_HALACHA1\\105_kitzur.txt";
                case "חפץ חיים":
                    return "Books\\040_HALACHA1\\106_0_0_hh_L1.txt";
                case "ספר גדר עולם":
                    return "Books\\040_HALACHA1\\106_0_1_geder_olam.txt";
                case "קיצור ש''ע ילקוט יוסף":
                    return "Books\\040_HALACHA1\\106_1_KITZUR_YALKUT_YOSEF.txt";
                case "אוצר דינים לאשה ולבת":
                    return "Books\\040_HALACHA1\\106_2_OTSAR_DINIM.txt";
                case "ספר החיים":
                    return "Books\\040_HALACHA1\\106_2_OTSAR_DINIM.txt";
                case "שער הזהב לטהרה":
                    return "Books\\042_HALACHA2\\109_shaar_hazahav_latahara.txt";
                case "נשואין ואישות":
                    return "Books\\042_HALACHA2\\110_1_nesuin_ve_ishut.txt";
                case "טהרה הריון ולידה כהלכה":
                    return "Books\\042_HALACHA2\\110_2_tahara2.txt";
                case "הלכות ביקור חולים ואבלות - יקרא דחיי":
                    return "Books\\042_HALACHA2\\111_yikra_dechayei.txt";
                case "מראה מקומות והערות לספר יקרא דחיי":
                    return "Books\\042_HALACHA2\\112_yikra_dechayei - notes.txt";
                case "הלכות חנוכה - פסקי משה":
                    return "Books\\042_HALACHA2\\115_piske_moshe_hanuka.txt";
                case "פתבג המלך":
                    return "Books\\042_HALACHA2\\116_PatBag.txt";
                case "טהרת כלים":
                    return "Books\\042_HALACHA2\\117_TaharatKelim.txt";
                case "ספר קול אליהו":
                    return "Books\\042_HALACHA2\\170_kol_eliyahu.txt";
                case "מראות הצובאות":
                    return "Books\\042_HALACHA2\\180_MarotHatsovot.txt";
                case "ספר מחניך קדוש":
                    return "Books\\042_HALACHA2\\181_machanecha_kadosh.txt";
                case "שבת כהלכה":
                    return "Books\\042_HALACHA2\\201_shabat.txt";
                case "ילדים כהלכה":
                    return "Books\\042_HALACHA2\\202_yeladim.txt";
                case "נשים בהלכה":
                    return "Books\\042_HALACHA2\\203_NashimBahalacha.txt";
                case "שמירת עיניים כהלכה":
                    return "Books\\042_HALACHA2\\204_ShmiratEnaiim.txt";
                case "ואהבת כהלכה":
                    return "Books\\042_HALACHA2\\205_veaavta_kahalacha.txt";
                case "ואין למו מכשול - הלכות תלמוד תורה":
                    return "Books\\042_HALACHA2\\220_VeenLamoTora.txt";
                case "ואין למו מכשול - הלכות גמילות חסדים":
                    return "Books\\042_HALACHA2\\221_VeenLamoChesed.txt";
                case "ואין למו מכשול - חלק י'":
                    return "Books\\042_HALACHA2\\223_VeenLamoTshuva.txt";
                case "ואין למו מכשול - חלק ה'":
                    return "Books\\042_HALACHA2\\224_VeenLamoLifneiIver.txt";
                case "נקי כפים":
                    return "Books\\042_HALACHA2\\230_neki_kapaiim.txt";
                case "קדושים תהיו על הלכות תולעים":
                    return "Books\\042_HALACHA2\\231_tolaiim.txt";
                case "כשרות המטבח":
                    return "Books\\042_HALACHA2\\299_kashrut_gamitbach.txt";
                case "כבוד אב ואם - בהלכה ובאגדה":
                    return "Books\\042_HALACHA2\\300_bahalacha_ubaagada_kibid_horim.txt";
                case "מצוות הארץ - בהלכה ובאגדה":
                    return "Books\\042_HALACHA2\\301_bahalacha_ubaagada_mitsvot_haarets.txt";
                case "השבת בהלכה ובאגדה":
                    return "Books\\042_HALACHA2\\301_bahalacha_ubaagada_shabat.txt";
                case "הטהרה בהלכה ובאגדה":
                    return "Books\\042_HALACHA2\\302_bahalacha_ubaagada_tahara.txt";
                case "הלכות סעודה":
                    return "Books\\042_HALACHA2\\303_hilchot_seuda.txt";
                case "סדר היום בהלכה ובאגדה":
                    return "Books\\042_HALACHA2\\304_seder_hayom.txt";
                case "ראש חודש בהלכה ובאגדה":
                    return "Books\\042_HALACHA2\\305_rosh_hodesh_bahalacha_ubaagada.txt";
                case "הלכות הגעלת כלים לפסח":
                    return "Books\\042_HALACHA2\\400_piskei_moshe_hagaala_lepesach.txt";
                case "הערות פסקי משה - הלכות הגעלת כלים לפסח":
                    return "Books\\042_HALACHA2\\400_piskei_moshe_hagaala_lepesach.txt.notes.txt";

                case "וביום השבת":
                    return "Books\\042_HALACHA2\\410_beyom_hashabat.txt";
                case "מנחת שי - הלכות בשר בחלב":
                    return "Books\\042_HALACHA2\\420_shay_basar_bechalav.txt";
                case "מנחת שי - הלכות טבילת כלים":
                    return "Books\\042_HALACHA2\\421_shay_tvilat_kelim.txt";
                case "גן נעול - על הלכות ייחוד":
                    return "Books\\042_HALACHA2\\430_holchot_yichud.txt";
                case "הערות להלכות יחוד":
                    return "Books\\042_HALACHA2\\430_holchot_yichud.txt.notes.txt";
                case "שלחן ערוך המדות - א":
                    return "Books\\042_HALACHA2\\440_midot.txt";
                case "שלחן ערוך המדות - ב":
                    return "Books\\042_HALACHA2\\441_midot2.txt";
                case "שלחן ערוך המדות - ג":
                    return "Books\\042_HALACHA2\\442_midot3.txt";
                case "וקָנֶה לך חבר":
                    return "Books\\042_IYUNIM\\028_vekane.txt ";
                case "שער אשר - הלכות נדה":
                    return "Books\\042_IYUNIM\\029_ShaarAsher.txt";
                case "בעניין מספר הפסוקים התיבות והאותיות בתורה":
                    return "Books\\042_IYUNIM\\030_RavZilber1.txt";
                case "בעניין הנחלות בארץ ישראל":
                    return "Books\\042_IYUNIM\\040_nachalot.txt";
                case "באר יעקב - חבורות":
                    return "Books\\042_IYUNIM\\050_BeerYaakovHavurot.txt";
                case "ספר באר יעקב - אגדות הש''ס":
                    return "Books\\042_IYUNIM\\051_BeerYaakovAgadot.txt";
                case "יוסף לקח - משלי":
                    return "Books\\042_IYUNIM\\070_YosefLekachMishlei.txt";
                case "קונטרס בגדרי שהייה וחזרה":
                    return "Books\\042_IYUNIM\\080_sheiya.txt";
                case "מחשבת כהן":
                    return "Books\\042_IYUNIM\\090_machsevet_cohen.txt";
                case "מנחת שי - הלכות":
                    return "Books\\042_IYUNIM\\100_minhat_shay_tfila_ad_brachot.txt";
                case "מנחת שי - הלכות יום טוב":
                    return "Books\\042_IYUNIM\\100_minhat_shay_yom_tov.txt";
                case "ספר ברכת ישראל":
                    return "Books\\042_IYUNIM\\110_birchat_israel.txt";
                case "יד הלוי - מסכת בבא מציעא":
                    return "Books\\042_IYUNIM\\120_YadHaleviMetsia.txt";
                case "ספר מנחת ישראל":
                    return "Books\\042_IYUNIM\\230_minchat_israel.txt";
                case "מאור המועדים":
                    return "Books\\042_IYUNIM\\240_maor_moadim.txt";
                case "מסילת ישרים":
                    return "Books\\100_MUSAR\\010_mesilat_yesharim.TXT ";
                case "אורחות צדיקים":
                    return "Books\\100_MUSAR\\011_orchot_tsadikim.TXT";
                case "שערי תשובה":
                    return "Books\\100_MUSAR\\012_ShaareiTeshuva.txt";
                case "חובות הלבבות":
                    return "Books\\100_MUSAR\\012_chovot_halevavot.txt";
                case "תומר דבורה":
                    return "Books\\100_MUSAR\\013_TomerDevora.txt";
                case "דרך השם":
                    return "Books\\100_MUSAR\\014_derech_hashem.txt";
                case "ספר הישר":
                    return "Books\\100_MUSAR\\015_SeferHayashar.txt";
                case "אגרת הרמב''ן":
                    return "Books\\100_MUSAR\\020_igeret_haramban.TXT";
                case "אגרת תימן להרמב''ם ז''ל":
                    return "Books\\100_MUSAR\\023_igeret_teiman.txt";
                case "שמירת הלשון":
                    return "Books\\100_MUSAR\\024_ShmiratHalashon_L1.txt";
                case "נפש החיים":
                    return "Books\\100_MUSAR\\025_NEFESH_HAHAIM_L1.txt";
                case "פלא יועץ":
                    return "Books\\100_MUSAR\\035_pele.txt";
                case "עבד השם":
                    return "Books\\100_MUSAR\\070_EvedHashem_L1.txt";
                case "קובץ אמונה מעשית":
                    return "Books\\100_MUSAR\\070_emuna_maasit.txt";
                case "בלבבי משכן אבנה - א":
                    return "Books\\100_MUSAR\\071_bilvavi1.txt";
                case "בלבבי משכן אבנה - ב":
                    return "Books\\100_MUSAR\\072_bilvavi2.txt";
                case "בלבבי משכן אבנה - ג":
                    return "Books\\100_MUSAR\\073_bilvavi3.txt";
                case "בלבבי משכן אבנה - ד":
                    return "Books\\100_MUSAR\\073_bilvavi4.txt";
                case "בלבבי משכן אבנה - ו":
                    return "Books\\100_MUSAR\\076_bilvavi6.txt";
                case "בלבבי משכן אבנה - ט":
                    return "Books\\100_MUSAR\\079_bilvavi9.txt";
                case "נר לרגלי":
                    return "Books\\100_MUSAR\\090_NerLeragli.txt";
                case "אור לנתיבתי":
                    return "Books\\100_MUSAR\\091_OrLintivati.txt";
                case "בעיקבתא דמשיחא":
                    return "Books\\100_MUSAR\\095_BikvetaDimsiha.txt";
                case "ברומו של עולם - על התפילה":
                    return "Books\\100_MUSAR\\096_BerumoShelOlam.txt";
                case "שובה ישראל":
                    return "Books\\100_MUSAR\\097_ShuvaIsrael.txt";
                case "בני בנימין - על מסכת אבות":
                    return "Books\\100_MUSAR\\110_BINYAMIN_L1.txt";
                case "שובי נפשי":
                    return "Books\\100_MUSAR\\115_ShuviNafshi.txt";
                case "מחנה שכינה":
                    return "Books\\100_MUSAR\\130_machane_shechina.TXT";
                case "ואנכי עפר ואפר - מעלות הענווה":
                    return "Books\\100_MUSAR\\200_ANAVA_L1.txt";
                case "מנורת המאור":
                    return "Books\\100_MUSAR\\300_menorat_hamaor.txt";
                case "אבות ישראל - על פרקי אבות":
                    return "Books\\100_MUSAR\\310_Avot_Israel.txt";
                case "אמרי יחזקאל":
                    return "Books\\100_MUSAR\\320_imrei_yechezkel.txt";
                case "אמרי יחזקאל - מעגל החיים":
                    return "Books\\100_MUSAR\\321_imeri_yechezkel_maagal_hachaiim.txt";
                case "פרדס רמונים - חלק א":
                    return "Books\\100_MUSAR\\400_pardes_rimonim_1.txt";
                case "פרדס רימונים - חלק ב":
                    return "Books\\100_MUSAR\\401_pardes_rimonim_2.txt";
                case "חי באמונה א - חי באמונה":
                    return "Books\\100_MUSAR\\500_chai_1.txt";
                case "חי באמונה ב - אהבת עולם אהבתנו":
                    return "Books\\100_MUSAR\\501_chai_2.txt";
                case "חי באמונה ג  -  ישמח ישראל":
                    return "Books\\100_MUSAR\\502_chai_3.txt";
                case "חי באמונה ד  -  אוצר החיים":
                    return "Books\\100_MUSAR\\503_chai_4.txt";
                case "חי באמונה ה  -  כל עכבה לטובה":
                    return "Books\\100_MUSAR\\504_chai_5.txt";
                case "חי בתודה":
                    return "Books\\100_MUSAR\\505_chai_betoda.txt";
                case "חיה באמונה":
                    return "Books\\100_MUSAR\\510_chaya_beemuna.txt";
                case "ויצא יצחק לשוח - א":
                    return "Books\\100_MUSAR\\600_vayetse_itschak.txt";
                case "ספר עמל ישראל":
                    return "Books\\100_MUSAR\\610_amal_israel.txt";
                case "הקדמת ספר הזוהר":
                    return "Books\\106_KABALA\\000025_Hakdamot.txt ";
                case "הזוהר הקדוש - ספר בראשית":
                    return "Books\\106_KABALA\\000021_ZOHAR1_L1.txt";
                case "הזוהר הקדוש - ספר שמות":
                    return "Books\\106_KABALA\\000021_ZOHAR2_L1.txt";
                case "הזוהר הקדוש - ספר ויקרא":
                    return "Books\\106_KABALA\\000021_ZOHAR3_L1.txt";
                case "הזוהר הקדוש - ספר במדבר":
                    return "Books\\106_KABALA\\000021_ZOHAR4_L1.txt";
                case "הזוהר הקדוש - ספר דברים":
                    return "Books\\106_KABALA\\000021_ZOHAR5_L1.txt";
                case "תיקוני הזוהר":
                    return "Books\\106_KABALA\\000022_ZOHAR6-tikunim_L1.txt";
                case "זוהר חדש":
                    return "Books\\106_KABALA\\000022_ZOHAR7-hadash_L1.txt";
                case "הזוהר המתורגם - הקדמת ספר הזוהר":
                    return "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-0.txt";
                case "הזוהר המתורגם - ספר בראשית":
                    return "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-1.txt";
                case "הזוהר המתורגם - ספר שמות":
                    return "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-2.txt";
                case "הזוהר המתורגם - ספר ויקרא":
                    return "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-3.txt";
                case "הזוהר המתורגם - ספר במדבר":
                    return "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-4.txt";
                case "הזוהר המתורגם - ספר דברים":
                    return "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-5.txt";
                case "הזוהר המתורגם - תיקוני הזוהר":
                    return "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-6.txt";
                case "הזוהר המתורגם - זוהר חדש":
                    return "Books\\106_KABALA\\000023_ZOHAR-VETARGUM-7.txt";
                case "מאמר העיקרים":
                    return "Books\\106_KABALA\\000024_MaamarHaIkarim.txt";
                case "דרשת הרמב''ן":
                    return "Books\\106_KABALA\\000024_drashat_haramban.txt";
                case "הקדמה לספר הזוהר":
                    return "Books\\106_KABALA\\000025_Hakdamot.txt";
                case "פתיחה לחכמת הקבלה":
                    return "Books\\106_KABALA\\000026_PtichaLakabala.txt";
                case "מבוא לספר הזהר":
                    return "Books\\106_KABALA\\000027_MavoLazohar.txt";
                case "ספר הפליאה":
                    return "Books\\106_KABALA\\006_sefer_hapliaa.txt";
                case "שער הכוונות":
                    return "Books\\106_KABALA\\010_shaar_hakaavnot.TXT";
                case "ספר מגיד מישרים":
                    return "Books\\106_KABALA\\011_magid_meisharim.TXT";
                case "ספר הבהיר":
                    return "Books\\106_KABALA\\012_sefer_habahir.TXT";
                case "ספר החשמל":
                    return "Books\\106_KABALA\\013_sefer_hachashmal.TXT";
                case "ספר יצירה":
                    return "Books\\106_KABALA\\014_sefer_yezira.TXT";
                case "פירוש הרמב''ן לספר יצירה":
                    return "Books\\106_KABALA\\015_p_ramban_sefer_yezira.TXT";
                case "פירוש הרמ''ק לספר יצירה":
                    return "Books\\106_KABALA\\016_p_ramak_sefer_yezira.txt";
                case "ספרא דצניעותא":
                    return "Books\\106_KABALA\\017_sifra_detsniuta.txt";
                case "ספר שערי קדושה":
                    return "Books\\106_KABALA\\018_shaarei_kedusha.TXT";
                case "ספר שקל הקדש":
                    return "Books\\106_KABALA\\020_DAAT_TVUNOT.txt";
                case "ספר תולדות אדם":
                    return "Books\\106_KABALA\\020_shla.TXT";
                case "דעת תבונות":
                    return "Books\\106_KABALA\\021_DaatTvunot.txt";
                case "מתן תורה":
                    return "Books\\106_KABALA\\052_MatanToraRavAshlag.txt";
                case "עשרה פרקים להרמח''ל":
                    return "Books\\106_KABALA\\053_TenPrakinLaRanchal.txt";
                case "לִקּוּטֵי אֲמָרִים תַּנְיָא":
                    return "Books\\110_CHASIDUT\\046_taniya_3.txt ";
                case "ספר התניא - אגרת התשובה":
                    return "Books\\110_CHASIDUT\\046_taniya_3.txt";
                case "ליקוטי מוהר''ן - חלק א":
                    return "Books\\110_CHASIDUT\\070_LikuteiMuharan_A_BreslevOrg.txt";
                case "ליקוטי מוהר''ן - חלק ב":
                    return "Books\\110_CHASIDUT\\070_LikuteiMuharan_B_BreslevOrg.txt";

                case "ספר המידות":
                    return "Books\\110_CHASIDUT\\072_midot.txt";
                case "משיבת נפש":
                    return "Books\\110_CHASIDUT\\073_meshivat_nefesh.txt";
                case "קיצור ליקוטי מוהר''ן השלם":
                    return "Books\\110_CHASIDUT\\100_kitsur_likutei.txt";

                case "ארחות חיים":
                    return "Books\\112_HANHAGOT\\0_OrchotHaiim.txt";
                case "הנהגות יום יום":
                    return "Books\\112_HANHAGOT\\1_hanagot_yom_yom.TXT";
                case "הנהגות עין טובה":
                    return "Books\\112_HANHAGOT\\2_hanhagot_aiin_tova.TXT";
                case "הנהגות לשבת קודש":
                    return "Books\\112_HANHAGOT\\3_hanhagot_leshabat_kodesh.TXT";
                case "קונטרס שבת קודש":
                    return "Books\\112_HANHAGOT\\4_kontras_shabat_kodesk.TXT";
                case "פניני הזוהר לשבת קודש":
                    return "Books\\112_HANHAGOT\\5_zohar_shabat_kodesh.TXT";
                case "הנהגות לשבת קודש - חלק ב":
                    return "Books\\112_HANHAGOT\\6_hanhagot_leshabat_kodesh_2.txt";
                case "הנהגות ועצות מעשיות לאבלים":
                    return "Books\\112_HANHAGOT\\7_avelim.txt";
                case "הנהגות אמונה מעשית":
                    return "Books\\112_HANHAGOT\\8_emula_maasit.txt";
                case "סביב למשפחה":
                    return "Books\\112_HANHAGOT\\SAVIV_L1.txt";
                case "הנהגות חודש אלול וימים נוראים":
                    return "Books\\112_HANHAGOT\\elul.txt";
                case "קונטרס - אגרת לבן תורה":
                    return "Books\\112_HANHAGOT\\igeret_leben_tora.txt";
                case "בים דרך - בראשית":
                    return "Books\\115_PARSHA\\008_bd1.txt ";
                case "בים דרך - שמות":
                    return "Books\\115_PARSHA\\008_bd2.txt";
                case "בים דרך - ויקרא":
                    return "Books\\115_PARSHA\\008_bd3.txt";
                case "בים דרך - במדבר":
                    return "Books\\115_PARSHA\\008_bd4.txt";
                case "בים דרך - דברים":
                    return "Books\\115_PARSHA\\008_bd5.txt";
                case "תפארת ישראל":
                    return "Books\\115_PARSHA\\010_TIFERET_L1.txt";
                case "נר תמיד - על פרשת השבוע":
                    return "Books\\115_PARSHA\\050_NerTamidHaravBrener.txt";
                case "פרי חנן על התורה - בראשית":
                    return "Books\\115_PARSHA\\070_PriHanan1.txt";
                case "פרי חנן על התורה - שמות":
                    return "Books\\115_PARSHA\\070_PriHanan2.txt";
                case "יגל יעקב - על פרשת השבוע":
                    return "Books\\115_PARSHA\\080_YagelYaakovTora.txt";
                case "ובחרת בחיים":
                    return "Books\\115_PARSHA\\090_bacharta_bachaiim.txt";
                case "באר יעקב על התורה":
                    return "Books\\115_PARSHA\\100_BeerYaakovTora.txt";
                case "סיפור מן ההפטרה - בראשית":
                    return "Books\\115_PARSHA\\101_SipurMinHahaftara1.txt";
                case "סיפור מן ההפטרה - שמות":
                    return "Books\\115_PARSHA\\102_SipurMinHahaftara2.txt";
                case "סיפור מן ההפטרה - ויקרא":
                    return "Books\\115_PARSHA\\103_SipurMinHahaftara3.txt";
                case "סיפור מן ההפטרה - במדבר":
                    return "Books\\115_PARSHA\\104_SipurMinHahaftara4.txt";
                case "סיפור מן ההפטרה - דברים":
                    return "Books\\115_PARSHA\\105_SipurMinHahaftara5.txt";
                case "פני דוד - על התורה":
                    return "Books\\115_PARSHA\\106_PneiDavid.txt";
                case "דובב שפתי ישנים":
                    return "Books\\115_PARSHA\\110_dovev.txt";
                case "פניני ינון ואליהו - על הפרשה":
                    return "Books\\115_PARSHA\\120_pninei_ynon_veeliyahu.txt";
                case "באר יעקב - מעשי אבות - בראשית":
                    return "Books\\115_PARSHA\\130_maase_avot.txt";
                case "אפיקי אליהו על התורה":
                    return "Books\\115_PARSHA\\140_afikey.txt";
                case "מיד מלכים - על התורה":
                    return "Books\\115_PARSHA\\150_shulchan_melachim_al_hatora.txt";
                case "סימן לבנים - שמות":
                    return "Books\\115_PARSHA\\160_siman_levanim.txt";
                case "ספר מיד מלכים - על התורה":
                    return "Books\\115_PARSHA\\170_miyad_melachim_tora.txt";
                case "משפטי ישראל - על חגי ומועדי ישראל":
                    return "Books\\118_HAGIM\\080_MISHPETE_L1.txt ";
                case "באר יעקב - מועדים":
                    return "Books\\118_HAGIM\\090_beer_yaakov_moadim.txt";
                case "ארבע התעניות ובין המצרים":
                    return "Books\\118_HAGIM\\100_arba_taaniot_naki.txt";
                case "הימים הנוראים בהלכה ובאגדה":
                    return "Books\\118_HAGIM\\101_yamim_noraiim_kaki.txt";
                case "חג הסוכות בהלכה ובאגדה":
                    return "Books\\118_HAGIM\\102_sukot_naki.txt";
                case "ימי החנוכה בהלכה ובאגדה":
                    return "Books\\118_HAGIM\\103_hanuka_naki.txt";
                case "ימי הפורים בהלכה ובאגדה":
                    return "Books\\118_HAGIM\\104_kurim_naki.txt";
                case "חג הפסח בהלכה והאגדה":
                    return "Books\\118_HAGIM\\105_pesach_naki.txt";
                case "חג השבועות בהלכה ובאגדה":
                    return "Books\\118_HAGIM\\106_shvuot_naki.txt";
                case "ספר חמדת ימים - חלק א":
                    return "Books\\118_HAGIM\\111_chemdat_yamim_1.txt";
                case "ספר חמדת ימים - חלק ב":
                    return "Books\\118_HAGIM\\111_chemdat_yamim_2.txt";
                case "ספר חמדת ימים - חלק ג":
                    return "Books\\118_HAGIM\\111_chemdat_yamim_3.txt";
                case "הגדה של פסח - למען תספר":
                    return "Books\\118_HAGIM\\190_HAGADA_L1.txt";
                case "הגדה של פסח - נוסח אשכנז":
                    return "Books\\118_HAGIM\\191_HAGADA2.txt";
                case "הגדה של פסח - אור דניאל":
                    return "Books\\118_HAGIM\\192_HagadaOrDaniel.txt";

                case "מגילת הסתר - נס בכל פסוק במגילת אסתר":
                    return "Books\\118_HAGIM\\200_megilat_hester.txt";
                case "קונטרס סדר ישראל":
                    return "Books\\118_HAGIM\\440_seder_israel.txt";
                case "מיד מלכים - שער המועדים":
                    return "Books\\118_HAGIM\\520_miyad_melachim_moadim.txt";
                case "hagada_for_beit_mikdash.htm":
                    return "Books\\118_HAGIM\\hagada_for_beit_mikdash.htm";
                case "סדר הדורות המקוצר":
                    return "Books\\120_GDOLEY_HADOROT\\100_seder_hadorot.txt ";
                case "ימי הילולא דצדיקיא":
                    return "Books\\120_GDOLEY_HADOROT\\150_hilula.txt";
                case "ספר מעשי אבות":
                    return "Books\\120_GDOLEY_HADOROT\\200_maase_avot.txt";
                case "דוד המלך ועוצמת התהילים":
                    return "Books\\120_GDOLEY_HADOROT\\300_david_hamelech.txt";
                case "ספר קבלת חכמי מרוקו":
                    return "Books\\120_GDOLEY_HADOROT\\400_maroko.txt";
                case "אמונה והשגחה מספר איוב":
                    return "Books\\120_GDOLEY_HADOROT\\500_iyov.txt";
                case "נפשי בשאלתי חלק א - שו''ת":
                    return "Books\\125_SHUT\\101_NafshiBesheelati1.txt ";
                case "נפשי בשאלתי חלק ב - שו''ת":
                    return "Books\\125_SHUT\\101_NafshiBesheelati2.txt";
                case "נפשי בשאלתי חלק ג - שו''ת":
                    return "Books\\125_SHUT\\102_NafshiBesheelati3.txt";
                case "ישמח משה - שו''ת":
                    return "Books\\125_SHUT\\150_YismachMoshe_L1.txt";
                case "ויען אליהו":
                    return "Books\\125_SHUT\\190_VayaanEliyahu.txt";
                case "בריח התיכון":
                    return "Books\\125_SHUT\\220_BariachHatichon.txt";
                case "מועדי ניסים":
                    return "Books\\125_SHUT\\221_MoadeiNissim.txt";
                case "שו''ת גם אני אודך - א":
                    return "Books\\125_SHUT\\230_ShutGamAniOdecha.txt";
                case "שו''ת גם אני אודך - ב":
                    return "Books\\125_SHUT\\231_ShutGamAniOdecha2.txt";
                case "שו''ת גם אני אודך - ג":
                    return "Books\\125_SHUT\\232_ShutGamAniOdecha3.txt";
                case "שו''ת בכל דרכיך דעהו":
                    return "Books\\125_SHUT\\240_bechol_drachecha.txt";
                case "שו''ת שאול שאל - חלק א":
                    return "Books\\125_SHUT\\250_ShaolShaal.txt";
                case "שו''ת שאול שאל - חלק ב":
                    return "Books\\125_SHUT\\251_ShaolShaal_2.txt";
                case "שו''ת נחלת לוי - ח''ב":
                    return "Books\\125_SHUT\\300_ShutNachalatLevi_1.txt";
                case "שו''ת עם סגולה - חלק א":
                    return "Books\\125_SHUT\\350_RavSilver1.txt";
                case "שו''ת עם סגולה - חלק ב":
                    return "Books\\125_SHUT\\350_RavSilver2.txt";
                case "שו''ת עם סגולה - חלק ג":
                    return "Books\\125_SHUT\\350_RavSilver3.txt";
                case "שו''ת עם סגולה - חלק ד":
                    return "Books\\125_SHUT\\350_RavSilver4.txt";
                case "קול חתן וקול כלה":
                    return "Books\\130_HABITE\\700_KolHatanVkolKala.txt ";
                case "קונטרס יבוא עזרי":
                    return "Books\\130_HABITE\\701_yavo_ezri.txt";
                case "האושר שבנשואין - לגבר":
                    return "Books\\130_HABITE\\702_HAOSHER1.txt";
                case "האושר שבנשואין - לאשה":
                    return "Books\\130_HABITE\\703_HAOSHER2_L1.txt";
                case "קונטרס הנהגות הבית":
                    return "Books\\130_HABITE\\704_hanhagot_habaite.txt";
                case "וילכו שניהם יחדיו":
                    return "Books\\130_HABITE\\705_vayelchu.txt";
                case "קונטרס - חינוך ילדים":
                    return "Books\\130_HABITE\\706_HINUCH_L1.txt";
                case "וביתך שלום":
                    return "Books\\130_HABITE\\707_ubeitcha_shalom.txt";
                case "קונטרס ותפקדנו":
                    return "Books\\130_HABITE\\800_$_1927_sgulot_lezera_vatifkedenu.txt";
                case "אוהליך יעקב":
                    return "Books\\130_HABITE\\810_OhalechaYaakov.txt";
                case "עושה שלום":
                    return "Books\\130_HABITE\\820_ose_shalom.txt";
                case "בני בבת עיני":
                    return "Books\\130_HABITE\\830_my_son.txt";
                case "אני והנער":
                    return "Books\\130_HABITE\\831_ani_vehanaar.txt";
                case "קונטרס קבלת התורה - אבות ובנים":
                    return "Books\\130_HABITE\\832_kabalat_hatora.txt";
                case "קונטרס - שלא לעבור כנגד המתפלל":
                    return "Books\\140_CONTRAS\\500_KontrasLoLaavor.txt ";
                case "קונטרס - המקדש שמו ברבים":
                    return "Books\\140_CONTRAS\\501_KIDUSH_HASHEM_L1.txt";
                case "דרך מנוחה - פירוש לאגרת הרמב''ן":
                    return "Books\\140_CONTRAS\\600_derech_menucha.TXT";
                case "מעלת אמירת הקורבנות קודם שחרית":
                    return "Books\\140_CONTRAS\\720_korbanot.txt";
                case "קונטרס - מעלת המלמדים":
                    return "Books\\140_CONTRAS\\750_maalat_hamelamdim.txt";
                case "קונטרס קול קורא":
                    return "Books\\140_CONTRAS\\801_KolKore.txt";
                case "להבת שלהבת קודש":
                    return "Books\\140_CONTRAS\\802_lehavat_esh.txt";
                case "קונטרס בריתי שלום":
                    return "Books\\140_CONTRAS\\820_beriti_shalom.txt";
                case "פסיכולוגיית העין":
                    return "Books\\140_CONTRAS\\821_eyes.txt";
                case "קונטרס יתגדל ויתקדש":
                    return "Books\\140_CONTRAS\\900_likut_kadish.txt";
                case "איגרת לבת ישראל היקרה":
                    return "Books\\140_CONTRAS\\910_igeret_lebat.txt";
                case "אחות יקרה":
                    return "Books\\140_CONTRAS\\911_shir.txt";
                case "מאמר צפית לישועה":
                    return "Books\\140_CONTRAS\\930_zipita.txt";
                case "הלבוש והקישוט מזוית יהודית":
                    return "Books\\140_CONTRAS\\935_levush.txt";
                case "הסלולרי מזוית יהודית":
                    return "Books\\140_CONTRAS\\936_cellular.txt";
                case "מאמר הדבק בחכמים ובתלמידים":
                    return "Books\\140_CONTRAS\\950_hidabek.txt";
                case "תִּכָּתֶב זֹאת לְדוֹר אַחֲרוֹן":
                    return "Books\\140_CONTRAS\\960_dor_acharon.txt";
                case "הלבוש לאור ההלכה":
                    return "Books\\140_CONTRAS\\961_halevush_leor_hahalacha.txt";
                case "פירוש אור צח - על פתח אליהו":
                    return "Books\\140_CONTRAS\\962_patach_eliyahu.txt";
                case "קונטרס ביכורי יוסף - דברי הלכה ואגדה הנוגעים לעיוור":
                    return "Books\\140_CONTRAS\\963_bikurei_yossef_laiver.txt";

                case "קונטרס בחוקותי תלכו":
                    return "Books\\140_CONTRAS\\965_ben_shtei_nashim.txt";
                case "קונטרס יקר בעיני ה'":
                    return "Books\\140_CONTRAS\\966_keri.txt";
                case "ותכס בצעיף":
                    return "Books\\140_CONTRAS\\967_vatekas.txt";
                case "קונטרס בגדי תפארתך":
                    return "Books\\140_CONTRAS\\968_simla.txt";
                case "המשתמטים":
                    return "Books\\140_CONTRAS\\969_mishtamtim.txt";
                case "קונטרס תורתו אומנותו":
                    return "Books\\140_CONTRAS\\970_torato_omanuto.txt";
                case "קונטרס הטוב שברופאים":
                    return "Books\\140_CONTRAS\\971_the_best_doctor.txt";
                case "אגלחך לשמים":
                    return "Books\\140_CONTRAS\\972_avoda_zara_bapea.txt";
                case "תורה ומדע 1":
                    return "Books\\145_HADERECH_LATORA\\100_tora_ve_mada1.txt ";
                case "שכרן של מצוות":
                    return "Books\\145_HADERECH_LATORA\\150_scharan_shell_mitsvot.TXT";
                case "צוהר לארחות החרדי":
                    return "Books\\145_HADERECH_LATORA\\200_ttsoar_laolam_hharedi.txt";
                case "מחפשים את האמת":
                    return "Books\\145_HADERECH_LATORA\\400_LookingForTruth.txt";
                case "מי נגד מי - דו שיח חרדי-חילוני":
                    return "Books\\145_HADERECH_LATORA\\410_MeNegedMe.txt";
                case "שער האמונה":
                    return "Books\\145_HADERECH_LATORA\\451_shaar_haemuna 2.txt";
                case "היכן זה כתוב":
                    return "Books\\145_HADERECH_LATORA\\500_where_is_it.TXT";
                case "ספר הכוזרי":
                    return "Books\\145_HADERECH_LATORA\\552_hakuzari.txt";
                case "מיהו בן חורין אמיתי":
                    return "Books\\145_HADERECH_LATORA\\580_BenChorin.txt";
                case "הפתעה - סיפור בעניין האבולוציה":
                    return "Books\\145_HADERECH_LATORA\\600_surprize.txt";
                case "סוד השבת - אור הנשמה":
                    return "Books\\145_HADERECH_LATORA\\601_shabat_rav_zamir.txt";
                case "אור חוזר":
                    return "Books\\145_HADERECH_LATORA\\603_OrHozer.txt";
                case "העיתונאי 1":
                    return "Books\\145_HADERECH_LATORA\\610_itinai_1.txt";
                case "העיתונאי 2":
                    return "Books\\145_HADERECH_LATORA\\611_itinai_2.txt";
                case "העיתונאי 3":
                    return "Books\\145_HADERECH_LATORA\\612_itinai_3.txt";
                case "העיתונאי 4":
                    return "Books\\145_HADERECH_LATORA\\613_itinai_4.txt";
                case "העיתונאי 5":
                    return "Books\\145_HADERECH_LATORA\\614_itinai_5.txt";
                case "העיתונאי 6":
                    return "Books\\145_HADERECH_LATORA\\615_itinai_6.txt";
                case "אורות של אמת":
                    return "Books\\145_HADERECH_LATORA\\650_orot_shel_emet.txt";
                case "התכלית":
                    return "Books\\145_HADERECH_LATORA\\651_hatachlit.txt";
                case "בנות מדברות על עצמן":
                    return "Books\\145_HADERECH_LATORA\\700_BANOT_MEDABROT.txt";
                case "נשים מדברות על עצמן":
                    return "Books\\145_HADERECH_LATORA\\701_NASHIM_MEDABROT.txt";
                case "אצבעותי למלחמה":
                    return "Books\\145_HADERECH_LATORA\\702_fingers.txt";
                case "הכוח השלישי":
                    return "Books\\145_HADERECH_LATORA\\710_the_3rd_power.txt";
                case "תכלית החיים":
                    return "Books\\145_HADERECH_LATORA\\720_tachlit_hachaiim.txt";
                case "יהדות על קצה המזלג":
                    return "Books\\145_HADERECH_LATORA\\730_mazleg.txt";
                case "ה' ניסי - ניסי ניסים":
                    return "Books\\145_HADERECH_LATORA\\740_hashem_nisi.txt";
                case "סידור תורת אמת":
                    return "Books\\150_TFILOT_VESGULOT\\0002_sidur1.txt ";
                case "סידור זכר מנחם":
                    return "Books\\150_TFILOT_VESGULOT\\0002_sidur2.txt";
                case "סדר סליחות והתרת נדרים":
                    return "Books\\150_TFILOT_VESGULOT\\0005_slichot.txt";
                case "לקט תפילות":
                    return "Books\\150_TFILOT_VESGULOT\\0010_Likutei_tfilot.txt";
                case "סדר הלימוד לעילוי נשמה":
                    return "Books\\150_TFILOT_VESGULOT\\0020_LimudLeiluiNishmat.txt";
                case "התיקון הכללי":
                    return "Books\\150_TFILOT_VESGULOT\\0021_TikunHaclali.txt";
                case "סדר מעמדות":
                    return "Books\\150_TFILOT_VESGULOT\\0050_seder_maamadot.txt";
                case "פסוק המתחיל ומסתיים באות":
                    return "Books\\150_TFILOT_VESGULOT\\0500_BeginEnd.txt";
                case "ישראל לסגולתו":
                    return "Books\\150_TFILOT_VESGULOT\\0550_SgulotRavLugacy.txt";
                case "קמיע תורני אמיתי להצלחה כללית":
                    return "Books\\150_TFILOT_VESGULOT\\0600_KAMIA_AMITI.txt";
                case "פרק שירה - שירת הבריאה":
                    return "Books\\150_TFILOT_VESGULOT\\0700_PirkeiShira.txt";
                case "תפילה לבת ישראל":
                    return "Books\\150_TFILOT_VESGULOT\\911_tfila_lebat.txt";

                case "נוסח סיום מסכת":
                    return "Books\\150_TFILOT_VESGULOT\\913_hadran.txt";
                case "חידון שמירת הלשון - ע''פ ספר החפץ חיים":
                    return "Books\\157_HIDONIM\\HidonLashon.txt ";
                case "אהבת חסד":
                    return "Books\\158_AHAVAT_ISRAEL\\050_ahavat_chesed.txt ";
                case "הנהגות אהבת ישראל":
                    return "Books\\158_AHAVAT_ISRAEL\\100_ahavat_israel.txt";
                case "בר לבב - אהבת ישראל":
                    return "Books\\158_AHAVAT_ISRAEL\\200_BarLevav.txt";
                case "מדריך מעשי כיצד לדון לכף זכות":
                    return "Books\\158_AHAVAT_ISRAEL\\300_madrich.txt";
                case "מאמר ואהבת לרעך כמוך":
                    return "Books\\158_AHAVAT_ISRAEL\\400_veahavta.txt";
                case "כנסת ישראל":
                    return "Books\\158_AHAVAT_ISRAEL\\500_kneset_israel.txt";
                case "יצור לוורד":
                    return "Books\\160_MISC\\0000_for_WORD.txt";
                case "סיפורי ניסים":
                    return "Books\\160_MISC\\0600_nisim.txt";
                case "ספר חמדת ימים - מבוא":
                    return "Books\\160_MISC\\501_mavo_chemdat_yamim.txt";
                case "מפתח ענייני התנ''ך":
                    return "Books\\160_MISC\\502_key_for_tanach.txt";
                case "הודעה":
                    return "Books\\160_MISC\\50_message1.txt";

                case "בראשית שמות ויקרא במדבר דברים":
                    return "Books\\160_MISC\\AllTora.txt";
                case "בראשית בראשית בראשית בראשית בראשית":
                    return "Books\\160_MISC\\BereshitX5.txt";
                case "חיים בריאים כהלכה":
                    return "Books\\160_MISC\\BriutKahalacha.txt";
                case "חיים ללא עישון":
                    return "Books\\160_MISC\\BriutKahalachaNoSigars.txt";
                case "פרקי דרבי אליעזר":
                    return "Books\\160_MISC\\PirkeiDerabiEliezer.txt";
                case "פרקי דרך ארץ - סדר אליהו זוטא ט''ז - י''ח":
                    return "Books\\160_MISC\\PirkeiDerechErets.txt";
                case "דרשות לאזכרות ולבתי אבלים":
                    return "Books\\160_MISC\\drashot_laavelim.txt";


                case "ספר חמדת ימים - חלק א - שבת":
                    return "Books\\170_GROUPS\\300_GROUP_SHABAT\\104_$_1830_chemdat_yamim_shabat.txt";

                case "שלחן ערוך - יורה דעה - הלכות טהרה":
                    return "Books\\170_GROUPS\\301_GROUP_TAHARA\\104_$_1044_yore_dea_tahara.txt";

                case "אגרת לבת ישראל היקרה":
                    return "Books\\170_GROUPS\\302_GROUP_TSNIUT\\102_$_1798_igeret_lebat_israel.txt";
                case "אנשי קודש":
                    return "Books\\170_GROUPS\\302_GROUP_TSNIUT\\103_$_1012_anshei_kodesh.txt";






                case "תבורך מנשים":
                    return "Books\\170_GROUPS\\302_GROUP_TSNIUT\\120_tevorach_menashim.txt";

                case "הלכות תולעים - קדושים תהיו":
                    return "Books\\170_GROUPS\\303_GROUP_KASHRUT\\001_$_1677_kedoshim_tihiyu.txt";
                case "הלכות טבילת כלים":
                    return "Books\\170_GROUPS\\303_GROUP_KASHRUT\\002_$_1599_tvilat_kelim.txt";
                case "הלכות פת ובישולי גוים - פתבג המלך":
                    return "Books\\170_GROUPS\\303_GROUP_KASHRUT\\003_$_1598_bishulei_goiim.txt";
                case "הלכות הגעלת כלים לפסח - פסקי משה":
                    return "Books\\170_GROUPS\\303_GROUP_KASHRUT\\004_$_1897_hagaalat_kelim.txt";
                case "פנקס ההערות שלי - 1":
                    return "Books\\400_NOTES\\0700_notes.txt ";
                case "פנקס ההערות שלי - 2":
                    return "Books\\400_NOTES\\0701_notes.txt";
                case "פנקס ההערות שלי - 3":
                    return "Books\\400_NOTES\\0702_notes.txt";
                case "פנקס ההערות שלי - 4":
                    return "Books\\400_NOTES\\0703_notes.txt";
                case "פנקס ההערות שלי - 5":
                    return "Books\\400_NOTES\\0704_notes.txt";
                case "פנקס ההערות שלי - 6":
                    return "Books\\400_NOTES\\0705_notes.txt";
                case "פנקס ההערות שלי - 7":
                    return "Books\\400_NOTES\\0706_notes.txt";
                case "פנקס ההערות שלי - 8":
                    return "Books\\400_NOTES\\0707_notes.txt";
                case "פנקס ההערות שלי - 9":
                    return "Books\\400_NOTES\\0708_notes.txt";
                case "פנקס ההערות שלי - 10":
                    return "Books\\400_NOTES\\0709_notes.txt";
                case "פנקס ההערות שלי - 11":
                    return "Books\\400_NOTES\\0710_notes.txt";
                case "פנקס ההערות שלי - 12":
                    return "Books\\400_NOTES\\0711_notes.txt";
                case "פנקס ההערות שלי - 13":
                    return "Books\\400_NOTES\\0712_notes.txt";
                case "פנקס ההערות שלי - 14":
                    return "Books\\400_NOTES\\0713_notes.txt";
                case "פנקס ההערות שלי - 15":
                    return "Books\\400_NOTES\\0714_notes.txt";
                case "פנקס ההערות שלי - 16":
                    return "Books\\400_NOTES\\0715_notes.txt";
                case "פנקס ההערות שלי - 17":
                    return "Books\\400_NOTES\\0716_notes.txt";
                case "פנקס ההערות שלי - 18":
                    return "Books\\400_NOTES\\0717_notes.txt";
                case "פנקס ההערות שלי - 19":
                    return "Books\\400_NOTES\\0718_notes.txt";
                case "פנקס ההערות שלי - 20":
                    return "Books\\400_NOTES\\0719_notes.txt";
                case "הקדמת הזוהר":
                    return "Books\\106_KABALA\\000020_ZOHAR0-hakdama_L1.txt";
                case "ליקוטי אמרים תניא":
                    return "Books\\110_CHASIDUT\\045_taniya_1.txt";
                
                case "עבודה שבלב ויקרא":
                    return "Books\\115_PARSHA\\180_AvodaShebaleveVaikra.txt";
                case "מעגל החיים - ויקרא":
                    return "Books\\115_PARSHA\\181_MaagalHachaiimVaikra.txt";
                case "נפשי בשאלתי":
                    return "Books\\125_SHUT\\100_NafshiBesheelati1.txt";
                case "שו\"ת שאול שאל - חלק ג":
                    return "Books\\125_SHUT\\253_ShaolShaal_3.txt";
                case "שו\"ת שאול שאל - חלק ד":
                    return "Books\\125_SHUT\\253_ShaolShaal_4.txt";
                case "סידור תורת אמת - ספרדים ועדות המזרח":
                    return "Books\\150_TFILOT_VESGULOT\\0001_sidur.txt";
                case "מבחנים":
                    return "Books\\160_MISC\\0000_TESTS.txt";
               
                case "גדר עולם":
                    return "Books\\170_GROUPS\\302_GROUP_TSNIUT\\099_$_2539_geder_olam.txt";                
                case "בגדי תפארתך":
                    return "Books\\170_GROUPS\\302_GROUP_TSNIUT\\106_$_1943_bigdei_tifartech.txt";
                case "שיר - אחות יקרה":
                    return "Books\\170_GROUPS\\302_GROUP_TSNIUT\\107_$_1942_shir.txt";
                
                case "אגלחך לשמים - תקרובת ע''ז בפאות":
                    return "Books\\170_GROUPS\\302_GROUP_TSNIUT\\110_$_5097_avoda_zara_pea.txt";
                
                case "קיצור הלכות שמירת הלשון - מבוסס על ספר החפץ חיים":
                    return "Books\\042_HALACHA2\\107_KitsurHafetsHaim.txt";
                case "שלחן ערוך המדות - קונטרס אונאת דברים":
                    return "Books\\042_HALACHA2\\443_midot4.txt";
                case "יתגבר כארי":
                    return "Books\\100_MUSAR\\612_yitgaber_kaari.txt";
                
                case "תלמוד בבלי - עדיות":
                    return "Books\\030_BAVLI\\29_MAS_EDUYOT\\Bav EDUYOT_L1.txt";



                // Add more cases for each translation
                default:
                    return originalFilename; // Return original filename if no translation found
            }
        }




    }
}

