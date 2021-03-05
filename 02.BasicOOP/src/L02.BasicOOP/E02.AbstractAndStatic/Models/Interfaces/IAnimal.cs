namespace E02.AbstractAndStatic.Models.Interfaces
{
    public interface IAnimal
    {
        int Id { get; set; }

        string Type { get; set; }

        string Name { get; set; }

        bool IsAlive { get; set; }

        public string Eat();
    }
}
