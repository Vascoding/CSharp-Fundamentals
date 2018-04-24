using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise
{
    public class WordCount
    {
        public static void MatchWords()
        {
            StreamReader reader = new StreamReader("../../Files/Words.txt");
            StreamWriter writer = new StreamWriter("../../Files/results.txt");
            List<string> words = new List<string>();
            Dictionary<string, int> matches = new Dictionary<string, int>();
            using (reader)
            {
                using (writer)
                {
                    for (int i = 1; i <= reader.Read(); i++)
                    {
                        words.Add(reader.ReadLine());
                    }
                    reader = new StreamReader("../../Files/Text.txt");
                    string[] text = reader.ReadToEnd().ToLower().Split(new[] { ' ', '.', '!', '?', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        foreach (var t in text)
                        {
                            if (word.Equals(t))
                            {
                                if (matches.ContainsKey(word))
                                {
                                    matches[word]++;
                                }
                                else
                                {
                                    matches.Add(word, 1);
                                }
                            }
                        }
                    }
                    foreach (var match in matches.OrderByDescending(v => v.Value))
                    {
                        writer.WriteLine($"{match.Key} {match.Value}");
                        Console.WriteLine($"{match.Key} {match.Value}");
                    }
                }
            } 
        }
    }
}
