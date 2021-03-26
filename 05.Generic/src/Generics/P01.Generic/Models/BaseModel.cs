namespace P01.Generic.Models
{
    using System;

    public abstract class BaseModel<T> : IBaseModel
    {
        public BaseModel(T id)
        {
            this.Id = id;
        }

        public T Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
