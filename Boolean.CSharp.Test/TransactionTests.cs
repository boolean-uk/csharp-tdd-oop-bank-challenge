using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void CreateTransaction()
        {
            Transaction transaction = new(TransactionType.Credit, 500, 0);
            Assert.That(transaction.NewValue, Is.EqualTo(500));
        }
    }
}
