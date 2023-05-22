using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Enums;
using Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }
        [Test]
        public void CheckingBalanceThrowHistoryTransaction()
        {
            User user = new User("Thanasakis", "test", "6999999", 0, AccountType.Saving);
            Bank bank = new Bank("test");
            bank.CreateAccount(user);
            Transaction transaction = new Transaction(DateTime.Now, TransactionType.Credit, 500m, user.balance);
            Transaction transaction2 = new Transaction(DateTime.Now, TransactionType.Credit, 500m, user.balance);
            Transaction transaction3 = new Transaction(DateTime.Now, TransactionType.Debit, 400m, user.balance);
            bank.MakeTransaction(transaction, user, bank.BankAccounts.ElementAt(0));
            bank.MakeTransaction(transaction2, user, bank.BankAccounts.ElementAt(0));
            bank.MakeTransaction(transaction3, user, bank.BankAccounts.ElementAt(0));

            Assert.AreEqual(600m, bank.GetBalance(user, bank.BankAccounts.ElementAt(0)));


        }
       
    }
}
