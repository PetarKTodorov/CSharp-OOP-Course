namespace E02.AbstractAndStatic.Common
{
    using System;

    public static class Validator
    {
        public static int countErrors = 0;

        static Validator()
        {
            countErrors = 0;
        }

        public static bool ValidateStringIsNotNull(string value)
        {
            bool isValid = true;

            if (value == null)
            {
                isValid = false;
            }

            return isValid;
        }

        public static void IncrementErrorCount()
        {
            countErrors++;
        }


    }
}
