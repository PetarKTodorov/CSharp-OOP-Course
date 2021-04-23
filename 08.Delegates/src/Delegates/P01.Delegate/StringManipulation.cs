namespace P01.Delegate
{
    using System;
    using System.IO;

    public class StringManipulation
    {
        public delegate void PrintString(string text);

        public void WriteToConosoleScreen(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteToFile(string text)
        {
            string path = "../../../my-file.txt";

            using (var writeText = new StreamWriter(path))
            {
                writeText.WriteLine(text);
            }
        }

        public void PrintStringTo(PrintString method)
        {
            Console.WriteLine("Hi");

            method("Hello World");
        }

        public void Run()
        {
            var printString1 = new PrintString(this.WriteToConosoleScreen);
            var printString2 = new PrintString(this.WriteToFile);

            PrintStringTo(printString1);
            PrintStringTo(printString2);
        }
    }
}
