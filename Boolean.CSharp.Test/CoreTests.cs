using System.Transactions;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Class;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;
using Transaction = Boolean.CSharp.Main.Class.Transaction;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        private Account _currentAccount;
        private Account _savingAccount;

      
        [SetUp]
        public void SetUp() 
        {
            _currentAccount = new CurrentAccount(Role.Customer);
            _savingAccount = new SavingAccount(Role.Customer);

            _currentAccount.Deposit(1000, new DateTime(2012, 1, 10));

            _currentAccount.Withdraw(500);
            _currentAccount.Withdraw(500);
            _currentAccount.Withdraw(500);

           
        }

        [Test]
        public void TestCreateCurrentAccount()
        {
           Assert.That(_currentAccount, Is.Not.Null);
        }

        [Test]
        public void TestCreateSavingAccount()
        {
            Assert.That(_savingAccount, Is.Not.Null);
        }

        [Test]
        public void TestBankStatement()
        {
            List<Transaction> transactions = _currentAccount.Transactions;
            Transaction transaction = transactions[0];


            Console.WriteLine(_currentAccount.ToString());
            Assert.That(transaction.TransactionDate, Is.TypeOf<DateTime>());
            Assert.That(transaction.Type, Is.TypeOf<TransactionType>());
            Assert.That(transaction.Balance, Is.GreaterThan(0));
        }

        [Test]
        public void TestDepositAndWithdrawal()
        {
            _savingAccount.Deposit(1000);
            _savingAccount.Withdraw(500);

            Assert.That(_savingAccount.CalculateBalance(), Is.EqualTo(500));
        }

    }
}