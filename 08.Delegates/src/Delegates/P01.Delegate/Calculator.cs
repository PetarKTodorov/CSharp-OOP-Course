namespace P01.Delegate
{
    public class Calculator
    {
        public Calculator()
        {
            this.Sum = (decimal)default;
        }

        public Calculator(decimal defaultSum)
            :this()
        {
            this.Sum = defaultSum;
        }

        public decimal Sum { get; private set; }

        public void AddNumber(decimal number)
        {
            this.Sum += number;
        }

        public void MultipleNumber(decimal number)
        {
            this.Sum *= number;
        }
    }
}
