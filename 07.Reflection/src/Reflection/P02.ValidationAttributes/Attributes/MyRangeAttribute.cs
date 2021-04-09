namespace P02.ValidationAttributes.Attributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool isValid(object obj)
        {
            int value = Convert.ToInt32(obj);

            bool isValid = value < minValue || value > maxValue;
            if (isValid)
            {
                return false;
            }

            return true;
        }
    }
}
