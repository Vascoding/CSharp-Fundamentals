using System;
using System.Collections.Generic;

namespace NMS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            string nextWord = "";
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("---NMS SEND---"))
                {
                    break;
                }
                nextWord += input;
            }
            
            string word = nextWord[0].ToString();
            for (int i = 1; i < nextWord.Length; i++)
            {
                if (nextWord.ToLower()[i] >= nextWord.ToLower()[i - 1])
                {
                    word += nextWord[i];
                }
                else
                {
                    words.Add(word);
                    word = nextWord[i].ToString();
                }
            }
            words.Add(word);
            var delimeter = Console.ReadLine();
            Console.WriteLine(string.Join(delimeter, words));
        }
    }
}
