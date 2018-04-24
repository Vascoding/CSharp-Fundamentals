using _02.Blobs.Entities;

namespace _02.Blobs.Interfaces
{
    public interface IBehavior
    {
        void Trigger(Blob source);
        void ApplyRecurrentEffect(Blob source);
        void ApplyTriggerEffect(Blob source);
        bool IsTriggered { get; set; }
    }
}