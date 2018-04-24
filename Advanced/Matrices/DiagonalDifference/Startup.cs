using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifference
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            int[][] matrix = new int[input][];
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                primaryDiagonal += matrix[i][i];
            }
            var count = 0;
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                secondaryDiagonal += matrix[i][count];
                count++;
            }
            Console.WriteLine($"{Math.Abs(primaryDiagonal - secondaryDiagonal)}");
        }
    }
}
