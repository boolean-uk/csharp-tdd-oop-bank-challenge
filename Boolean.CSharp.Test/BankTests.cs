using Boolean.CSharp.Main;
using Boolean.CSharp.Main.User;
using NUnit.Framework;
using System.Transactions;
using Transaction = Boolean.CSharp.Main.Transaction;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {
        private Bank _bank;

        public BankTests()
        {
            _bank = new Bank();

        }

        [Test]
        public void CreateCurrentAccountTest()
        {
            //arrange
            Bank bank = new Bank();
            Customer customer = new Customer("Ola Nordmann", "Osloveien 2", "Oslo", 123456789, 19790303);
            //act
            CurrentAccount currentAccount = new CurrentAccount() {Owner = "Ola Nordmann", Balance = 0 };
            //assert
            Assert.That(currentAccount.Owner.Equals(customer.Fullname));
        }

        [Test]
        public void CreateSavingsAccountTest()
        {
            //arrange
            Bank bank = new Bank();
            Customer customer = new Customer("Ola Nordmann", "Osloveien 2", "Oslo", 123456789, 19790303);
            //act
            SavingsAccount savingsAccount = new SavingsAccount() { Owner = "Ola Nordmann", Balance = 0 };
            //assert
            Assert.That(savingsAccount.Owner.Equals(customer.Fullname));
        }

        [Test]
        public void DepositTest()
        {
            //arrange
            Bank bank = new Bank();
            List<Transaction> transactions = new List<Transaction>();
            Customer customer = new Customer("Ola Nordmann", "Osloveien 2", "Oslo", 123456789, 19790303);
            CurrentAccount currentAccount = new CurrentAccount() { Owner = "Ola Nordmann", Balance = 0 };
            SavingsAccount savingsAccount = new SavingsAccount() {Owner = "Ola Nordmann", Balance = 0 };
            //act
            Transaction transaction1 = new Transaction(DateTime.Now, "Credit", 2000, "Approved", 0);
            Transaction transaction2 = new Transaction(DateTime.Now, "Credit", 500, "Approved", 0);
            bank.Deposit(transaction1.Amount, currentAccount);
            bank.Deposit(transaction2.Amount, currentAccount);
            transactions.Add(transaction1);
            transactions.Add(transaction2);
            
            //assert
            Assert.AreEqual(2500, currentAccount.Balance);
            Assert.AreEqual(2, transactions.Count);

        }

        [Test]
        public void WithdrawTest()
        {
            //arrange
            Bank bank = new Bank();
            List<Transaction> transactions = new List<Transaction>();
            Customer customer = new Customer("Ola Nordmann", "Osloveien 2", "Oslo", 123456789, 19790303);
            CurrentAccount currentAccount = new CurrentAccount() { Owner = "Ola Nordmann", Balance = 7500 };
            SavingsAccount savingsAccount = new SavingsAccount() { Owner = "Ola Nordmann", Balance = 0 } ;
            //act
            Transaction transaction1 = new Transaction(DateTime.Now, "Debit", 2000, "Approved", 0);
            Transaction transaction2 = new Transaction(DateTime.Now, "Debit", 500, "Approved", 0);
            bank.Withdraw(transaction1.Amount, currentAccount);
            bank.Withdraw(transaction2.Amount, currentAccount);
            transactions.Add(transaction1);
            transactions.Add(transaction2);
            //assert
            Assert.AreEqual(5000, currentAccount.Balance);
            Assert.AreEqual(2, transactions.Count);
        }
        [Test]
        public void WriteStatementTest()
        {
            //arrange
            Bank bank = new Bank();
            List<Transaction> finishedTransactions = new List<Transaction>();
            Customer customer = new Customer("Ola Nordmann", "Osloveien 2", "Oslo", 123456789, 19790303);
            CurrentAccount currentAccount = new CurrentAccount() { Owner = "Ola Nordmann", Balance = 5000 };
            SavingsAccount savingsAccount = new SavingsAccount() { Owner = "Ola Nordmann", Balance = 0 };
            Transaction transaction1 = new Transaction(DateTime.Now, "Credit", 1000, "Approved", 0);
            Transaction transaction2 = new Transaction(DateTime.Now, "Credit", 500, "Approved", 0);
            Transaction transaction3 = new Transaction(DateTime.Now, "Debit", 2500, "Approved", 0);
            Transaction transaction4 = new Transaction(DateTime.Now, "Debit", 500, "Approved", 0);
            //act
            Transaction finished1 = bank.Deposit(transaction1.Amount, currentAccount);
            Transaction finished2 = bank.Deposit(transaction2.Amount, currentAccount);
            Transaction finished3 = bank.Withdraw(transaction3.Amount, currentAccount);
            Transaction finished4 = bank.Withdraw(transaction4.Amount, currentAccount);
            finishedTransactions.Add(finished1);
            finishedTransactions.Add(finished2);
            finishedTransactions.Add(finished3);
            finishedTransactions.Add(finished4);
            //assert
            bank.WriteStatement(finishedTransactions);
            Assert.AreEqual(3500, currentAccount.Balance);
            Assert.AreEqual("Ola Nordmann", currentAccount.Owner);
        }
    }
}