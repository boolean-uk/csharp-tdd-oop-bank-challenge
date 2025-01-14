using System.Security.Cryptography.X509Certificates;
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
        public void TestQuestion1()
        {
            CurrentAccount current = new CurrentAccount();
            Assert.That(current.AccountNumber, Is.TypeOf(Guid));

            current.Branch = Main.Enums.Branch.Bournemouth;
            current.Role = Console.Enums.Role.Customer;
        }

    }
}