using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void TestCalculateBalance()
        {
            User user = new User("Øystein", "Bjørkeng", "Åsaveien 7a");
            SavingsAccount account = new SavingsAccount(user);
            BankTransaction deposit = new BankTransaction(200.0m, TransactionType.Credit);

            account.Deposit(deposit);
            decimal actual = account.GetBalance();

            Assert.That(200.0m == actual);
        }

        [Test]
        public void TestAddBranch()
        {
            User user = new User("Øystein", "Bjørkeng", "Åsaveien 7a");
            SavingsAccount account = new SavingsAccount(user, Branch.EnglandsCalifornia);

            Assert.That(account.Branch == Branch.EnglandsCalifornia);
        }

        [Test]
        public void TestRequestOverdraft()
        {
            User user = new User("Øystein", "Bjørkeng", "Åsaveien 7a");
            SavingsAccount account = new SavingsAccount(user, Branch.EnglandsCalifornia);
            var output = account.RequestOverDraft(1000.0m);

            Assert.That(account.OverDraftRequests.Count() > 0);
            Assert.That(output == "Successfully applied for overdraft");
        }

        [Test]
        public void TestApproveOverdraft()
        {
            User user = new User("Øystein", "Bjørkeng", "Åsaveien 7a");
            CurrentAccount account = new CurrentAccount(user, Branch.EnglandsCalifornia);
            account.RequestOverDraft(1000.0m);

            account.HandleOverDraftRequest(1, OverDraftRequestStatus.Approved);
            var filter = account.OverDraftRequests.Where(x => x.Status == OverDraftRequestStatus.Approved);
            Assert.That(filter.Count() > 0);
        }

        [Test]
        public void TestRejectOverdraft()
        {
            User user = new User("Øystein", "Bjørkeng", "Åsaveien 7a");
            CurrentAccount account = new CurrentAccount(user, Branch.EnglandsCalifornia);
            account.RequestOverDraft(1000.0m);

            account.HandleOverDraftRequest(1, OverDraftRequestStatus.Denied);
            var filter = account.OverDraftRequests.Where(x => x.Status == OverDraftRequestStatus.Denied);

            Assert.That(filter.Count() > 0);
        }

        [Test]
        public void TestOverdraftAccount()
        {
            User user = new User("Øystein", "Bjørkeng", "Åsaveien 7a");
            CurrentAccount account = new CurrentAccount(user, Branch.EnglandsCalifornia);
            account.RequestOverDraft(1000.0m);

            account.HandleOverDraftRequest(1, OverDraftRequestStatus.Approved);
            BankTransaction withdraw = new BankTransaction(1000.0m, TransactionType.Debit);
            account.Withdraw(withdraw);

            Assert.That(account.GetOverdraftBalance() == 1000.0m);
        }
    }
}
