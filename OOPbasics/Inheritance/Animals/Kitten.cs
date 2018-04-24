namespace Animals
{
    public class Kitten : Cat
    {
        public override string ProduceSound()
        {
            return "Miau";
        }

        public Kitten(string name, int age) : base(name, age, "Female")
        {
        }

        public override string ToString()
        {
            return $"Kitten\r\n{this.Name} {this.Age} {this.Gender}\r\n{this.ProduceSound()}";
        }
    }
}