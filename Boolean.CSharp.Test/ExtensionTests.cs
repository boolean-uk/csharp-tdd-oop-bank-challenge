using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountType;
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
        public Bank Bank { get; set; }
        public Customer Customer { get; set; }
        public Branch Branch { get; set; }
        [SetUp]
        public void SetUp()
        {
            Bank = new Bank();
            Branch = new Branch("Cooperations", Bank);
            new Branch("Cooperations", Bank);
            Bank.BranchList.Add(Branch);
            Customer = new Customer("John", Branch);
            Branch.CustomerList.Add(Customer);
        }

        [Test]
        public void BalanceUpdatedWhenDepositsAndWithdrawals()
        {
            IAccount account = Branch.CreateAccount(Customer, 's');
            Customer.Deposit(account, 100);     // 100
            Customer.Deposit(account, 200);     // 300
            Customer.Deposit(account, 300);     // 600
            Assert.AreEqual(account.balance, 600);
        }
        [Test]
<        public void RequestOverdraftPendingTest()
        {
            CurrentAccount account = (CurrentAccount) Branch.CreateAccount(Customer, 'c');
            CurrentAccount.RequestOverDraft();
            Assert.True(Branch.OverdraftRequests.Count == 1);
        }

        [Test]
        public void AcceptOverdraftTest()
        {
            CurrentAccount account = (CurrentAccount)Branch.CreateAccount(Customer, 'c');
            CurrentAccount.RequestOverDraft();
            Branch.AcceptOverdraft(account);
            Assert.True(account.lowerBalanceLimit == -500);
        }

        [Test]
        public void DenyOverdraftTest()
        {
            CurrentAccount account = (CurrentAccount)Branch.CreateAccount(Customer, 'c');
            CurrentAccount.RequestOverDraft();
            Branch.DenyOverdraft(account);
            Assert.True(account.lowerBalanceLimit == 0);
        }

        [Test]
        public void WithdrawFromOverdraftedAccountTest()
        {
            CurrentAccount account = (CurrentAccount)Branch.CreateAccount(Customer, 'c');
            CurrentAccount.RequestOverDraft();
            Branch.AcceptOverdraft(account);
            Customer.Withdraw(account, 300);
            Assert.AreEqual(account.balance, -300);
        }
    }
}
