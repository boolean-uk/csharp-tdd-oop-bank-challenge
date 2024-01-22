using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Transations;
using Boolean.CSharp.Main.Users;
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
        public void createCurrentAccount()
        {
            Customer customer = new Customer("Sebastian");
            SavingsAccount account = new SavingsAccount(customer);

            var id = customer.CustomerId;

            Assert.That(id, Is.EqualTo(account.Customer.CustomerId));
        }
        [Test]
        public void createSavingsAccount()
        {
            Customer customer = new Customer("Sebastian");
            SavingsAccount account = new SavingsAccount(customer);

            var id = customer.CustomerId;

            Assert.That(id, Is.EqualTo(account.Customer.CustomerId));
        }

        [Test]
        public void depositFromCurrentAccount() 
        {
            Customer customer = new Customer("Sebastian");
            CurrentAccount currentAccount = new CurrentAccount(customer);
            currentAccount.deposit(1000);

            Assert.That(currentAccount.Balance, Is.EqualTo(1000));
        }

        [Test]
        public void withdrawFromCurrentAccount()
        {
            Customer customer = new Customer("Sebastian");
            CurrentAccount currentAccount = new CurrentAccount(customer);
            currentAccount.withdraw(1000);

            Assert.That(currentAccount.Balance, Is.EqualTo(1000));
        }

        [Test]
        public void getBankStatement()
        {
            Customer customer = new Customer("Sebastian");
            CurrentAccount currentAccount = new CurrentAccount(customer);
            BankTransaction bt = new BankTransaction();
            string s = bt.getTransations();
            string bs = "bankstatement";

            Assert.That(s, Is.EqualTo(bs));


        }





    }
}