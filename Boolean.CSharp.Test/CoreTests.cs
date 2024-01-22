using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Objects;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [TestCase("Current account 1")]
        public void CreateCurrentAccountTest(string accountName)
        {
            //arrange
            BankManager bankManager = new BankManager();

            //act
            bankManager.CreateCurrentAccount(accountName);
            

            //assert
            Assert.IsTrue(bankManager.Accounts.Count > 0);
            Assert.IsTrue(bankManager.Accounts[0].AccountType == "CurrentAccount");
        }

        [TestCase("Savings account 1")]
        public void CreateSavingsAccountTest(string accountName)
        {
            //arrange
            BankManager bankManager = new BankManager();

            //act
            bankManager.CreateSavingsAccount(accountName);


            //assert
            Assert.IsTrue(bankManager.Accounts.Count > 0);
            Assert.IsTrue(bankManager.Accounts[0].AccountType == "SavingsAccount");
        }

        [TestCase(1000, 500)]
        public void PrintBankStatementTest(int depositAmount, int withdrawAmount)
        {
            //arrange
            BankStatement bankStatement = new BankStatement();

            CurrentAccount account = new CurrentAccount("Current account 1");
            account.Deposit(depositAmount);
            account.Withdraw(withdrawAmount);

            //act
            account.PrintBankStatement();

            //assert
            Assert.AreEqual(account.AccountStatement.Transactions[0].Amount, depositAmount);
            Assert.AreEqual(account.AccountStatement.Transactions[1].Amount, withdrawAmount);

        }

        [TestCase(300)]
        public void DepositTest(double amount)
        {
            //arrange
            CurrentAccount account = new CurrentAccount("Current account 1");

            //act
            account.Deposit(amount);

            //assert
            Assert.AreEqual(300, account.Balance);
        }

        [TestCase(500)]
        public void WithdrawTest(double amount)
        {
            //arrange
            CurrentAccount account = new CurrentAccount("Current account 1");
            account.Deposit(700);

            //act
            account.Withdraw(500);

            //assert
            Assert.AreEqual(200, account.Balance);

        }
    }
}