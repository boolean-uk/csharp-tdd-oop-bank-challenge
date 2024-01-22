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
        public void withdraw()
        {
            BankAccount userAccount = new CurrentAccount("1");
            userAccount.Deposit(3000);
            userAccount.Withdraw(1000);
            Assert.AreEqual(2000, userAccount.Balance);
        }

        [Test]
        public void InvalidWithdraw()
        {
            BankAccount userAccount = new CurrentAccount("1");
            userAccount.Deposit(1000);
            userAccount.Withdraw(2000);
            Assert.AreEqual(1000, userAccount.Balance);
        }

        public void AccountType_ShouldBeSavings()
        {
            // Arrange
            BankAccount userAccount = new SavingsAccount("2");

            // Act & Assert
            Assert.AreEqual(AccountType.Savings, userAccount.Type);
        }

    }
}