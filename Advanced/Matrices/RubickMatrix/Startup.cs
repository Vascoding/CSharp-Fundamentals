using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubickMatrix
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[input[0]][];
            var count = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[input[1]];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = count; 
                    count++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                int index = int.Parse(command[0]);
                string direction = command[1];
                int moves = int.Parse(command[2]);

                if (direction.Equals("up"))
                {
                    MoveCol(matrix, index, moves);
                }
                if (direction.Equals("down"))
                {
                    MoveCol(matrix, index, matrix.Length - moves % matrix.Length);
                }
                if (direction.Equals("left"))
                {
                    MoveRow(matrix, index, moves);
                }
                if (direction.Equals("right"))
                {
                    MoveRow(matrix, index, matrix.Length - moves % matrix.Length);
                }
            }
            int rearranger = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != rearranger)
                    {
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            for (int j = 0; j < matrix[i].Length; j++)
                            {
                                if (matrix[i][j] == rearranger)
                                {
                                    var swap = matrix[row][col];
                                    matrix[row][col] = rearranger;
                                    matrix[i][j] = swap;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    rearranger++;
                }
            }
        }

        private static void MoveRow(int[][] matrix, int index, int moves)
        {
            var temp = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[index][(row + moves)%matrix.Length];
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[index][row] = temp[row];
            }
        }

        private static void MoveCol(int[][] matrix, int rowIndex, int moves)
        {
            var temp = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[(row + moves) % matrix.Length][rowIndex];
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][rowIndex] = temp[row];
            }
        }
    }
}
