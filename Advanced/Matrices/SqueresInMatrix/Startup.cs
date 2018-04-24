using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqueresInMatrix
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[][] matrix = new char[input[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            char topLeft;
            char topRight;
            char botLeft;
            char botRight;
            int square = 0;
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    topLeft = matrix[i][j];
                    botLeft = matrix[i + 1][j];
                    topRight = matrix[i][j + 1];
                    botRight = matrix[i + 1][j + 1];
                    if (topLeft == topRight && topLeft == botLeft && topLeft == botRight)
                    {
                        square++;
                    }
                }
            }
            Console.WriteLine(square);
        }
    }
}
