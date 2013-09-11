using System;
using System.IO;

class Program
{
    static void Main()
    {
        int n = 1;

        using (StreamReader input = new StreamReader("../../test.txt"))
        using (StreamWriter output = new StreamWriter("../../testEnd.txt"))
            for (string line; (line = input.ReadLine()) != null; n++)
                output.WriteLine("{0}.{1}", n, line);
    }
}