using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTest
    {
        [Test]
        public void TestAccount()
        {
            var account = new CurrentAccount(1);

            Assert.AreEqual(1 , account.Id);
            Assert.AreEqual(0 , account.ViewBalance());
            Assert.AreEqual(0 , account.Transactions.Count);

            Assert.IsTrue(account.Deposit(100));
            Assert.AreEqual(100 , account.ViewBalance());

            Assert.IsFalse(account.Deposit(-50));
            Assert.AreEqual(100 , account.ViewBalance());

            Assert.IsTrue(account.Withdraw(50));
            Assert.AreEqual(50 , account.ViewBalance());

            Assert.IsFalse(account.Withdraw(60));
            Assert.AreEqual(50 , account.ViewBalance());

            Assert.IsFalse(account.Withdraw(-10));
            Assert.AreEqual(50 , account.ViewBalance());
        }

        [Test]
        public void TestTransaction()
        {
            var transaction = new Transaction(DateTime.Now , 100 , 0 , 100);

            Assert.AreEqual(100 , transaction.Credit);
            Assert.AreEqual(0 , transaction.Debit);
            Assert.AreEqual(100 , transaction.BalanceAfterTransaction);
        }

        [Test]
        public void TestBankStatement()
        {
            var transactions = new List<Transaction>
        {
            new Transaction(new DateTime(2024, 1, 10), 1000, 0, 1000),
            new Transaction(new DateTime(2024, 1, 13), 2000, 0, 3000),
            new Transaction(new DateTime(2024, 1, 14), 0, 500, 2500)
        };
            var bankStatement = new BankStatement(transactions);

            Assert.AreEqual(transactions , bankStatement.Transactions);
        }

        [Test]
        public void TestCustomer()
        {
            var customer = new Customer();

            Assert.AreEqual(0 , customer.Accounts.Count);

            var currentAccount = customer.CreateCurrentAccount();
            Assert.AreEqual(1 , customer.Accounts.Count);
            Assert.AreEqual(currentAccount , customer.Accounts[0]);

            var savingsAccount = customer.CreateSavingsAccount();
            Assert.AreEqual(2 , customer.Accounts.Count);
            Assert.AreEqual(savingsAccount , customer.Accounts[1]);

            var bankStatement = customer.GenerateBankStatement(1);
            Assert.AreEqual(currentAccount.Transactions , bankStatement.Transactions);
        }
    }
}