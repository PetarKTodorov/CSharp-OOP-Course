namespace P03.ExerciseFactoryPattern.Models
{
    public class Guitar : Instrument
    {
        private const int REPAIER_AMOUNT = 60;

        protected override int RepairAmount => REPAIER_AMOUNT;
    }
}
