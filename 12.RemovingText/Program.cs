//Write a program that removes from a text file all words
//listed in given another text file. Handle all possible exceptions in your methods.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextFiles
{
    internal class Exercise12
    {
        private static void Main()
        {
            try
            {
                var words = File.ReadAllLines("words.txt", Encoding.Default);
                using (var reader = new StreamReader("text.txt", Encoding.Default))
                using (var writer = new StreamWriter("textOut.txt"))
                    while (!reader.EndOfStream)
                    {
                        var line = new StringBuilder(reader.ReadLine());
                        var buffer = new StringBuilder();
                        for (int i = 0; i < line.Length; i++)
                        {
                            var ch = line[i];
                            if (!char.IsLetter(ch))
                            {
                                if (words.Contains(buffer.ToString()))
                                {
                                    line.Remove(i - buffer.Length, buffer.Length);
                                    i -= buffer.Length;
                                }
                                buffer.Clear();
                            }
                            else
                            {
                                buffer.Append(ch);
                            }
                        }
                        writer.WriteLine(line.ToString());
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}:{1}", e.GetType().Name, e.Message);
            }
        }
    }
}