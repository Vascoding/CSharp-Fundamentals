using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("\\[([^[]+<([a-zA-Z0-9]+)>[^[]+)]{1}");
            List<int> indexes = new List<int>();
            if (regex.IsMatch(input))
            {
                var matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    var nums =
                        match.Groups[2].Value.Split(new string[] { "REGEH" }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                    foreach (var num in nums)
                    {
                        int n;
                        int.TryParse(num, out n);
                        if (n != 0)
                        {
                            indexes.Add(n);
                        }
                        
                    }
                }
                StringBuilder sb = new StringBuilder();
                var index = 0;
                
                for (int i = 0; i < indexes.Count; i++)
                {
                    index += indexes[i];
                    if (index > input.Length)
                    {
                        index = index - input.Length;
                        
                    }
                    
                    sb.Append(input[index]);
                    
                        
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
