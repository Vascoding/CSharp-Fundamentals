using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                var firstNum = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondNum = int.Parse(stack.Pop());

                if (op.Equals("+"))
                {
                    stack.Push((firstNum + secondNum).ToString());
                }
                if (op.Equals("-"))
                {
                    stack.Push((firstNum - secondNum).ToString());
                }
            }
            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
