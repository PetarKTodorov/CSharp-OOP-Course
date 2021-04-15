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
            // TODO: write reflection
            return null;
        }
    }
}
