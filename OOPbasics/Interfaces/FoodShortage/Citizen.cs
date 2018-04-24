namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthdate;
        }
        public void BuyFood()
        {
            this.Food += 10;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BirthDate { get; set; }
        public int Food { get; private set; }
    }
}