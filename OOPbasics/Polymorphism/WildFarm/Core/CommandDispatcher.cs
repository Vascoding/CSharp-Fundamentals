using System;
using System.Text;

namespace WildFarm.Core
{
    public class CommandDispatcher
    {
        public static void Dispatch(Animal animal)
        {
            Console.WriteLine(animal);
        }
    }
}
