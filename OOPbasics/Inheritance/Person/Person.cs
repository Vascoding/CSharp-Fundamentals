﻿using System;
using System.Text;

namespace Person
{
    class Person
    {
        private int age;
        private string name;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }


        public virtual string Name
        {
            get { return this.name; }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(@"Name's length should not be less than 3 symbols!");
                }
                this.name = value;
            }
        }


        public virtual int Age
        {
            get { return this.age; }
            protected set
            {

                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.name}, Age: {this.age}";
        }

    }
}
