using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        
        [Test]
        public void AddCurrentAccountTest()
        {
            Bank bank = new Bank();
            string name = "joeri";
            AccountType accountType = AccountType.Current;
            bank.CreateAccount(name, accountType);
            Assert.AreEqual(1, bank.currentAccounts.Count);
        }

        [Test]
        public void AddSavingsAccountTest()
        {
            Bank bank = new Bank();
            string name = "joeri";
            AccountType accountType = AccountType.Saving;
            bank.CreateAccount(name, accountType);
            Assert.AreEqual(1, bank.savingsAccounts.Count);
        }

        [TestCase(300, TransactionType.deposit)]

        public void TransactionTest(decimal amount, TransactionType transactionType) 
        {
            Bank bank = new Bank();
            string name = "joeri";
            AccountType accountType = AccountType.Current;
            
            bank.CreateAccount(name, accountType);
            bank.AddTransaction(name, accountType, transactionType, amount);
            Assert.AreEqual(amount, bank.currentAccounts.FirstOrDefault(i => i._CustomerName == name)._balance);
        }
    }
}