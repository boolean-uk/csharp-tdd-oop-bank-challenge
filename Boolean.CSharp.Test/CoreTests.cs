using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CustomerCreateCurrentAccount()
        {
            Customer c = new Customer(1, "Elsa");
            Current account = new Current();
            c.AddAccount(account);

            Assert.That(c.Accounts, Is.Not.Null);
        }
        [Test]
        public void CustomerCreateSavingsAccount()
        {
            Customer c = new Customer(1, "Elsa");
            Savings account = new Savings();
            c.AddAccount(account);

            Assert.That(c.Accounts, Is.Not.Null);
        }
        [Test]
        public void DepositMoneyToAccount()
        {
            Customer c = new Customer(1, "Elsa");
            Savings account = new Savings(120.0d);
            c.AddAccount(account);

            account.deposit(50d);
            Assert.That(account.Balance, Is.EqualTo(170.0d));
        }
        [Test]
        public void WithDrawMoneyFromAccount()
        {
            Customer c = new Customer(1, "Elsa");
            Current account = new Current(120.0d);
            c.AddAccount(account);

            account.withDraw(20d);
            Assert.That(account.Balance, Is.EqualTo(100.0d));
        }

    }
}