using System.Security.Principal;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountTypes;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Tests
    {

        private Customer _customer;
        private BankManager _bankManager;
        [SetUp]
        public void Setup()
        {
            _customer = new Customer("1234", "Bob");
            _bankManager = new BankManager("9999", "Chief");
        }
        [Test]
        public void CreateCurrentAccount()
        {
            CurrentAccount account = new CurrentAccount("account", Branch.Oslo);
            _customer.AddAccount(account);
            Assert.That(_customer.Accounts.Count, Is.EqualTo(1));
            Assert.IsInstanceOf<CurrentAccount>(_customer.Accounts[0]);
        }
        [Test]
        public void CreateSavingAccount()
        {
            SavingAccount account = new SavingAccount("account", Branch.Oslo);
            _customer.AddAccount(account);
            Assert.That(_customer.Accounts.Count, Is.EqualTo(1));
            Assert.IsInstanceOf<SavingAccount>(_customer.Accounts[0]);
        }

        [Test]
        public void DepositAndWithdrawFromAccount()
        {
            CurrentAccount account = new CurrentAccount("account", Branch.Oslo);
            _customer.AddAccount(account);

            account.Deposit(1000m);
            var balance = account.CalculateBalance();

            Assert.That(balance, Is.EqualTo(1000m));

            account.Withdraw(500m);
            balance = account.CalculateBalance();
           
            Assert.That(balance, Is.EqualTo(500m));
        }

        [Test]
        public void AccountBranch()
        {
            SavingAccount account = new SavingAccount("oslo", Branch.Oslo);
            _customer.AddAccount(account);
            CurrentAccount account2 = new CurrentAccount("london", Branch.London);
            _customer.AddAccount(account2);

            Assert.That(account.Branch, Is.EqualTo(Branch.Oslo));
            Assert.That(account2.Branch, Is.EqualTo(Branch.London));
        }  

        [Test]
        public void OverdraftRequestApproved()
        {
            CurrentAccount account = new CurrentAccount("london", Branch.London);
            _customer.AddAccount(account);

            var request = _customer.RequestOverdraft(account, 1000m);

            Assert.That(request.RequestStatus, Is.EqualTo(RequestStatus.Pending));
            
            _bankManager.HandleOverdraftRequest(request, true);
            Assert.That(request.RequestStatus, Is.EqualTo(RequestStatus.Approved));
            Assert.That(account.OverdraftLimit, Is.EqualTo(1000m));
        }

        [Test]
        public void OverdraftRequestRejected()
        {
            CurrentAccount account = new CurrentAccount("london", Branch.London);
            _customer.AddAccount(account);

            var request = _customer.RequestOverdraft(account, 1000m);

            Assert.That(request.RequestStatus, Is.EqualTo(RequestStatus.Pending));

            _bankManager.HandleOverdraftRequest(request, false);
            Assert.That(request.RequestStatus, Is.EqualTo(RequestStatus.Rejected));
            Assert.That(account.OverdraftLimit, Is.EqualTo(0m));
        }

    }
}