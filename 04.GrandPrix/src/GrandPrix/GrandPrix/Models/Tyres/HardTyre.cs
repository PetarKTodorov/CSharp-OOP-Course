namespace GrandPrix.Models.Tyres
{
    public class HardTyre : Tyre
    {
        public HardTyre(double hardness) 
            : base(hardness)
        {
            this.Name = "Hard";
        }
    }
}
