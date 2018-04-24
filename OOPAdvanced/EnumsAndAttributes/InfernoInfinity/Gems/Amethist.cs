namespace InfernoInfinity.Gems
{
    class Amethyst : Gem
    {
        private const int BaseStrength = 2;
        private const int BaseAgility = 8;
        private const int BaseVitality = 4;

        public Amethyst(string clarity)
            : base(clarity, BaseStrength, BaseAgility, BaseVitality) { }

    }
}