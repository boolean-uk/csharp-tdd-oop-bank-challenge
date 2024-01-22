using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTest
    {
        private IAccount account;
        [SetUp]
        public void SetUp()
        {
            account = new Account(Main.AccountType.Current,Main.Branch.First,"test");
        }
        [Test]
        public void CreateSavingsAccount() { }
        [Test]
        public void GetStatements() { }
        [Test]
        public void Deposit() { }
        [Test]
        public void Withdraw() { }
    }
}
