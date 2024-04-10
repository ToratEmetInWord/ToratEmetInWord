using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows;

namespace ToratEmetInWordInstaller
{
    public static class Installer
    {
        static string destinationFolderPath;
        public static void CopyFiles()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            destinationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "ToratEmetInWord");

            try
            {
                if (!Directory.Exists(destinationFolderPath)) 
                {
                    Directory.CreateDirectory(destinationFolderPath);
                }
              
                string[] files = Directory.GetFiles(Path.Combine(appPath, "SetupFiles"));
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationFilePath = Path.Combine(destinationFolderPath, fileName);
                    File.Copy(file, destinationFilePath, true);

                    if (Path.GetExtension(file).Equals(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        // Unzip the file
                        string extractPath = Path.Combine(destinationFolderPath, Path.GetFileNameWithoutExtension(file));
                        ZipFile.ExtractToDirectory(destinationFilePath, extractPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        public static void RunInstaller(bool vstoInstallOption)
        {
            string[] vstoFiles;
            // Locate the .vsto file and execute it
            if (vstoInstallOption) { vstoFiles = Directory.GetFiles(destinationFolderPath, "*.vsto", SearchOption.AllDirectories); }
            else { vstoFiles = Directory.GetFiles(destinationFolderPath, "*.exe", SearchOption.AllDirectories); }
            if (vstoFiles.Length > 0)
            {
                string vstoFilePath = vstoFiles[0];

                // Start the process and wait for its child processes to finish
                Process process = Process.Start(vstoFilePath);
                if (process == null)
                {
                    MessageBox.Show("Failed to start VSTO installation process.");
                }
            }
            else
            {
                MessageBox.Show("No .vsto file found in the extracted folder.");
            }
        }

        public static void DeleteFiles()
        {
            try{Directory.Delete(destinationFolderPath, true); } catch { }
        }
    }
}