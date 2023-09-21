using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void DoingADepositShouldIncreaseTheBalance()
        {
            var account = new Account();
            account.Deposit(100, DateTime.Now);
            Assert.AreEqual(100, account.Balance);
        }

        [Test]
        public void DoingWithdrawShouldDecreaseTheBalance()
        {
            var account = new Account();
            account.Deposit(200, DateTime.Now);
            account.Withdraw(100, DateTime.Now);
            Assert.AreEqual(100, account.Balance);
        }

        [Test]
        public void PrintStateMentShouldReturnFormattedStateMent()
        {
            var account = new Account();
            account.Deposit(1000, new DateTime(1992, 5, 5));
            account.Deposit(2000, new DateTime(1992, 5, 6));
            account.Withdraw(999, new DateTime(1992, 5, 7));
            var statement = account.PrintStatement();
            var expectedStatement =
    "date       || credit  || debit  || balance" + Environment.NewLine +
    "07/05/1992 ||         || 999.00 || 2001.00" + Environment.NewLine +
    "06/05/1992 || 2000.00 ||        || 3000.00" + Environment.NewLine +
    "05/05/1992 || 1000.00 ||        || 1000.00";
            Assert.AreEqual(expectedStatement, statement);
        }
        [Test]
        public void DoesCurrentAccountInheritFromAccAndInitializeItCorrectly()
        {
            var currentAccount = new Account();
            Assert.AreEqual(0, currentAccount.Balance);
        }
    }
}