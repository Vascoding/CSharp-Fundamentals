using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerlahShake
{
    class Startuo
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();
            while (true)
            {
                if (pattern.Length == 0)
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(text);
                    break;
                }
                if (text.IndexOf(pattern) != -1)
                {
                    int startIndex = text.IndexOf(pattern);
                    if (text.Substring(startIndex + pattern.Length, text.Length - startIndex - pattern.Length).IndexOf(pattern) != -1)
                    {
                        Console.WriteLine("Shaked it.");
                        int index = text.IndexOf(pattern);
                        var shaked = text.Substring(0, index);
                        shaked += text.Substring(index + pattern.Length, text.Length - (index + pattern.Length));
                        index = text.LastIndexOf(pattern);
                        text = shaked.Substring(0, index - pattern.Length);
                        text += shaked.Substring(index, shaked.Length - index);

                        if (pattern.Length == 1)
                        {
                            pattern = pattern.Remove(0);
                        }
                        else
                        {
                            pattern = pattern.Remove(1, pattern.Length / 2);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No shake.");
                        Console.WriteLine(text);
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(text);
                    break;
                }
            }

        }
    }
}
