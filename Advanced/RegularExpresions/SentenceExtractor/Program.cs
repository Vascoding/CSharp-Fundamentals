using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SentenceExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var input = Console.ReadLine();

            Regex regex = new Regex("(?<=[.!?])\\s+");

            var splited = regex.Split(input);
            bool isEqual = false;
            foreach (var s in splited)
            {
                foreach (var w in s.Split())
                {
                    if (w == word)
                    {
                        isEqual = true;
                    }
                }
                if (isEqual && (s.Contains('!') || s.Contains('.') || s.Contains('?')))
                {
                    Console.WriteLine(s);
                }
                isEqual = false;
            }
        }
    }
}
