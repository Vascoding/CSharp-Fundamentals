using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsOfElements
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < input[0]; i++)
            {
                var num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }

            for (int i = 0; i < input[1]; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (firstSet.Contains(num))
                {
                    secondSet.Add(num);
                }
            }
            Console.WriteLine(string.Join(" ", secondSet));
        }
    }
}
