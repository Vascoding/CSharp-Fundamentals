using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareWithMaximumSum
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[input[0]][];
            int maxSum = int.MinValue;
            int topLeft = 0;
            int topRight = 0;
            int botLeft = 0;
            int botRight = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                     
                    var nextSum = matrix[i][j] + matrix[i + 1][j] + matrix[i][j + 1] + matrix[i + 1][j + 1];
                    if (maxSum < nextSum)
                    {
                        maxSum = nextSum;
                        topLeft = matrix[i][j];
                        botLeft = matrix[i + 1][j];
                        topRight = matrix[i][j + 1];
                        botRight = matrix[i + 1][j + 1];
                    }
                }
            }
            Console.WriteLine($"{topLeft} {topRight}\r\n{botLeft} {botRight}\r\n{maxSum}");
            
        }
    }
}
