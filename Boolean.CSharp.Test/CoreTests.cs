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

            Assert.That(accounts.Count, Is.EqualTo(2));
        }


        [Test]
        public void AddTransaction()
        {
            double amount = 10.00d;
            double amount2 = -10.00d;
            ITransaction transaction = new Transaction(amount);
            _currentAccount.AddTransaction(transaction);
            ITransaction transaction2 = new Transaction(amount);
            _currentAccount.AddTransaction(transaction2);
            ITransaction transaction3 = new Transaction(amount2);
            _currentAccount.AddTransaction(transaction3);

            double actualBalance = _currentAccount.GetBalance();

            Assert.That(amount, Is.EqualTo(actualBalance));

        }

        [Test]
        public void GenerateBankStatementTest()
        {
            _currentAccount = new CurrentAccount();
            // Arrange
            ITransaction deposit1 = new Transaction(1000.00d);
            _currentAccount.AddTransaction(deposit1);
            ITransaction deposit2 = new Transaction(2000.00d);
            _currentAccount.AddTransaction(deposit2);
            ITransaction withdrawal = new Transaction(-500.00d);
            _currentAccount.AddTransaction(withdrawal);



            var (date1, amount1, balance1) = withdrawal.GetDetails();
            var (date2, amount2, balance2) = deposit2.GetDetails();
            var (date3, amount3, balance3) = deposit1.GetDetails();

            string expectedStatement =
                                          "date                || amount        || balance" + Environment.NewLine +
                                         $"{date1} ||   {amount1:F2}     || {balance1:F2}" + Environment.NewLine +
                                         $"{date2} || {amount2:F2}       || {balance2:F2}" + Environment.NewLine +
                                         $"{date3} || {amount3:F2}       || {balance3:F2}";



            // Act
            string actualStatement = _currentAccount.GenerateBankStatement();

            // Assert
            Assert.That(actualStatement, Is.EqualTo(expectedStatement));
        }

    }
}