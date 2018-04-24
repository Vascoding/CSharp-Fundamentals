using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBlocks
{
    class Startup
    {
        static void Main(string[] args)
        {
            var rowsForJagget = int.Parse(Console.ReadLine());

            int[][] firstJagget = new int[rowsForJagget][];
            int[][] secondJagget = new int[rowsForJagget][];

            for (int row = 0; row < rowsForJagget; row++)
            {
                int[] rows =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                firstJagget[row] = new int[rows.Length];
                for (int col = 0; col < rows.Length; col++)
                {
                    firstJagget[row][col] = rows[col];
                }
            }

            for (int row = 0; row < rowsForJagget; row++)
            {
                int[] rows =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                secondJagget[row] = new int[rows.Length];
                for (int col = 0; col < rows.Length; col++)
                {
                    secondJagget[row][col] = rows[col];
                }
            }
            int[][] matrix = new int[rowsForJagget][];
            bool fit = true;
            int count = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                var length = firstJagget[row].Length + secondJagget[row].Length;
                if (length != firstJagget[0].Length + secondJagget[0].Length)
                {
                    fit = false;
                }
                matrix[row] = new int[length];
                int[] reversed = secondJagget[row].Reverse().ToArray();
                for (int col = 0; col < length; col++)
                {
                    if (firstJagget[row].Length > col)
                    {
                        matrix[row][col] = firstJagget[row][col];
                        count++;
                    }
                    else
                    {
                        matrix[row][col] = reversed[col - firstJagget[row].Length];
                        count++;
                    }
                }
            }
            if (fit)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    Console.Write("[");
                    Console.Write(string.Join(", ", matrix[row]));
                    Console.WriteLine("]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {count}");
            }
        }
    }
}
