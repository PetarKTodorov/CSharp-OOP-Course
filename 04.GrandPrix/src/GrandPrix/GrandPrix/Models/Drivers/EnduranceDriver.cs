namespace GrandPrix.Models.Drivers
{
    using Vehicles;

    public class EnduranceDriver : Driver
    {
        private const double DEFAULT_FUEL_CONSUMTION_PER_KM = 1.5d;

        public EnduranceDriver(string name, Car car) 
            : base(name)
        {
            this.FuelConsumptionPerKm = DEFAULT_FUEL_CONSUMTION_PER_KM;
            this.Car = car;
        }
    }
}
