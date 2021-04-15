namespace P03.ExerciseFactoryPattern.Models
{
    public class Drums : Instrument
    {
        private const int REPAIER_AMOUNT = 20;

        protected override int RepairAmount => REPAIER_AMOUNT;
    }
}
