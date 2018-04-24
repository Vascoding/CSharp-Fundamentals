using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UseYourChainsBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex pTag = new Regex("<p>(.+?)<\\/p>");
            Regex replace = new Regex("[^a-z0-9]+");
            StringBuilder sb = new StringBuilder();

            var matches = pTag.Matches(input);
            
            foreach (Match match in matches)
            {
                var text = replace.Replace(match.Groups[1].Value, " ");
                for (int i = 0; i < text.ToCharArray().Length; i++)
                {
                    if ((int)text[i] < 110 && !char.IsDigit(text[i]) && char.IsLetter(text[i]))
                    {
                        sb.Append((char)(text[i] + 13));
                    }
                    if ((int)text[i] >= 110 && !char.IsDigit(text[i]) && char.IsLetter(text[i]))
                    {
                        sb.Append((char)(text[i] - 13));
                    }
                    if (text[i] == ' ' || char.IsDigit(text[i]))
                    {
                        sb.Append(text[i]);
                    }
                }
            }
            Console.WriteLine(sb);
        }
    }
}
