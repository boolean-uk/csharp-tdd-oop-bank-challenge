using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Interface;
using Boolean.CSharp.Main.PersonType;
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
        public void CreateAccount()
        {
            Customer customer = new Customer("Axel");


            customer.CreateAccount("Checkings", "Axel Account");
            

            Assert.That(customer.GetAccountsCount, Is.GreaterThan(0));
        }


        [Test]
        public void DepositMoney()
        {
            Customer customer = new Customer("Axel");
            customer.CreateAccount("Checkings", "Axel Account");
            customer.Deposit(100, customer.GetAccount("Axel Account"));

            Assert.That(customer.GetAccount("Axel Account").accountBalance, Is.EqualTo(100));
        }
    }
}