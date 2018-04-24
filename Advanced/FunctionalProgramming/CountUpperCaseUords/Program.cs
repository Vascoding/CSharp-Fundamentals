using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountUpperCaseUords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\r\n", Console.ReadLine().Trim()
                .Split()
                .Where(a => a.StartsWith(char.ToUpper(a[0]).ToString()))));
        }
    }
}
