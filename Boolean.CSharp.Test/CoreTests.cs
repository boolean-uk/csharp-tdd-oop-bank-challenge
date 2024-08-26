using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Security.Principal;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateCurrentAccount()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Trondheim);

            Assert.AreEqual(customer.Accounts[0].AccountType, AccountType.Current);
            Assert.AreEqual(customer.Accounts.Count(), 1);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Savings, Branch.Trondheim);
            customer.CreateAccount(AccountType.Savings, Branch.Oslo);

            Assert.AreEqual(customer.Accounts[0].AccountType, AccountType.Savings);
            Assert.AreEqual(customer.Accounts.Count(), 2);
        }

        [Test]
        public void Deposit()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Trondheim);
            Account account = customer.Accounts[0];

            account.Deposit(100, TransactionType.Deposit);
            account.Deposit(50, TransactionType.Deposit);

            var transactions = account.Transactions;

            Assert.AreEqual(transactions[0].Amount, 100);
            Assert.AreEqual(transactions[1].Balance, 100 + 50);

        }

        [Test]
        public void Withdraw()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Savings, Branch.Trondheim);
            Account account = customer.Accounts[0];
            account.Deposit(100, TransactionType.Deposit);

            account.Withdraw(50, TransactionType.Withdraw);
            var transactions = account.Transactions;

            Assert.AreEqual(transactions[1].Amount, 50);
            Assert.AreEqual(transactions[1].Balance, 100 - 50);
        }

        [Test]
        public void GenerateBankStatement()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Trondheim);
            Account account = customer.Accounts[0];
            account.Deposit(1000, TransactionType.Deposit);
            account.Deposit(2000, TransactionType.Deposit);
            account.Withdraw(500, TransactionType.Withdraw);

            // use stringwriter to convert console output to string
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                account.GenerateBankStatement();
                string output = stringWriter.ToString();

                Assert.IsTrue(output.Contains("date       || credit || debit  || balance"));
                Assert.IsTrue(output.Contains("|| 0      || 500    || 2500"));
            }
        }

        [Test]
        public void BranchTest()
        {
            Customer customer1 = new Customer();
            customer1.CreateAccount(AccountType.Current, Branch.Trondheim);
            customer1.CreateAccount(AccountType.Current, Branch.Bergen);
            Account account = customer1.Accounts[0];
            Account account2 = customer1.Accounts[1];

            Assert.AreEqual(account.Branch, Branch.Trondheim);
            Assert.AreEqual(account2.Branch, Branch.Bergen);
        }

        [Test]
        public void RequestOverdraft()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Trondheim);
            Account account = customer.Accounts[0];
            customer.RequestOverdraft(account);

            Assert.That(account.OverdraftActive, Is.True);
        }

        [Test]
        public void ApproveOverdraft()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Trondheim);
            Account account = customer.Accounts[0];
            customer.RequestOverdraft(account);
            Manager manager = new Manager();

            manager.ApproveOverdraft(account, 200); // customer can withdraw 200 under 0
            account.Withdraw(100, TransactionType.Withdraw); // customer is within approved amount

            Assert.That(account.OverdraftActive, Is.False);
            Assert.That(account.BalanceCapacity == -200, Is.True);
            Assert.That(account.GetBalance() == -100, Is.True);
        }

        [Test]
        public void RejectOverdraft()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Oslo);
            var account = customer.Accounts[0];
            customer.RequestOverdraft(account);
            Manager manager = new Manager();

            manager.RejectOverdraft(account);

            account.Withdraw(200, TransactionType.Withdraw);

            Assert.IsFalse(account.OverdraftActive);
            Assert.IsTrue(account.BalanceCapacity == 0);
            Assert.AreEqual(account.GetBalance(), 0);
        }
    }
}
