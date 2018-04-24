namespace InfernoInfinity.Weapons
{
    class Sword : Weapon
    {
        private const int BaseMinDamage = 4;
        private const int BaseMaxDamage = 6;
        private const int BaseSockets = 3;

        public Sword(string name, string rarity)
            : base(name, rarity, BaseMinDamage, BaseMaxDamage, BaseSockets) { }

    }
}