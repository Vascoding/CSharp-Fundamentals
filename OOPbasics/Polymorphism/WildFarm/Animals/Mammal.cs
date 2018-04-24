using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }

        public Mammal(string animalType, string animalName, double animalWeight, string leavingRegion) : base(animalType, animalName, animalWeight)
        {
            this.LivingRegion = leavingRegion;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]");
            return sb.ToString();
        }
    }
}