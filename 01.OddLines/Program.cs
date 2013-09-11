using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        int lineNumber = 1;

        using (StreamReader input = new StreamReader("../../Text.txt"))
            for (string line; (line = input.ReadLine()) != null; lineNumber++)
                if (lineNumber % 2 == 1) Console.WriteLine(line);      
    }
}