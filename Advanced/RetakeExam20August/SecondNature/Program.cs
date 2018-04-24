using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondNature
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var secondInput = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> flowers = new Queue<int>(firstInput);
            Stack<int> water = new Stack<int>(secondInput);
            List<int> secondNature = new List<int>();
            int waterLeft = 0;
            while (true)
            {
                if (water.Count == 0)
                {
                    break;
                }
                if (flowers.Count == 0)
                {
                    water.Push(waterLeft + water.Pop());
                    break;
                }
                
                if (water.Peek() + waterLeft == flowers.Peek())
                {
                    secondNature.Add(flowers.Peek());
                }
                if (water.Peek() + waterLeft < flowers.Peek())
                {
                    var weiss = flowers.Dequeue() - water.Pop();
                    List<int> newSeq = new List<int>();
                    foreach (var flower in flowers)
                    {
                        newSeq.Add(flower);
                    }
                    flowers.Clear();
                    for (int j = 0; j < newSeq.Count; j++)
                    {
                        if (j == 0)
                        {
                            flowers.Enqueue(weiss);
                        }

                        flowers.Enqueue(newSeq[j]);
                    }
                }

                else
                {
                    waterLeft += water.Pop() - flowers.Dequeue();
                    if (water.Count == 0 && waterLeft > 0)
                    {
                        water.Push(waterLeft);
                        waterLeft = 0;
                    }
                }
            }
            if (water.Count > 0)
            {
                Console.WriteLine(string.Join(" ", water));
            }
            if (flowers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", flowers));
            }
            if (secondNature.Count == 0)
            {
                Console.WriteLine("None");
            }
            if (secondNature.Count > 0)
            {
                Console.WriteLine(string.Join(" ", secondNature));
            }

        }
    }
}


