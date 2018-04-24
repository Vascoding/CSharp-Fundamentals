using System;
using System.Collections.Generic;
using System.Linq;
using Google;

namespace _12.Google
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var people = new List<Person>();

            while (input != "End")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var person = people.FirstOrDefault(n => n.Name == tokens[0]);
                if (person == null)
                {
                    //we don't have the person, add them
                    person = new Person(tokens[0]);
                    ProcessCommand(tokens, person);
                    people.Add(person);
                }
                else
                {
                    ProcessCommand(tokens, person);
                }

                input = Console.ReadLine();
            }

            var personName = Console.ReadLine();
            
            var p = people.FirstOrDefault(n => n.Name == personName);
            Console.WriteLine($"{personName}");
            Console.WriteLine("Company:");
            if (p.Company != null)
            {
                Console.WriteLine($"{p.Company.Name} {p.Company.Department} {p.Company.Salary:f2}");
            }
            Console.WriteLine("Car:");
            if (p.Car != null)
            {
                Console.WriteLine($"{p.Car.Model} {p.Car.Speed}");
            }
            Console.WriteLine("Pokemon:");
            foreach (var pok in p.Pokemons)
            {
                Console.WriteLine($"{pok.Name} {pok.Type}");
            }
            Console.WriteLine("Parents:");
            foreach (var per in p.Parents)
            {
                Console.WriteLine($"{per.Name} {per.BirthDay}");
            }
            Console.WriteLine("Children:");
            foreach (var ch in p.Childrens)
            {
                Console.WriteLine($"{ch.Name} {ch.BirthDay}");
            }
        }

        private static void ProcessCommand(string[] tokens, Person person)
        {
            switch (tokens[1])
            {
                case "company":
                    person.Company = new Company(tokens[2], tokens[3], double.Parse(tokens[4]));
                    break;
                case "pokemon":
                    person.Pokemons.Add(new Pokemon(tokens[2], tokens[3]));
                    break;
                case "parents":
                    person.Parents.Add(new Parent(tokens[2], tokens[3]));
                    break;
                case "children":
                    person.Childrens.Add(new Child(tokens[2], tokens[3]));
                    break;
                case "car":
                    person.Car = new Car(tokens[2], int.Parse(tokens[3]));
                    break;
            }
        }
    }
}