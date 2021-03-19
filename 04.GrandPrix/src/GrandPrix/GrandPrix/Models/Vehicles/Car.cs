namespace GrandPrix.Models.Vehicles
{
    using System;

    using Tyres;
    using Constants;

    public class Car
    {
        private const double MAX_FUEL_AMOUNT = 160;
        private const double MIN_FUEL_AMOUNT = 0;

        private double fuelAmount;

        public Car(int horsepower, double fuelAmount, Tyre tyre)
        {
            this.Horsepower = horsepower;
            this.FuelAmount = fuelAmount;
            this.Tyre = tyre;
        }

        public int Horsepower { get; private set; }

        public double FuelAmount 
        { 
            get
            {
                return fuelAmount;
            }
            set
            {
                bool isInvalid = value < MIN_FUEL_AMOUNT;

                if (isInvalid)
                {
                    throw new ArgumentException(OutputMessages.OutOfFuel);
                }

                fuelAmount = Math.Min(value, MAX_FUEL_AMOUNT);
            } 
        }

        public Tyre Tyre { get; private set; }

        public void Refuel(double fuelAmount)
        {
            this.fuelAmount += fuelAmount;
        }

        public void ChangeTyre(Tyre tyre)
        {
            this.Tyre = tyre;
        }

        public void CompleteLap(int trackLength, double fuelConsumption)
        {
            this.FuelAmount -= trackLength * fuelConsumption;

            this.Tyre.CompleteLap();
        }
    }
}
