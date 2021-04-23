namespace P02.Action
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static Action<string> MessageTarget;

        public static void Main()
        {
            Console.Write("Enter a text: ");
            string input = Console.ReadLine();

            if (input.Length >= 3)
            {
                MessageTarget = WriteToFile;
            } 
            else
            {
                MessageTarget = Console.WriteLine;
            }

            MessageTarget(input);
        }

        public static void WriteToFile(string text)
        {
            string path = "../../../my-file.txt";

            using (var writeText = new StreamWriter(path))
            {
                writeText.WriteLine(text);
            }
        }
    }
}
