using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicRube
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[][][] rube = new int[n][][];
            int unchanged = n * n * n;
            long result = 0;
            for (int i = 0; i < n; i++)
            {
                rube[i] = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    rube[i][j] = new int[n];
                }

            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Analyze"))
                {
                    break;
                }
                var boom = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var firstParam = boom[0];
                var secondParam = boom[1];
                var thirdParam = boom[2];
                var particle = boom[3];

                if (firstParam >= 0 && firstParam <= n - 1 && secondParam >= 0 && secondParam <= n - 1 && thirdParam >= 0 && thirdParam <= n - 1)
                {
                    if (rube[firstParam][secondParam][thirdParam] == 0 && particle != 0)
                    {
                        rube[firstParam][secondParam][thirdParam] = particle;
                        result += particle;
                        unchanged--;
                    }
                }
            }

            Console.WriteLine($"{result}");
            Console.WriteLine($"{unchanged}");
        }
    }
}
