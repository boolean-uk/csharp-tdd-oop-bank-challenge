using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class TransactionTest
    {
        [TestCase(10f, true)]
        public void Transaction(float amount, bool isCredit)
        {
            DateTime date = DateTime.Today;
            Transaction transaction = new Transaction(amount, isCredit);
            Assert.That(transaction.Amount, Is.EqualTo(amount));
            Assert.That(transaction.IsCredit, Is.True);
            Assert.That(date, Is.EqualTo(transaction.transactionDate));
        }

        [TestCase(10f)]
        public void Overdraft(float amount)
        {
            DateTime date = DateTime.Today;
            Overdraft transaction = new Overdraft(amount);
            Assert.That(transaction.Amount, Is.EqualTo(amount));
            Assert.That(transaction.IsCredit, Is.True);
            Assert.That(date, Is.EqualTo(transaction.transactionDate));
        }
    }
}
