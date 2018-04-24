namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public string Id { get; }
        public string Name { get; }
        public string Birthday { get; }
        public int Age { get; }


        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }
    }
}