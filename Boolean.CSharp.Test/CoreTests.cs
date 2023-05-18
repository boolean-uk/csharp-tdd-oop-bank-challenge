using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Xml.Linq;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void AddUser()
        {
            // I want to create a current account.

            // Arrange
            string name = "Max";
            string password = "password";
            bool savingsaccount = false;

            // Act
            _core.CreateAccount(name, password, savingsaccount);

            // Assert
            Assert.AreEqual(_core.AccountList.Count, 1);
        }

        [Test]
        public void IsSavingsAccount()
        {
            // I want to create a savings account.

            // Arrange
            _core.CreateAccount("name", "password", false);
            Assert.IsFalse(_core.AccountList.First().SavingsAccount);
            var user = _core.AccountList.First();

            // Act
            _core.SavingsAccount(user);

            // Assert
            Assert.IsTrue(_core.AccountList.First().SavingsAccount);
        }

        [Test]
        public void DepositAmount()
        {
            // I want to deposit funds.

            // Arrange
            _core.CreateAccount("name", "password", false);
            var user = _core.AccountList.First();
            int amount = 1000;

            // Act
            _core.DepositAmount(user, amount);

            // Assert
            Assert.AreEqual(amount, _core.AccountList.First().Balance);
        }
    }
}