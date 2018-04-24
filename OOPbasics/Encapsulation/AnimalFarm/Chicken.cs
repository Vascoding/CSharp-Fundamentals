using System;

namespace AnimalFarm
{
    public class Chicken
    {
        private string name;
        private int age;

        public Chicken()
        {
            
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0 || value > 15)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
                this.age = value;
            }
        }

        
    }
}
