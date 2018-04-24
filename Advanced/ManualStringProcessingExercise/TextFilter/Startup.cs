using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter
{
    class Startup
    {
        static void Main(string[] args)
        {
            var banList = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();
            
            for (int i = 0; i < banList.Length; i++)
            {
                text = text.Replace(banList[i], new string('*', banList[i].Length));
            }
            Console.WriteLine(text);
        }
    }
}
