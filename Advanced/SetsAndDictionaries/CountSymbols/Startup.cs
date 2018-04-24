using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSymbols
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

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
                Console.WriteLine($"{d.Key}: {d.Value} time/s");
            }
        }
    }
}
