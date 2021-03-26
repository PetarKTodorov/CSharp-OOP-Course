namespace P01.Generic.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyCollection<T> 
        where T : IBaseModel
    {
        private readonly IList<T> list;

        public MyCollection()
        {
            this.list = new List<T>();
        }

        public void Add(T item)
        {
            this.list.Add(item);
        }

        public void Remove(T item)
        {
            this.list.Remove(item);
        }

        public override string ToString()
        {
            string listAsText = string.Join(Environment.NewLine, this.list);

            return listAsText;
        }
    }
}
