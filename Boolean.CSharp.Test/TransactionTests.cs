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
            decimal amount = 2000m;
            string expected = $"{date.ToString("dd/MM/yyyy")} || {amount} || \t || {amount}";

            Transaction t = new Transaction(1, date, TransactionType.Credit, amount, 0);

            Assert.AreEqual(expected, t.ToString());
        }

    }
}
