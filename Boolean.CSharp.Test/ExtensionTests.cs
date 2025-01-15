using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
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
        private List<User> _users;
        private List<Account> _accounts;
        private List<OverdraftRequest> _overdraftRequests;
        private User _customerUser;
        private User _managerUser;
        private User _engineerUser;

        [SetUp]
        public void SetUp()
        {
            // Need to reset the BankData lists
            BankData.Users = new List<User>();
            BankData.Accounts = new List<Account>();
            BankData.Transactions = new List<Transaction>();

            _users = new List<User>();
            _accounts = new List<Account>();
            _overdraftRequests = new List<OverdraftRequest>();

            // Create and add users
            _customerUser = new User(Main.Enums.Role.Customer, "Bob");
            _managerUser = new User(Main.Enums.Role.Manager, "Jeff");
            _engineerUser = new User(Main.Enums.Role.Engineer, "Harold");

            _users.Add(_customerUser);
            _users.Add(_managerUser);
            _users.Add(_engineerUser);
        }

        [Test]
        public void TestCalculateFunds()
        {
            CurrentAccount currentAccount1 = _customerUser.CreateCurrentAccount("CurrentAccount1");
            currentAccount1.Deposit(240f);
            currentAccount1.Deposit(253240f);
            currentAccount1.Deposit(140f);
            currentAccount1.Deposit(2f);

            Assert.That(currentAccount1.CalculateFunds(), Is.EqualTo(240f + 253240f + 140f + 2f));
        }

        [Test]
        public void TestSetBranch()
        {
            CurrentAccount currentAccount1 = _customerUser.CreateCurrentAccount("CurrentAccount1");

            Assert.IsNull(currentAccount1.Branch);

            currentAccount1.SetBranch(Role.Manager, Branch.Trondheim);

            Assert.That(currentAccount1.Branch, Is.EqualTo(Branch.Trondheim));
        }

        [Test]
        public void TestRequestAndManageOverdraft()
        {
            float requestAmount = 200f;

            CurrentAccount currentAccount1 = _customerUser.CreateCurrentAccount("CurrentAccount1");

            currentAccount1.Withdraw(10f);
            Assert.That(currentAccount1.CalculateFunds(), Is.EqualTo(0f));

            currentAccount1.RequestOverdraft(requestAmount);
            Assert.That(currentAccount1.OverdraftAmount, Is.EqualTo(0f));

            currentAccount1.ManageOverdraftRequest(Role.Customer, true);
            Assert.That(currentAccount1.OverdraftAmount, Is.EqualTo(0f));

            currentAccount1.ManageOverdraftRequest(Role.Manager, true);
            Assert.That(currentAccount1.OverdraftAmount, Is.EqualTo(requestAmount));

            currentAccount1.Withdraw(50f);
            Assert.That(currentAccount1.CalculateFunds(), Is.EqualTo(-50f));
        }
    }
}
