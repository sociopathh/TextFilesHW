/*Write a program that reads a list of words from a file words.txt
 * and finds how many times each of the words is contained in another file test.txt.
 * The result should be written in the file result.txt and
 * the words should be sorted by the number of their occurrences in descending order.
 * Handle all possible exceptions in your methods. */
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace TextFiles
{
    class Exercise13
    {
        static void Main()
        {
            try
            {
                var words = File.ReadAllLines("words.txt", Encoding.Default).ToDictionary(line => line, line => 0);
                using (var reader = new StreamReader("text.txt", Encoding.Default))
                    while (!reader.EndOfStream)
                    {
                        var buffer = new StringBuilder();
                        foreach (var ch in reader.ReadLine())
                        {
                            if (!char.IsLetter(ch))
                            {
                                if (words.ContainsKey(buffer.ToString()))
                                    words[buffer.ToString()] += 1;
                                buffer.Clear();
                            }
                            else buffer.Append(ch);
                        }
                    }
                File.WriteAllLines("words13Out.txt", (from item in words orderby item.Value descending select string.Format("{0} {1}", item.Key, item.Value)).ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}:{1}", e.GetType().Name, e.Message);
            }
        }
    }
}