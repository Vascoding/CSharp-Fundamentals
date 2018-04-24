using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        public static void Main()
        {
            Smartphone smartphone = new Smartphone();

            var phones = Console.ReadLine().Split();
            var webSites = Console.ReadLine().Split();

            foreach (var phone in phones)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(phone));

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            
            foreach (var webSite in webSites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(webSite));

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
