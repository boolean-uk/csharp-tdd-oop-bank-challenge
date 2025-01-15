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
        public void CreateCurrentAccount()
        {
            Person person = new Customer();
            person.CreateCurrentAccount();
            Assert.That(person.GetCurrentAccount(), Is.Not.EqualTo(null));
        }
        [Test]
        public void CreateSavingsAccount()
        {
            Person person = new Customer();
            person.CreateSavingsAccount();
            Assert.That(person.GetSavingsAccount(), Is.Not.EqualTo(null));
        }
        [Test]
        public void GenerateBankStatements()
        {
            Iperson customer = new Customer();
            customer.CreateSavingsAccount();
            Iaccount SavingsAccount = customer.GetSavingsAccount();
            SavingsAccount.GenerateBankStatements();
            throw new NotImplementedException();
        }
        [Test]
        public void Deposit()
        {
            Customer customer = new Customer();
            customer.CreateCurrentAccount();
            Iaccount CurrentAccount = customer.GetCurrentAccount();
            CurrentAccount.Deposit(100);
            Assert.That(CurrentAccount.CalculateBalance(), Is.EqualTo(100));
        }
        [Test]
        public void Withdraw()
        {
            Customer customer = new Customer();
            customer.CreateCurrentAccount();
            Iaccount CurrentAccount = customer.GetCurrentAccount();
            CurrentAccount.Deposit(100);
            CurrentAccount.Withdraw(50);
            Assert.That(CurrentAccount.CalculateBalance(), Is.EqualTo(50));
        }
    }
}