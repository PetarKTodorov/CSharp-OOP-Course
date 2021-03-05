namespace E02.AbstractAndStatic.Models
{
    using System;

    public class Dog : Animal
    {
        public override bool MakeSound()
        {
            Console.WriteLine("Bay");

            return true;
        }
    }
}
