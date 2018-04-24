using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var list = new List<int>();
            Stack<int> stack = new Stack<int>(input);
            
            for (int i = 0; i < input.Length; i++)
            {
                list.Add(stack.Pop());
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
