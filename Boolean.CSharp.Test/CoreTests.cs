using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Xml.Linq;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateUser()
        {
            // I want to create a user account.

            // Arrange
            Core _core = new Core();

            string name = "Max";
            string password = "password";

            // Act
            _core.CreateUser(name, password);

            // Assert
            Assert.AreEqual(_core.UserList.Count, 1);
        }

/*        [Test]
        public void CreateBankAccount()
        {
            // I want to create a bank account.

            // Arrange
            _core.CreateUser("name", "password", false);

            // Act
            _core.CreateUser(name, password, savingsaccount);

            // Assert
            Assert.AreEqual(_core.UserList.Count, 1);
        }

        [Test]
        public void IsSavingsAccount()
        {
            // I want to create a savings account.

            // Arrange
            _core.CreateUser("name", "password", false);
            Assert.IsFalse(_core.UserList.First().SavingsAccount);
            var user = _core.UserList.First();

            // Act
            _core.SavingsAccount(user);

            // Assert
            Assert.IsTrue(_core.UserList.First().SavingsAccount);
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
            Assert.AreEqual(amount, _core.AccountList.First().Transaction.Balance);
        }*/
    }
}