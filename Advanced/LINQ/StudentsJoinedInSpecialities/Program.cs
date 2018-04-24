using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsJoinedInSpecialities
{
    public class StudentSpeciality
    {
        public string SpecialtyName { get; set; }
        public string FacultyNumber { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public string FacultyNumber { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<StudentSpeciality> studentSpecialities = new List<StudentSpeciality>();
            List<Student> students = new List<Student>();
            while (true)
            {
                var input = Console.ReadLine().Split(new []{ ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0].Equals("Students:"))
                {
                    break;
                }
                var specialtyName = input[0] + " " + input[1];
                var facultyNumber = input.Last();
                StudentSpeciality sSpec = new StudentSpeciality
                {
                    SpecialtyName = specialtyName,
                    FacultyNumber = facultyNumber
                };
                studentSpecialities.Add(sSpec);
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("END"))
                {
                    break;
                }
                var studentName = "";
                var facultyNumber = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]))
                    {
                        facultyNumber += input[i];
                    }
                    else
                    {
                        studentName += input[i];
                    }
                }
                
                Student student = new Student
                {
                    Name = studentName.Trim(),
                    FacultyNumber = facultyNumber.Trim()
                };
                students.Add(student);
            }

            var query = students.Join(studentSpecialities,
                s => s.FacultyNumber,
                f => f.FacultyNumber,
                (s, f) => new { s.Name, s.FacultyNumber, f.SpecialtyName });
            foreach (var q in query.OrderBy(a => a.Name))
            {
                Console.WriteLine($"{q.Name} {q.FacultyNumber} {q.SpecialtyName}");
            }

            
        }
    }
}
