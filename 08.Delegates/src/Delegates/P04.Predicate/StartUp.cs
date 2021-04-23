namespace P04.Predicate
{
    using System;

    public class StartUp
    {
        public static Predicate<string> IsUpper;

        public static void Main()
        {
            IsUpper = IsUppercase;

            Console.Write("Enter a text: ");
            string input = Console.ReadLine();

            bool isUpper = IsUpper(input);

            Console.WriteLine($"Is the text uppercase: {isUpper}");
        }

        public static bool IsUppercase(string inputString)
        {
            bool isUppercase = inputString == inputString.ToUpper();

            return isUppercase;
        }
    }
}
