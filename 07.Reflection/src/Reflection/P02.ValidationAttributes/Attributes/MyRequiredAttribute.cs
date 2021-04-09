namespace P02.ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool isValid(object obj)
        {
            bool isNotNull = obj == null;

            if (isNotNull)
            {
                return false;
            }

            return true;
        }
    }
}
