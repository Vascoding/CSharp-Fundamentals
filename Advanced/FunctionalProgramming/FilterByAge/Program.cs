using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                people.Add(input[0], int.Parse(input[1]));
            }
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine().Split();

            if (format.Length > 1)
            {
                if (condition.Equals("younger"))
                {
                    foreach (var p in people.Where(a => a.Value <= age))
                    {
                        Console.WriteLine($"{p.Key} - {p.Value}");
                    }
                }
                else
                {
                    foreach (var p in people.Where(a => a.Value >= age))
                    {
                        Console.WriteLine($"{p.Key} - {p.Value}");
                    }
                }
            }
            else
            {
                if (format[0].Equals("name"))
                {
                    if (condition.Equals("younger"))
                    {
                        foreach (var p in people.Where(a => a.Value <= age))
                        {
                            Console.WriteLine($"{p.Key}");
                        }
                    }
                    else
                    {
                        foreach (var p in people.Where(a => a.Value >= age))
                        {
                            Console.WriteLine($"{p.Key}");
                        }
                    }
                }
                if (format[0].Equals("age"))
                {
                    if (condition.Equals("younger"))
                    {
                        foreach (var p in people.Where(a => a.Value <= age))
                        {
                            Console.WriteLine($"{p.Value}");
                        }
                    }
                    else
                    {
                        foreach (var p in people.Where(a => a.Value >= age))
                        {
                            Console.WriteLine($"{p.Value}");
                        }
                    }
                }
            }
        }
    }
}