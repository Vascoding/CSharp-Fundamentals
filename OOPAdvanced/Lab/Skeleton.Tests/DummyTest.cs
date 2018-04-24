using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTest
    {
        private const int axeDurability = 1;
        private const int axeAttack = 10;
        private const int dummyHealth = 0;
        private const int dummyExperience = 10;
        private Axe axe;
        private Dummy dummy;
        private Hero hero;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(axeAttack, axeDurability);
            this.dummy = new Dummy(dummyHealth, dummyExperience);
            this.hero = new Hero("Pesho", new Axe(axeAttack, axeDurability));
        }

        [Test]
        public void Dummy_Loose_Helth_If_Attacked()
        {

            this.dummy.TakeAttack(axe.AttackPoints);

            Assert.AreEqual(0, this.dummy.Health);
        }

        [Test]
        public void Dead_Dummy_Throws_Exception_If_Attacked()
        {

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(this.axe.AttackPoints));

            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void Dead_Dummy_Can_Give_Xp()
        {
            this.hero.Attack(this.dummy);

            Assert.AreEqual(10, hero.Experience);
        }

        [Test]
        public void Alive_Dummy_Cant_Give_Xp()
        {
            this.hero.Attack(this.dummy);
            var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}
