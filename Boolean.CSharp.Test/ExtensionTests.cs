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

            _currentAccount.Deposit(1000, new DateTime(2012, 1, 10));

            _currentAccount.Withdraw(500);
            _currentAccount.Withdraw(500);
            _currentAccount.Withdraw(500);


        }

        [Test]
        private void TestBalanceCalculation()
        {
            throw new NotImplementedException();
        }
        [Test]
        private void TestBranches()
        {
            throw new NotImplementedException();
        }
        [Test]
        private void TestOverdraft()
        {
            throw new NotImplementedException();
        }
        [Test]
        private void TestOverdraftRequestApprovalAndRejection()
        {
            throw new NotImplementedException();
        }
        [Test]
        private void TestStatementMessage()
        {
            throw new NotImplementedException();
        }
    }
}
