using System;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

class DeleteWordsStartingWithGivenPrefix
{
    static void Main()
    {
        string fileName = "testFile.txt";
        string resultFileName = "resultFile.txt";
        Random randomGenerator = new Random();

        List<string> words = new List<string>(66);
        GenerateWords(words);

        StreamWriter writer = new StreamWriter(fileName, false, Encoding.GetEncoding("windows-1251"));
        using (writer)
        {
            for (int i = 0; i < 200; i++)
            {
                switch (randomGenerator.Next(5))
                {
                    case 0:
                        writer.Write(words[0]);
                        break;
                    case 1:
                        writer.Write(words[1]);
                        break;
                    case 2:
                        writer.Write(words[2]);
                        break;
                    default:
                        writer.Write(words[randomGenerator.Next(words.Count)]);
                        break;
                }
            }
        }

        writer = new StreamWriter(resultFileName, false, Encoding.GetEncoding("windows-1251"));
        StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("windows-1251"));
        using (writer)
        {
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = Regex.Replace(line, @"(\b)test((\d|\w|_)*)(\b)", " ");
                    writer.WriteLine(Regex.Replace(line, @"(\s){2,}", " "));
                    line = reader.ReadLine();
                }
            }
        }


        Process openFile = new Process();
        openFile.StartInfo.FileName = fileName;
        openFile.Start();

        openFile.StartInfo.FileName = resultFileName;
        openFile.Start();
    }

    private static void GenerateWords(List<string> words)
    {
        words.Add("test");
        words.Add("\r\n");
        words.Add(" ");
        words.Add("_");
        for (int i = 48; i <= 57; i++)
        {
            words.Add(((char)i).ToString());
        }
        for (int i = 65; i <= 90; i++)
        {
            words.Add(((char)i).ToString());
        }
        for (int i = 97; i <= 122; i++)
        {
            words.Add(((char)i).ToString());
        }
    }
}