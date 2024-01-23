using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {


        [Test]
        public void DepositTest()
        {
            BankAccount userAccount = new CurrentAccount("1");
            userAccount.Deposit(1000);
            Assert.AreEqual(1000, userAccount.Balance);

        }

        [Test]
        public void WithdrawTest()
        {
            BankAccount userAccount = new CurrentAccount("1");
            userAccount.Deposit(3000);
            userAccount.Withdraw(1000);
            Assert.AreEqual(2000, userAccount.Balance);
        }

        [Test]
        public void InvalidWithdrawTest()
        {
            BankAccount userAccount = new CurrentAccount("1");
            userAccount.Deposit(1000);
            userAccount.Withdraw(2000);
            Assert.AreEqual(1000, userAccount.Balance);
        }

        public void AccountTypeShouldBeSavingsTest()
        {
            
            BankAccount userAccount = new SavingsAccount("2");

           
            Assert.AreEqual(AccountType.Savings, userAccount.Type);
        }

    }
}