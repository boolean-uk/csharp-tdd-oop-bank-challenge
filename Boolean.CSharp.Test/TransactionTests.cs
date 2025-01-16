using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void transtactionWithdraw()
        {
            Main.Transaction transaction = new(100, "WITHDRAW", new DateTime(2012, 1, 10));

            Assert.AreEqual(100, transaction.Amount);

            Assert.AreEqual("WITHDRAW", transaction.Type);
        }
        [Test]
        public void transactionWithdraw()
        {
            Main.Transaction transaction = new(100, "DEPOSIT", new DateTime(2012, 1, 10));

            Assert.AreEqual(100, transaction.Amount);
            Assert.AreEqual("DEPOSIT", transaction.Type);
        }
    }
}
