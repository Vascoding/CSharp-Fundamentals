using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Stack<string> lastUpdate = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var operations = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int operation = int.Parse(operations[0]);
                if (operation.Equals(1))
                {
                    lastUpdate.Push(sb.ToString());
                    sb.Append(operations[1]);
                }
                if (operation.Equals(2))
                {
                    lastUpdate.Push(sb.ToString());
                    sb.Remove(sb.Length - int.Parse(operations[1]), sb.Length);
                }
                if (operation.Equals(3))
                {
                    Console.WriteLine(sb[int.Parse(operations[1]) - 1]);
                }
                if (operation.Equals(4))
                {
                    string text = lastUpdate.Pop();
                    sb.Remove(0, sb.Length);
                    sb.Append(text);
                }
            }
        }
    }
}
