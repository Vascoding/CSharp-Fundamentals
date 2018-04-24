namespace CatLady
{
    public class Cat : Breed
    {
        public string Name { get; set; }

        public override string ToString()
        {
            if (this.BreedName == "Siamese")
            {
                return $"{this.BreedName} {this.Name} {this.EarSize}";
            }
            if (this.BreedName == "Cymric")
            {
                return $"{this.BreedName} {this.Name} {this.FurLength:f2}";
            }
            else
            {
                return $"{this.BreedName} {this.Name} {this.MeawingDecibels}";
            }
        }
    }
}
