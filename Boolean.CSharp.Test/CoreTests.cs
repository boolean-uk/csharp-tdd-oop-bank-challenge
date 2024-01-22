using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Transaction transaction;

        /*public CoreTests()
        {
            _transaction = new Transaction();

        }
        */

        //trying to create transactions with different ammounts
        [TestCase(0.1f)]
        [TestCase(100.34f)]
        [TestCase(0.0f)]
        public void CanCreateInsertTransactions(float ammount)
        {
            Transaction transaction = new Transaction(ammount);
            Assert.AreEqual(ammount, transaction.ammount);
            Assert.AreEqual("insertion", transaction.ammount);
            Assert.AreEqual(DateTime.Now.ToString(), transaction.date);
        }

        //trying to create withdrawal transaction
        [TestCase(-5.0)]
        [TestCase(-500.05f)]
        public void CanCreateWithdrawTransactions(float ammount)
        {
            Transaction transaction = new Transaction(ammount);
            Assert.AreEqual(ammount, transaction.ammount);
            Assert.AreEqual("withdraw", transaction.ammount);
            Assert.AreEqual(DateTime.Now.ToString(), transaction.date);

        }

        //Testing functionality of current account
        [Test]
        public void BankAccountFunctionality() 
        {
            //Create account, and make sure all settings are default
            BankAccount bankAccount = new BankAccount();
            Assert.AreEqual(bankAccount.currentbalance = 0.0f);
            Assert.AreEqual(bankAccount.balanceList.Count, 1);
            Assert.AreEqual(bankAccount.transactionList.Count, 0);
            Assert.IsNotNull(bankAccount.accountID);

            //Make transaction with zero ammount
            bankAccount.MakeTransaction(0.0f);

            //Make sure the settings are still default
            //nothing should happen when try to make transaction with 
            // ammount of 0.0
            Assert.AreEqual(bankAccount.currentbalance = 0.0f);
            Assert.AreEqual(bankAccount.balanceList.Count, 1);
            Assert.AreEqual(bankAccount.transactionList.Count, 0);

            //Make negative transaction,
            //still nothing should happen, since there is no
            //possibility to have negative balance at the moment
            bankAccount.MakeTransaction(-10.0f);

            Assert.AreEqual(bankAccount.currentbalance = 0.0f);
            Assert.AreEqual(bankAccount.balanceList.Count, 1);
            Assert.AreEqual(bankAccount.transactionList.Count, 0);

            //Make insertion of 10.0 and see that everything is 
            //as ecpected
            bankAccount.MakeTransaction(10.0f);

            Assert.AreEqual(bankAccount.currentbalance = 10.0f);
            Assert.AreEqual(bankAccount.balanceList.Count, 2);
            Assert.AreEqual(bankAccount.balanceList[1], 10.0f);
            Assert.AreEqual(bankAccount.transactionList.Count, 1);
        }

        [Test]
        public void bankStatementTest()
        {
            
            BankAccount bankaccount = new BankAccount();

            
            myAccount.MakeTransaction(1000.0f); // Deposit
            myAccount.MakeTransaction(-500.0f); // Withdrawal
            myAccount.MakeTransaction(200);  // Deposit

            string expectedStatement =
                "date       || credit  || debit  || balance\n" +
                $"{DateTime.Now.ToString("dd/MM/yyyy")} || 1000.00 ||         || 1000.00\n" +
                $"{DateTime.Now.ToString("dd/MM/yyyy")} ||         || 500.00 || 500.00\n" +
                $"{DateTime.Now.ToString("dd/MM/yyyy")} || 200.00  ||         || 700.00";

            // Assert
            string actualStatement = bankaccount.GetBankStatement();
            Assert.AreEqual(expectedStatement, actualStatement);
        }

    }

}
