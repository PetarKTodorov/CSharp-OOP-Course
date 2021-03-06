﻿namespace E02.FirstSteps
{
    using System;

    public class Person
    {
        public Person()
        {
            this.Address = "st. One";
            this.Age = 18;
        }

        public Person(string address)
            :this()
        {
            this.Address = address;
        }

        public Person(string address, int age)
            :this(address)
        {
            this.Age = age;
        }

        public string Address { get; set; }

        public int Age { get; set; }
    }
}
