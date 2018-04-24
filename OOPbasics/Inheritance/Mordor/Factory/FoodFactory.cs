using Mordor.Models;

namespace Mordor
{
    class FoodFactory
    {
        private int allPoints;

        public int AllPoints
        {
            get { return this.allPoints; }
        }
        public static int GetPoints(string type)
        {
            switch (type)
            {
                case "apple":
                    return new Apple().Points;
                case "cram":
                    return new Cram().Points;
                case "honeycake":
                    return new HoneyCake().Points;
                case "lembas":
                    return new Lembas().Points;
                case "mushrooms":
                    return new Mushroom().Points;
                case "melon":
                    return new Melon().Points;
                default: return new EverythingElse().Points;
            }
        }
    }
}
