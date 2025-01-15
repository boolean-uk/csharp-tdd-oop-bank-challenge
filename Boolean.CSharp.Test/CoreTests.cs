using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private List<User> _users;
        private List<Account> _accounts;
        private List<OverdraftRequest> _overdraftRequests;
        private User _customerUser;
        private User _managerUser;
        private User _engineerUser;

        [SetUp]
        public void SetUp()
        {
            // Need to reset the BankData lists
            BankData.Users = new List<User>();
            BankData.Accounts = new List<Account>();
            BankData.Transactions = new List<Transaction>();

            _users = new List<User>();
            _accounts = new List<Account>();
            _overdraftRequests = new List<OverdraftRequest>();

            // Create and add users
            _customerUser = new User(Main.Enums.Role.Customer, "Bob");
            _managerUser = new User(Main.Enums.Role.Manager, "Jeff");
            _engineerUser = new User(Main.Enums.Role.Engineer, "Harold");

            _users.Add(_customerUser);
            _users.Add(_managerUser);
            _users.Add(_engineerUser);
        }

        [Test]
        public void TestCreateCurrentAccount()
        {
            Account account = _customerUser.CreateCurrentAccount("CurrentAccount1");
            Assert.That(BankData.Accounts.Contains(account));
        }

        [Test]
        public void TestCreateSavingsAccount()
        {
            Account account = _customerUser.CreateCurrentAccount("SavingsAccount1");
            Assert.That(BankData.Accounts.Contains(account));
        }

        [Test]
        public void TestDeposit()
        {
            float deposit = 1000f;

            CurrentAccount account = _customerUser.CreateCurrentAccount("CurrentAccount1");
            account.Deposit(deposit);

            Assert.That(account.CalculateFunds(), Is.EqualTo(deposit));
        }

        [Test]
        public void TestWithdraw()
        {
            float deposit = 5000f;
            float withdraw = 1000f;

            CurrentAccount account = _customerUser.CreateCurrentAccount("CurrentAccount1");
            account.Deposit(deposit);

            Assert.That(account.CalculateFunds(), Is.EqualTo(deposit));

            account.Withdraw(withdraw);

            Assert.That(account.CalculateFunds(), Is.EqualTo(deposit - withdraw));
        }

        [Test]
        public void TestTransferTo()
        {
            float deposit = 500f;
            float transfer = 200f;
            float transferBack = 50f;

            CurrentAccount currentAccount1 = _customerUser.CreateCurrentAccount("CurrentAccount1");
            SavingsAccount savingsAccount1 = _customerUser.CreateSavingsAccount("SavingsAccount1");

            currentAccount1.Deposit(deposit);

            currentAccount1.TransferTo(savingsAccount1.AccountNumber, transfer);

            Assert.That(currentAccount1.CalculateFunds(), Is.EqualTo(deposit - transfer));
            Assert.That(savingsAccount1.CalculateFunds(), Is.EqualTo(transfer));

            savingsAccount1.TransferTo(currentAccount1.AccountNumber, transferBack);

            Assert.That(currentAccount1.CalculateFunds(), Is.EqualTo(deposit - transfer + transferBack));
            Assert.That(savingsAccount1.CalculateFunds(), Is.EqualTo(transfer - transferBack));
        }

        [Test]
        public void TestCalculateFunds()
        {
            CurrentAccount currentAccount1 = _customerUser.CreateCurrentAccount("CurrentAccount1");
            currentAccount1.Deposit(240f);
            currentAccount1.Deposit(253240f);
            currentAccount1.Deposit(140f);
            currentAccount1.Deposit(2f);

            Assert.That(currentAccount1.CalculateFunds(), Is.EqualTo(240f + 253240f + 140f + 2f));
        }

        [Test]
        public void TestSetBranch()
        {
            CurrentAccount currentAccount1 = _customerUser.CreateCurrentAccount("CurrentAccount1");

            Assert.IsNull(currentAccount1.Branch);

            currentAccount1.SetBranch(Role.Manager, Branch.Trondheim);

            Assert.That(currentAccount1.Branch, Is.EqualTo(Branch.Trondheim));
        }

        [Test]
        public void TestRequestAndManageOverdraft()
        {
            float requestAmount = 200f;

            CurrentAccount currentAccount1 = _customerUser.CreateCurrentAccount("CurrentAccount1");

            currentAccount1.Withdraw(10f);
            Assert.That(currentAccount1.CalculateFunds(), Is.EqualTo(0f));

            currentAccount1.RequestOverdraft(requestAmount);
            Assert.That(currentAccount1.OverdraftAmount, Is.EqualTo(0f));

            currentAccount1.ManageOverdraftRequest(Role.Customer, true);
            Assert.That(currentAccount1.OverdraftAmount, Is.EqualTo(0f));

            currentAccount1.ManageOverdraftRequest(Role.Manager, true);
            Assert.That(currentAccount1.OverdraftAmount, Is.EqualTo(requestAmount));

            currentAccount1.Withdraw(50f);
            Assert.That(currentAccount1.CalculateFunds(), Is.EqualTo(-50f));
        }
    }
}