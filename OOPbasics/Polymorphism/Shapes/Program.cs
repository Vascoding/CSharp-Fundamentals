using System;


    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(5);
            Console.WriteLine($"{c.CalculatePerimeter()}");
            Console.WriteLine($"{c.CalculateArea()}");
            Console.WriteLine(c.Draw());
        }
    }

