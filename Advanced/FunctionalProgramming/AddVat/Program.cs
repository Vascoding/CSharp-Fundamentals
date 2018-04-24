using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddVat
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).Select(a => a+= a*0.2).ToList().ForEach(b => Console.WriteLine($"{b:f2}"));
           
        }
    }
}
