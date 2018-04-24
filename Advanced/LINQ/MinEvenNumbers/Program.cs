using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(double.Parse);
            
            if (input.Any(a => a % 2 == 0))
            {
                Console.WriteLine($"{input.Where(a => a % 2 == 0).Min():f2}");
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
