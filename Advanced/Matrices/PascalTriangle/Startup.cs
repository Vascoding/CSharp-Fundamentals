using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];
            int count = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new long[count];
                long[] arr = new long[count];

                if (arr.Length > 2)
                {
                    for (int j = 1; j < arr.Length - 1; j++)
                    {
                        arr[j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                    }
                }
                if (arr.Length == 1)
                {
                    arr[0] = 1;
                    
                }
                else
                {
                    arr[0] = 1;
                    arr[arr.Length-1] = 1;
                }

                matrix[i] = arr;
                count++;
            }

            foreach (var m in matrix)
            {
                Console.WriteLine(string.Join(" ", m));
            }
        }
    }
}
