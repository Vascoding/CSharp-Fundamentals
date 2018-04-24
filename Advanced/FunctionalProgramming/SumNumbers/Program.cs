using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = Console.ReadLine();
            //Console.WriteLine(input
            //    .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Count());

            //Console.WriteLine(input
            //    .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Sum());
            var n = int.Parse(Console.ReadLine());
            var num = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                if (input > num)
                {
                    num = input;
                }
            }
            Console.WriteLine(num);
            //var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //Console.WriteLine(input.Max());

        }
    }
}
