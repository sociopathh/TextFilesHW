using System;
using System.IO;

//Write a program that concatenates two text files into another text file.

class ConcatenateTwoFilesIntoOne
{
    static void Main()
    {
        StreamReader readerOne = new StreamReader("../../fileOne.txt");
        StreamReader readerTwo = new StreamReader("../../fileTwo.txt");
        StreamWriter writer = new StreamWriter("concatenated.txt");

        // the file with the two text will be created in the project directory -> bin -> debug
        using (readerOne)
        {
            using (readerTwo)
            {
                using (writer)
                {
                    string textOne = readerOne.ReadToEnd();
                    string textTwo = readerTwo.ReadToEnd();
                    writer.Write(textOne + "\r\n" + textTwo);
                }
            }
        }
    }
}
