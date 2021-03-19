namespace GrandPrix.Factories
{
    using System;

    using Constants;
    using Models.Tyres;

    public class TyreFactory
    {
        public Tyre Create(string[] tyreArguments)
        {
            string type = tyreArguments[0];
            double hardness = double.Parse(tyreArguments[1]);

            Tyre tyre = null;

            if (type == "Hard")
            {
                tyre = new HardTyre(hardness);

                return tyre;
            }
            else if (type == "Ultrasoft")
            {
                double grip = double.Parse(tyreArguments[2]);

                tyre = new UltrasoftTyre(hardness, grip);

                return tyre;
            }

            throw new ArgumentException(OutputMessages.InvalidTyreType);
        }
    }
}
