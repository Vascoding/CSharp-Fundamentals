namespace Animals
{
    public class Frog : Animal
    {
        public override string ProduceSound()
        {
            return "Frogggg";
        }

        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ToString()
        {
            return $"Frog\r\n{this.Name} {this.Age} {this.Gender}\r\n{this.ProduceSound()}";
        }
    }
}