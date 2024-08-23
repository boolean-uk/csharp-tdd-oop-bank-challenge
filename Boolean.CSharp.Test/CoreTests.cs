using Boolean.CSharp.Main;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using System.Transactions;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {


        public CoreTests()
        {


        }

        [Test]
        public void CreateCurrentAccount()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current);
            customer.CreateAccount(AccountType.Current);

            Assert.AreEqual(customer.accounts[0].Type, AccountType.Current);
            Assert.AreEqual(customer.accounts[1].GetBalance(), 0m);
            Assert.IsTrue(customer.accounts.Count() == 2);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Savings);
            customer.CreateAccount(AccountType.Savings);
            customer.CreateAccount(AccountType.Savings);

            Assert.AreEqual(customer.accounts[0].Type, AccountType.Savings);
            Assert.AreEqual(customer.accounts[1].GetBalance(), 0m);
            Assert.IsTrue(customer.accounts.Count() == 3);
        }

        [Test]
        public void Deposit()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Savings);
            IAccount account = customer.accounts[0];

            account.Deposit(50);
            account.Deposit(3000);

            var transactions = account.Transactions;

            Assert.AreEqual(transactions[0].Amount, 50);
            Assert.AreEqual(transactions[1].Type, TransactionType.Deposit);
            Assert.IsTrue(account.GetBalance() == 3050);
        }

        [Test]
        public void Withdraw()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current);
            IAccount account = customer.accounts[0];

            account.Deposit(5000);
            account.Withdraw(3000);

            var transactions = account.Transactions;

            Assert.AreEqual(transactions[1].Amount, 3000);
            Assert.AreEqual(transactions[1].Type, TransactionType.Withdraw);
            Assert.IsTrue(account.GetBalance() == 2000);
        }

        [Test]
        public void IllegalWithdraw()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current);
            IAccount account = customer.accounts[0];

            bool withdraw = account.Withdraw(3000);

            Assert.IsFalse(withdraw);
        }

        [Test]
        public void IllegalDeposit()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current);
            IAccount account = customer.accounts[0];

            bool deposit = account.Deposit(-1000);

            Assert.IsFalse(deposit);
        }


        [Test]
        public void GenerateStatement()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current);
            IAccount account = customer.accounts[0];

            account.Deposit(5000);
            account.Withdraw(3000);

            account.GenerateStatement(); //For visual testing in test log

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                account.GenerateStatement();
                string output = stringWriter.ToString();

                Assert.IsTrue(output.Contains("date         || credit   || debit    || balance "));
                Assert.IsTrue(output.Contains("|| 5000     ||          || 5000    "));
                Assert.IsTrue(output.Contains("||          || 3000     || 2000    "));
            }
        }
    }
}