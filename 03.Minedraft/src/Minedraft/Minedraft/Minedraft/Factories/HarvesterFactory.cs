namespace Minedraft.Factories
{
    using System.Collections.Generic;

    using Minedraft.Models.Harvesters;

    public class HarvesterFactory
    {
        public Harvester Create(List<string> arguments)
        {
            Harvester harvester = null;

            string type = arguments[0];
            string id = arguments[1];
            double oreOutput = double.Parse(arguments[2]);
            double energyRequirement = double.Parse(arguments[3]);

            switch (type)
            {
                case "Hammer":
                    harvester = new HammerHarvester(id, oreOutput, energyRequirement);

                    break;
                case "Sonic":
                    int sonicFactor = int.Parse(arguments[4]);

                    harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);

                    break;
            }


            return harvester;
        }
    }
}
