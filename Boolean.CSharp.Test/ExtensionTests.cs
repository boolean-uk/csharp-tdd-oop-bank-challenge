using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Class;
using Boolean.CSharp.Main.Enums;
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
        private Account _currentAccount;
        private Account _savingAccount;


        [SetUp]
        public void SetUp()
        {
            _currentAccount = new CurrentAccount(Role.Customer);
            _savingAccount = new SavingAccount(Role.Customer);
        }

        [Test]
        public void TestBalanceCalculation()
        {

            _savingAccount.Deposit(5000);
            _savingAccount.Withdraw(500);
            _savingAccount.Deposit(1000);
            _savingAccount.Withdraw(3000);

            decimal balance = _savingAccount.CalculateBalance();

            Assert.That(balance, Is.EqualTo(2500));
            
        }
        [Test]
        public void TestBranches()
        {
            _savingAccount.Branch = Main.Enums.Branch.Oslo;

            Assert.That(_savingAccount.Branch, Is.TypeOf<Main.Enums.Branch>());
            Assert.That(_savingAccount.Branch, Is.EqualTo(Main.Enums.Branch.Oslo));
        }
        [Test]
        public void TestOverdraft()
        {
            OverdraftRequest request = new OverdraftRequest(_currentAccount);

            _currentAccount.Deposit(1000);
            bool approvedOverdraft = request.Overdraft(1500);

            Assert.That(approvedOverdraft, Is.True);
        }
        [Test]
        public void TestOverdraftRequestApprovalAndRejection()
        {
            throw new NotImplementedException();
        }
        [Test]
        public void TestStatementMessage()
        {
            throw new NotImplementedException();
        }
    }
}
