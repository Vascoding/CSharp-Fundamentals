using System;
using System.Collections.Generic;
using System.Linq;

namespace CompairingObjects
{
    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split();
                people.Add(new Person(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]));
            }
            var n = int.Parse(Console.ReadLine());
            var person = people[n - 1];
            var equal = 0;
            var nonEqual = 0;
            bool isMatch = false;
            for (int i = 0; i < people.Count; i++)
            {
                if (i != n - 1)
                {
                    var num = person.CompareTo(people[i]);
                    if (num != 0)
                    {
                        nonEqual++;
                    }
                    else
                    {
                        isMatch = true;
                        equal++;
                    }
                }
            }
            if (isMatch)
            {
                Console.WriteLine($"{equal += 1} {nonEqual} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
