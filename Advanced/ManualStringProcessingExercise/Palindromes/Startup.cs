using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' ', '.', ',', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> palindromes = new SortedSet<string>();
            foreach (var word in input)
            {
                var left = string.Empty;
                var right = string.Empty;
                if (word.Length > 3 && word.Length % 2 != 0)
                {
                    for (int i = 0; i < word.Length / 2; i++)
                    {
                        left += word[i];

                    }
                    for (int i = word.Length - 1; i >= word.Length / 2 + 1; i--)
                    {
                        right += word[i];
                    }

                    if (left.Equals(right))
                    {
                        palindromes.Add(word);
                    }
                }
                if (word.Length > 3 && word.Length % 2 == 0)
                {
                    for (int i = 0; i < word.Length / 2; i++)
                    {
                        left += word[i];

                    }
                    for (int i = word.Length - 1; i >= word.Length / 2; i--)
                    {
                        right += word[i];
                    }

                    if (left.Equals(right))
                    {
                        palindromes.Add(word);
                    }
                }
                else if (word.Length == 3)
                {
                    var leftWing = word[0];
                    var rightWing = word[2];
                    if (leftWing == rightWing)
                    {
                        palindromes.Add(word);
                    }
                }
                else if (word.Length == 1)
                {
                    palindromes.Add(word);
                }
                
            }
            Console.Write("[");
            Console.Write(string.Join(", ", palindromes));
            Console.WriteLine("]");
        }
    }
}
