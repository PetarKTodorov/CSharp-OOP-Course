namespace P03.Func
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static Func<string, string> convertMethod;

        public static void Main()
        {
            convertMethod = UppercaseString;

            var names = new string[] { "Gosho", "Pesho", "Ivan", "Olga" };

            //names = names.Select(name => name.ToUpper()).ToArray();

            names = names.Select(convertMethod).ToArray();

            string uppercaseNamesAsString = String.Join(", ", names);

            Console.WriteLine(uppercaseNamesAsString);
        }

        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }
    }
}
