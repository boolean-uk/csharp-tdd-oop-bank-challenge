using Boolean.CSharp.Main;
using Boolean.CSharp.Main.BankAccounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using Boolean.CSharp.Main.IUsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class AccountTest
    {
        [Test]
        public void ChecksIfFundsWasDeposited()
        {
            Bank bank = new Bank();
            IUser customer = new Customer("Stavros", "1212121212");
            BankAccount currentAccount = new BankAccount(customer);

            bank.CreateAccount(currentAccount, AccountType.Current);
            Transaction transcaction1 = new Transaction(TransactionType.Credit, 1000, DateTime.Now);
            Transaction transcaction2 = new Transaction(TransactionType.Credit, 2000, DateTime.Now);

            Assert.AreEqual(currentAccount.DepositFunds(transcaction1), "Deposit has been made successfully");
            Assert.AreEqual(currentAccount.DepositFunds(transcaction2), "Deposit has been made successfully");
            Assert.AreEqual(currentAccount.ListOfTransactions.Count, 2);

        }

        [Test]
        public void ChecksIfFundsWasWitdrawed()
        {
            Bank bank = new Bank();
            IUser customer = new Customer("Stavros", "1212121212");
            BankAccount savingsAccount = new BankAccount(customer);

            bank.CreateAccount(savingsAccount, AccountType.Savings);
            Transaction transcaction1 = new Transaction(TransactionType.Credit, 1000, DateTime.Now);
            Transaction transcaction2 = new Transaction(TransactionType.Credit, 2000, DateTime.Now);
            Transaction transcaction3 = new Transaction(TransactionType.Debit, 500, DateTime.Now);
            savingsAccount.DepositFunds(transcaction1);
            savingsAccount.DepositFunds(transcaction2);

            Assert.AreEqual(savingsAccount.WithdrawFunds(transcaction3), "Withdrawal has been made successfully");
            Assert.AreEqual(savingsAccount.ListOfTransactions.Count, 3);

        }

        [Test]
        public void CalculateBalanceTest()
        {
            Bank bank = new Bank();
            IUser customer = new Customer("Stavros", "1212121212");
            BankAccount savingsAccount = new BankAccount(customer);

            bank.CreateAccount(savingsAccount, AccountType.Savings);
            Transaction transcaction1 = new Transaction(TransactionType.Credit, 1000, DateTime.Now);
            Transaction transcaction2 = new Transaction(TransactionType.Credit, 2000, DateTime.Now);
            Transaction transcaction3 = new Transaction(TransactionType.Debit, 500, DateTime.Now);
            savingsAccount.DepositFunds(transcaction1);
            savingsAccount.DepositFunds(transcaction2);
            savingsAccount.WithdrawFunds(transcaction3);

            Assert.AreEqual(savingsAccount.CalculateBalance(), 2500.00);
        }
    }
}
