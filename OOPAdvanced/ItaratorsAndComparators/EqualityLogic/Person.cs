using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }
        public bool Equals(Person other)
        {
            var result = this.Name.Equals(other.Name);
            if (result)
            {
                result = this.Age.Equals(other.Age);
            }
            return result;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}