using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfernoInfinity
{
    abstract class Weapon : Item
    {
        internal static Dictionary<ItemRarity, Int16> RarityDamageIncrease = new Dictionary<ItemRarity, short>
        {
            {ItemRarity.Common, 1}, {ItemRarity.Uncommon, 2}, {ItemRarity.Rare, 3}, {ItemRarity.Epic, 5}
        };

        private ItemRarity _rarity;
        private readonly Gem[] _socketSlots;

        public string Name { get; protected set; }
        public int Sockets { get; protected set; }

        private int GetDamageIncreaseFromStrength(int modifier = 1)
        {
            return _socketSlots
                       .Where(g => g != null)
                       .Sum(g => g.Strength)
                   * modifier;
        }

        private int GetDamageIncreaseFromAgility(int modifier = 1)
        {
            return _socketSlots
                       .Where(g => g != null)
                       .Sum(g => g.Agility)
                   * modifier;
        }

        public string Rarity
        {
            get
            {
               return this._rarity.ToString();
            } 
            protected set
            {
                ItemRarity.TryParse(value, out _rarity);
            }
        }

        public int MinDamage { get; protected set; }

        public int MaxDamage { get; protected set; }

        public void AddGem(Gem gem, int slotIndex)
        {
            _socketSlots[slotIndex] = gem;
        }

        public void RemoveGem(int slotIndex)
        {
            _socketSlots[slotIndex] = default(Gem);
        }

        private void ReCalculateDamage()
        {
            this.MinDamage = this.MinDamage;
            this.MaxDamage = this.MaxDamage;
        }

        public override string ToString()
        {
            var minDamageFromSockets = GetDamageIncreaseFromStrength(2) + GetDamageIncreaseFromAgility();
            var minDamage = this.MinDamage * RarityDamageIncrease[_rarity] + minDamageFromSockets;

            var maxDamageFromSockets = GetDamageIncreaseFromStrength(3) + GetDamageIncreaseFromAgility(4);
            var maxDamage = this.MaxDamage * RarityDamageIncrease[_rarity] + maxDamageFromSockets;

            return new StringBuilder(
                    String.Format("{0}: {1}-{2} Damage, +{3} Strength, +{4} Agility, +{5} Vitality",
                        this.Name, minDamage, maxDamage,
                        _socketSlots.Where(x => x != null).Sum(g => g.Strength),
                        _socketSlots.Where(x => x != null).Sum(g => g.Agility),
                        _socketSlots.Where(x => x != null).Sum(g => g.Vitality)))
                .ToString();
        }


        protected Weapon(
            string name, string rarity,
            int minDamage, int maxDamage,
            int sockets)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Sockets = sockets;
            _socketSlots = new Gem[sockets];
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
        }
    }
}