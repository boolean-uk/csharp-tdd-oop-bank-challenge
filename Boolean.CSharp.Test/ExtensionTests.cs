using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Transactions;
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
        

        [Test]
        public void BalanceTest()
        {
            Bank bank = new Bank();
            string accountName = "Test";
            bank.CreateAccount(accountName, AccountType.Current);


            bank.AddTransaction(accountName, AccountType.Current, TransactionType.deposit, 1000);
            bank.AddTransaction(accountName, AccountType.Current, TransactionType.deposit, 2000);
            bank.AddTransaction(accountName, AccountType.Current, TransactionType.withdraw, 500);



            Assert.AreEqual(2500, bank.currentAccounts.FirstOrDefault(i => i._CustomerName == "Test")._balance);
        }
        [Test]
        public void BrancheTest()
        {
            Bank bank = new Bank();
            string accountName = "Test";
            bank.CreateAccount(accountName, AccountType.Current, BranceType.Athens);
            Assert.AreEqual(BranceType.Athens, bank.currentAccounts.FirstOrDefault(i => i._CustomerName == accountName)._branceType);
        }

        [TestCase(300, TransactionType.withdraw)]

        public void OverdraftTest(decimal amount, TransactionType transactionType)
        {
            Bank bank = new Bank();
            string name = "joeri";
            AccountType accountType = AccountType.Current;

            bank.CreateAccount(name, accountType);
            bank.AddTransaction(name, accountType, transactionType, amount);
            Assert.AreEqual(1, bank.overdrafts.Count);
        }

        [TestCase(300, TransactionType.withdraw)]

        public void OverdraftApproveTest(decimal amount, TransactionType transactionType)
        {
            Bank bank = new Bank();
            string name = "joeri";
            AccountType accountType = AccountType.Current;

            bank.CreateAccount(name, accountType);
            bank.AddTransaction(name, accountType, transactionType, amount);
            bank.AcceptOverdraftById(1);
            Assert.AreEqual(true, bank.overdrafts.FirstOrDefault(i => i._id == 1)._status);
        }
    }
}
