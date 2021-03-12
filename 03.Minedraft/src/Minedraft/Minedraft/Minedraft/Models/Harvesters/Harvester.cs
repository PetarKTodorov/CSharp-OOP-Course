namespace Minedraft.Models.Harvesters
{
    using System;
    using System.Text;

    public abstract class Harvester : BaseModel
    {
        private const int MIN_ORE_OUTPUT = 0;
        private const string ORE_OUTPUT_ERROR = "Harvester is not registered, because of it's OreOutput";

        private const int MIN_ENERGY_REQUIRMENT = 0;
        private const int MAX_ENERGY_REQUIRMENT = 20_000;
        private const string ENERGY_REQUIRMENT_ERROR = "Harvester is not registered, because of it's EnergyRequirement";

        private double oreOutput;
        private double energyRequirement;

        protected Harvester(string id, double oreOutput, double energyRequirement) 
            : base(id)
        {
            this.OreOutput = oreOutput;
            this.EnergyRequirement = energyRequirement;
        }

        public double OreOutput 
        {
            get
            {
                return oreOutput;
            }
            set
            {
                bool isInvalid = value < MIN_ORE_OUTPUT;

                if (isInvalid)
                {
                    throw new ArgumentException(ORE_OUTPUT_ERROR);
                }

                oreOutput = value;
            }
        }

        public double EnergyRequirement 
        {
            get
            {
                return energyRequirement;
            }
            set
            {
                bool isInvalid = value < MIN_ENERGY_REQUIRMENT || value > MAX_ENERGY_REQUIRMENT;

                if (isInvalid)
                {
                    throw new ArgumentException(ENERGY_REQUIRMENT_ERROR);
                }

                energyRequirement = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Type} Harvester – {this.Id}")
                .AppendLine($"Ore Output: {this.OreOutput}")
                .Append($"Energy Requirement: {this.EnergyRequirement}");

            string harvesterAsString = stringBuilder.ToString();

            return harvesterAsString;
        }
    }
}
