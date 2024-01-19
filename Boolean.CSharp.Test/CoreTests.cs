using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Core;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        [Test]
        public void createCurrentAccount()
        {
            CurrentAccount current = new CurrentAccount();
            Assert.Pass();
        }

        [Test]
        public void createSavingsAccount() { 
            SavingsAccount savingsAccount = new SavingsAccount();
            Assert.Pass();
        }

    }
}