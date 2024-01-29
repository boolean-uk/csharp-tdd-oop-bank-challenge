using Boolean.CSharp.Main;
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
        public void TestEngineerCalculateBalance()
        {
            Customer customer = new Customer();
            customer.CreateCurrentAccount(1);
            customer.Deposit(1, 100);
            customer.Deposit(1, 200);
            customer.Deposit(1, 300);
            customer.Deposit(1, 400);
            customer.Withdraw(1, 200);
            Engineer engineer = new Engineer();

            var result = engineer.CalculateBalance(customer.GetSpecifiedAccount(1));

            Assert.That(result, Is.EqualTo(800));
        }

        [Test]
        public void TestDefaultBranch()
        {
            Customer customer = new Customer();
            BankManager manager = new BankManager();
            customer.CreateCurrentAccount(1);

            var branch = manager.GetBranch(customer.GetSpecifiedAccount(1));

            Assert.That(branch, Is.EqualTo(Enums.Branches.Oslo));

        }

        [Test]
        public void TestChangedBranch()
        {
            Customer customer = new Customer();
            BankManager manager = new BankManager();
            customer.CreateCurrentAccount(1);
            manager.ChangeAccountBranch(customer.GetSpecifiedAccount(1), Enums.Branches.Trondheim);

            var branch = manager.GetBranch(customer.GetSpecifiedAccount(1));

            Assert.That(branch, Is.EqualTo(Enums.Branches.Trondheim));

        }
    }
}
