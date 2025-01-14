using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Bank _bank;
        private Customer _customer1;
        private Customer _customer2;
        private CurrentAccount _currentAccount1;
        private SavingsAccount _savingsAccount1;
        private CurrentAccount _currentAccount2;
        private SavingsAccount _savingsAccount2;

        [SetUp]
        public void Setup()
        {
            _bank = new Bank();
            _customer1 = new Customer();
            _customer2 = new Customer();

            _currentAccount1 = _customer1.CreateAccount(AccountType.Current, Branch.Oslo) as CurrentAccount;
            _savingsAccount1 = _customer1.CreateAccount(AccountType.Savings, Branch.Oslo) as SavingsAccount;
            _currentAccount2 = _customer2.CreateAccount(AccountType.Current, Branch.Trondheim) as CurrentAccount;
            _savingsAccount2 = _customer2.CreateAccount(AccountType.Savings, Branch.Trondheim) as SavingsAccount;

            _bank.AddCustomer(_customer1);
            _bank.AddCustomer(_customer2);

        }

        [Test]
        public void TestCreateCustomerAndAccount()
        {
            Assert.IsNotNull(_currentAccount1);
            Assert.IsNotNull(_savingsAccount1);
            Assert.IsNotNull(_currentAccount2);
            Assert.IsNotNull(_savingsAccount2);
            Assert.IsNotNull(_customer1);
            Assert.IsNotNull(_customer2);
            Assert.That(_customer1.Accounts.Count, Is.EqualTo(2));
            Assert.That(_customer2.Accounts.First(), Is.EqualTo(_currentAccount1));
        }

        [Test]
        public void TestCreateTransaction()
        {
            _currentAccount1.Deposit(1000);
            _currentAccount1.Withdraw(500);

            Assert.That(_currentAccount1.Transactions.Count, Is.EqualTo(2));
            Assert.That(_currentAccount1.Transactions.First().Amount, Is.EqualTo(1000));
            Assert.That(_currentAccount1.Transactions.Last().Amount, Is.EqualTo(-500));
        }

        [Test]
        public void TestGetBalance()
        {
            _currentAccount1.Deposit(1000);
            _currentAccount1.Withdraw(500);

            Assert.That(_currentAccount1.GetBalance(), Is.EqualTo(500));
        }

        [Test]
        public void TestBankStatement()
        {
            _currentAccount1.Deposit(1000);
            _currentAccount1.Withdraw(500);
            _currentAccount1.Deposit(2000);
            _currentAccount1.Withdraw(1000);

            _currentAccount1.CreateBankStatement();
            Assert.That(_currentAccount1.BankStatements.Count, Is.EqualTo(1));
            Assert.That(_currentAccount1.BankStatements.First().Transactions.Count, Is.EqualTo(4));
            Assert.That(_currentAccount1.BankStatements.First().Transactions[0].Amount, Is.EqualTo(1000));
        }


    }
}