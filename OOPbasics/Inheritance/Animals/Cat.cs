namespace Animals
{
    public class Cat : Animal
    {
        public override string ProduceSound()
        {
            return "MiauMiau";
        }

        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ToString()
        {
            return $"Cat\r\n{this.Name} {this.Age} {this.Gender}\r\n{this.ProduceSound()}";
        }
    }
}