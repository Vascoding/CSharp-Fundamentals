using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var v in names)
            {
                var sum = 0;
                for (int i = 0; i < v.ToCharArray().Length; i++)
                {
                    sum += v[i];
                    if (sum >= n)
                    {
                        Console.WriteLine(v);
                        return;
                    }
                }
            }
        }
    }
}



