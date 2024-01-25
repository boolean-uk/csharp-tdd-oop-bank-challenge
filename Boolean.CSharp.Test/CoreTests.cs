using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountFolder;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreBankTests
    {
        [Test]
        public void TestDeposit()
        {
            Account savingsAccount = new SavingsAccount();
            Transactions transaction = new Transactions(200, TransactionTypes.Credit); 

            savingsAccount.Deposit(transaction);

            Assert.That(savingsAccount.GetBalance() == 200);
        }

        [Test]

        public void TestWithdraw() 
        {
            Account savingsAccount = new SavingsAccount();
            Transactions transaction = new Transactions(300, TransactionTypes.Credit);
            Transactions transaction2 = new Transactions(300, TransactionTypes.Debit);

            savingsAccount.Deposit(transaction);
            savingsAccount.Withdraw(transaction2);

            Assert.That(savingsAccount.GetBalance() == 0);
        }

        [Test]

        public void TestPrintStatement()
        {
            Account savingsAccount = new SavingsAccount();
            Transactions transaction = new Transactions(4000, TransactionTypes.Credit);
            Transactions transaction2 = new Transactions(2000, TransactionTypes.Debit);
            Transactions transaction3 = new Transactions(1000, TransactionTypes.Credit);
            Transactions transaction4 = new Transactions(3000, TransactionTypes.Debit);

            savingsAccount.Deposit(transaction);
            savingsAccount.Withdraw(transaction2);
            savingsAccount.Deposit(transaction3);
            savingsAccount.Withdraw(transaction4);

            savingsAccount.printStatement();

            Assert.Pass();
        }

        

        


        
        

    }
}