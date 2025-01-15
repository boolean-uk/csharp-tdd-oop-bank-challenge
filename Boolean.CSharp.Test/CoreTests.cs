using System.Security.Principal;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        public Bank bank { get; set; }
        [SetUp]
        public void SetUp()
        {
            bank = new Bank();
        }

        [Test]
        public void CreateNewAccountOnExistingCustomerTest()
        {
            Customer customer = new Customer(1, "John", bank);
            bank.CustomerList.Add(customer);
            Account account = bank.CreateAccount(customer, "C");
            Assert.That(account, Is.EqualTo(customer.Account[0]));
            Assert.Equals(account.Type, CurrentAccount.Type);
        }

        [Test]
        public void createNewAccountOnNonExistingCustomerTest()
        {
            Customer customer = new Customer(1, "John", bank);
            Account account = bank.CreateAccount(customer, "S");
            Assert.That(account, Is.EqualTo(customer.Account[0]));
            Assert.Equals(account.Type, SavingsAccount.Type);
        }

        [Test]
        public void DepositAmountToSavingsAccountTest()
        {
            Customer customer = new Customer(1, "John", bank);
            bank.CustomerList.Add(customer);
            Account customerAccount = bank.CreateAccount(customer, "S");
            double depositBalance = customer.Deposit(customerAccount, 100);
            Assert.Equals(customerAccount.Balance, depositBalance);
        }

        [Test]
        public void WithDrawFromSavingsAccount()
        {
            Customer customer = new Customer(1, "John", bank);
            bank.CustomerList.Add(customer);
            Account customerAccount = bank.CreateAccount(customer, "S");
            customer.deposit(customerAccount, 100);
            double withdrawBalance = customer.Withdraw(customerAccount, 90);
            Assert.Equals(customerAccount.Balance, withdrawBalance);
        }


    }
}