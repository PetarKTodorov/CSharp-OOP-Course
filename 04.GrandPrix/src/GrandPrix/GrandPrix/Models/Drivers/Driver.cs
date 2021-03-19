namespace GrandPrix.Models.Drivers
{
    using Tyres;
    using Vehicles;

    public abstract class Driver
    {
        private const double BOX_DEFAULT_TIME = 20d;
        private const double TOTAL_TIME_DIVIDER = 60d;

        public Driver(string name)
        {
            this.Name = name;
            this.TotalTime = 0d;
            this.IsRacing = true;
        }

        public string Name { get; private set; }

        public double TotalTime { get; set; }

        public Car Car { get; protected set; }

        public double FuelConsumptionPerKm { get; protected set; }

        public virtual double Speed => (this.Car.Horsepower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

        public string FailureReason { get; private set; }

        public bool IsRacing { get; private set; }

        public string Status => this.IsRacing ? this.TotalTime.ToString("F3") : this.FailureReason;

        public void Reful(string[] methodArguments)
        {
            this.Box();

            double fuelAmount = double.Parse(methodArguments[0]);

            this.Car.Refuel(fuelAmount);
        }

        public void ChangeTyres(Tyre tyre)
        {
            this.Box();

            this.Car.ChangeTyre(tyre);
        }

        public override string ToString()
        {
            string driverAsText = $"{this.Name} {this.Status}";

            return driverAsText;
        }

        public void CompleteLap(int trackLength)
        {
            this.TotalTime += TOTAL_TIME_DIVIDER / (trackLength / this.Speed);

            this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
        }

        public void Fail(string message)
        {
            this.IsRacing = false;
            this.FailureReason = message;
        }

        private void Box()
        {
            this.TotalTime += BOX_DEFAULT_TIME;
        }
    }
}
