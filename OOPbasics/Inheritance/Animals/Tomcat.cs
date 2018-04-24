namespace Animals
{
    public class Tomcat : Cat
    {
        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }

        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }

        public override string ToString()
        {
            return $"Tomcat\r\n{this.Name} {this.Age} {this.Gender}\r\n{this.ProduceSound()}";
        }
    }
}