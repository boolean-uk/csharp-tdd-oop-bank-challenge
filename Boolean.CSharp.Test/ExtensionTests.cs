using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Core;
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
        private CurrentAccount current;
        private SavingsAccount saving;

        [SetUp]
        public void SetUp()
        {
            current = new CurrentAccount();
            saving = new SavingsAccount(Branch.Lancashire);

        }

        [Test]
        public void BalanceOfEmptyAccountIs0()
        {
            Assert.That(saving.Savings(), Is.EqualTo(0d));
        }

        [Test]
        public void CumulativeDeposit()
        {
            saving.Deposit(15000);
            saving.Deposit(20000);
            Assert.That(saving.Savings(), Is.EqualTo(35000));
        }

        [Test]
        public void BankBranchTest()
        {
            Assert.That(saving.Branch, Is.EqualTo(Branch.Lancashire));
            Assert.That(current.Branch, Is.EqualTo(Branch.Yorkshire));
        }

        [Test]
        public void OverdraftRequest()
        {
            Assert.That(saving.RequestOverdraft(), Is.True);
            Assert.That(saving.Overdraft, Is.EqualTo(OverdraftStatus.Requested));
        }

        [Test]
        public void AcceptOverdraft()
        {
            current.RequestOverdraft();
            Assert.That(current.AcceptOverdraft(), Is.True);
            Assert.That(current.Withdraw(50d), Is.True);
        }

        [Test]
        public void RejectOverdraft() {
            current.RequestOverdraft();
            Assert.That(current.RejectOverdraft(), Is.True);
            Assert.That(current.Withdraw(50d), Is.False);
        }

        [Test]
        public void RejectWrongAccount()
        {
            current.RequestOverdraft();
            Assert.That(saving.RejectOverdraft(), Is.False);
        }
    }
}
