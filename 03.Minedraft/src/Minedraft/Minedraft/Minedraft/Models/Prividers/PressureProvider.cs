namespace Minedraft.Models.Prividers
{
    public class PressureProvider : Provider
    {
        private const double ENERGY_OUTPUT_INCREASE_MULTIPLAYER = 1.5;

        public PressureProvider(string id, double energyOutput) 
            : base(id, energyOutput)
        {
            this.EnergyOutput *= ENERGY_OUTPUT_INCREASE_MULTIPLAYER;
        }

        public override string Type => "Pressure";
    }
}
