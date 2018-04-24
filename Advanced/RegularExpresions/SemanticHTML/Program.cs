using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SemanticHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                Regex openTag = new Regex("id *= *\\\"(.+?)\\\"");
                Regex openClass = new Regex("class *= *\\\"(.+?)\\\"");
                if (openTag.IsMatch(input))
                {
                    var text = openTag.Match(input).Groups[1].Value;

                    if (input.Contains("div"))
                    {
                        input = input.Replace(openTag.Match(input).Groups[0].Value, "");
                        input = input.Replace("div", text);
                        input = Regex.Replace(input, @"\s+", " ");
                        if (input[input.Length - 2] == ' ')
                        {
                            input = input.Substring(0, input.Length - 2);
                            input += '>';
                        }
                    }
                }
                if (openClass.IsMatch(input))
                {
                    var text = openClass.Match(input).Groups[1].Value;
                    if (input.Contains("div"))
                    {
                        input = input.Replace(openClass.Match(input).Groups[0].Value, "");
                        input = input.Replace("div", text);
                        input = Regex.Replace(input, @"\s+", " ");
                        if (input[input.Length - 2] == ' ')
                        {
                            input = input.Substring(0, input.Length - 2);
                            input += '>';
                        }
                    }

                }
                Regex closeTag = new Regex("<!-- *(.+?) *-->");
                if (closeTag.IsMatch(input))
                {
                    var text = closeTag.Match(input).Groups[1].Value;

                    if (text.Split().Length == 1)
                    {
                        input = input.Replace(closeTag.Match(input).Groups[0].Value, "");
                        input = input.Replace("div", text);
                        input = Regex.Replace(input, @"\s+", " ");
                        if (input[input.Length - 2] == ' ')
                        {
                            input = input.Substring(0, input.Length - 2);
                            input += '>';
                        }
                    }
                }
                Console.WriteLine(input);
                input = Console.ReadLine();
            }
        }
    }
}
