using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<Rectangle> rectangles = new List<Rectangle>();
            for (int i = 0; i < input[0]; i++)
            {
                var rec = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var id = rec[0];
                var width = double.Parse(rec[1]);
                var height = double.Parse(rec[2]);
                Rectangle rectangle = new Rectangle
                {
                    Id = id,
                    Width = width,
                    Height = height
                };
                if (rec.Length == 4)
                {
                    var x = double.Parse(rec[3]);
                    rectangle.X = x;
                    
                }
                if (rec.Length == 5)
                {
                    var x = double.Parse(rec[3]);
                    var y = double.Parse(rec[4]);
                    rectangle.X = x;
                    rectangle.Y = y;
                }
                
                rectangles.Add(rectangle);
            }
            for (int i = 0; i < input[1]; i++)
            {
                var recs = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

                var firstRectangle = rectangles.FirstOrDefault(r => r.Id.ToLower() == recs[0].ToLower());
                var secondRectangle = rectangles.FirstOrDefault(r => r.Id.ToLower() == recs[1].ToLower());
                if (firstRectangle != null && secondRectangle != null)
                {
                    bool result = firstRectangle.Intersect(secondRectangle);
                    Console.WriteLine(result.ToString().ToLower());
                }
            }
        }
    }
}
