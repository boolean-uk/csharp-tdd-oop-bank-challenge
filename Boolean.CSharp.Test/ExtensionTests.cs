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
        public void CheckBalance()
        {
            Customer cus = new Customer("Seb");

            SavingsAccount sa = new SavingsAccount(cus);

            sa.deposit(1000);
            sa.deposit(1000);
            sa.withdraw(1000);
            sa.withdraw(1000);

            double balance = sa.getBalance();

            Assert.That(0, Is.EqualTo(balance));

        }
        [Test]
        public void getBranch()
        {
            Customer customer = new Customer("Nigel");

            SavingsAccount sa = new SavingsAccount(customer);
            sa.Branches = Main.Enums.Branches.Oslo;

            Assert.That("Oslo", Is.EqualTo(sa.Branches.ToString()));
        }
    }
}
