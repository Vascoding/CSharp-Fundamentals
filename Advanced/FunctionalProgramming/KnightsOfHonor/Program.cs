using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> print = message => Console.WriteLine("Sir " + string.Join("\r\nSir ", message));
            print(Console.ReadLine().Split().ToList());
        }
    }
}
