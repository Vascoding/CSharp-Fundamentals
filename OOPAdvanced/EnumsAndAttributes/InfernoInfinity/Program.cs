using System;
using System.Collections.Generic;
using InfernoInfinity.Builders;

namespace InfernoInfinity
{
    public class Program
    {
        public static void Main()
        {
            var weapons = new HashSet<Weapon>();

            var weaponBuilder = new WeaponBuilder();
            var gemBuilder = new GemBuilder();

            while (true)
            {
                var input = Console.ReadLine().Trim().Split(';');

                if (input[0].Equals("END"))
                    break;

                string[] temp;
                string type;
                int slotIndex;
                string weaponName;

                switch (input[0])
                {
                    case "Create":
                        temp = input[1].Split();

                        var rarity = temp[0];
                        type = temp[1];
                        weaponName = input[2];

                        weaponBuilder.Create(rarity, type, weaponName);
                        weapons.Add(weaponBuilder.Item);
                        break;
                    case "Add":
                        temp = input[3].Split();
                        var clarity = temp[0];
                        type = temp[1];

                        weaponName = input[1];
                        slotIndex = int.Parse(input[2]);

                        gemBuilder.Create(clarity, type);

                        weaponBuilder
                            .ChangeWith(weapons, w => w.Name.Equals(weaponName))
                            .AddGem(gemBuilder.Item, slotIndex);
                        break;
                    case "Remove":
                        weaponName = input[1];
                        slotIndex = int.Parse(input[2]);

                        weaponBuilder
                            .ChangeWith(weapons, w => w.Name.Equals(weaponName))
                            .RemoveGem(slotIndex);
                        break;
                    case "Print":
                        weaponName = input[1];

                        weaponBuilder.ChangeWith(weapons, w => w.Name.Equals(weaponName));

                        Console.WriteLine(weaponBuilder.Item);
                        break;
                }
            }
        }
    }
}
