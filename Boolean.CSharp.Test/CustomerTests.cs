using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CustomerTests
    {
        Customer customer;
        Account account;

        [SetUp]
        public void SetUp()
        {
            customer = new();
            account = new("test");
            customer.Accounts.Add(account);
        }

        [Test]
        public void CreateSavingAcc()
        {
            Assert.That(customer.CreateSavingsAccount("Savings"), Is.EqualTo("Savings account Savings has been created"));
        }

        [Test]
        public void CantCreateDuplicateSavingAcc() 
        {
            customer.CreateSavingsAccount("Savings");
            Assert.That(customer.CreateSavingsAccount("Savings"), Is.EqualTo("Could not create account, Savings already exists"));
        }

        [Test]
        public void CreateCurrentAcc()
        {
            Assert.That(customer.CreateSavingsAccount("Current"), Is.EqualTo("Current account Current has been created"));
        }

        [Test]
        public void CantCreateDuplicateCurrentAcc()
        {
            customer.CreateSavingsAccount("Current");
            Assert.That(customer.CreateSavingsAccount("Current"), Is.EqualTo("Could not create account, Current already exists"));
        }

        [Test]
        public void Deposit() 
        {
            Assert.That(customer.Deposit("test",500), Is.EqualTo("500 deposited to test, new balance is 500"));
            Assert.That(customer.Accounts.Last().Balance, Is.EqualTo(500));
        }

        [Test]
        public void Withdraw()
        {
            customer.Deposit("test",500);
            Assert.That(customer.Withdraw("test",250), Is.EqualTo("250 withdrawn from test, new balance is 250"));
            Assert.That(customer.Accounts.Last().Balance, Is.EqualTo(250));
        }

        public void CantWithdrawLackingFunds()
        {
            customer.Deposit("test", 500);
            Assert.That(customer.Withdraw("test", 750), Is.EqualTo("Cannot withdraw from test, balance is less than withdrawal amount"));
            Assert.That(customer.Accounts.Last().Balance, Is.EqualTo(500));
        }
    }
}