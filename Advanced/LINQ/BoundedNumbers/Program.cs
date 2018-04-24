using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var bound = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n >= Math.Min(bound[0], bound[1]) && n <= Math.Max(bound[0], bound[1]))
                .ToList()
                .ForEach(a => Console.Write(a + " "));
        }
    }
}
