namespace BorderControl
{
    public class Pet : IBirthable
    {
        public string Birthday { get; }
        public string Name { get; }

        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}