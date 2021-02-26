namespace E01.GetAndSet
{
    using System;

    public class Person
    {
        private const string NAME_LENGHT_ERROR_MESSAGE = "Name must be more then 2 symbols.";
        private const string NAME_WHITESPACE_AND_NULL_ERROR_MESSAGE = "Name must can not be null or empty or with spaces.";

        private readonly string emailMessage = "Hi";

        private string name;
        private byte age;
        
        public Person()
        {
           
        }

        public Person(string name)
            :this()
        {
            this.Name = name;
        }

        public Person(string name, byte age)
            :this(name)
        {
            this.Age = age;
        }

        public virtual byte Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public string Name { 
            get
            {
                return this.name;
            }
            set
            {
                string exeption = string.Empty;

                if (value.Length < 2)
                {
                    exeption = NAME_LENGHT_ERROR_MESSAGE;
                }
                else if(String.IsNullOrWhiteSpace(value))
                {
                    exeption = NAME_WHITESPACE_AND_NULL_ERROR_MESSAGE;
                }

                bool isInvalid = exeption.Length != 0;

                if (isInvalid)
                {
                    throw new Exception(exeption);
                }

                this.name = value;
            }
        }

        public virtual void Run()
        {
            Console.WriteLine("Run.");
        }

        public override string ToString()
        {
            string personAsString = $"{this.GetType().Name} -> Name: {this.Name}; Age: {this.Age};";

            return personAsString;
        }
    }
}
