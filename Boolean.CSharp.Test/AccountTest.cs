using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.User;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTest
    {
        private Account? account;
        [SetUp]
        public void SetUp()
        {
            account = new SpendingAccount(Main.Branch.First,"test");
        }
        [Test]
        public void Deposit()
        {
            Assert.IsTrue(account.MakeTransaction(TransactionType.Credit,500d));
            Assert.AreEqual(account.Balance, 500d);
            account.MakeTransaction(TransactionType.Credit, 200d);
            Assert.AreEqual(account.Balance, 700d);

        }
        [Test]
        public void Withdraw()
        {
            account.MakeTransaction(TransactionType.Credit, 500d);

            Assert.IsTrue(account.MakeTransaction(TransactionType.Debit, 200d));
            Assert.AreEqual(account.Balance, 300d);

        }
        [Test]
        public void GetStatements() 
        {
            account.MakeTransaction(TransactionType.Credit, 500d);
            account.MakeTransaction(TransactionType.Debit, 300d);


            var result = account.GetTransactions();

            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void CreateOverdraftRequest()
        {
            var result = account.CreateOverdraftRequest(500d);

            Assert.IsNotNull(result);
            Manager manager = new Manager();
            manager.EditRequest(result, OverdraftStatus.Approved);
            bool result2 = account.MakeTransaction(TransactionType.Debit, 400d);
            Assert.IsTrue(result2);
        }
        [Test]
        public void GetBalance()
        {
            account.MakeTransaction(TransactionType.Credit, 400d);
            account.MakeTransaction(TransactionType.Debit, 400d);

            account.MakeTransaction(TransactionType.Credit, 500d);
            account.MakeTransaction(TransactionType.Credit, 200d);

            Assert.That(account.GetBalance(), Is.EqualTo(700d));
        }

    }
}
