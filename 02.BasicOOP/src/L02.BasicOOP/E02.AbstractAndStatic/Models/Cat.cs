namespace E02.AbstractAndStatic.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cat : Animal
    {
        public override bool MakeSound()
        {
            Console.WriteLine("May");

            return true;
        }
    }
}
