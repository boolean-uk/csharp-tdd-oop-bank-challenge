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
    public class AccountTests
    {
        private User _user;
        private GeneralAccount _genAccount;
        private SavingsAccount _savingsAccount;

        [SetUp]
        public void SetUp()
        {
            _user = new User();
            _genAccount = new GeneralAccount();
            _savingsAccount = new SavingsAccount();
        }

        [Test]
        public void userCanCreateSavingsAndGeneralAccount()
        {
            IAccount acc = _user.createAccount(_genAccount);
            IAccount acc2 = _user.createAccount(_savingsAccount);

            Assert.IsNotNull(acc);
            Assert.IsNotNull(acc2);

            Assert.True(acc is GeneralAccount);
            Assert.True(acc2 is SavingsAccount);

            List<IAccount> res = _user.ListAccounts();

            Assert.AreEqual(2, res.Count);

        }

        [TestCase(1000.0, TransactionType.DEPOSIT, 1000.0)]
        [TestCase(100.0, TransactionType.WITHDRAW, 900.0)]
        public void UserCanDepositMoney(float amount, TransactionType type, float newBalance)
        {
            IAccount acc = _user.createAccount(_genAccount);
            Transaction transaction = new Transaction(amount, type);

            acc.DepositFund(transaction);

            float sum = acc.getBalance();

            Assert.AreEqual(newBalance, sum);
           

        }

        [TestCase(1000.0, TransactionType.DEPOSIT, 1000.0)]
        [TestCase(100.0, TransactionType.WITHDRAW, 900.0)]
        public void UserCanWithdrawMoney(float amount, TransactionType type, string newBalance)
        {
            IAccount acc = _user.createAccount(_genAccount);
            Transaction transaction = new Transaction(amount, type);

            acc.WithdrawFund(transaction);

            Assert.AreEqual(newBalance, sum);

        }

    }
}