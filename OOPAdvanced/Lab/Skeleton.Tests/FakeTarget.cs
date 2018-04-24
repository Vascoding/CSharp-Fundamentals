namespace Skeleton.Tests
{
    public class FakeTarget : ITarget
    {
        public void TakeAttack(int attackPoints)
        {
            this.Health -= attackPoints;
        }

        public int Health
        {
            get { return 1; }
            set { this.Health = value; }
        }
        public int GiveExperience()
        {
            return 20;
        }

        public virtual bool IsDead()
        {
            return false;
        }
    }
}