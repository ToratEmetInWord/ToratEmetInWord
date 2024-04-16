using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToratEmet.Models
{
    public static class DetectFileType
    {
        public static bool IsTextFile(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    char[] buffer = new char[1024];
                    int bytesRead = sr.ReadBlock(buffer, 0, buffer.Length);

                    foreach (char c in buffer)
                    {
                        if (c == '\0')
                            return false; // Non-textual characters found, not a text file
                    }
                    return true; // No non-textual characters found, it's likely a text file
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is NotSupportedException)
            {
                // Handle exceptions if file cannot be read or accessed
                return false;
            }
        }
    }
}
