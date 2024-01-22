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
            Transaction transaction = new Transaction(400, TransactionType.Deposit, 0);

            Assert.That(transaction.Amount, Is.EqualTo(400));
            Assert.That(transaction.Type, Is.EqualTo(TransactionType.Deposit));
            Assert.That(transaction.Time.Date, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        public void TestTransactionWithdrawal()
        {
            Transaction transaction = new Transaction(-400, TransactionType.Withdrawal, 0);

            Assert.That(transaction.Amount, Is.EqualTo(-400));
            Assert.That(transaction.Type, Is.EqualTo(TransactionType.Withdrawal));
            Assert.That(transaction.Time.Date, Is.EqualTo(DateTime.Now.Date));
        }

    }
}