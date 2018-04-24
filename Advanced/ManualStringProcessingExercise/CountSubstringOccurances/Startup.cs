using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringOccurances
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var word = Console.ReadLine();
            var count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.ToLower(word[0]) == char.ToLower(input[i]))
                {
                    var firstString = string.Empty;
                    if (input.Length - i < word.Length)
                    {
                        firstString = input.Substring(i, input.Length - i);
                    }
                    else
                    {
                        firstString = input.Substring(i, word.Length);
                    }
                    
                    if (string.Compare(firstString, word, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
