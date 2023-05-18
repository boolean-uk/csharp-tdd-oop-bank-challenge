using Boolean.CSharp.Main;
using NUnit.Framework;

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

            // Act
            _core.CreateAccount(name, password);

            // Assert
            Assert.AreEqual(_core.AccountList.Count, 1);
        }

    }
}