using InfernoInfinity.Gems;

namespace InfernoInfinity.Builders
{
    class GemBuilder : Builder<Gem, GemBuilder>
    {

        public GemBuilder Create(string clarity, string type)
        {
            Gem gem = default(Gem);

            switch (type)
            {
                case "Ruby":
                    gem = new Ruby(clarity);
                    break;
                case "Emerald":
                    gem = new Emerald(clarity);
                    break;
                case "Amethyst":
                    gem = new Amethyst(clarity);
                    break;
            }

            Item = gem;
            return this;
        }
    }
}