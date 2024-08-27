using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Customer _customer;
             
        public CoreTests()
        {
            
        }

        [Test]
        public void CreateAccountsTest()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Customer customer = new Customer(accounts);

            Assert.That(customer.Accounts.Count, Is.EqualTo(2));
        }

        [Test]
        public void DepositFundTest()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Customer customer = new Customer(accounts);

            customer.DepositToAccount(0, 1000);

            Assert.That(customer.Accounts[0].Balance , Is.EqualTo(1000));
        }

        [Test]
        public void WithdrawFundTest()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Customer customer = new Customer(accounts);
            customer.DepositToAccount(0, 1000);

            customer.WithdrawFromAccount(0, 500);

            Assert.That(customer.Accounts[0].Balance, Is.EqualTo(500));
        }

        [Test]
        public void ShouldNotLetCustomerWithdrawMoreThanTheyHave()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Customer customer = new Customer(accounts);
            customer.DepositToAccount(0, 1000);

            string message = customer.WithdrawFromAccount(0, 2000);

            Assert.That(message, Is.EqualTo("Insufficent funds"));
        }

        [Test]
        public void BankStatementCheck()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Customer customer = new Customer(accounts);
            customer.DepositToAccount(0, 1000);
            customer.DepositToAccount(0, 2000);
            customer.WithdrawFromAccount(0, 500);

            Console.WriteLine(customer.SeeBankStatement(0));

            Assert.Pass();
        }
    }
}