using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialWords
{
    class Startup
    {
        static void Main(string[] args)
        {
            
            var specialWords = Console.ReadLine()
                .Split(new[] {' ', '(', ')', '[', ']', '<', '>', ',', '-', '?'}, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine().Split(new[] { ' ', '(', ')', '[', ']', '<', '>', ',', '-', '?' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var word in specialWords)
            {
                dict.Add(word, 0);
            }

            for (int i = 0; i < specialWords.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (specialWords[i] == text[j])
                    {
                        if (dict.ContainsKey(specialWords[i]))
                        {
                            dict[specialWords[i]]++;
                        }
                    }
                }
            }

            foreach (var d in dict)
            {
                Console.WriteLine($"{d.Key} - {d.Value}");
            }
        }
    }
}
