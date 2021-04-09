namespace P02.ValidationAttributes.Utilities
{
    using System.Linq;
    using System.Reflection;

    using P02.ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties();

            foreach (var property in propertyInfos)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(attribute => attribute is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributes)
                {
                    bool isInvalid = !attribute.isValid(property.GetValue(obj));
                    if (isInvalid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
