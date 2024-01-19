using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Customer _customer;
        private BankStatement _bankStatement;

        public CoreTests()
        {
            _customer = new Customer();
            _bankStatement = new BankStatement();
        }

        [Test]
        public void addAccountTest()
        {
            SavingsAccount newSavings = (SavingsAccount)_customer.createAccount(762308, accountType.savings);
            CurrentAccount newCurrent = (CurrentAccount)_customer.createAccount(556223, accountType.current);
            Assert.That(_customer.Accounts.Contains(newSavings));
            Assert.That(_customer.Accounts.Contains(newCurrent));
        }
        [Test]
        public void depositWithdrawTest()
        {
            SavingsAccount savingsAccount = (SavingsAccount)_customer.createAccount(123456, accountType.savings);
            CurrentAccount currentAccount = (CurrentAccount)_customer.createAccount(642758, accountType.current);
            savingsAccount.deposit(0f);
            currentAccount.deposit(0f);
            Assert.That(savingsAccount.Balance, Is.EqualTo(0f));
            Assert.That(currentAccount.Balance, Is.EqualTo(0f));
            savingsAccount.deposit(1000f);
            currentAccount.deposit(50f);
            Assert.That(savingsAccount.Balance, Is.EqualTo(1000f));
            Assert.That(currentAccount.Balance, Is.EqualTo(50f));
            savingsAccount.withdraw(0f);
            currentAccount.withdraw(0f);
            Assert.That(savingsAccount.Balance, Is.EqualTo(1000f));
            Assert.That(currentAccount.Balance, Is.EqualTo(50f));
            savingsAccount.withdraw(100f);
            currentAccount.withdraw(10f);
            Assert.That(savingsAccount.Balance, Is.EqualTo(900f));
            Assert.That(currentAccount.Balance, Is.EqualTo(40f));
        }
        [Test]
        public void transactionsAddToList()
        {
            SavingsAccount savingsAccount = (SavingsAccount)_customer.createAccount(123456, accountType.savings);
            savingsAccount.deposit(1000f);
            DateTime now = DateTime.Now;
            Transaction transaction = new Transaction(1000f, Transaction.transactionType.deposit, now);
            Assert.That(_bankStatement.Transaction.ElementAt(0).Equals(transaction));
        }
    }
}