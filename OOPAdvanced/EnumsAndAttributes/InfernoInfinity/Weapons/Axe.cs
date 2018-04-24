namespace InfernoInfinity.Weapons
{
    class Axe : Weapon
    {
        private const int BaseMinDamage = 5;
        private const int BaseMaxDamage = 10;
        private const int BaseSockets = 4;

        public Axe(string name, string rarity)
            : base(name, rarity, BaseMinDamage, BaseMaxDamage, BaseSockets) { }
    }
}