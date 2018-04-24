using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByGroup
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
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
                var student = input.Take(input.Length - 1).ToList();
                var group = input.Last();
                var stud = new Student
                {
                    FirstName = student[0],
                    LastName = student[1],
                    Phone = group
                };
                students.Add(stud);
            }
            foreach (var student in students.Where(p => p.Phone.StartsWith("02") || p.Phone.StartsWith("+3592")))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }
}
