namespace P03.ExerciseFactoryPattern.Factories.Interfaces
{
	using P03.ExerciseFactoryPattern.Models.Interfaces;

	public interface IInstrumentFactory
	{
		IInstrument CreateInstrument(string type);
	}
}
