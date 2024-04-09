using FolderPicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToratEmet.Models
{
    public static class ExternalFiles
    {
        public static void SetDefaultExternalFolder()
        {
            string folder = FolderPickerLauncher.Pick_A_Folder("בחר תיקיית ברירת מחדל עבור פתיחת קבצים חיצוניים");
            if(!string.IsNullOrEmpty(folder) ) 
            {
                Properties.Settings.Default.DefaultExternalFolder = folder;
                Properties.Settings.Default.Save();
            }          
        }
    }
}
