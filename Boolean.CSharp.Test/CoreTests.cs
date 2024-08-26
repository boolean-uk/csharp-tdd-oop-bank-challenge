using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;
        private Bank _bank;
        private string _branchname;
        private Customer _customer;
        [SetUp]
        public void setup()
        {
            _core = new Core();
            _bank = new Bank();
            _branchname = "Main Branch";
            _customer = new Customer();
        }

        [Test]
        public void createCurrentAccountTest()
        {
            Account account = _bank.createCurrentAccount(_customer, _branchname);
            Assert.That(account.GetType() == typeof(CurrentAccount));
        }

        [Test]
        public void createSavingsAccountTest()
        {
            Account account = _bank.createSavingsAccount(_customer, _branchname);
            Assert.That(account.GetType() == typeof(SavingsAccount));
        }

        [Test]
        public void getTransactionHistoryTest()
        {
            Transactions tran1 = new Transactions();
            Transactions tran2 = new Transactions();
            Account ca = _bank.createCurrentAccount(_customer, _branchname);
            ca.transaction(tran1);
            ca.transaction(tran2);
            List<Transactions> transactions = ca.getTransactionHistory();
            Assert.That(transactions.Contains(tran1));
            Assert.That(transactions.Contains(tran2));
        }

        [Test]
        public void depositTest()
        {
            Account ca = _bank.createCurrentAccount(_customer, _branchname);
            Customer customer = new Customer();
            customer.deposit(70.0f, ca);
            Assert.That(ca.getBalance(), Is.EqualTo(70.0f));
        }

        [Test]
        public void withDrawTest()
        {
            Account ca = _bank.createCurrentAccount(_customer, _branchname);
            Customer customer = new Customer();
            customer.deposit(70.0f, ca);
            customer.withDraw(70.0f, ca);
            Assert.That(ca.getBalance(), Is.EqualTo(0.0f));
        }

        [Test]
        public void getBalanceTest()
        {
            Account ca = _bank.createCurrentAccount(_customer, _branchname);
            Customer customer = new Customer();
            customer.deposit(70.0f, ca);
            Assert.That(ca.getBalance(), Is.EqualTo(70.0f));
        }

        [TestCase("Branch1")]
        public void getBranchTest(string branch)
        {
            Account ca = _bank.createCurrentAccount(_customer, branch);
            Assert.That(ca.getBranch(), Is.EqualTo(branch));
        }

        [Test]
        public void requestOverDraftTest()
        {
            Account ca = _bank.createCurrentAccount(_customer, _branchname);
            _customer.requestOverDraft(ca);
            Assert.That(_bank.requests.Contains(ca));
        }

        [Test]
        public void rejectOverDraftTest()
        {
            CurrentAccount ca = (CurrentAccount)_bank.createCurrentAccount(_customer, _branchname);
            _customer.requestOverDraft(ca);
            _bank.rejectRequest(ca);
            Assert.That(_bank.requests.Count == 0);
            Assert.That(!ca.overDraft);
        }

        [Test]
        public void approveOverDraftTest()
        {
            CurrentAccount ca = (CurrentAccount)_bank.createCurrentAccount(_customer, _branchname);
            _customer.requestOverDraft(ca);
            _bank.approveRequest(ca);
            Assert.That(_bank.requests.Count == 0);
            Assert.That(ca.overDraft);
        }

        [Test]
        public void sendTransactionTest()
        {

        }

    }
}