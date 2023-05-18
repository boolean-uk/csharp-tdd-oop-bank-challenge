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
            // Arrange
            _core.CreateAccount("name", "password", false);
            Assert.IsFalse(_core.AccountList.First().SavingsAccount);
            var user = _core.AccountList.First();

            // Act
            _core.SavingsAccount(user);

            // Assert
            Assert.IsTrue(_core.AccountList.First().SavingsAccount);
        }
    }
}