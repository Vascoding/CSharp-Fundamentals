using System;
using _02.Blobs.Interfaces;

namespace _02.Blobs.Entities.Behaviors
{
    public class Inflated : IBehavior
    {
        private const int inflatedHealthGain = 50;
        private const int inflatedHealthDecrement = 10;
        
        public bool IsTriggered { get; set; }
        public void ApplyTriggerEffect(Blob source)
        {
            source.Health += inflatedHealthGain;
        }

        public void Trigger(Blob source)
        {
            this.ApplyTriggerEffect(source);
            this.IsTriggered = true;
        }
        public void ApplyRecurrentEffect(Blob source)
        {
            source.Health -= inflatedHealthDecrement;
        }
    }
}