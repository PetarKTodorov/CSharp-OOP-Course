namespace P01.Generic.Models
{
    public class Person : BaseModel<int>
    {
        public Person(int id, string name)
            :base(id)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            string result = $"{this.Id} - Name: {this.Name}";

            return result;
        }
    }
}
