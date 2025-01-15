using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;
using IKVM.Runtime;
using java.time;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class TestTransaction
    {
        [Test]
        public void TestTransactionCreationAndGetters()
        {
            DateTime now = DateTime.Now;
            Transaction transaction = new Transaction(now, 100.0, 500.0, "Credit");

            // Test getters
            Assert.AreEqual(now, transaction.getData());
            Assert.AreEqual(100.0, transaction.getAmount());
            Assert.AreEqual(500.0, transaction.getCurrentBalance());
            Assert.AreEqual("Credit", transaction.getDebitOrCredit());
        }

        [Test]
        public void TestTransactionSetters()
        {
            DateTime now = DateTime.Now;
            Transaction transaction = new Transaction(now, 100.0, 500.0, "Credit");

            DateTime newDate = now.AddDays(1);
            transaction.setData(newDate);
            transaction.setAmount(200.0);
            transaction.setCurrentBalance(700.0);
            transaction.setDebitOrCredit("Debit");

            Assert.AreEqual(newDate, transaction.getData());
            Assert.AreEqual(200.0, transaction.getAmount());
            Assert.AreEqual(700.0, transaction.getCurrentBalance());
            Assert.AreEqual("Debit", transaction.getDebitOrCredit());
        }
    }
}
