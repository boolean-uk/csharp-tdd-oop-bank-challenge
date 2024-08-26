using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class CoreTests
    {
        [Test]
        public void shouldCreateCurrentAccount()
        {
            //SetUp
            Customer customer = new Customer("Kaja");

            //Execute
            IAccount result = customer.CreateAccount("Current");
            
            //Verify
            Assert.That(result.Type == "Current");
        }  
        
        [Test]
        public void shouldCreateSavingsAccount()
        {
            //SetUp
            Customer customer = new Customer("Kaja");

            //Execute
            IAccount result = customer.CreateAccount("Savings");

            //Verify
            Assert.That(result.Type == "Saving");
        }  
        
        [Test]
        public void shouldDepositIntoAccount()
        {
            //SetUp
            Customer customer = new Customer("Kaja");
            IAccount current = customer.CreateAccount("Current");
            IAccount savings = customer.CreateAccount("Savings");

            //Execute
            current.Deposit(1000);
            savings.Deposit(1000);


            //Verify

            Assert.IsTrue(1000 == current.Balance);
            Assert.IsTrue(1000 == savings.Balance);
        }  
        
        [Test]
        public void shouldWithDrawalFromAccount()
        {
            //SetUp
            Customer customer = new Customer("Kaja");
            IAccount current = customer.CreateAccount("Current");
            IAccount savings = customer.CreateAccount("Savings");
            current.Deposit(1000);
            savings.Deposit(1000);
            
            //Execute
            current.Withdraw(500);
            savings.Withdraw(300);


            //Verify
            Assert.IsTrue(500 == current.Balance);
            Assert.IsTrue(700 == savings.Balance);
        }  
        
        [Test]
        public void shouldGetTransactions()
        {
            //SetUp
            Customer customer = new Customer("Kaja");
            IAccount current = customer.CreateAccount("Current");
            IAccount savings = customer.CreateAccount("Savings");
            current.Deposit(1000);
            savings.Deposit(1000);
            current.Withdraw(500);
            savings.Withdraw(300);
            
            //Execute
            List<ITransaction> currentTransactions = current.GetTransactions();
            List<ITransaction> savingsTransactions = savings.GetTransactions();
            
            //Verify
            Assert.IsTrue(currentTransactions.Any(x => x.Amount == 1000 && x.Type == "Deposit" && x.BalanceAfterTransaction == 1000));
            Assert.IsTrue(currentTransactions.Any(x => x.Amount == 500 && x.Type == "Withdrawal" && x.BalanceAfterTransaction == 500));

            Assert.IsTrue(savingsTransactions.Any(x => x.Amount == 1000 && x.Type == "Deposit" && x.BalanceAfterTransaction == 1000));
            Assert.IsTrue(savingsTransactions.Any(x => x.Amount == 300 && x.Type == "Withdrawal" && x.BalanceAfterTransaction == 700));

        }


    }
}