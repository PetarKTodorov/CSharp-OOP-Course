namespace E02.AbstractAndStatic.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    public abstract class Animal : IAnimal
    {
        protected Animal()
        {

        }

        protected Animal(int id, string type, string name)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }

        public string Eat()
        {
            throw new NotImplementedException();
        }

        public abstract bool MakeSound();

        public bool Kill()
        {
            if (this.IsAlive == false)
            {
                Console.WriteLine("Is allready dead.");
            }

            this.IsAlive = false;

            return this.IsAlive;
        }
    }
}
