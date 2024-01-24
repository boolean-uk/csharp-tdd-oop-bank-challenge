using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Transactions;
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
            Customer customer = new Customer("Sebastian", "Oslo");
            SavingsAccount account = new SavingsAccount(customer);

            var id = customer.CustomerId;

            Assert.That(id, Is.EqualTo(account.Customer.CustomerId));
        }
        [Test]
        public void createSavingsAccount()
        {
            Customer customer = new Customer("Sebastian", "Oslo");
            SavingsAccount account = new SavingsAccount(customer);

            var id = customer.CustomerId;

            Assert.That(id, Is.EqualTo(account.Customer.CustomerId));
        }

        [Test]
        public void depositFromCurrentAccount()
        {
            Customer customer = new Customer("Sebastian", "Oslo");
            CurrentAccount currentAccount = new CurrentAccount(customer);
            currentAccount.deposit(1000);
            double b = currentAccount.getBalance();

            Assert.That(b, Is.EqualTo(1000));
        }

        [Test]
        public void withdrawFromCurrentAccount()
        {
            Customer customer = new Customer("Sebastian", "Oslo");
            CurrentAccount currentAccount = new CurrentAccount(customer);
            currentAccount.deposit(1000);
            currentAccount.withdraw(1000);
            double b = currentAccount.getBalance();

            Assert.That(b, Is.EqualTo(1000));
        }

        [Test]
        public void depositFromSavingsAccount()
        {
            Customer customer = new Customer("Sebastian", "Oslo");
            SavingsAccount sa = new SavingsAccount(customer);
            sa.deposit(1000);
            double b = sa.getBalance();

            Assert.That(b, Is.EqualTo(1000));
        }

        [Test]
        public void withdrawFromSavingsAccount()
        {
            Customer customer = new Customer("Sebastian", "Oslo");
            SavingsAccount sa = new SavingsAccount(customer);
            sa.deposit(1000);
            sa.withdraw(1000);
            double b = sa.getBalance();

            Assert.That(b, Is.EqualTo(1000));
        }

        [Test]
        public void PrintBankStatement()
        {
            Customer customer = new Customer("Sebastian", "Oslo");
            CurrentAccount currentAccount = new CurrentAccount(customer);
            currentAccount.deposit(1000);
            currentAccount.withdraw(500);


            Assert.IsNotNull(currentAccount.printTransactions);
        }

        [Test]

        public void makeTransaction()
        {
            Customer customer = new Customer("Sebastian", "Oslo");
            CurrentAccount currentAccount = new CurrentAccount(customer);
            currentAccount.makeTransaction("deposit", 1000);
            currentAccount.makeTransaction("deposit", 500);

            

            Assert.That(b, Is.EqualTo(1000));

        }







    }
}