using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public static class StreamReaderX
    {
        public static StreamReader Reader(string filePath)
        {
            if (filePath.Contains("ToratEmetInstall") || filePath.Contains("ToratEmetUserData"))
            {
                return new StreamReader(filePath, Encoding.GetEncoding("Windows-1255"));
            }
            else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    for (int i = 0; i < 20; i++)
                    {
                        if ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains("�"))
                            {
                                return new StreamReader(filePath, Encoding.GetEncoding("Windows-1255"));
                            }
                        }
                        else
                        {
                            break; // End of file reached before 20 lines
                        }
                    }
                }
            }
            return new StreamReader(filePath); // Default encoding
        }
    }
}
