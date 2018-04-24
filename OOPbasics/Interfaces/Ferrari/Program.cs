using System;

namespace Ferrari
{
    public class Program
    {
        public static void Main()
        {
            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

            var driver = Console.ReadLine();
            ICar ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}
