using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersChangeNumbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (var word in input)
            {
                if (word[0].ToString() == word[0].ToString().ToUpper())
                {
                    long num = long.Parse(word.Substring(1, word.Length - 2));
                    sum += (double)num / (int)(word[0] - 64);
                }
                else
                {
                    long num = long.Parse(word.Substring(1, word.Length - 2));
                    sum += (double)num * (int)(word[0] - 96);
                }
                if (word[word.Length-1].ToString() == word[word.Length - 1].ToString().ToUpper())
                {
                    sum -= (int)(word[word.Length -1] - 64);
                }
                else
                {
                    sum += (int)(word[word.Length -1] - 96);
                }
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
