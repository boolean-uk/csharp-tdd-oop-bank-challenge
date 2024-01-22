using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class CoreAndExtensionTest
    {
        [Test]
        public void TestAccount()
        {
            var branch = new Branch(1 , "Branch Name" , "Branch Address" , "Branch SortCode");
            var account = new CurrentAccount(1 , branch);

            Assert.AreEqual(1 , account.GetId());
            Assert.AreEqual(branch , account.GetBranch());
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
        public void TestCurrentAccount()
        {
            var branch = new Branch(1 , "Branch Name" , "Branch Address" , "Branch SortCode");
            var account = new CurrentAccount(1 , branch);

            Assert.AreEqual(0 , account.OverdraftLimit);

            branch.AddAccount(account);
            branch.ApproveOverdraftRequest(1 , 500);
            Assert.AreEqual(500 , account.OverdraftLimit);
        }

        [Test]
        public void TestTransaction()
        {
            var transaction = new Transaction(DateTime.Now , 100 , 0);

            Assert.AreEqual(100 , transaction.Credit);
            Assert.AreEqual(0 , transaction.Debit);
        }

        [Test]
        public void TestBankStatement()
        {
            var transactions = new List<Transaction>
        {
            new Transaction(new DateTime(2024, 1, 10), 1000, 0),
            new Transaction(new DateTime(2024, 1, 13), 2000, 0),
            new Transaction(new DateTime(2024, 1, 14), 0, 500)
        };
            var bankStatement = new BankStatement(transactions);

            Assert.AreEqual(transactions , bankStatement.Transactions);
        }

        [Test]
        public void TestCustomer()
        {
            var branch = new Branch(1 , "Branch Name" , "Branch Address" , "Branch SortCode");
            var customer = new Customer();

            Assert.AreEqual(0 , customer.Accounts.Count);

            var currentAccount = customer.CreateCurrentAccount(branch);
            Assert.AreEqual(1 , customer.Accounts.Count);
            Assert.AreEqual(currentAccount , customer.Accounts[0]);

            var savingsAccount = customer.CreateSavingsAccount(branch);
            Assert.AreEqual(2 , customer.Accounts.Count);
            Assert.AreEqual(savingsAccount , customer.Accounts[1]);

            var bankStatement = customer.GenerateBankStatement(1);
            Assert.AreEqual(currentAccount.Transactions , bankStatement.Transactions);

            bankStatement = customer.GenerateBankStatement(3);
            Assert.IsNull(bankStatement);
        }

        [Test]
        public void TestBranch()
        {
            var branch = new Branch(1 , "Branch Name" , "Branch Address" , "Branch SortCode");

            Assert.AreEqual(1 , branch.Id);
            Assert.AreEqual("Branch Name" , branch.Name);
            Assert.AreEqual("Branch Address" , branch.Address);
            Assert.AreEqual("Branch SortCode" , branch.SortCode);
            Assert.AreEqual(0 , branch.Accounts.Count);

            var account = new CurrentAccount(1 , branch);
            Assert.IsTrue(branch.AddAccount(account));
            Assert.AreEqual(1 , branch.Accounts.Count);

            Assert.IsFalse(branch.AddAccount(null));
            Assert.AreEqual(1 , branch.Accounts.Count);

            Assert.IsTrue(branch.RemoveAccount(1));
            Assert.AreEqual(0 , branch.Accounts.Count);

            Assert.IsFalse(branch.RemoveAccount(1));
            Assert.AreEqual(0 , branch.Accounts.Count);

            branch.AddAccount(account);
            Assert.IsTrue(branch.ApproveOverdraftRequest(1 , 500));
            Assert.AreEqual(500 , account.OverdraftLimit);
        }
    }
}