using InfernoInfinity.Weapons;

namespace InfernoInfinity.Builders
{
    class WeaponBuilder : Builder<Weapon, WeaponBuilder>
    {

        public WeaponBuilder Create(string rarity, string type, string name)
        {
            Weapon weapon = default(Weapon);

            switch (type)
            {
                case "Axe":
                    weapon = new Axe(name, rarity);
                    break;
                case "Sword":
                    weapon = new Sword(name, rarity);
                    break;
                case "Knife":
                    weapon = new Knife(name, rarity);
                    break;
            }

            Item = weapon;
            return this;
        }

        public WeaponBuilder AddGem(Gem gem, int slotIndex)
        {
            if (slotIndex > Item.Sockets - 1)
                return this;

            Item.AddGem(gem, slotIndex);
            return this;
        }

        public WeaponBuilder RemoveGem(int slotIndex)
        {
            if (slotIndex > Item.Sockets - 1)
                return this;

            Item.RemoveGem(slotIndex);
            return this;
        }

    }
}