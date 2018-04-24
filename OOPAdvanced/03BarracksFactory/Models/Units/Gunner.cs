using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Models.Units
{
    public class Gunner : Unit
    {
        private const int DefaultHealth = 20;
        private const int DefaultDamage = 20;
        public Gunner() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}