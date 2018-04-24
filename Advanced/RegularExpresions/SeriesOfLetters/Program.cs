using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            List<char> list = new List<char>(input);
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] == list[i-1])
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine(string.Join("", list));
        }
    }
}
