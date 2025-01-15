using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class BankTests
    {



        [Test]

        public void checkIfRegularAccountCreated()
        {
            //Arrange
            Bank bank = new Bank();
            RegularAccount account = new RegularAccount();
            string accountHolder = "Jonh Johnson";
            string type = "Regular";

            //Act
            account.Create(type, accountHolder);
            var accountToCheck = Bank.accounts.FirstOrDefault(x => x.AccountHolderName == accountHolder);

            //Assert
            Assert.IsTrue(Bank.accounts.Contains(accountToCheck));
            Bank.accounts.Remove(accountToCheck);

        }



        [Test]
        public void checkIfSavingsAccountCreated()
        {

            //Arrange 
            Bank bank = new Bank();
            SavingsAccount Saccount = new SavingsAccount();
            string accountHolder = "Mike Smith";
            string type = "Savings";

            //Act
            Saccount.Create(type, accountHolder);
            var account = Bank.accounts.FirstOrDefault(x => x.AccountHolderName == accountHolder);

            //Assert
            Assert.IsTrue(Bank.accounts.Contains(account));
            Bank.accounts.Remove(account);

        }

        [Test]

        public void checkIfDeposited()
        {

            Bank bank = new Bank();
            bank.bankName = "Min Bank 1";
            Bank.accounts = new List<IAccount>();

            RegularAccount account = new RegularAccount();
            string receiver = "John Johnson";
            decimal amount = 500m;

            account.Create("Regular", receiver);
            Bank.accounts.Add(account);

            // Act
            account.deposit(amount, receiver);

            // Assert
            decimal balance = account.balance(receiver);
            Assert.AreEqual(amount, balance);
            Bank.accounts.Remove(account);

        }


        [Test]

        public void checkIfDepositedSavings()
        {

            Bank bank = new Bank();
            bank.bankName = "Min Bank 1";
            Bank.accounts = new List<IAccount>();

            SavingsAccount account = new SavingsAccount();
            string receiver = "John Johnson";
            decimal amount = 500m;

            account.Create("Savings", receiver);
            Bank.accounts.Add(account);

            // Act
            account.deposit(amount, receiver);

            // Assert
            decimal balance = account.balance(receiver);
            Assert.AreEqual(amount, balance);
            Bank.accounts.Remove(account);

        }


        [Test]
        public void CheckIfWithdrawnSavings()
        {
            // Arrange
            Bank bank = new Bank();
            bank.bankName = "Min Bank 1";
            Bank.accounts = new List<IAccount>();

            SavingsAccount account = new SavingsAccount();
            string receiver = "John Johnson";
            decimal depositAmount = 1000m;
            decimal withdrawAmount = 500m;

            account.Create("Savings", receiver);
            Bank.accounts.Add(account);

            // Act
            account.deposit(depositAmount, receiver);
            bool withdrawResult = account.withdraw(withdrawAmount, receiver);

            // Assert
            Assert.IsTrue(withdrawResult);
            decimal balance = account.balance(receiver);
            Assert.AreEqual(depositAmount - withdrawAmount, balance);

            Bank.accounts.Remove(account);
        }

        [Test]

        public void CheckIfWithdrawn()
        {
            // Arrange
            Bank bank = new Bank();
            bank.bankName = "Min Bank 1";
            Bank.accounts = new List<IAccount>();

            RegularAccount account = new RegularAccount();
            string receiver = "John Johnson";
            decimal depositAmount = 1000m;
            decimal withdrawAmount = 500m;

            account.Create("Regular", receiver);
            Bank.accounts.Add(account);

            // Act
            account.deposit(depositAmount, receiver);
            bool withdrawResult = account.withdraw(withdrawAmount, receiver);

            // Assert
            Assert.IsTrue(withdrawResult);
            decimal balance = account.balance(receiver);
            Assert.AreEqual(depositAmount - withdrawAmount, balance);

            Bank.accounts.Remove(account);
        }

        [Test]

        public void checkIfRegularBalanceCorrect()
        {

            //Arrange
            Bank bank = new Bank();
            bank.bankName = "Min Bank 1";
            Bank.accounts = new List<IAccount>();

            RegularAccount account = new RegularAccount();
            string receiver = "John Johnson";
            account.Create("Regular", receiver);
            Bank.accounts.Add(account);
            account.deposit(100, receiver);
            account.deposit(100, receiver);

            decimal expectedBalance = 200;
            Assert.AreEqual(expectedBalance, account.balance(receiver));
            Bank.accounts.Remove(account);
        }




        [Test]

        public void checkIfSavingsBalanceCorrect()
        {

            //Arrange
            Bank bank = new Bank();
            bank.bankName = "Min Bank 1";
            Bank.accounts = new List<IAccount>();

            SavingsAccount account = new SavingsAccount();
            string receiver = "John Johnson";
            account.Create("Savings", receiver);
            Bank.accounts.Add(account);
            account.deposit(100, receiver);
            account.deposit(100, receiver);

            decimal expectedBalance = 200;
            Assert.AreEqual(expectedBalance, account.balance(receiver));
            Bank.accounts.Remove(account);
        }


        [Test]

        public void checkIfBranchCorrect()
        {
            //Arrange
            Bank bank = new Bank();
            RuralBranch branch = new RuralBranch();
            branch.accounts = new List<IAccount>();
            bank.bankName = "Min Bank 1";
            Bank.accounts = new List<IAccount>();

            SavingsAccount account = new SavingsAccount();
            string receiver = "John Johnson";
            account.Create("Savings", receiver);
            Bank.accounts.Add(account);
            branch.accounts.Add(account);


            Assert.IsTrue(branch.accounts.Contains(account));
            Bank.accounts.Remove(account);


        }

        [Test]

        public void checkIfRequestHandled()
        {
            // Arrange
            Bank bank = new Bank();
            bank.bankName = "Min Bank 1";

            // Clear static collections to ensure test isolation
            Bank.accounts = new List<IAccount>();
            Bank.requestQueue = new List<Request>();

            RegularAccount account = new RegularAccount();
            string receiver = "Alan Wake";
            account.Create("Regular", receiver);
            Bank.accounts.Add(account);
            decimal amountToIncrease = 100m;



            // Act
            bool overdraftRequested = account.RequestOverdraft(receiver, "Medical needs", amountToIncrease);
            bool requestHandled = bank.handleRequest(receiver, true);



            RegularAccount accountAfterRequestHandled = Bank.accounts?.OfType<RegularAccount>().FirstOrDefault(x => x.AccountHolderName == receiver);
            Assert.IsTrue(accountAfterRequestHandled.overdrafted);
            Assert.AreEqual(accountAfterRequestHandled.overdraftedAmount,amountToIncrease);

            Bank.accounts.Remove(account);
            
        }

    }
}



