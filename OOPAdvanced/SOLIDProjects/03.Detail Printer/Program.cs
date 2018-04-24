using System.Collections.Generic;

namespace _03.Detail_Printer
{
    public class Program
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee("Pesho"),
                new Manager("Gosho", new List<string> {"firstDoc", "secondDoc"})
            };
            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.printDetails();
        }
    }
}
