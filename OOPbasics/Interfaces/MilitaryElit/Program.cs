using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElit.Interfaces;
using MilitaryElit.Models;

namespace MilitaryElit
{
    public class Program
    {
        public static void Main()
        {
            var soldiers = new HashSet<ISoldier>();
            while (true)
            {
                var input = Console.ReadLine().Trim().Split();

                if (input[0].Equals("End", StringComparison.OrdinalIgnoreCase))
                    break;

                try
                {
                    ISoldier soldier;
                    if (input[0].Equals("LeutenantGeneral", StringComparison.OrdinalIgnoreCase))
                    {
                        var privatesIds = input.Skip(5);
                        var ltg = GetSoldier(input) as LuetenantGeneral;

                        foreach (var privatesId in privatesIds)
                        {
                            var @private = soldiers.First(x => x.Id.Equals(privatesId));
                            ltg.AddPrivate(@private);
                        }

                        soldier = ltg;
                    }
                    else
                    {
                        soldier = GetSoldier(input);
                    }
                    soldiers.Add(soldier);
                }
                catch (ArgumentException)
                {
                    // ignored
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        static ISoldier GetSoldier(string[] args)
        {
            var type = args[0];
            var id = args[1];
            var firstName = args[2];
            var lastName = args[3];
            double salary;
            string corps;

            ISoldier soldier;
            if (type == "Spy")
            {
                var codeNumber = args[4];

                soldier = new Spy(id, firstName, lastName, codeNumber);
            }
            else if (type == "Private")
            {
                salary = double.Parse(args[4]);

                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (type == "Engineer")
            {
                salary = double.Parse(args[4]);
                corps = args[5];

                soldier = new Engineer(id, firstName, lastName, salary, corps,
                    GetAuxiliary("Repair", args.Skip(6).ToArray()));

            }
            else if (type == "LeutenantGeneral")
            {
                salary = double.Parse(args[4]);
                soldier = new LuetenantGeneral(id, firstName, lastName, salary);
            }
            else
            {
                salary = double.Parse(args[4]);
                corps = args[5];

                soldier = new Commando(id, firstName, lastName, salary, corps, GetAuxiliary("Mission", args.Skip(6).ToArray()));
            }

            return soldier;
        }

        static HashSet<IAuxiliary> GetAuxiliary(string type, string[] args)
        {
            HashSet<IAuxiliary> aux = new HashSet<IAuxiliary>();

            if (type == "Mission")
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    try
                    {
                        aux.Add(new Mission(args[i], args[i + 1]));
                    }
                    catch (ArgumentException)
                    {
                        // ignored
                    }
                }
            }
            else
            {
                for (int i = 0; i < args.Length; i += 2)
                    aux.Add(new Repair(args[i], int.Parse(args[i + 1])));
            }

            return aux;
        }
    }
}
