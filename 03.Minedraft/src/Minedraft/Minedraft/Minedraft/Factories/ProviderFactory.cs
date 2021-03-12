namespace Minedraft.Factories
{
    using System.Collections.Generic;

    using Minedraft.Models.Prividers;

    public class ProviderFactory
    {
        public Provider Create(List<string> arguments)
        {
            Provider provider = null;

            string type = arguments[0];
            string id = arguments[1];
            double energyOutput = double.Parse(arguments[2]);

            switch (type)
            {
                case "Solar": provider = new SolarProvider(id, energyOutput); break;
                case "Pressure": provider = new PressureProvider(id, energyOutput); break;
            }

            return provider;
        }
    }
}
