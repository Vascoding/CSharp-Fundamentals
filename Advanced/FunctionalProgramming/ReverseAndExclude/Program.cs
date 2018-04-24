using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToList();
            var num = int.Parse(Console.ReadLine());
            Predicate<int> isDevisible = (int x) => x % num != 0;
            Console.WriteLine(string.Join(" ", input.Where(isDevisible.Invoke)));
        }
    }
}
