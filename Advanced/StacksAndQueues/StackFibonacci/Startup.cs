using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFibonacci
{
    class Startup
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Stack<ulong> fibo = new Stack<ulong>();
            fibo.Push(0);
            fibo.Push(1);

            for (int i = 1; i < input; i++)
            {
                var n1 = fibo.Pop();
                var n2 = fibo.Pop();
                var res = n1 + n2;
                fibo.Push(n2);
                fibo.Push(n1);
                fibo.Push(res);
            }
            Console.WriteLine(fibo.Peek());

        }
    }
}
