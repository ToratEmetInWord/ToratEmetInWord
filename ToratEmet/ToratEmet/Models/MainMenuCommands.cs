using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using ToratEmet.Controls;
using ToratEmet.Properties;

namespace ToratEmet.Models
{
    public static class MainMenuCommands
    {
        public static void OpenExternalFile()
        {
            OpenSelected openSelected = new OpenSelected();
            openSelected.OpenExternalFile();
        }

        public static void SetExternalDefaultFolder()
        {
            ExternalFiles.SetDefaultExternalFolder();
        }

        public static void ShowApplicationFilesFolder()
        {
            if (Directory.Exists(Properties.Settings.Default.MainFolder)) { Process.Start("explorer.exe", Properties.Settings.Default.MainFolder); }
        }

        public static void ChangeApplicationFolderLocation()
        {
            ApplicationFolders.SetNewMainFolder();
        }

        public static void ChangeToratEmetLocation()
        {
            ApplicationFolders.SetNewToratEmetInstallFolder();
        }

        public static void CreateNewIndex()
        {
            IndexerWindow indexerWindow = new IndexerWindow();
            indexerWindow.Show();
        }

        public static void DeleteIndex()
        {
            Directory.Delete(ApplicationFolders.IndexFolder, true);
            Directory.CreateDirectory(ApplicationFolders.IndexFolder);
            MessageBox.Show("האינדקס נמחק");
        }

        public static void ResetFontSettings()
        {
            Properties.Settings.Default.HtmlFontFamily = "";  
            Properties.Settings.Default.HtmlFontSize = 100;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.FontSettingsTrigger = "";
        }

        public static void ShemHashemDisplayOptions()
        {
            OptionsWindow optionsWindow = new OptionsWindow
               ("תצוגת שם ה' (בחיפוש יש להזין יקוק)", "שם הוי-ה", "יי", "יקוק", "ה'")
            {
                FlowDirection = FlowDirection.RightToLeft,
                Height = 100,
                Width = 250,
                Icon = null
            };
            var result = optionsWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Settings.Default.ShemHashemDisplayOptions = optionsWindow.ClickedButton;
                Settings.Default.Save();
            }
        }

        public static void AboutButton()
        {
            try { System.Diagnostics.Process.Start("https://mitmachim.top/post/704012"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
