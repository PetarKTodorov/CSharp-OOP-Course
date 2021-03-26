namespace P01.Generic
{
    using System;
    using System.Collections.Generic;

    using P01.Generic.Models;

    public class StartUp
    {
        public static void Main()
        {
            var myCollection = new MyCollection<IBaseModel>();

            var baseModel1 = new Person(1, "Gosho");
            var baseModel2 = new Person(2, "Pesho");

            var baseModel3 = new Car("3sddfsdf", "Lada");
            var baseModel4 = new Car("4sdfsdfs", "Volga");

            myCollection.Add(baseModel1);
            myCollection.Add(baseModel2);
            myCollection.Add(baseModel3);
            myCollection.Add(baseModel4);

            Console.WriteLine(myCollection);
        }
    }
}
