using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                var command = Console.ReadLine();
                if (command.Equals("Party!"))
                {
                    break;
                }
                if (command.Trim().StartsWith("Remove"))
                {
                    var criteria = command.Split(new[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    if (criteria[1].Trim().Equals("StartsWith"))
                    {
                        var remove = names.Where(n => n.StartsWith(criteria[2], StringComparison.InvariantCultureIgnoreCase)).ToList();
                        names = names.Except(remove).ToList();
                    }
                    if (criteria[1].Trim().Equals("EndsWith"))
                    {
                        var remove = names.Where(n => n.EndsWith(criteria[2], StringComparison.InvariantCultureIgnoreCase)).ToList();
                        names = names.Except(remove).ToList();
                    }
                    if (criteria[1].Trim().Equals("Length"))
                    {
                        var remove = names.Where(n => n.Length == int.Parse(criteria[2])).ToList();
                        names = names.Except(remove).ToList();
                    }
                }
                if (command.Trim().StartsWith("Double"))
                {
                    var criteria = command.Split(new[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    if (criteria[1].Trim().Equals("StartsWith"))
                    {
                        var add = names.Where(n => n.StartsWith(criteria[2], StringComparison.InvariantCultureIgnoreCase)).ToList();
                        var person = names.FirstOrDefault(n => n.StartsWith(criteria[2], StringComparison.InvariantCultureIgnoreCase));
                        for (int i = 0; i < add.Count * 2 - add.Count; i++)
                        {
                            names.Add(person);
                        }

                    }
                    if (criteria[1].Trim().Equals("EndsWith"))
                    {
                        var add = names.Where(n => n.EndsWith(criteria[2], StringComparison.InvariantCultureIgnoreCase)).ToList();
                        var person = names.FirstOrDefault(n => n.EndsWith(criteria[2], StringComparison.InvariantCultureIgnoreCase));
                        for (int i = 0; i < add.Count * 2 - add.Count; i++)
                        {
                            names.Add(person);
                        }
                        
                    }
                    if (criteria[1].Trim().Equals("Length"))
                    {
                        var add = names.Where(n => n.Length == int.Parse(criteria[2])).ToList();
                        var person = names.FirstOrDefault(n => n.Length == int.Parse(criteria[2]));
                        for (int i = 0; i < add.Count * 2 - add.Count; i++)
                        {
                            names.Add(person);
                        }
                    }
                }
            }
            if (names.Count > 0)
            {
                Console.Write(string.Join(", ", names));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
