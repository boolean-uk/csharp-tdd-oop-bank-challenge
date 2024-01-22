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
        private UserAccount _userAccount;
        private Bank _bank;

        private Management _management;

        [SetUp]
        public void Setup()
        {
            _management = new Management();
            _bank = new Bank();
            _userAccount = UserAccount.CreateAccount("John", "Current", "London");
        }


        [Test]
        public void Deposit_WhenCalled_DepositsAmount()
        {
            _bank.Deposit("John", "Current", "London", 200);
            Assert.AreEqual(200, _bank.GetBalance("John", "Current", "London"));
        }

        [Test]
        public void Withdraw_WhenCalled_WithdrawsAmount()
        {
            _bank.Deposit("John", "Current", "London", 200);
            _bank.Withdraw("John", "Current", "London", 100);
            Assert.AreEqual(100, _bank.GetBalance("John", "Current", "London"));
        }

        [Test]
        public void WithdrawsAmount()
        {
            _bank.Deposit("John", "Current", "London", 200);
            _bank.Withdraw("John", "Current", "London", 300);
            Assert.AreEqual(-100, _bank.GetBalance("John", "Current", "London"));
        }

        [Test]
        public void DoesNotWithdrawAmount()
        {
            _bank.Deposit("John", "Current", "London", 200);
            _bank.Withdraw("John", "Current", "London", 1300);
            Assert.AreEqual(200, _bank.GetBalance("John", "Current", "London"));
        }

        [Test]
        public void OverDraftLimit_WhenCalled_ReturnsTrue()
        {
            Assert.IsTrue(_management.OverDraftLimit(100));
        }

        [Test]

        public void GetUserAccount_WhenCalled_ReturnsUserAccount()
        {
            Assert.AreEqual(_userAccount, UserAccount.GetAccount("John", "Current", "London"));
        }
        
        [Test]
        public void GetUserAccount_WhenCalled_ReturnsNull()
        {
            Assert.IsNull(UserAccount.GetAccount("John", "Current", "Manchester"));
        }

       }
}
