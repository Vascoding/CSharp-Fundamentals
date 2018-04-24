using System;
using _02.Blobs.Interfaces;
using _02.Blobs.Entities.Attacks;
namespace _02.Blobs.Entities
{
    public class Blob
    {
        private string name;
        private int health;
        private int damage;
        private Attack attack;
        private IBehavior behavior;
        private int triggerCount;
        private int initialHealth;
        private bool behaviourTriggeredInThisTurn;
        public Blob(string name, int health, int damage, IBehavior behavior, Attack attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Behavior = behavior;
            this.attack = attack;
            this.initialHealth = health;          
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                }

                if (this.health <= this.initialHealth / 2 && !this.Behavior.IsTriggered)
                {
                    this.TriggerBehavior();
                }
            }
        }

        public int Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        public IBehavior Behavior
        {
            get { return this.behavior; }
            private set { this.behavior = value; }
        }

        public void Attack(Blob target)
        {
            this.attack.Execute(this, target);
        }
        public void TriggerBehavior()
        {
            if (this.behavior.IsTriggered)
            {
                throw new ArgumentException("Behavior is triggered!");
            }

            this.behavior.Trigger(this);
            this.behaviourTriggeredInThisTurn = true;
        }

        public void MoveToNextTurn()
        {
            if (this.behavior.IsTriggered && !this.behaviourTriggeredInThisTurn)
            {
                this.behavior.ApplyRecurrentEffect(this);
            }

            this.behaviourTriggeredInThisTurn = false;
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"Blob {this.Name} KILLED";
            }

            return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }
    }
}