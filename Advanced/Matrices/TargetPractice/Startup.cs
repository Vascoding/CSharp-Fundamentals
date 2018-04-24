using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPractice
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            var snake = Console.ReadLine();
            var cordinates =
                Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int selectedRow = cordinates[0];
            int selectedCol = cordinates[1];
            int radius = cordinates[2];


            char[][] matrix = new char[rows][];
            
            bool zigZag = false;
            int i = 0;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (zigZag)
                {
                    matrix[row] = new char[cols];
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = snake[i];
                        i++;
                        if (i == snake.Length)
                        {
                            i = 0;
                        }
                    }
                    row--;
                }
                matrix[row] = new char[cols];
                for (int col = matrix[row].Length - 1; col >= 0; col--)
                {
                    matrix[row][col] = snake[i];
                    i++;
                    if (i == snake.Length)
                    {
                        i = 0;
                    }
                }
                zigZag = true;
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    bool isInRange = Math.Sqrt(Math.Pow(Math.Abs(selectedRow - row), 2)
                                        + Math.Pow(Math.Abs(selectedCol - col), 2))
                                        <= radius;
                    if (isInRange)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

            int rowsIndex = matrix.GetLength(0);
            for (int col = 0; col < matrix[0].Length; col++)
            {
                string collapsedCol = "";
                for (int row = rowsIndex - 1; row >= 0; row--)
                    if (matrix[row][col] != ' ')
                        collapsedCol += matrix[row][col];
                for (int c = 0; c < rowsIndex; c++)
                    if (c >= collapsedCol.Length)
                        matrix[rows - 1 - c][col] = ' ';
                    else
                        matrix[rows - 1 - c][col] = collapsedCol[c];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine($"{string.Join("", matrix[row])}");
            }
        }
    }
}
