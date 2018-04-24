using System;
using System.Collections.Generic;
using System.Linq;

namespace DefineClassPerson
{
    public class Family
    {
        public Family()
        {
            this.persons = new List<Person>();
        }
        private List<Person> persons;

        public List<Person> Persons
        {
            get { return this.persons; }
            set { this.persons = value; }
        }

        public void AddMember(Person member)
        {
            this.persons.Add(member);
        }

        public static Person GetOldestMember(Family family)
        {
            var max = family.persons.Max(a => a.age);
            Person person = family.persons.FirstOrDefault(a => a.age == max);
            return person;
        }
    }
}
