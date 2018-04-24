using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossfire
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            List<List<int>> matrix = new List<List<int>>();
            int number = 1;
            for (int row = 0; row < input[0]; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row].Add(number++);
                }
            }

            var command = Console.ReadLine();
            while (!command.Equals("Nuke it from orbit"))
            {
                var cordinates =
                    command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var rowIndex = cordinates[0];
                var colIndex = cordinates[1];
                var radius = cordinates[2];
                var containsDestroyedCells = false;

                if (rowIndex >= 0 && rowIndex < matrix.Count)
                {
                    for (int col = Math.Max(0, colIndex - radius); col <= Math.Min(colIndex + radius, matrix[rowIndex].Count - 1); col++)
                    {
                        matrix[rowIndex][col] = 0;
                        containsDestroyedCells = true;
                    }
                }

                if (colIndex >= 0)
                {
                    for (int row = Math.Max(0, rowIndex - radius); row <= Math.Min(rowIndex + radius, matrix.Count - 1); row++)
                    {
                        if (colIndex < matrix[row].Count)
                        {
                            matrix[row][colIndex] = 0;
                            containsDestroyedCells = true;
                        }
                    }
                }
                if (containsDestroyedCells)
                {
                    for (int row = 0; row < matrix.Count; row++)
                    {
                        if (matrix[row].Contains(0))
                        {
                            List<int> elements = new List<int>();
                            for (int col = 0; col < matrix[row].Count; col++)
                            {
                                if (matrix[row][col] != 0)
                                {
                                    elements.Add(matrix[row][col]);
                                }
                            }
                            if (elements.Count > 0)
                            {
                                matrix[row] = elements;
                            }

                            else
                            {
                                matrix.RemoveAt(row);
                                row--;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }
            for (int row = 0; row < matrix.Count; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}

