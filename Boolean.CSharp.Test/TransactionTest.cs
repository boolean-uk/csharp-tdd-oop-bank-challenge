using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class TransactionTest
    {
        [TestCase(10f, "", true)]
        [TestCase(10f, "Test", false)]
        public void Transaction(float amount, string description, bool isCredit)
        {
            DateTime date = DateTime.Today;
            Transaction transaction = new Transaction(amount, description, isCredit);
            Assert.That(transaction.Amount, Is.EqualTo(amount));
            Assert.That(transaction.Description, Is.EqualTo(description));
            Assert.That(transaction.IsCredit, Is.EqualTo(isCredit));
            Assert.That(date, Is.EqualTo(transaction.transactionDate));
        }

        [TestCase(10f, "")]
        public void Overdraft(float amount, string description)
        {
            DateTime date = DateTime.Today;
            Overdraft transaction = new Overdraft(amount, description);
            Assert.That(transaction.Amount, Is.EqualTo(amount));
            Assert.That(transaction.Description, Is.EqualTo(description));
            Assert.That(transaction.IsCredit, Is.False);
            Assert.That(date, Is.EqualTo(transaction.transactionDate));
        }
    }
}
