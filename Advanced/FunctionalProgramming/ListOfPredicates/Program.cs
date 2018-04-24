using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var deviders =
                Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            for (int i = 1; i <= n; i++)
            {
                bool isDevisible = true;
                for (int j = 0; j < deviders.Count; j++)
                {
                    if (i % deviders[j] != 0)
                    {
                        isDevisible = false;
                        break;
                    }
                }
                if (isDevisible)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
