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
            customer.CreateAccount(AccountType.Current);

            Assert.AreEqual(customer.accounts[0].AccountType, AccountType.Current);
            Assert.AreEqual(customer.accounts.Count(), 1);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Savings);
            customer.CreateAccount(AccountType.Savings);

            Assert.AreEqual(customer.accounts[0].AccountType, AccountType.Savings);
            Assert.AreEqual(customer.accounts.Count(), 2);
        }

        [Test]
        public void Deposit()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current);
            Account account = customer.accounts[0];

            account.Deposit(100, TransactionType.Deposit);
            account.Deposit(50, TransactionType.Deposit);

            var transactions = account.Transactions;

            Assert.AreEqual(transactions[0].Amount, 100);
            Assert.AreEqual(transactions[1].Balance, 100+50);

        }

        [Test]
        public void Withdraw()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Savings);
            Account account = customer.accounts[0];
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
            customer.CreateAccount(AccountType.Current);
            Account account = customer.accounts[0];
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

    }
}