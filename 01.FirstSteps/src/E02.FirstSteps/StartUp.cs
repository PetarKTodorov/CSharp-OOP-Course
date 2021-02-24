namespace E02.FirstSteps
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Person person1 = new Person();

            Person person2 = new Person("st. Two");

            Person person3 = new Person("st. 3", 19);

            person3.Address = "new Address";

            Console.WriteLine(person2.Address);
        }
    }
}
