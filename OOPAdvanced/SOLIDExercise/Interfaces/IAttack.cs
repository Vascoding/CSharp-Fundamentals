using _02.Blobs.Entities;

namespace _02.Blobs.Interfaces
{
    public interface IAttack
    {
        void Execute(Blob attacker, Blob target);
    }
}