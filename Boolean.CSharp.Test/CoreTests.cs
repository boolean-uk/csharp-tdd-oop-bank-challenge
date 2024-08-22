using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Model;
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
        public void CreateCustomer()
        {

        }

        [Test]
        public void CreateSavingsAccount()
        {
            SavingsAccount s = new SavingsAccount("Test");
        }

        [Test]
        public void AddFundsTest() { }


        [Test]
        public void RemoveFundsTest() { }

    }
}