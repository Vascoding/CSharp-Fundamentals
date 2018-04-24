using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTest
    {
        [Test]


        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            Mock<FakeTarget> fakeTarget = new Mock<FakeTarget>();
            Hero hero = new Hero("Pesho", new FakeWeapon());
            fakeTarget.Setup(f => f.IsDead()).Returns(true).Callback(() => { fakeTarget.Object.GiveExperience(); });

            
            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(20, hero.Experience);
        }
    }
}