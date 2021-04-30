namespace P02.ExtentionMethod
{
    using System;

    public static class MyExtensions
    {
        public static int WordCount(this string text)
        {
            string splitSymbols = " .?";

            int words = text.Split(splitSymbols.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;

            return words;
        }
    }
}
