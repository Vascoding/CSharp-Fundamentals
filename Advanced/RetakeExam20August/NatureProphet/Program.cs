using System;
using System.Collections.Generic;
using System.Linq;

namespace NatureProphet
{
    public class Parameter
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];
            List<Parameter> parameter = new List<Parameter>();
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
            }

            while (true)
            {
                var bloom = Console.ReadLine();
                if (bloom.Equals("Bloom Bloom Plow"))
                {
                    break;
                }
                var param = bloom.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Parameter p = new Parameter
                {
                    Row = param[0],
                    Col = param[1]
                };
                parameter.Add(p);
            }

            for (int i = 0; i < parameter.Count; i++)
            {
                for (int j = 0; j < matrix[parameter[i].Row].Length; j++)
                {
                    matrix[parameter[i].Row][j]++;
                }
                for (int j = 0; j < matrix[parameter[i].Col].Length; j++)
                {
                    if (j != parameter[i].Row)
                    {
                        matrix[j][parameter[i].Col]++;
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine($"{string.Join(" ", matrix[row])}");
            }
        }
    }
}


