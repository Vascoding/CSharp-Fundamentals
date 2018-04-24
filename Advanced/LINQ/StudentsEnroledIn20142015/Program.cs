using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByGroup
{
    public class Student
    {
        public string Enroll { get; set; }

        public List<int> Grade { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0].Equals("END"))
                {
                    break;
                }
                var enroll = input[0];
                var group = input.Skip(1).Select(int.Parse).ToList();
                var stud = new Student
                {
                    Enroll = enroll,
                    Grade = group
                };
                students.Add(stud);
            }
            foreach (var student in students.Where(e => e.Enroll.EndsWith("14") || e.Enroll.EndsWith("15")))
            {
                Console.WriteLine($"{string.Join(" ", student.Grade)}");
            }
        }
    }
}
