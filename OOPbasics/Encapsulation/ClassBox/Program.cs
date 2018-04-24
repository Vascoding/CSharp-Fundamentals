using System;
using System.Linq;
using System.Reflection;

namespace ClassBox
{
    public class Program
    {
        public static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine(fields.Count());
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LeteralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(fields.Count());
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
