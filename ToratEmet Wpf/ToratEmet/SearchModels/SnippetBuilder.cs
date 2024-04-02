using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;

namespace ToratEmet.Models
{
    public static class SnippetBuilder
    {
        public static List<string> SplitStringIntoSnippets(string input, int chunkSize, int overlapIndex)
        {
            List<string> chunks = new List<string>();

            int endIndex = 0;
            int startIndex = 0;
            int snippetLength = 0;
            int inputLength = input.Length;

            if(chunkSize >= inputLength) { chunks.Add(input); return chunks; }
            for (int i = 0; i < inputLength; i++)
            {
                endIndex = Math.Min(inputLength, i + chunkSize);
                startIndex = Math.Max(i - overlapIndex, 0);

                while (endIndex < inputLength && input[endIndex + 1] != ' ') { endIndex++; }//ensures that endindex soes not cut off words in the middle            
                snippetLength = endIndex - startIndex;

                while (startIndex > 0 && snippetLength < chunkSize) { startIndex--; }//ensures symmetrical chunks
                while (startIndex > 0 && input[startIndex - 1] != ' ') { startIndex--; }//ensures that startindex soes not cut off words in the middle            

                chunks.Add(input.Substring(startIndex, snippetLength).Trim());

                i = i + snippetLength;
            }
            return chunks;
        }
    }
}


#region test code
//using Microsoft.Office.Interop.Word;
//using System;
//using System.Collections.Generic;

//namespace ToratEmet.Models
//{
//    public static class SnippetBuilder
//    {
//        public static List<string> SplitStringIntoSnippets(string input, int chunkSize, int overlapIndex)
//        {
//            List<string> chunks = new List<string>();

//            int wordCount = 0;
//            int startIndex = 0;

//            for (int i = 0; i < input.Length; i++)
//            {
//                if (input[i] == ' ')
//                {
//                    wordCount++;
//                    if (wordCount == chunkSize)
//                    {
//                        chunks.Add(input.Substring(startIndex, i - startIndex).Trim());
//                        //Define new chunks Starting point
//                        startIndex = i + 1;
//                        if (overlapIndex <= )
//                            // Move back startIndex to avoid cutting a word in half
//                            while (startIndex > 0 && input[startIndex - 1] != ' ') { startIndex--; }
//                        wordCount = 0;
//                    }
//                }
//            }

//            // Add the remaining text if any
//            if (startIndex < input.Length)
//            {
//                chunks.Add(input.Substring(startIndex).Trim());
//            }

//            return chunks;
//        }
//    }
//}

#endregion 

