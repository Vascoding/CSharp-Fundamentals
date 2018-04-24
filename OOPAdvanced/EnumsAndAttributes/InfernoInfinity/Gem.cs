using System.Collections.Generic;

namespace InfernoInfinity
{
    abstract class Gem : Item
    {
        internal enum GemClarity
        {
            Chipped, Regular, Perfect, Flawless
        }

        internal static Dictionary<GemClarity, short> ClarityDamageIncrease = new Dictionary<GemClarity, short>
        {
            {GemClarity.Chipped, 1}, {GemClarity.Regular, 2}, {GemClarity.Perfect, 5}, {GemClarity.Flawless, 10}
        };

        private int _strength;
        private int _agility;
        private int _vitality;
        private GemClarity _clarity;

        public string Clarity
        {
            get
            {
                return this._clarity.ToString();
            }
            set
            {
                GemClarity.TryParse(value, out _clarity);
            }
        }

        public int Strength
        {
            get
            {
                return this._strength;
            }
            protected set
            {
                _strength = value + ClarityDamageIncrease[_clarity];
            }
        }

        public int Agility
        {
            get {return this._agility; }
            protected set
            {
                _agility = value + ClarityDamageIncrease[_clarity];
            } 
            }

        public int Vitality
        {
            get { return this._vitality; }
            protected set
            {
                _vitality = value + ClarityDamageIncrease[_clarity];
            } 
            }


        protected Gem(string clarity, int strength, int agility, int vitality)
        {
            this.Clarity = clarity;
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
        }
    }
}