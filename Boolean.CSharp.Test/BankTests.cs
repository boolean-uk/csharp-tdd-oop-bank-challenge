using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Bank.AccountTypes;
using Boolean.CSharp.Main.Bank;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {
        [SetUp]
        public void Setup()
        {
        }


        //1. As a customer, So I can safely store use my money, I want to create a current account.
        [Test]
        public void CanCreateCurrentAccountTest()
        { 
            Branch branch = new Branch();
            CurrentAccount currentAccount1 = new CurrentAccount("Current");
            
            bool hasBeenCreated = branch.CreateAccount(currentAccount1);

            Assert.That(hasBeenCreated, Is.True);

        }

        //2. As a customer, So I can save for a rainy day, I want to create a savings account.
        [Test]
        public void CanCreateSavingsAccountTest()
        {
            
        }

        //4. As a customer, So I can use my account, I want to deposit and withdraw funds.
        [Test]
        public void CanMakeDepositTest()
        {
            /*decimal depositAmount = 200.00M;
            CurrentAccount currentAccount = new CurrentAccount();

            bool hasMadeDeposit = currentAccount.MakeDeposit(depositAmount);

            Assert.That(hasMadeDeposit, Is.True);
            */
        }

        [Test]
        public void CanMakeWithdrawalTest()
        {
            /*decimal withdrawAmount = 200.00M;
            CurrentAccount currentAccount = new CurrentAccount() { Balance = 200.00M };

            bool hasMadeWithdrawal = currentAccount.MakeWithdrawal(withdrawAmount);

            Assert.That(hasMadeWithdrawal, Is.True);
            */
        }

        //3. As a customer, So I can keep a record of my finances, I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
        [Test]
        public void CanGenerateBankStatementTest()
        {

        }

        public void CanPrintBankStatementTest()
        {

        }


    }
}