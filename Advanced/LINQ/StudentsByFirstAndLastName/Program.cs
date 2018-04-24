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
                var firstName = input[0];
                var lastName = input[1];
                var stud = new Student
                {
                    FirstName = firstName,
                    LastName = lastName
                };
                students.Add(stud);
            }
            foreach (var student in students.Where(a => a.FirstName.CompareTo(a.LastName) < 0))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }
}
