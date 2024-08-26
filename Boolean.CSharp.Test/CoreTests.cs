using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Acounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        

        [Test]
        public void DepositTest()
        {
            CurrentSavingsAccount currentSavingsAccount = new CurrentSavingsAccount();
            SavingsAccount savingsAccount = new SavingsAccount();

            decimal expected1 = 2000;
            decimal expected2 = 1000;

            currentSavingsAccount.Deposit(1300);
            currentSavingsAccount.Deposit(0);
            currentSavingsAccount.Deposit(700);
            savingsAccount.Deposit(1000);

            decimal result1 = currentSavingsAccount.Balance;
            decimal result2 = savingsAccount.Balance;

            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);

        }

        [Test]
        public void WithdrawTest()
        {
            CurrentSavingsAccount currentSavingAccount = new CurrentSavingsAccount();

            decimal expected = 1000;
            currentSavingAccount.Deposit(1500);
            currentSavingAccount.Withdraw(500);

            decimal result = currentSavingAccount.Balance;

            Assert.AreEqual(expected, result);

        }

        [Test]
        public void BalanceTest()
        {
            CurrentSavingsAccount savingsAccount = new CurrentSavingsAccount();

            decimal expected = 2000;

            savingsAccount.Deposit(1500);
            savingsAccount.Deposit(1500);
            savingsAccount.Withdraw(1000);

            decimal result = savingsAccount.getBalance();

            Assert.AreEqual(expected, result);
        }


    }
}