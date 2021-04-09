namespace P02.ValidationAttributes
{
    using System;

    using P02.ValidationAttributes.Entities;
    using P02.ValidationAttributes.Utilities;

    public static class Engine
    {
        public static void Run()
        {
            var person = new Person("Gosho", 16);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
