namespace P03.ExerciseFactoryPattern.Models.Interfaces
{
    public interface IInstrument
    {
        double Wear { get; }

        void Repair();

        void WearDown();

        bool IsBroken { get; }
    }
}
