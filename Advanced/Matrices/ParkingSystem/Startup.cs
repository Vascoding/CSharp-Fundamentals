using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[input[0]][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[input[1]];
            }
            var command = Console.ReadLine();



            while (!command.Equals("stop"))
            {
                var cordinates =
                    command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var enter = cordinates[0];
                var rowIndex = cordinates[1];
                var colIndex = cordinates[2];
                var distance = 0;
                bool find = false;


                if (matrix[rowIndex][colIndex] == 0)
                {
                    matrix[rowIndex][colIndex] = 1;
                    distance = colIndex + Math.Abs(enter - rowIndex) + 1;
                    find = true;
                }

                else
                {
                    for (int row = 1; row < input[1]; row++)
                    {
                        if ((colIndex > 0) && matrix[rowIndex][row] == 0)
                        {
                            matrix[rowIndex][row] = 1;
                            distance = Math.Abs(enter - rowIndex) + 1 + row;
                            find = true;
                            break;
                        }
                    }
                }

                if (find)
                {
                    Console.WriteLine(distance);
                }
                else
                {
                    Console.WriteLine($"Row {rowIndex} full");
                }
                command = Console.ReadLine();

            }
        }
    }
}
