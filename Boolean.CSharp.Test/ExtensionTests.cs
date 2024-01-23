using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
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
        public void CalculateTest()
        {
            //CurrentAccount currentAccount = new CurrentAccount("CurrentAccount1");
            Customer customer1 = new Customer();
            customer1.CreateCurrentAccount("Account1", Boolean.CSharp.Main.Enums.AccountBranch.Oslo);

            customer1._currentAccount.Deposit(1000.0D);

            Assert.AreEqual(customer1._currentAccount.Balance(), 1000);

        }


        [Test]
        public void OverdraftTest()
        {
            //CurrentAccount currentAccount = new CurrentAccount("CurrentAccount1");
            Customer customer1 = new Customer();
            customer1.CreateCurrentAccount("Account1", Boolean.CSharp.Main.Enums.AccountBranch.Oslo);
            Customer customer2 = new Customer();
            customer2.CreateCurrentAccount("Account2", Boolean.CSharp.Main.Enums.AccountBranch.Bergen);

            List<Account> accounts = new List<Account>();
            accounts.Add(customer1._currentAccount);
            accounts.Add(customer2._currentAccount);

            Manager manager = new Manager(accounts);
            

            customer1._currentAccount.Deposit(1000.0D);
            customer2._currentAccount.Deposit(9999.0D);

            manager.AutomaticOverdraft("yes");
            Assert.That(customer2._currentAccount.GetOverdraftStatus, Is.EqualTo(Enums.OverdraftStatus.Approved));
            manager.AutomaticOverdraft("no");
            Assert.That(customer2._currentAccount.GetOverdraftStatus, Is.EqualTo(Enums.OverdraftStatus.Rejected));
        }
    }
}
