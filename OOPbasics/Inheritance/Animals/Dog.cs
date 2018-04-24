namespace Animals
{
    public class Dog : Animal
    {
        public override string ProduceSound()
        {
            return "BauBau";
        }

        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ToString()
        {
            return $"Dog\r\n{this.Name} {this.Age} {this.Gender}\r\n{this.ProduceSound()}";
        }
    }
}