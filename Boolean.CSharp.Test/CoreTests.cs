using Boolean.CSharp.Main.Users;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        [Test]
        public void TestCreatingAccounts()
        {
            Customer customer = new Customer();

            customer.CreateSavingsAccount(1);
            customer.CreateCurrentAccount(2);

            Assert.IsNotNull(customer.GetSpecifiedAccount(1));
            Assert.IsNotNull(customer.GetSpecifiedAccount(2));
            Assert.That(customer.GetAllAccounts().Count, Is.EqualTo(2));
        }

        [Test]
        public void TestDepositingMoney()
        {
            Customer customer = new Customer();
            customer.CreateSavingsAccount(1);

            customer.Deposit(1, 1000);

            Assert.AreEqual(1000, customer.GetSpecifiedAccount(1).Balance);
        }

        [Test]
        public void TestWithdrawingMoney()
        {
            Customer customer = new Customer();
            customer.CreateSavingsAccount(1);

            customer.Deposit(1, 1000);
            customer.Withdraw(1, 500);

            Assert.AreEqual(500, customer.GetSpecifiedAccount(1).Balance);
        }

        [Test]
        public void TestTransactions()
        {
            Customer customer = new Customer();
            customer.CreateSavingsAccount(1);

            customer.Deposit(1, 1000);
            customer.Withdraw(1, 500);

            var account = customer.GetSpecifiedAccount(1);

            Assert.AreEqual(2, account.GetTransactions().Count);
            Assert.AreEqual(1000, account.GetTransactions()[0].Amount);
            Assert.AreEqual(-500, account.GetTransactions()[1].Amount);
            Console.WriteLine(account.GetTransactions()[1].TransactionDate);
        }

    }
}