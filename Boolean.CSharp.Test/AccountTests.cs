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
        private Account _user;
        private GeneralAccount _genAccount;
        private SavingsAccount _savingsAccount;

        [SetUp]
        public void SetUp()
        {
            _user = new Account();
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

        [TestCase(1000.0F, TransactionType.DEPOSIT, 1000.0F)]
        [TestCase(0.0F, TransactionType.DEPOSIT, 0.0F)]
        public void UserCanDepositMoney(float amount, TransactionType type, float newBalance)
        {
            IAccount acc = _user.createAccount(_genAccount);
            Transaction transaction = new Transaction(amount, type, acc.getBalance());

            acc.MakeTransaction(transaction);

            float balance = acc.getBalance();

            Assert.AreEqual(newBalance, balance);
           

        }

        [TestCase(1000.0F, TransactionType.WITHDRAW, 0.0F)]
        [TestCase(100.0F, TransactionType.WITHDRAW, 900.0F)]
        public void UserCanWithdrawMoney(float amount, TransactionType type, float newBalance)
        {
            IAccount acc = _user.createAccount(_genAccount);
            Transaction initTransaction = new Transaction(1000.0F, TransactionType.DEPOSIT, acc.getBalance());
            acc.MakeTransaction(initTransaction);

            Transaction transaction = new Transaction(amount, type, acc.getBalance());

            acc.MakeTransaction(transaction);

            float balance = acc.getBalance();

            Assert.AreEqual(newBalance, balance);

        }

    }
}