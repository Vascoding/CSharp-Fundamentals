using System;
using _02.Blobs.Interfaces;

namespace _02.Blobs.Entities.Behaviors
{
    public class Aggressive : IBehavior
    {
        private const int AggressiveDamageMultiplier = 2;
        private const int AggressiveDamageDecrementer = 5;

        private int sourceInitialDamage;

        public void ApplyTriggerEffect(Blob source)
        {
            source.Damage *= AggressiveDamageMultiplier;
        }
        public void Trigger(Blob source)
        {
            
            this.sourceInitialDamage = source.Damage;
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }

        public void ApplyRecurrentEffect(Blob source)
        {
            source.Damage -= AggressiveDamageDecrementer;

            if (source.Damage <= this.sourceInitialDamage)
            {
                source.Damage = this.sourceInitialDamage;
            }
        }
        public bool IsTriggered { get; set; }
    }
}