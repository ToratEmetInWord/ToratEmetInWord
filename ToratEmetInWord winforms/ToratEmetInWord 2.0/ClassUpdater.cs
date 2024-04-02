using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

public class UpdatesCheck
{
    public static async Task CheckForUpdates()
    {
        try
        {
            bool fileExists = await CheckFileExists("https://drive.google.com/uc?id=1BNQmVsXixLZ7pg3vU9DZJSbO0XPYPzUd");
            if (fileExists)
            {
                fileExists = await CheckFileExists("https://drive.google.com/uc?id=1BVAXcFcGtjt7doK_fKGzo6Xsxx9kdaw7");

                if (!fileExists)
                {
                    DialogResult result = MessageBox.Show("נמצאו עדכונים לתוסף \"תורת אמת בוורד\". האם ברצונכם להוריד את העדכונים כעת? (העידכונים יישמרו על שלחן העבודה).", "עדכון נמצא!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (result == DialogResult.Yes)
                    {
                        await DownloadFile();
                    }
                }
            }
        }
        catch (Exception ex) { /*MessageBox.Show("Error In: UpdateCheck" + ex.Message); */}
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

    static async Task DownloadFile()
    {
        string fileUrl = "https://drive.google.com/uc?id=1oqWJZKykjLlfvCzaMB2DCdlkHqYEk7pd";
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(fileUrl);

            if (response.IsSuccessStatusCode)
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fullPath = Path.Combine(desktopPath, "תורת אמת בוורד עדכון מס' 3.Zip");

                using (FileStream fileStream = File.Create(fullPath))
                {
                    await response.Content.CopyToAsync(fileStream);
                    MessageBox.Show($"ההורדה הסתיימה.");
                }
            }
            else
            {
               MessageBox.Show($"לא החצחנו להוריד את הקבצים.\r\n Status code: {response.StatusCode}");
            }
        }
    }
}