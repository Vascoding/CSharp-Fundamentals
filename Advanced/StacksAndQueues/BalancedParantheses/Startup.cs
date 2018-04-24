using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParantheses
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            List<char> list = new List<char>();
            bool isBalanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals('{'))
                {
                    list.Clear();
                    for (int j = input.Length - 1 - i; j >= i; j--)
                    {
                        if (input[j].Equals('}'))
                        {
                            for (int k = i; k <= j; k++)
                            {
                                list.Add(input[k]);
                            }
                            break;
                        }
                    }
                    if (list.Count % 2 != 0)
                    {
                        isBalanced = false;
                    }
                }

                if (input[i].Equals('['))
                {
                    list.Clear();
                    for (int j = input.Length - 1 - i; j >= i; j--)
                    {
                        if (input[j].Equals(']'))
                        {
                            for (int k = i; k <= j; k++)
                            {
                                list.Add(input[k]);
                            }
                            break;
                        }
                    }
                    if (list.Count % 2 != 0)
                    {
                        isBalanced = false;
                    }
                }
                if (input[i].Equals('('))
                {
                    list.Clear();
                    for (int j = input.Length - 1 - i; j >= i; j--)
                    {
                        if (input[j].Equals(')'))
                        {
                            for (int k = i; k <= j; k++)
                            {
                                list.Add(input[k]);
                            }
                            break;
                        }
                    }
                    if (list.Count % 2 != 0)
                    {
                        isBalanced = false;
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
