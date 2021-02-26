namespace E01.GetAndSet
{
    using System;

    public class Kid : Person
    {
        private const string AGE_RANGE_ERROR_MESSAGE = "You are not a kid anymore.";

        private byte age;

        public Kid()
        {
            this.HasToy = true;
        }

        public Kid(string name, byte age)
            :base(name)
        {
            this.Age = age;
        }

        public bool HasToy { get; set; }

        public override byte Age 
        {
            get 
            { 
                return this.age;
            }
            set 
            {
                string exeption = string.Empty;

                if (value >= 18)
                {
                    exeption = AGE_RANGE_ERROR_MESSAGE;
                }

                bool isInvalid = exeption.Length != 0;

                if (isInvalid)
                {
                    throw new Exception(exeption);
                }

                this.age = value; 
            } 
        }

        public override void Run()
        {
            Console.WriteLine("Run Run");
        }

        public override string ToString()
        {
            string kidAsString = base.ToString() + $" HasToy: {this.HasToy}";

            return kidAsString;
        }
    }
}
