using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        public static void Main()
        {
            MyStack<int> myStack = new MyStack<int>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                var cmd = cmdArgs[0];
                var args = cmdArgs.Skip(1).Select(int.Parse).ToArray();
                switch (cmd)
                {
                    case "Push":
                        myStack.Push(args);
                        break;
                    case "Pop":
                        try
                        {
                            myStack.Pop();
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                       
                        break;
                    case "END":
                        return;
                }
            }
            foreach (var stack in myStack)
            {
                Console.WriteLine(stack);
            }
        }
    }
}
