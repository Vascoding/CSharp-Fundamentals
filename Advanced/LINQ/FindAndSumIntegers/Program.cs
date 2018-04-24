using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndSumIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(n =>
                {
                    long num;
                    bool success = long.TryParse(n, out num);
                    return new {num, success};
                }).Where(a => a.success)
                .Select(v => v.num)
                .ToList();
            if (input.Count != 0)
            {
                Console.WriteLine(input.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
