using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupNumbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] sizes = new int[3];
            for (int i = 0; i < input.Length; i++)
            {
                int reminder = Math.Abs(input[i]) % 3;
                sizes[reminder]++;
            }
            int[][] matrix = { new int[sizes[0]], new int[sizes[1]], new int[sizes[2]] };
            int firstRow = 0;
            int secondRow = 0;
            int thirdRow = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (Math.Abs(input[i]) % 3 == 0)
                {
                    matrix[0][firstRow] = input[i];
                    firstRow++;
                }
                if (Math.Abs(input[i]) % 3 == 1)
                {
                    matrix[1][secondRow] = input[i];
                    secondRow++;
                }
                if (Math.Abs(input[i]) % 3 == 2)
                {
                    matrix[2][thirdRow] = input[i];
                    thirdRow++;
                }
            }
            foreach (var m in matrix)
            {
                Console.WriteLine(string.Join(" ", m));
            }
        }
    }
}
