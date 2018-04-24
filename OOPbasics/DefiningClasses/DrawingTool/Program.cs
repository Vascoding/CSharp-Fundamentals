using System;

namespace DrawingTool
{
    public class Program
    {
        public static void Main()
        {
            string figureType = Console.ReadLine();

            Figure figure = default(Figure);
            int firstSide = int.Parse(Console.ReadLine());
            if (figureType == "Square")
            {
                figure = new Square(firstSide);
            }
            else
            {
                int secondSide = int.Parse(Console.ReadLine());
                figure = new Rectangle(firstSide, secondSide);
            }

            figure.Draw();
        }
    }
}
