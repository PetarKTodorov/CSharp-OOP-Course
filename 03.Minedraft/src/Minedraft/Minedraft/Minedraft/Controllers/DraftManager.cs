namespace Minedraft.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Minedraft.Factories;
    using Minedraft.Models;
    using Minedraft.Models.Harvesters;
    using Minedraft.Models.Prividers;

    public class DraftManager
    {
        private HarvesterFactory harvesterFactory;
        private ProviderFactory providerFactory;
        private List<Harvester> harvesters;
        private List<Provider> providers;
        private string mode;
        private double totalStoredEnergy;
        private double totalMinedOre;
        private StringBuilder stringBuilder;

        public DraftManager()
        {
            this.harvesterFactory = new HarvesterFactory();
            this.providerFactory = new ProviderFactory();
            this.harvesters = new List<Harvester>();
            this.providers = new List<Provider>();
            this.mode = "Full";
            this.totalStoredEnergy = 0;
            this.totalMinedOre = 0;
            this.stringBuilder = new StringBuilder();
        }

        public string RegisterHarvester(List<string> arguments)
        {
            this.stringBuilder.Clear();

            try
            {
                Harvester harvester = harvesterFactory.Create(arguments);
                this.harvesters.Add(harvester);

                this.stringBuilder.Append($"Successfully registered {harvester.Type} Harvester – {harvester.Id}");
            }
            catch (ArgumentException ae)
            {
                this.stringBuilder.Append(ae.Message);
            }

            string result = this.stringBuilder.ToString();

            return result;
        }

        public string RegisterProvider(List<string> arguments)
        {
            string result = string.Empty;

            try
            {
                Provider provider = providerFactory.Create(arguments);
                this.providers.Add(provider);

                result = $"Successfully registered {provider.Type} Provider – {provider.Id}";
            }
            catch (ArgumentException ae)
            {
                result = ae.Message;
            }

            return result;
        }

        public string Day()
        {
            this.stringBuilder.Clear();

            double dayEnergyOutput = this.providers.Sum(provider => provider.EnergyOutput);

            this.totalStoredEnergy += dayEnergyOutput;

            double dayOreOutput;
            double dayEnergyRequired;

            if (this.mode == "Full")
            {
                dayEnergyRequired = this.harvesters.Sum(harvester => harvester.EnergyRequirement);
                dayOreOutput = this.harvesters.Sum(harvester => harvester.OreOutput);
            }
            else if (this.mode == "Half")
            {
                dayEnergyRequired = this.harvesters.Sum(harvester => harvester.EnergyRequirement) * 0.6;
                dayOreOutput = this.harvesters.Sum(harvester => harvester.OreOutput) * 0.5;
            }
            else
            {
                dayOreOutput = 0;
                dayEnergyRequired = 0;
            }


            double dayOreResult = 0;
            if (this.totalStoredEnergy >= dayEnergyRequired)
            {
                this.totalStoredEnergy -= dayEnergyRequired;
                this.totalMinedOre += dayOreOutput;
                dayOreResult = dayOreOutput;
            }

            this.stringBuilder.AppendLine("A day has passed.")
                .AppendLine($"Energy Provided: {dayEnergyOutput}")
                .Append($"Plumbus Ore Mined: {dayOreResult}");

            string result = stringBuilder.ToString();

            return result;
        }

        public string Mode(List<string> arguments)
        {
            string mode = arguments[0];

            this.mode = mode;

            string result = $"Successfully changed working mode to {this.mode} Mode";

            return result;
        }

        public string Check(List<string> arguments)
        {
            string result = string.Empty;
            string id = arguments[0];

            BaseModel unit = (BaseModel)this.harvesters.FirstOrDefault(harvester => harvester.Id == id)
                ?? (BaseModel)this.providers.FirstOrDefault(provider => provider.Id == id);

            if (unit == null)
            {
                result = $"No element found with id – {id}";
            }
            else
            {
                result = unit.ToString();
            } 

            return result;
        }

        public string ShutDown()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("System Shutdown")
                .AppendLine($"Total Energy Stored: {this.totalStoredEnergy}")
                .Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

            string result = stringBuilder.ToString();

            return result;
        }
    }
}
