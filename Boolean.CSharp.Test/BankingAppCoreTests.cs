using BankingApp.Boolean.CSharp.Main;
using BankingApp.Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System.Transactions;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankingAppCoreTests
    {
        private Core _core;

        public BankingAppCoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateCurrentAccountTest()
        {
            var account = new CurrentAccount();


            Assert.IsNotNull(account);
            Assert.AreEqual(0, account.Balance);


        }

        [Test]
        public void CreateSavingsAccountTest()
        {
            var account = new SavingAccount();

            Assert.IsNotNull(account);
            Assert.AreEqual(0, account.Balance);

        }

        [Test]
        public void BankStatementTest()
        {
            var account = new CurrentAccount();

            var bankStatement = account.GenerateStatement();

            Assert.IsNotNull(bankStatement);


        }
        [Test]
        public void PrintBankStatementTest()
        {
            Account account = new CurrentAccount();

            var deposit1 = account.Deposit(new DateTime(2012, 1, 10), 1000);
            var deposit2 = account.Deposit(new DateTime(2012, 1, 13), 2000);

            var withdrawal = account.Withdraw(new DateTime(2012, 1, 14), 500);

            var expectedValue = "date || credit || debit || balance \n" +
            $"{withdrawal.Date} ||  || {withdrawal.Amount} || {withdrawal.BalanceAfterTransaction}\n" +
            $"{deposit2.Date} || {deposit2.Amount} ||  || {deposit2.BalanceAfterTransaction}\n" +
            $"{deposit1.Date} || {deposit1.Amount} ||  || {deposit1.BalanceAfterTransaction}\n";

            var bankStatement = BankStatement.PrintStatement(account.Transactions);

            Assert.AreEqual(expectedValue, bankStatement);

            Assert.NotNull(account.Transactions);
            Assert.AreEqual(3, account.Transactions.Count);
        }

    }
}