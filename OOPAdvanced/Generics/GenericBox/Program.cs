using System;

namespace GenericBox
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
