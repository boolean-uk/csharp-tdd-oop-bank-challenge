using Boolean.CSharp.Main;
using Boolean.CSharp.Main.extra;
using Boolean.CSharp.Main.src.account;
using Boolean.CSharp.Main.src.transaction;
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
        CurrentAccount current;
        SavingsAccount savings;

        [SetUp]
        public void SetUp()
        {
            current = new CurrentAccount(Branch.Copenhagen);
            savings = new SavingsAccount(Branch.Oslo);
        }

        [Test]
        public void TestBalance()
        {
            savings.Deposit(34);
            savings.Deposit(54);
            savings.Withdraw(3);

            Assert.That(savings.GetBalance(), Is.EqualTo(85));
        }

        [Test]
        public void BranchShouldBeOslo()
        {
            Assert.That(savings.Branch, Is.EqualTo(Branch.Oslo));
        }

        [Test]
        public void TestOverdraft()
        {
            current.Deposit(500);
            bool w1 = current.Withdraw(1000);
            Overdraft overdraft = new Overdraft(1000);
            current.RequestOverdraft(overdraft);
            bool w2 = current.Withdraw(1000);
            overdraft.Approve();
            bool w3 = current.Withdraw(1000);
            bool w4 = current.Withdraw(1000);

            Assert.That(w1, Is.False);
            Assert.That(w2 , Is.False);
            Assert.That(w3 , Is.True);
            Assert.That(w4 , Is.False);
            Assert.That(current.GetBalance(), Is.EqualTo(-500));
        }
    }
}
