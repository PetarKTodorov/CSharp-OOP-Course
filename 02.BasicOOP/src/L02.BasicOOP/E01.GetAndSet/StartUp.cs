namespace E01.GetAndSet
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = "Estel";
            byte age = 19;

            Person person = new Person(name, age);

            Console.WriteLine(person);

            Kid kid = new Kid("Gosho", 17);

            Console.WriteLine(kid);
        }
    }
}
