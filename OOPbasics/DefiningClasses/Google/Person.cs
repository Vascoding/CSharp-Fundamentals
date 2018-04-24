using System;
using System.Collections.Generic;

namespace Google
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Parents = new List<Parent>();
            this.Childrens = new List<Child>();
            this.Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public Company Company { get; set; }
        public Car Car { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Child> Childrens { get; set; }

    }
}
