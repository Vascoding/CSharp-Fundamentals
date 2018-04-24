using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethonds
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                boxes.Add(new Box<double>(input));
            }

            var commandCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(boxes.Count(a => a.Compare(commandCompare) > 0));
            
        }

        

        private static void Swap<T>(List<T> boxes, int a, int b)
        {
            var box = boxes[a];
            boxes[a] = boxes[b];
            boxes[b] = box;
        }
    }
}
