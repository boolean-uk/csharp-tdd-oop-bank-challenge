using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateCurrentAccount()
        {
            Person person = new Customer();
            person.CreateCurrentAccount();
            Assert.That(person.GetCurrentAccount(), Is.Not.EqualTo(null));
        }
        [Test]
        public void CreateSavingsAccount()
        {
            Person person = new Customer();
            person.CreateSavingsAccount();
            Assert.That(person.GetSavingsAccount(), Is.Not.EqualTo(null));
        }
    }
}