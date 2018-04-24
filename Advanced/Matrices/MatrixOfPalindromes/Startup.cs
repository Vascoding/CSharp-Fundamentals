using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOfPalindromes
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[][] matrix = new string[input[0]][];
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            for (int i = 0; i < matrix.Length; i++)
            {
                 matrix[i] = new string[input[1]];
            }
            
            for (int i = 0; i < matrix.Length; i++)
            {
                var currChar = new char[3];
                currChar[0] = alphabet[i];
                currChar[2] = alphabet[i];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int middle = i + j;
                    currChar[1] = alphabet[middle];
                    string concat = currChar[0] + "" + currChar[1] + currChar[2];
                    matrix[i][j] = concat;
                }
            }
            foreach (var m in matrix)
            {
                Console.WriteLine(string.Join(" ", m));
            }
            
        }
    }
}
