using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceTags
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            while (!input.Equals("end"))
            {
                Regex openTag = new Regex("<a");
                Regex closeTag = new Regex("<\\/a>");
                input = openTag.Replace(input, "[URL");
                input = closeTag.Replace(input, "[/URL]");
                var result = input.ToCharArray();
                for (int i = result.Length - 1; i >= 0; i--)
                {
                    if (result[i] == '>' && result[i - 1] == '"')
                    {
                        result[i] = ']';
                    }
                }

                Console.WriteLine(result);

                input = Console.ReadLine();
            }
            
        }
    }
}
