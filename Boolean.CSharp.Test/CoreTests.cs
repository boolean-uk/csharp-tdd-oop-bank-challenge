using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateCurrentAccountTest()
        {
            //arrange
            BankManager bankManager = new BankManager();
            AccountList accountList = new AccountList();

            //act
            bankManager.CreateCurrentAccount();
            

            //assert
            Assert.IsTrue(accountList.Accounts.Count > 0);
            Assert.IsTrue(accountList.Accounts[0].AccountType == "CurrentAccount");
        }

        [Test]
        public void CreateSavingsAccountTest()
        {
            //arrange

            //act


            //assert
            Assert.Fail();
        }

        [Test]
        public void PrintBankStatementTest()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [Test]
        public void WithdrawTest()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [Test] 
        public void DepositTest()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        

    }
}