namespace P02.ValidationAttributes.Entities
{
    using P02.ValidationAttributes.Attributes;

    public class Person
    {
        private const int MIN_RANGE_AGE = 12;
        private const int MAX_RANGE_AGE = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MIN_RANGE_AGE, MAX_RANGE_AGE)]
        public int Age { get; private set; }
    }
}
