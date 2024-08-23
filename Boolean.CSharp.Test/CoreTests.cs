using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
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

        [TestCase(5000)]
        public void TestGetBalance(int depositAmount)
        {
            User user = new User("Jonas", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user);
            account.Deposit(depositAmount, user);

            int? result = account.GetBalance(user);

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(depositAmount));
        }

    }
}