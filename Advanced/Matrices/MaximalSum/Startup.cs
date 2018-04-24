using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[input[0]][];
            int maxSum = int.MinValue;
            int topLeft = 0;
            int topMiddle = 0;
            int leftMiddle = 0;
            int middle = 0;
            int topRight = 0;
            int rightMiddle = 0;
            int botRight = 0;
            int botMiddle = 0;
            int botLeft = 0;


            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int i = 0; i < matrix.Length - 2; i++)
            {
                for (int j = 0; j < matrix[i].Length - 2; j++)
                {

                    var nextSum = matrix[i][j] + matrix[i + 1][j] + matrix[i][j + 1] + matrix[i + 1][j + 1] + matrix[i][j + 2] + matrix[i+1][j+2] + matrix[i+2][j+2]
                        + matrix[i + 2][j+1] + matrix[i+2][j]; 
                    if (maxSum < nextSum)
                    {
                        maxSum = nextSum;
                        topLeft = matrix[i][j];
                        leftMiddle = matrix[i + 1][j];
                        topMiddle = matrix[i][j + 1];
                        middle = matrix[i + 1][j + 1];
                        topRight = matrix[i][j + 2];
                        rightMiddle = matrix[i + 1][j + 2];
                        botRight = matrix[i + 2][j + 2];
                        botMiddle = matrix[i + 2][j + 1];
                        botLeft = matrix[i + 2][j];
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}\n{topLeft} {topMiddle} {topRight}\n{leftMiddle} {middle} {rightMiddle}\n{botLeft} {botMiddle} {botRight}");
        }
    }
}
