using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
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
        private Account account;
        [SetUp]
        public void SetUp()
        {
            account = new SpendingAccount(Main.Branch.First,"test");
        }
        [Test]
        public void Deposit()
        {
            Assert.IsTrue(account.makeTransaction(TransactionType.Credit,500d));
            Assert.AreEqual(account.Balance, 500d);
            account.makeTransaction(TransactionType.Credit, 200d);
            Assert.AreEqual(account.Balance, 700d);

        }
        [Test]
        public void Withdraw()
        {
            account.makeTransaction(TransactionType.Credit, 500d);

            Assert.IsTrue(account.makeTransaction(TransactionType.Debit, 200d));
            Assert.AreEqual(account.Balance, 300d);

        }
        [Test]
        public void GetStatements() 
        {
            account.makeTransaction(TransactionType.Credit, 500d);
            account.makeTransaction(TransactionType.Debit, 300d);


            var result = account.GetTransactions();

            Assert.AreEqual(2, result.Count);
        }
        
        
    }
}
