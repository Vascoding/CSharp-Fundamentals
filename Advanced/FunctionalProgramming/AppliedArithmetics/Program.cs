using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<int, int> addFunc = n => n + 1;
            Func<int, int> substractFunc = n => n - 1;
            Func<int, int> multiplyFunc = n => n * 2;
           
            while (true)
            {
                var command = Console.ReadLine();
                if (command.Equals("end"))
                {
                    break;
                }
                if (command.Equals("add"))
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input[i] = addFunc.Invoke(input[i]);
                    }
                }
                if (command.Equals("multiply"))
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input[i] = multiplyFunc.Invoke(input[i]);
                    }
                }
                if (command.Equals("subtract"))
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input[i] = substractFunc.Invoke(input[i]);
                    }
                }
                if (command.Equals("print"))
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        Console.Write(input[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
