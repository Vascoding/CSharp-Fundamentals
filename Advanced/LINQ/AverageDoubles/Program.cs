using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0:f2}", Console.ReadLine().Split().Select(double.Parse).Average());
        }
    }
}
