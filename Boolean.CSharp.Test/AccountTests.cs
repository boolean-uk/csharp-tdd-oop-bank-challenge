using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        private Customer _user;

        [SetUp]
        public void SetUp()
        {
            _user = new Customer();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [Test]
        public void userCanCreateGeneralAccount()
        {
            IAccount acc = _user.addAccount(AccountType.GENERAL, "SPAIN");

            Assert.IsNotNull(acc);
   
            Assert.True(acc is GeneralAccount);

            List<IAccount> res = _user.ListAccounts();

            GeneralAccount ga = (GeneralAccount)res[0];

            Assert.AreEqual(ga.ACCTYPE, AccountType.GENERAL);
            Assert.AreEqual(ga.BRANCH, "SPAIN");

        }

        [Test]
        public void userCanCreateSavingsAccount()
        {
            IAccount acc2 = _user.addAccount(AccountType.SAVINGS, "SPAIN");

            Assert.IsNotNull(acc2);

            Assert.True(acc2 is SavingsAccount);

            List<IAccount> res = _user.ListAccounts();

            SavingsAccount sa = (SavingsAccount)res[0];

            Assert.AreEqual(sa.ACCTYPE, AccountType.SAVINGS);
            Assert.AreEqual(sa.BRANCH, "SPAIN");

        }

        [Test]
        public void userCanCreateMultipleAccounts()
        {
            IAccount acc = _user.addAccount(AccountType.GENERAL, "SPAIN");
            IAccount acc2 = _user.addAccount(AccountType.SAVINGS, "SPAIN");

            List<IAccount> res = _user.ListAccounts();

            Assert.AreEqual(2, res.Count);

        }

        [TestCase(1000.0F, 1000.0F)]
        [TestCase(0.0F, 0.0F)]
        [TestCase(200.0F, 200.0F)]
        public void UserCanDepositMoney(float amount, float newBalance)
        {
            IAccount acc = _user.addAccount(AccountType.GENERAL, "SPAIN");
            bool isSuccess = acc.Deposit(amount);

            float balance = acc.getBalance();
            Assert.IsTrue(isSuccess);
            Assert.AreEqual(newBalance, balance);

            IAccount acc2 = _user.addAccount(AccountType.SAVINGS, "SPAIN");
            bool isSuccess2 = acc2.Deposit(amount);

            float balance2 = acc2.getBalance();
            Assert.AreEqual(newBalance, balance2);
            Assert.IsTrue(isSuccess2);


        }

        [TestCase(1000.0F, 1000.0F)]
        [TestCase(0.0F, 0.0F)]
        [TestCase(200.0F, 200.0F)]
        public void transactionInfoIsCorrect(float amount, float newBalance)
        {
            IAccount acc = _user.addAccount(AccountType.GENERAL, "SPAIN");
            acc.Deposit(amount);

            List<IAccount> res = _user.ListAccounts();
            List<Transaction> tr = res[0].TRANSACTIONS;
            Assert.AreEqual(1, tr.Count);
            Assert.AreEqual(tr[0].Amount, amount);
            Assert.AreEqual(tr[0].TransactionType, TransactionType.DEPOSIT);
            Assert.AreEqual(tr[0].Balance, newBalance);
            Assert.AreEqual(DateOnly.FromDateTime(tr[0].DateTime).ToString(), DateOnly.FromDateTime(DateTime.Now).ToString());

        }

        [TestCase(1000.0F, 0.0F)]
        [TestCase(100.0F, 900.0F)]
        public void UserCanWithdrawMoney(float amount, float newBalance)
        {
            IAccount acc = _user.addAccount(AccountType.GENERAL, "SPAIN");
            bool initSuccess = acc.Deposit(1000.0F);

            Assert.IsTrue(initSuccess);

            bool isSuccess = acc.Withdraw(amount);
            float balance = acc.getBalance();

            Assert.AreEqual(newBalance, balance);
            Assert.IsTrue(isSuccess);



            IAccount acc2 = _user.addAccount(AccountType.SAVINGS, "SPAIN");
            bool isSuccess3 = acc2.Deposit(1000.0F);

            bool isSuccess4 = acc2.Withdraw(amount);
            float balance2 = acc2.getBalance();

            Assert.IsTrue(isSuccess3);
            Assert.IsTrue(isSuccess4);
            Assert.AreEqual(newBalance, balance2);

        }

        [TestCase(1200.0F, 1000.0F)]
        public void userCantWithdrawIfBalanceGoesToNegative(float amount, float newBalance)
        {
   
            IAccount acc = _user.addAccount(AccountType.GENERAL, "SPAIN");
            
            acc.Deposit(1000.0F);
           
            Exception ex = Assert.Throws<System.Exception>(() => acc.Withdraw(amount));
            Assert.That(ex.Message, Is.EqualTo("WITHDRAW DENIED!"));

            float sum = acc.getBalance();
            Assert.AreEqual(sum, newBalance);
        }

        [Test]
        public void BankStatements()
        {

            // here
            IAccount acc = _user.addAccount(AccountType.GENERAL, "SPAIN");
           
            acc.Deposit( 1000.0F, "10/01/2012");
            acc.Deposit( 2000.0F, "13/01/2012");
            acc.Withdraw( 500.0F, "14/01/2012");

            List<string> res = acc.ListBankStatement();

            
            Assert.That("    date    ||  credit ||  debit  || balance", Is.EqualTo(res[0]));
            Assert.That("  14/01/2012||         ||   500,00||  2500,00", Is.EqualTo(res[1]));
            Assert.That("  13/01/2012||  2000,00||         ||  3000,00", Is.EqualTo(res[2]));
            Assert.That("  10/01/2012||  1000,00||         ||  1000,00", Is.EqualTo(res[3]));

        }

        [Test]
        public void BankStatementsNoSetDates()
        {

            // here
            IAccount acc = _user.addAccount(AccountType.GENERAL, "SPAIN");

            acc.Deposit(100.0F);
            acc.Deposit(2000.0F);
            acc.Withdraw(500.0F);

            Manager.acceptOverdraft((GeneralAccount)acc, 2000.0F);

            acc.Withdraw(2000.0F);

            acc.Deposit(3000.0F);

            List<string> res = acc.ListBankStatement();


            Assert.That("    date    ||  credit ||  debit  || balance", Is.EqualTo(res[0]));
            Assert.That($"  {DateOnly.FromDateTime(DateTime.Now)}||  3000,00||         ||  2600,00", Is.EqualTo(res[1]));
            Assert.That($"  {DateOnly.FromDateTime(DateTime.Now)}||         ||  2000,00||  -400,00", Is.EqualTo(res[2]));
            Assert.That($"  {DateOnly.FromDateTime(DateTime.Now)}||         ||   500,00||  1600,00", Is.EqualTo(res[3]));
            Assert.That($"  {DateOnly.FromDateTime(DateTime.Now)}||  2000,00||         ||  2100,00", Is.EqualTo(res[4]));
            Assert.That($"  {DateOnly.FromDateTime(DateTime.Now)}||   100,00||         ||   100,00", Is.EqualTo(res[5]));

        }

    }
}