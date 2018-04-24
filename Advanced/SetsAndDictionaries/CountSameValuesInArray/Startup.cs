using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSameValuesInArray
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);
            SortedDictionary<double, int> dict = new SortedDictionary<double, int>();

            foreach (var i in input)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i] += 1;
                }
                else
                {
                    dict.Add(i, 1);
                }
            }
            foreach (var d in dict)
            {
                Console.WriteLine($"{d.Key} - {d.Value} times");
            }
        }
    }
}
