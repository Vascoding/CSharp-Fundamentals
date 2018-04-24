using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicExchangeableWords
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var first = input[0].ToCharArray();
            var second = input[1].ToCharArray();
            Dictionary<char, char> dict = new Dictionary<char, char>();
            bool isExchangeble = true;

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                if (!dict.ContainsKey(first[i]))
                {
                    dict.Add(first[i], second[i]);
                }
                else
                {
                    if (!dict.ContainsValue(second[i]))
                    {
                        isExchangeble = false;
                    }
                }
            }

            for (int i = Math.Min(first.Length, second.Length); i < Math.Max(first.Length, second.Length); i++)
            {
                if (first.Length > second.Length)
                {
                    if (!dict.ContainsKey(first[i]))
                    {
                        isExchangeble = false;
                    }
                }
                else
                {
                    
                    if (!dict.ContainsKey(second[i]))
                    {
                        isExchangeble = false;
                    }
                    
                }
            }
            if (isExchangeble)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
