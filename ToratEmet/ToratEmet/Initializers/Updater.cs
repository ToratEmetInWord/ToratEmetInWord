using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToratEmet
{
    public static class Updater
    {
        public static async Task CheckForUpdates()
        {
            if (Properties.Settings.Default.UpdatesDisabled) return;
            try
            {
                bool fileExists = await CheckFileExists("https://drive.google.com/uc?id=1BNQmVsXixLZ7pg3vU9DZJSbO0XPYPzUd");
                if (fileExists)
                {
                    fileExists = await CheckFileExists("https://drive.google.com/uc?id=1OFC4Hh6snAWUxclKWMQNH_E1Ep_SUpAy");
                    if (!fileExists)
                    {
                        DialogResult result = MessageBox.Show("נמצאו עדכונים לתוסף \"תורת אמת בוורד\". האם ברצונכם להוריד את העדכונים כעת?", "עדכון נמצא!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                        if (result == DialogResult.Yes)
                        {
                            DownloadFile();
                        }
                    }
                }
            }
            catch { /*MessageBox.Show("Error In: UpdateCheck" + ex.Message); */}
        }

        static async Task<bool> CheckFileExists(string fileUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response;

                try
                {
                    response = await client.GetAsync(fileUrl);
                    return response.IsSuccessStatusCode;
                }
                catch (HttpRequestException)
                {
                    // Request failed, file does not exist or is not accessible
                    return false;
                }
            }
        }

        static void DownloadFile()
        {
            System.Diagnostics.Process.Start("https://github.com/pcinfogmach/ToratEmetInWord/releases/tag/ToratEmetInWord");
        }
    }
}
