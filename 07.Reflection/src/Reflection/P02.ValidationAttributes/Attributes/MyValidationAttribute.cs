namespace P02.ValidationAttributes.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool isValid(object obj);
    }
}
