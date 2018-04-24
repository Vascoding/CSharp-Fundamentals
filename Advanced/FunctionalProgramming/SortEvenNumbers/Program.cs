using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _11___The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main()
        {
            List<string> people = new List<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()));
            List<string> filters = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Print")
                {
                    break;
                }

                var commands = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0].Contains("Add"))
                {
                    filters.Add(commands[1] + " " + commands[2]);
                }
                else if (commands[0].Contains("Remove"))
                {
                    filters.Remove(commands[1] + " " + commands[2]);
                }
            }

            foreach (var filter in filters)
            {
                string[] commands = filter.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Starts")
                {
                    var toRemove = people.Where(p => p.StartsWith(commands[2], StringComparison.InvariantCultureIgnoreCase));
                    people = people.Except(toRemove).ToList();
                }
                else if (commands[0] == "Ends")
                {
                    var toRemove = people.Where(p => p.EndsWith(commands[2], StringComparison.InvariantCultureIgnoreCase));
                    people = people.Except(toRemove).ToList();
                }
                else if (commands[0] == "Length")
                {
                    var toRemove = people.Where(p => p.Length == int.Parse(commands[1]));
                    people = people.Except(toRemove).ToList();
                }
                else if (commands[0] == "Contains")
                {
                    var toRemove = people.Where(p => p.ToLower().Contains(commands[1].ToLower()));
                    people = people.Except(toRemove).ToList();
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}