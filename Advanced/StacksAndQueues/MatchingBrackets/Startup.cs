using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingBrackets
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    for (int j = stack.Pop(); j < i + 1; j++)
                    {
                        Console.Write($"{input[j]}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
