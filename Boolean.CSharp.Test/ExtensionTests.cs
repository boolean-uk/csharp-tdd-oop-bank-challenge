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
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }
        [Test]
        public void CheckBranch()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Oslo);
            customer.CreateAccount(AccountType.Current, Branch.Bournemouth);
            customer.CreateAccount(AccountType.Current, Branch.Southampton);
            var accounts = customer.accounts;

            Assert.AreEqual(accounts[0].Branch, Branch.Oslo);
            Assert.AreEqual(accounts[1].Branch, Branch.Bournemouth);
            Assert.AreEqual(accounts[2].Branch, Branch.Southampton);
        }

        [Test]
        public void RequestOverdraft()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Oslo);
            var accounts = customer.accounts;

            customer.RequestOverdraft(accounts[0]);


            Assert.IsTrue(accounts[0].OverdraftRequestIsActive);
        }

        [Test]
        public void ApproveOverdraft()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Oslo);
            var account = customer.accounts[0];
            customer.RequestOverdraft(account);
            BankManager manager = new BankManager();

            manager.ApproveOverdraft(account, 500);

            account.Withdraw(400);

            Assert.IsFalse(account.OverdraftRequestIsActive);
            Assert.IsTrue(account.BalanceLimit == -500);
            Assert.AreEqual(account.GetBalance(), -400);
        }

        [Test]
        public void RejectOverdraft()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current, Branch.Oslo);
            var account = customer.accounts[0];
            customer.RequestOverdraft(account);
            BankManager manager = new BankManager();

            manager.RejectOverdraft(account);

            account.Withdraw(200);

            Assert.IsFalse(account.OverdraftRequestIsActive);
            Assert.IsTrue(account.BalanceLimit == 0);
            Assert.AreEqual(account.GetBalance(), 0);
        }
    }
}
