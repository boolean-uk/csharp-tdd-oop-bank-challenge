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
            Bank bank = new Bank();
            Customer customer = new Customer(accounts, bank);

            Assert.That(customer.Accounts.Count, Is.EqualTo(2));
        }

        [Test]
        public void DepositFundTest()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Bank bank = new Bank();
            Customer customer = new Customer(accounts, bank);

            customer.DepositToAccount(0, 1000);

            Assert.That(customer.Accounts[0].Balance , Is.EqualTo(1000));
        }

        [Test]
        public void WithdrawFundTest()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Bank bank = new Bank();
            Customer customer = new Customer(accounts, bank);
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
            Bank bank = new Bank();
            Customer customer = new Customer(accounts, bank);
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
            Bank bank = new Bank();
            Customer customer = new Customer(accounts, bank);
            customer.DepositToAccount(0, 1000);
            customer.DepositToAccount(0, 2000);
            customer.WithdrawFromAccount(0, 500);
            customer.WithdrawFromAccount(0, 8.21m);
            customer.WithdrawFromAccount(0, 1001);
            customer.DepositToAccount(0, 30000);
            customer.DepositToAccount(0, 9.21m);
            customer.WithdrawFromAccount(0, 7000);

            Console.WriteLine(customer.SeeBankStatement(0));

            Assert.Pass();
        }
    }
}