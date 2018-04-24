using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByGroup
{
    public class Person
    {
        public string Name { get; set; }

        public int Group { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> students = new List<Person>();
            while (true)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0].Equals("END"))
                {
                    break;
                }
                var name = input.Take(input.Length - 1).ToArray();
                var firstLastName = name[0] + " " + name[1];
                var group = int.Parse(input.Last());
                var stud = new Person
                {
                    Name = firstLastName,
                    Group = group
                };
                students.Add(stud);
            }
            foreach (var student in students.GroupBy(g => g.Group).ToDictionary(k => k.Key).OrderBy(a => a.Key))
            {
                Console.WriteLine($"{student.Key} - {string.Join(", ", student.Value.Select(a => a.Name))}");
            }
        }
    }
}
