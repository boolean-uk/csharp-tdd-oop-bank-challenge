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
            _customer = new Customer((ICustomer)_bank, _branchname);
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
            Account ca = _bank.createCurrentAccount(_customer, _branchname);
            Transactions tran1 = new Transactions(70f, ca);
            Transactions tran2 = new Transactions(59f, ca);
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
            _customer.deposit(70.0f, ca);
            Assert.That(ca.getBalance(), Is.EqualTo(70.0f));
        }

        [Test]
        public void withDrawTest()
        {
            Account ca = _bank.createCurrentAccount(_customer, _branchname);
            _customer.deposit(70.0f, ca);
            _customer.withDraw(70.0f, ca);
            Assert.That(ca.getBalance(), Is.EqualTo(0.0f));
        }

        [Test]
        public void getBalanceTest()
        {
            Account ca = _bank.createCurrentAccount(_customer, _branchname);
            _customer.deposit(70.0f, ca);
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
            IManager bankManager = (IManager)_bank;
            bankManager.rejectRequest(ca);
            Assert.That(_bank.requests.Count == 0);
            Assert.That(!ca.overDraft);
        }

        [Test]
        public void approveOverDraftTest()
        {
            CurrentAccount ca = (CurrentAccount)_bank.createCurrentAccount(_customer, _branchname);
            _customer.requestOverDraft(ca);
            IManager bankManager = (IManager)_bank;
            bankManager.approveRequest(ca);
            Assert.That(_bank.requests.Count == 0);
            Assert.That(ca.overDraft);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void overDraftTest(bool overdraft)
        {
            CurrentAccount ca = (CurrentAccount)_bank.createCurrentAccount(_customer, _branchname);
            ca.overDraft = overdraft;
            _customer.withDraw(50f, ca);
            //Console.WriteLine(ca.overDraft);
            Console.WriteLine(ca.getBalance() > 0f);
            Assert.That(ca.getBalance() == (-50f), Is.EqualTo(overdraft));
        }

    }
}