using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void TestTransactionDeposit()
        {
            Transaction transaction = new Transaction(400);

            Assert.That(transaction.Balance, Is.EqualTo(400));
            Assert.That(transaction.Type, Is.EqualTo("Deposit"));
            Assert.That(transaction.Time.Date, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        public void TestTransactionWithdrawal()
        {
            Transaction transaction = new Transaction(-400);

            Assert.That(transaction.Balance, Is.EqualTo(400));
            Assert.That(transaction.Type, Is.EqualTo("Withdraw"));
            Assert.That(transaction.Time.Date, Is.EqualTo(DateTime.Now.Date));
        }

    }
}