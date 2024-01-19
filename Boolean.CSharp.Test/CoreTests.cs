using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateCurrentAccount()
        {
            User user = new User();
            Assert.That(user.CreateCurrent(), Is.True);
            Assert.That(user.accounts[0], Is.TypeOf<CurrentAccount>());
        }

        [Test]
        public void CreateSavingsAccount()
        {
            User user = new User();
            Assert.That(user.CreateSavings(), Is.True);
            Assert.That(user.accounts[0], Is.TypeOf<SavingsAccount>());
        }

    }
}