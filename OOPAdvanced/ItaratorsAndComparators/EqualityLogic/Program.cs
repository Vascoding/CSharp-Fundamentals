using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            SortedSet<Person> sortedPepople = new SortedSet<Person>();
            HashSet<Person> hashPeople = new HashSet<Person>();
            for (int i = 0; i < n; i++)
            {
                var p = Console.ReadLine().Split();
                Person person = new Person(p[0], int.Parse(p[1]));
                sortedPepople.Add(person);
                hashPeople.Add(person);
            }
            Console.WriteLine(sortedPepople.Count);
            Console.WriteLine(hashPeople.Count);
        }
    }
}
