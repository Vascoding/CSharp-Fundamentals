namespace InfernoInfinity.Weapons
{
    class Knife : Weapon
    {
        private const int BaseMinDamage = 3;
        private const int BaseMaxDamage = 4;
        private const int BaseSockets = 2;

        public Knife(string name, string rarity)
            : base(name, rarity, BaseMinDamage, BaseMaxDamage, BaseSockets) { }
    }
}