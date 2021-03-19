namespace GrandPrix.Models.Drivers
{
    using Vehicles;

    public class AggressiveDriver : Driver
    {
        private const double DEFAULT_FUEL_CONSUMTION_PER_KM = 2.7d;
        private const double SPPED_MULTYPLIER= 1.3d;

        public AggressiveDriver(string name, Car car) 
            : base(name)
        {
            this.FuelConsumptionPerKm = DEFAULT_FUEL_CONSUMTION_PER_KM;
            this.Car = car;
        }

        public override double Speed => base.Speed * SPPED_MULTYPLIER;
    }
}
