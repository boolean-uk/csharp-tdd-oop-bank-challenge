using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Bank.AccountTypes;
using Boolean.CSharp.Main.Bank;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

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
            
            bool hasBeenCreated = branch.AddAccount(currentAccount1);

            Assert.That(hasBeenCreated, Is.True);

        }

        //2. As a customer, So I can save for a rainy day, I want to create a savings account.
        [Test]
        public void CanCreateSavingsAccountTest()
        {
            Branch branch = new Branch();
            SavingsAccount savingsaccount1 = new SavingsAccount("Savings");

            bool hasBeenCreated = branch.AddAccount(savingsaccount1);

            Assert.That(hasBeenCreated, Is.True);
        }

        //4. As a customer, So I can use my account, I want to deposit and withdraw funds.
        [Test]
        public void CanMakeDepositTest()
        {
            decimal depositAmount = 200.00M;
            CurrentAccount currentAccount = new CurrentAccount("Current");

            bool hasMadeDeposit = currentAccount.MakeDeposit(depositAmount);

            Assert.That(hasMadeDeposit, Is.True);
            
        }

        [Test]
        public void CanMakeWithdrawalTest()
        {
            decimal withdrawAmount = 200.00M;
            CurrentAccount currentAccount = new CurrentAccount("Current");
            currentAccount.MakeDeposit(300.00M);

            bool hasMadeWithdrawal = currentAccount.MakeWithdrawal(withdrawAmount);

            Assert.That(hasMadeWithdrawal, Is.True);
            
        }

        //3. As a customer, So I can keep a record of my finances, I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
        [Test]
        public void CanGenerateBankStatementTest()
        {
            Branch branch = new Branch();
            CurrentAccount currentAccount = new CurrentAccount("Current");
            branch.AddAccount(currentAccount);
            List<Transaction> bankStatement = currentAccount.MyTransactions;

            currentAccount.MakeDeposit(1000.00M);
            Assert.That(bankStatement.Count, Is.EqualTo(1));
            Assert.That(bankStatement.First().Amount, Is.EqualTo(1000.00M));
            Assert.That(bankStatement.First().Date, !Is.Null);
            Assert.That(bankStatement.First().Balance, Is.EqualTo(1000.00M));

            currentAccount.MakeDeposit(2000.00M);
            bankStatement = currentAccount.MyTransactions;
            Assert.That(bankStatement.Count, Is.EqualTo(2));

            currentAccount.MakeWithdrawal(500.00M);
            bankStatement = currentAccount.MyTransactions;
            Assert.That(bankStatement.Count, Is.EqualTo(3));

            decimal expectedbalance = 2500.00M;
            Assert.That(bankStatement.Last().Balance == expectedbalance);
            
        }

        [Test]
        public void CanPrintBankStatementTest()
        {
            Branch branch = new Branch();
            CurrentAccount currentAccount = new CurrentAccount("Current");
            branch.AddAccount(currentAccount);
            List<Transaction> bankStatement = currentAccount.MyTransactions;

            currentAccount.MakeDeposit(1000.00M);
            currentAccount.MakeDeposit(2000.00M);
            currentAccount.MakeWithdrawal(500.00M);

            string printBankStatement = currentAccount.PrintBankStatement;

            Assert.That(printBankStatement, Does.Contain("|| date                   || credit    || debit     || balance  "));
           
        }


    }
}