using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Concretes;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System.Transactions;
using Transaction = Boolean.CSharp.Main.Concretes.Transaction;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private IAccount _currentAccount;
        private IAccount _savingsAccount;

        public CoreTests()
        {
            _currentAccount = new CurrentAccount();
            _savingsAccount = new SavingsAccount();

        }

        [Test]
        public void AddAccountTest()
        {
            IAccount savingsAccount = new SavingsAccount();
            IAccount currentAccount = new CurrentAccount();
            ICustomer customer = new Customer();

            customer.AddAccount(savingsAccount);
            customer.AddAccount(currentAccount);

            List<IAccount> accounts = customer.GetAccounts();

            Assert.That(accounts.Count,Is.EqualTo(2));
        }


        [Test]
        public void AddTransaction()
        {
            double amount = 10.00d;
            double amount2 = -10.00d;
            ITransaction transaction = new Transaction(amount, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(transaction);
            ITransaction transaction2 = new Transaction(amount, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(transaction2);
            ITransaction transaction3 = new Transaction(amount2, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(transaction3);

            double actualBalance = _currentAccount.GetBalance();
            
            Assert.That(amount, Is.EqualTo(actualBalance));
            
        }

        [Test]
        public void GenerateBankStatementTest()
        {
            // Arrange
            ITransaction deposit1 = new Transaction(1000.00d, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(deposit1);
            ITransaction deposit2 = new Transaction(2000.00d, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(deposit2);
            ITransaction withdrawal = new Transaction(-500, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(withdrawal);

            string expectedStatement = $"date       || amount || balance{Environment.NewLine}" +
                                       $"{withdrawal.GetDetails().Item1} || -500,00 || 2500,00{Environment.NewLine}" +
                                       $"{deposit2.GetDetails().Item1} || 2000,00 || 3000,00{Environment.NewLine}" +
                                       $"{deposit1.GetDetails().Item1} || 1000,00 || 1000,00";

            // Act
            string actualStatement = _currentAccount.GenerateBankStatement();

            // Assert
            Assert.That(actualStatement, Is.EqualTo(expectedStatement));
        }

    }
}