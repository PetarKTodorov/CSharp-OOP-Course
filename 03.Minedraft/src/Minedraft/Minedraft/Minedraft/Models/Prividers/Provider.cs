namespace Minedraft.Models.Prividers
{
    using System;
    using System.Text;

    public abstract class Provider : BaseModel
    {
        private const int MIN_ENERGY_OUTPUT = 0;
        private const int MAX_ENERGY_OUTPUT = 10_000;

        private const string ENERGY_OUTPUT_ERROR = "Provider is not registered, because of it's EnergyOutput";

        private double energyOutput;

        protected Provider(string id, double energyOutput)
            : base(id)
        {
            this.EnergyOutput = energyOutput;
        }

        public double EnergyOutput { 
            get
            {
                return energyOutput;
            }
            set
            {
                bool isInvalid = value < MIN_ENERGY_OUTPUT || value > MAX_ENERGY_OUTPUT;

                if (isInvalid)
                {
                    throw new ArgumentException(ENERGY_OUTPUT_ERROR);
                }

                energyOutput = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Type} Provider – {this.Id}")
                .Append($"Energy Output: {this.EnergyOutput}");

            string privaderAsString = stringBuilder.ToString();

            return privaderAsString;
        }
    }
}
