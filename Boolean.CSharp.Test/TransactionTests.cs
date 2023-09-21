using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void CreditTransactionToStringTest()
        {
            DateTime date = DateTime.Now;
            decimal amount = 2000.00m;
            string expected = $"{date.ToString("dd/MM/yyyy")} || {amount} ||        || {amount}";

            Transaction t = new Transaction(date, TransactionType.Credit, amount, 0m);

            Assert.AreEqual(expected, t.ToString());
        }

        [Test]
        public void DebitTransactionToStringTest()
        {
            DateTime date = DateTime.Now;
            decimal prevBalance = 5000m;
            decimal amount = 2000.00m;
            string expected = $"{date.ToString("dd/MM/yyyy")} ||        || {amount} || {prevBalance - amount}";

            Transaction t = new Transaction(date, TransactionType.Debit, amount, prevBalance);

            Assert.AreEqual(expected, t.ToString());
        }

    }
}
