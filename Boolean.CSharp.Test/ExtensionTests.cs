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
            Customer cus = new Customer("Seb", "Oslo");

            SavingsAccount sa = new SavingsAccount(cus);

            sa.makeTransaction("deposit", 1000);

            sa.makeTransaction("deposit", 500);
            sa.makeTransaction("withdraw", 500);
            sa.makeTransaction("withdraw", 500);
            sa.makeTransaction("deposit", 500);
            double balance = sa.getBalance();

            Assert.That(1000, Is.EqualTo(balance));

        }
        [Test]
        public void getBranch()
        {
            Customer customer = new Customer("Nigel", "London");

            SavingsAccount sa = new SavingsAccount(customer);


            Assert.That("London", Is.EqualTo(sa.Customer.branch));
        }
    }
}
