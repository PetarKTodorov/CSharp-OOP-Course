namespace Minedraft.Models.Harvesters
{
    public class HammerHarvester : Harvester
    {
        public HammerHarvester(string id, double oreOutput, double energyRequirement) 
            : base(id, oreOutput, energyRequirement)
        {
            this.OreOutput *= 3;
            this.EnergyRequirement *= 2;
        }

        public override string Type => "Hammer";
    }
}
