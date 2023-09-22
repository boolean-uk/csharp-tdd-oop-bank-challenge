using Boolean.CSharp.Main;
using NUnit.Framework;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        BankAccount newaccount = new BankAccount();
        BankTransaction newtransaction = new BankTransaction();

        [Test]
        public void CreateAccount()
        {
            newaccount.Create_Account("GR2342456708", 500, "current");

            Assert.Pass();
        }

        [Test]
        public void WriteStatement()
        {
            newaccount.Create_Account("GR2342456708", 500, "current");
            newaccount.Write_Statement(date, 500, 0, 500);

            Assert.Pass();
        }

        [Test]
        public void ShouldCreateTransaction()
        {
            newaccount.Create_Account("GR2342456708", 500, "current");
            newtransaction.Create_Transaction("withdraw", 500, "GR2342456708");

            Assert.Pass();
        }

    }
}