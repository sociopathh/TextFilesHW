using System;
using System.IO;
using System.Collections.Generic;

class SortWords
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("words.txt"))
        {
            List<string> names = new List<string>();

            for (string currentName = reader.ReadLine(); currentName != null; currentName = reader.ReadLine())
            {
                names.Add(currentName);
            }

            names.Sort();

            using (StreamWriter writer = new StreamWriter("sortedWords.txt"))
            {
                foreach (string name in names) writer.WriteLine(name);
            }
        }
    }
}