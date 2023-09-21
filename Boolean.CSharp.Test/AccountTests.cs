using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        // User Story: I want to create a current account
        [Test]
        public void CreateCurrentAccountTest()
        {
            CurrentAccount current = new CurrentAccount(1);

            Assert.AreEqual(8, current.Number.Length);
        }

        // User Story: I want to create a savings account
        [Test]
        public void CreateSavingsAccountTest()
        {
            SavingsAccount current = new SavingsAccount(1);

            Assert.AreEqual(8, current.Number.Length);
        }

    }
}