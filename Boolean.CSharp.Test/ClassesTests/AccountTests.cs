using NUnit.Framework;
using System;
using Boolean.CSharp.Main.Classes;

namespace Boolean.CSharp.Tests
{
    [TestFixture]
    public class AccountTests
    {
        private Bank bank;
        private Customer customer;
        private Account savingsAccount;

        [SetUp]
        public void setUp()
        {
            bank = new Bank("Experis Bank", "Bergen Branch");
            customer = new Customer("Jone", "Hjorteland", "jonehjorteland@experis.no", "Vestre Strømkaien 13, 5008 Bergen", bank);
            savingsAccount = new Account("Savings", customer, "Bergen Branch");
        }

        [Test]
        public void accountCreationShouldInitializeCorrectly()
        {
            Assert.AreEqual("Savings", savingsAccount.AccountType);
            Assert.AreEqual(customer, savingsAccount.Owner);
            Assert.AreEqual("Bergen Branch", savingsAccount.Branch);
            Assert.AreEqual(0m, savingsAccount.Balance);
        }

        [Test]
        public void depositShouldIncreaseBalance()
        {
            savingsAccount.Deposit(1000m);
            Assert.AreEqual(1000m, savingsAccount.Balance);
        }

        [Test]
        public void depositShouldThrowExceptionForNegativeAmount()
        {
            var ex = Assert.Throws<ArgumentException>(() => savingsAccount.Deposit(-500m));
            Assert.That(ex.Message, Is.EqualTo("Deposit amount must be greater than zero."));
        }

        [Test]
        public void withdrawShouldDecreaseBalance()
        {
            savingsAccount.Deposit(1000m);
            savingsAccount.Withdraw(500m);
            Assert.AreEqual(500m, savingsAccount.GetBalance());
        }

        [Test]
        public void withdrawShouldThrowExceptionForInsufficientFunds()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => savingsAccount.Withdraw(500m));
            Assert.That(ex.Message, Is.EqualTo("Insufficient funds."));
        }

        [Test]
        public void withdrawShouldThrowExceptionForNegativeAmount()
        {
            var ex = Assert.Throws<ArgumentException>(() => savingsAccount.Withdraw(-200m));
            Assert.That(ex.Message, Is.EqualTo("Withdrawal amount must be greater than zero."));
        }

        [Test]
        public void accountTypeShouldThrowExceptionForInvalidAccountType()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Account("InvalidType", customer, "Branch"));
            Assert.That(ex.Message, Is.EqualTo("Account type must be either 'Current' or 'Savings'"));
        }
    }
}
