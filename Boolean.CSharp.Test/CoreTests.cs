using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Bank _core;

       

        [Test]
        public void CheckIfAccountCreated()
        {
            User user = new User("Thanasakis", "test", "6999999", 1000m, AccountType.Saving);

            
            Bank bank = new Bank("test");
            int accounts = bank.BankAccounts.Count;
            bank.CreateAccount(user);

            Assert.AreEqual(accounts+1, bank.BankAccounts.Count);

        }

        [Test]
        public void CheckTransaction()
        {
            User user = new User("Thanasakis", "test", "6999999", 1000m, AccountType.Saving);
            Bank bank = new Bank("test");
            Transaction transaction = new Transaction(DateTime.Now, TransactionType.Debit,500m, user.balance);
            bank.CreateAccount(user);
            string result = bank.MakeTransaction(transaction, user, bank.BankAccounts.ElementAt(0));

            Assert.AreEqual(result, "Witdhawal completed succesfully");

        }
        [Test]
        public void CheckReceipt()
        {
            User user = new User("Thanasakis", "test", "6999999", 1000m, AccountType.Saving);
            Bank bank = new Bank("test");
            Transaction transaction = new Transaction(DateTime.Now, TransactionType.Debit, 500m, user.balance);
            bank.CreateAccount(user);
            bank.MakeTransaction(transaction, user, bank.BankAccounts.ElementAt(0));

            transaction.TransactionsReceipt(user, bank.BankAccounts.ElementAt(0));

        }

    }
}