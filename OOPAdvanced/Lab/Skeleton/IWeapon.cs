namespace Skeleton
{
    public interface IWeapon
    {
        void Attack(ITarget target);
        int AttackPoints { get; set; }
        int DurabilityPoints { get; }
    }
}