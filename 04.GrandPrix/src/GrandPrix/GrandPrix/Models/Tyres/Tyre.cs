namespace GrandPrix.Models.Tyres
{
    using System;

    using Constants;

    public class Tyre
    {
        private const double MIN_DEGRADATION = 0;
        private const int DEFAULT_DEGRADATION_VALUE = 100;

        private double degradation;

        public Tyre(double hardness)
        {
            this.Hardness = hardness;
            this.Degradation = DEFAULT_DEGRADATION_VALUE;
        }

        public string Name { get; protected set; }

        public double Hardness { get; private set; }

        public virtual double Degradation 
        { 
            get
            {
                return degradation;
            }
            protected set
            {
                bool isInvalid = value < MIN_DEGRADATION;

                if (isInvalid)
                {
                    throw new ArgumentException(OutputMessages.BlownTyre);
                }

                degradation = value;
            }
        }

        public virtual void CompleteLap()
        {
            this.Degradation -= this.Hardness;
        }

    }
}
