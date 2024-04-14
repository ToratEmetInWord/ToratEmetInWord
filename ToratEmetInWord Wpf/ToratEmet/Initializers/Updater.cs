using System;
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
            if (IsTimeToUpdate())
            {
                LogDateTime();
                try
                {
                    bool fileExists = await CheckFileExists("https://drive.google.com/uc?id=1BNQmVsXixLZ7pg3vU9DZJSbO0XPYPzUd");
                    if (fileExists)
                    {
                        string modifiedDate = await GetModifiedDate("https://drive.google.com/uc?id=1BNQmVsXixLZ7pg3vU9DZJSbO0XPYPzUd");
                        if (modifiedDate != Properties.Settings.Default.UpdateFileInfo) 
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
        }

        static bool IsTimeToUpdate()
        {
            DateTime lastLogDate;
            if (DateTime.TryParse(Properties.Settings.Default.LastUpdateCheck, out lastLogDate))             // Get the last log date from settings
            {
                int daysSinceLastUpdate = (DateTime.Now - lastLogDate).Days;
                return (DateTime.Now - lastLogDate).TotalDays >= 2;// Check if seven days have passed since the last log
            }
            else
            {
                return true;
            }
        }

        static void LogDateTime()
        {
            Properties.Settings.Default.LastUpdateCheck = DateTime.Now.ToString();
            Properties.Settings.Default.Save();
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

        public static async Task<string> GetModifiedDate(string fileUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, fileUrl);
                HttpResponseMessage  response = await client.SendAsync(request).ConfigureAwait(false);
                var headers = response.Headers.Concat(response.Content.Headers);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var header in headers)
                {
                    if (header.Key.ToLower().Contains("last") && header.Key.ToLower().Contains("modified"))
                    {
                        return header.Value.FirstOrDefault();
                    }
                }
                return null;              
            }
        }


            static void DownloadFile()
        {
            System.Diagnostics.Process.Start("https://github.com/pcinfogmach/ToratEmetInWord/releases/tag/ToratEmetInWord");
        }
    }
}
