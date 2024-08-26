using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Acounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        

        [Test]
        public void DepositTest()
        {
           CurrentSavingsAccount savingsAccount = new CurrentSavingsAccount();

            decimal expected = 1000;

            savingsAccount.Deposit(1000);

            decimal result = savingsAccount.Balance;

            Assert.AreEqual(expected, result);

        }

    }
}