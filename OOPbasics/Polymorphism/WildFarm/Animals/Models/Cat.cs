using System.Text;

namespace WildFarm
{
    public class Cat : Felime
    {
        public string Breed { get; set; }
        public override string MakeSound()
        {
            return "Meowwww";
        }

        public override void EatFood(Food food)
        {
            this.FoodEaten = food.Quantity;
        }

        public Cat(string animalType, string animalName, double animalWeight, string leavingRegion, string breed) : base(animalType, animalName, animalWeight, leavingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]");
            return sb.ToString();
        }
    }
}