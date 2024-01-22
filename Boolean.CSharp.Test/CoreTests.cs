using Boolean.CSharp.Main;
using NUnit.Framework;

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

        [Test]
        public void PrintBankStatementTest()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [TestCase(300)]
        public void DepositTest(int amount)
        {
            //arrange
            CurrentAccount account = new CurrentAccount("Current account 1");

            //act
            account.Deposit(amount);

            //assert
            Assert.AreEqual(300, account.Balance);
        }

        [TestCase(500)]
        public void WithdrawTest(int amount)
        {
            
            
        }
    }
}