using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Predicate<int> isEven = (int n) => n % 2 == 0;
            Predicate<int> isOdd = (int n) => n % 2 != 0;

            Console.Write(string.Join(" ", input.Where(isEven.Invoke).OrderBy(a => a)));
            Console.WriteLine(" " + string.Join(" ", input.Where(isOdd.Invoke).OrderBy(a => a)));
        }
    }
}
