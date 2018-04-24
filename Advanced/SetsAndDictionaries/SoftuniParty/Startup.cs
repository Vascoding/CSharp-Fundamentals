using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftuniParty
{
    class Startup
    {
        static void Main(string[] args)
        {
            var invite = Console.ReadLine();
            SortedSet<string> guests = new SortedSet<string>();
            while (!invite.Equals("PARTY"))
            {
                guests.Add(invite);

                invite = Console.ReadLine();
            }
            invite = Console.ReadLine();
            while (!invite.Equals("END"))
            {
                if (guests.Contains(invite))
                {
                    guests.Remove(invite);
                }
                invite = Console.ReadLine();
            }
            Console.WriteLine($"{guests.Count}");
            Console.WriteLine(string.Join("\r\n", guests));
        }
    }
}
