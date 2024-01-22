using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Transaction transaction;
        private BankAccount BankAccount;
        private CurrentAccount CurrentAccount;
        private SavingsAccount SavingsAccount;

        //trying to create deposit transactions with different ammounts
        [TestCase(0.1f)]
        [TestCase(100.34f)]
        [TestCase(0.0f)]
        public void CanCreateTransactions(float ammount)
        {
            Transaction transaction = new Transaction(ammount);
            Assert.AreEqual(ammount, transaction.ammount);
            Assert.AreEqual("Deposit", transaction.transactionType);
            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), transaction.date);
        }

        //trying to create withdrawal transactions
        [TestCase(-5.0f)]
        [TestCase(-500.05f)]
        public void CanCreateWithdrawTransactions(float ammount)
        {
            Transaction transaction = new Transaction(ammount);
            Assert.AreEqual(ammount, transaction.ammount);
            Assert.AreEqual("Withdraw", transaction.transactionType);
            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), transaction.date);

        }

        
        //Testing functionality of BankAccount
        [Test]
        public void BankAccountFunctionality() 
        {
            //Create account, and make sure all settings are default
            BankAccount bankAccount = new BankAccount();

            Assert.AreEqual(bankAccount.currentBalance, 0.0f);
            Assert.AreEqual(bankAccount.balanceList.Count, 0);
            Assert.AreEqual(bankAccount.transactionsList.Count, 0);
            Assert.IsNotNull(bankAccount.AccountID);

            
            //Make transaction with zero ammount
            bankAccount.MakeTransaction(0.0f);

            //Make sure the settings are still default
            //nothing should happen when try to make transaction with 
            // ammount of 0.0
            Assert.AreEqual(bankAccount.currentBalance, 0.0f);
            Assert.AreEqual(bankAccount.balanceList.Count, 0);
            Assert.AreEqual(bankAccount.transactionsList.Count, 0);
            
            //Make negative transaction,
            //still nothing should happen, since there is no
            //possibility to have negative balance at the moment
            bankAccount.MakeTransaction(-10.0f);
            
            Assert.AreEqual(bankAccount.currentBalance, 0.0f);
            Assert.AreEqual(bankAccount.balanceList.Count, 0);
            Assert.AreEqual(bankAccount.transactionsList.Count, 0);
            
            //Make insertion of 10.0 and see that everything is 
            //as ecpected
            bankAccount.MakeTransaction(10.0f);

            Assert.AreEqual(bankAccount.currentBalance, 10.0f);
            Assert.AreEqual(bankAccount.balanceList.Count, 1);
            Assert.AreEqual(bankAccount.balanceList[0], 10.0f);
            Assert.AreEqual(bankAccount.transactionsList.Count, 1);
            
        }
        
        [Test]
        //Test the bankStatementMethod
        public void bankStatementTest()
        {

            BankAccount bankAccount = new BankAccount();

            //Expected outputs
            string expectedString1000 = "\nDate: 22/01/2024|| TransactionType: Deposit: 1000|| Balance: 1000";

            string expectedString500 = "\nDate: 22/01/2024|| TransactionType: Withdraw: -500|| Balance: 500";

            
            bankAccount.MakeTransaction(1000.0f); // Deposit

            Assert.AreEqual(expectedString1000, bankAccount.getBankStatement());

            bankAccount.MakeTransaction(-500.0f); // Withdrawal

            Assert.AreEqual((expectedString1000 + expectedString500), bankAccount.getBankStatement());

            bankAccount.MakeTransaction(-1000.0f); // Withdrawal over limit

            //should stay the same
            Assert.AreEqual((expectedString1000 + expectedString500), bankAccount.getBankStatement());
        }

        //Not to much functionality to test on the classes currentAccount
        //& SavingsAccount
        [Test]
        public void CurrentAccountTest()
        {
            CurrentAccount currentAccount = new CurrentAccount();
            Assert.AreEqual(currentAccount.accountType, "CurrentAccount");
        }

        [Test]
        public void SavingsAccountTest()
        {
            SavingsAccount savingsaccount = new SavingsAccount();
            Assert.AreEqual(savingsaccount.accountType, "SavingsAccount");
        }

    }

}
