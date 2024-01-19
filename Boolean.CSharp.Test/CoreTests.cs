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
            user.CreateCurrent();
            Assert.That(user.accounts.Count, Is.EqualTo(1));
            Assert.That(user.accounts[0], Is.TypeOf<CurrentAccount>());

        }

        [Test]
        public void CreateSavingsAccount()
        {
            User user = new User();
            user.CreateSavings();
            Assert.That(user.accounts.Count, Is.EqualTo(1));
            Assert.That(user.accounts[0], Is.TypeOf<SavingsAccount>());
        }

        [TestCase(0f, false)]
        [TestCase(-1f, false)]
        [TestCase(10f, true)]
        public void DepositMoney(float amount, bool expectedResult)
        {
            User user = new User();
            user.CreateCurrent();
            Assert.That(user.accounts[0].DepositMoney(amount), Is.EqualTo(expectedResult));
        }

    }
}