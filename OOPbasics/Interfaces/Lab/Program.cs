using System;

public class Program
{
    public static void Main()
    {
        //var radius = int.Parse(Console.ReadLine());
        //IDrawable circle = new Circle(radius);

        //var width = int.Parse(Console.ReadLine());
        //var height = int.Parse(Console.ReadLine());
        //IDrawable rect = new Rectangle(width, height);

        //circle.Draw();
        //rect.Draw();

        ICar seat = new Seat("Leon", "Grey");
        ICar tesla = new Tesla("Model 3", "Red", 2);

        Console.WriteLine(seat.ToString());
        Console.WriteLine(tesla.ToString());

        var arr = new int[] { 1, 2 ,3};

        var narr = arr;
    }
}


