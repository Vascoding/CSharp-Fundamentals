using System;

public class StartUp
{
    static void Main(string[] args)
    {
        Console.WriteLine("coeficient(x)");
        double coefx = double.Parse(Console.ReadLine());
        double n = Math.Exp(coefx);
        Console.WriteLine("exponent (x) =:{0}", (Math.Exp(coefx)));
    }
}
