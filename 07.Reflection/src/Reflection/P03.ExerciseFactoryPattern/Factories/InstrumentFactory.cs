namespace P03.ExerciseFactoryPattern.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using P03.ExerciseFactoryPattern.Common;
    using P03.ExerciseFactoryPattern.Factories.Interfaces;
    using P03.ExerciseFactoryPattern.Models.Interfaces;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            var instrumentType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(IInstrument).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == type);

            if (instrumentType == null)
            {
                string error = string.Format(ErrorMessages.InvalideInstrument, type);

                throw new ArgumentException(error);
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType);

            return instrument;
        }
    }
}
