using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            SortedSet<Person> peopleSortByName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> peopleSortByAge = new SortedSet<Person>(new AgeComparator());
            for (int i = 0; i < n; i++)
            {
                var p = Console.ReadLine().Split();
                peopleSortByName.Add(new Person(p[0], int.Parse(p[1])));
                peopleSortByAge.Add(new Person(p[0], int.Parse(p[1])));
            }

            foreach (var person in peopleSortByName)
            {
                Console.WriteLine(person);
            }
            foreach (var person in peopleSortByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
