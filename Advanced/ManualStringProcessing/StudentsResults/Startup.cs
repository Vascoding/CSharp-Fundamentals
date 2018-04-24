using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResults
{
    public class Student
    {
        public string Name { get; set; }
        public double CSharpAdvanced { get; set; }
        public double Oop { get; set; }
        public double AdvancedOop { get; set; }
    }
    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var cAdv = double.Parse(input[1]);
                var cOop = double.Parse(input[2]);
                var advOop = double.Parse(input[3]);
                students.Add(new Student
                {
                    Name = name,
                    CSharpAdvanced = cAdv,
                    Oop = cOop,
                    AdvancedOop = advOop
                });

            }
            Console.WriteLine(string.Format($"{"Name",-10}|{"CAdv",7}|{"COOP",7}|{"AdvOOP",7}|{"Average", 7}|"));
            foreach (var s in students)
            {
                double avg = (s.AdvancedOop + s.CSharpAdvanced + s.Oop)/3;
                Console.WriteLine(string.Format($"{s.Name,-10}|{s.CSharpAdvanced,7:f2}|{s.Oop,7:f2}|{s.AdvancedOop,7:f2}|{avg, 7:f4}|"));

            }
        }
    }
}
