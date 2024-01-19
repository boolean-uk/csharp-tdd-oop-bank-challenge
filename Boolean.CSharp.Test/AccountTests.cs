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
        [TestCase(200.0F, TransactionType.DEPOSIT, 200.0F)]
        public void UserCanDepositMoney(float amount, TransactionType type, float newBalance)
        {
            IAccount acc = _user.createAccount(_genAccount);

            // float amount, TransactionType type, string date = null

            bool isSuccess = acc.MakeTransaction( amount , type , DateTime.Now.ToString());

            float balance = acc.getBalance();
            Assert.IsTrue(isSuccess);
            Assert.AreEqual(newBalance, balance);
            

            IAccount acc2 = _user.createAccount(_savingsAccount);
           
            bool isSuccess2 = acc2.MakeTransaction(amount, type, DateTime.Now.ToString());

            float balance2 = acc2.getBalance();
            Assert.AreEqual(newBalance, balance2);
            Assert.IsTrue(isSuccess2);


        }

        [TestCase(1000.0F, TransactionType.WITHDRAW, 0.0F)]
        [TestCase(100.0F, TransactionType.WITHDRAW, 900.0F)]
        public void UserCanWithdrawMoney(float amount, TransactionType type, float newBalance)
        {
            IAccount acc = _user.createAccount(_genAccount);

     
            bool initSuccess = acc.MakeTransaction(1000.0F, TransactionType.DEPOSIT, DateTime.Now.ToString());

            Assert.IsTrue(initSuccess);

            bool isSuccess = acc.MakeTransaction(amount, type, DateTime.Now.ToString());
            float balance = acc.getBalance();

            Assert.AreEqual(newBalance, balance);
            Assert.IsTrue(isSuccess);



            IAccount acc2 = _user.createAccount(_savingsAccount);
            bool isSuccess3 = acc2.MakeTransaction(1000.0F, TransactionType.DEPOSIT, DateTime.Now.ToString());

          
            bool isSuccess4 = acc2.MakeTransaction(amount, type, DateTime.Now.ToString());
            float balance2 = acc2.getBalance();

            Assert.IsTrue(isSuccess3);
            Assert.IsTrue(isSuccess4);
            Assert.AreEqual(newBalance, balance2);

        }

        [TestCase(1200.0F, TransactionType.WITHDRAW, 1000.0F)]
        public void userCantWithdrawIfBalanceGoesToNegative(float amount, TransactionType type, float newBalance)
        {
            IAccount acc = _user.createAccount(_genAccount);
            
            acc.MakeTransaction(1000.0F, TransactionType.DEPOSIT, DateTime.Now.ToString());

            bool isSuccess = acc.MakeTransaction(amount, type, DateTime.Now.ToString());
            float sum = acc.getBalance();

            Assert.False(isSuccess);
            Assert.AreEqual(sum, newBalance);
        }

        [Test]
        public void BankStatements()
        {

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);


            // here
            IAccount acc = _user.createAccount(_genAccount);
           
            acc.MakeTransaction(1000.0F, TransactionType.DEPOSIT, "10/01/2012");
            acc.MakeTransaction( 2000.0F, TransactionType.DEPOSIT, "13/01/2012");
            acc.MakeTransaction( 500.0F, TransactionType.WITHDRAW, "14/01/2012");

            acc.ListBankStatement();

            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.That("    date    || credit  || debit  || balance", Is.EqualTo(outputLines[0]));
            Assert.That(" 14/01/2012 ||         || 500,00 || 2500,00", Is.EqualTo(outputLines[1]));
            Assert.That(" 13/01/2012 || 2000,00 ||        || 3000,00", Is.EqualTo(outputLines[2]));
            Assert.That(" 10/01/2012 || 1000,00 ||        || 1000,00", Is.EqualTo(outputLines[3]));


        }

    }
}