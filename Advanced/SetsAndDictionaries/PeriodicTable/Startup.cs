using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < input; i++)
            {
                var element = Console.ReadLine().Split();
                foreach (var e in element)
                {
                    elements.Add(e);
                }
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
