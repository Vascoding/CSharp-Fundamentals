using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    public class Stat
    {
        private string damage;
        private string health;
        private string armor;
        public string Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                if (value == "null")
                {
                    value = "45";
                }
                this.damage = value;
            }
        }
        public string Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value == "null")
                {
                    value = "250";
                }
                this.health = value;
            }
        }
        public string Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                if (value == "null")
                {
                    value = "10";
                }
                this.armor = value;
            }
        }
    }
    class Startup
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, Stat>> dict = new Dictionary<string, Dictionary<string, Stat>>();
            for (int i = 0; i < num; i++)
            {
                var dragons = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var type = dragons[0];
                var name = dragons[1];
                var damage = dragons[2];
                var health = dragons[3];
                var armor = dragons[4];

                if (dict.ContainsKey(type))
                {
                    if (dict[type].ContainsKey(name))
                    {
                        dict[type][name].Damage = damage;
                        dict[type][name].Health = health;
                        dict[type][name].Armor = armor;
                    }
                    else
                    {
                        dict[type].Add(name, new Stat
                        {
                            Damage = damage,
                            Health = health,
                            Armor = armor
                        });
                    }
                }
                else
                {
                    dict.Add(type, new Dictionary<string, Stat>());
                    dict[type].Add(name, new Stat
                    {
                        Damage = damage,
                        Health = health,
                        Armor = armor
                    });
                }
            }

            foreach (var d in dict)
            {
                Console.WriteLine($@"{d.Key}::({d.Value.Average(a => int.Parse(a.Value.Damage)):f2}/{d.Value.Average(a => int.Parse(a.Value.Health)):f2}/{d.Value.Average(a => int.Parse(a.Value.Armor)):f2})");
                foreach (var v in d.Value.OrderBy(v => v.Key))
                {
                    Console.WriteLine($"-{v.Key} -> damage: {v.Value.Damage}, health: {v.Value.Health}, armor: {v.Value.Armor}");
                }
            }
        }
    }
}
