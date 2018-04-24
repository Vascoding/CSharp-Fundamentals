using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' ', '\\', '/', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9_]{2,25}$");
            List<string> list = new List<string>();
            Stack<string> final = new Stack<string>();
            foreach (var user in input)
            {
                if (regex.IsMatch(user))
                {
                    list.Add(user);
                }
            }
            var result = 0;

            for (int i = 1; i < list.Count; i++)
            {
                var sum = list[i - 1].Length + list[i].Length;
                if (result < sum)
                {
                    result = sum;
                    final.Push(list[i]);
                    final.Push(list[i - 1]);
                }
            }

            Console.WriteLine($"{final.Pop()}");
            Console.WriteLine($"{final.Pop()}");
        }
    }
}
