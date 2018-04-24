using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven =
            (int x) => x % 2 == 0;

            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var command = Console.ReadLine();
            if (command.Equals("even"))
            {
                for (int i = input[0]; i <= input[1]; i++)
                {
                    if (isEven.Invoke(Math.Abs(i)))
                    {
                        Console.Write(i + " ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = input[0]; i <= input[1]; i++)
                {
                    if (!isEven.Invoke(Math.Abs(i)))
                    {
                        Console.Write(i + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
