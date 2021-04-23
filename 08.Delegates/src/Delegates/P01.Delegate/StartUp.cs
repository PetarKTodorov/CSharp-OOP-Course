namespace P01.Delegate
{
    using System;

    public class StartUp
    {
        public delegate void NumberChanger(decimal number);

        public static void Main()
        {
            //TestCalculator();

            TestStringManipulation();
        }

        private static void TestStringManipulation()
        {
            StringManipulation stringManipulation = new StringManipulation();

            stringManipulation.Run();
        }

        private static void TestCalculator()
        {
            var calculator = new Calculator();

            NumberChanger numberChanger;
            var numberChanger1 = new NumberChanger(calculator.AddNumber);
            var numberChanger2 = new NumberChanger(calculator.MultipleNumber);

            numberChanger1(20);
            Console.WriteLine($"Value of Numbers: {calculator.Sum}");

            numberChanger2(4);
            Console.WriteLine($"Value of Numbers: {calculator.Sum}");

            numberChanger = numberChanger1;
            numberChanger += numberChanger2;

            numberChanger(2);
            Console.WriteLine($"Value of Numbers: {calculator.Sum}");
        }
    }
}
