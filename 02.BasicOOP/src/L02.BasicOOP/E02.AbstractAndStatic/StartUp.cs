namespace E02.AbstractAndStatic
{
    using System;

    using Common;
    using Models.Interfaces;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            Cat cat = new Cat();

            cat.Kill();

            Console.WriteLine(Validator.countErrors);

            
            Console.WriteLine(Constants.DB_CONECTION_STRING);

            bool isValid = Validator.ValidateStringIsNotNull("text");

            Console.WriteLine(isValid);
        }
    }
}
