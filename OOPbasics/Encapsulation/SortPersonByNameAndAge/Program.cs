using System;
using System.Collections.Generic;
using System.Linq;

namespace SortPersonByNameAndAge
{
    public class Program
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            Team team = new Team("maic");
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        double.Parse(cmdArgs[3]));

                persons.Add(person);
                team.AddPlayer(person);
            }

            Console.WriteLine(team.FirstTeam.Count);
            Console.WriteLine(team.ReserveTeam.Count);
        }
    }
}
