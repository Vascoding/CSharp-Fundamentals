namespace Skeleton.Tests
{
    public class FakeWeapon : IWeapon
    {
        public void Attack(ITarget target)
        {
        }

        public int AttackPoints { get; set; }
        public int DurabilityPoints { get; }
    }
}