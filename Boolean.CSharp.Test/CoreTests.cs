using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
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
        public void DepositTest()
        {
            //CurrentAccount currentAccount = new CurrentAccount("CurrentAccount1");
            Customer customer1 = new Customer();
            customer1.CreateCurrentAccount("Account1", Boolean.CSharp.Main.Enums.AccountBranch.Oslo);

            customer1._currentAccount.Deposit(1000.0D);

            Assert.AreEqual(customer1._currentAccount.Balance(), 1000);

        }
        [Test]
        public void WithdrawTest()
        {
            //CurrentAccount currentAccount = new CurrentAccount("CurrentAccount1");
            Customer customer1 = new Customer();
            customer1.CreateCurrentAccount("Account1", Boolean.CSharp.Main.Enums.AccountBranch.Oslo);

            customer1._currentAccount.Deposit(1000.0D);
            customer1._currentAccount.Withdraw(500.00);

            Assert.AreEqual(customer1._currentAccount.Balance(), 500);

        }
            


    }
}