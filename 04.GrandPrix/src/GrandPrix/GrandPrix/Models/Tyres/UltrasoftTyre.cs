namespace GrandPrix.Models.Tyres
{
    using System;

    using Constants;

    public class UltrasoftTyre : Tyre
    {
        private const double MIN_DEGRADATION = 30;

        public UltrasoftTyre(double hardness, double grip) 
            : base(hardness)
        {
            this.Name = "Ultrasoft";
            this.Grip = grip;
        }

        public double Grip { get; private set; }

        public override double Degradation 
        {
            get => base.Degradation; 
            protected set
            {
                bool isInvalid = value < MIN_DEGRADATION;

                if (isInvalid)
                {
                    throw new ArgumentException(OutputMessages.BlownTyre);
                }

                base.Degradation = value;
            }
        }

        public override void CompleteLap()
        {
            base.CompleteLap();

            this.Degradation -= this.Grip;
        }
    }
}
