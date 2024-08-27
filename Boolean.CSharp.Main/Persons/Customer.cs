using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.BankAccountClasses;
using Microsoft.VisualBasic;

namespace Boolean.CSharp.Main.Persons
{
    public class Customer : Person
    {
        public Customer(Bank bank, int id, string name) : base(bank, id, name)
        {

        }

        public void CreateAccount(string accountName)
        {
            Account account = new Account(accountName, ID);

            Bank.CreateAccount(account);
        }

        public void CreateSavingsAccount(string accountName)
        {
            SavingsAccount savingsAccount = new SavingsAccount(accountName, ID);

            Bank.CreateAccount(savingsAccount);
        }

        public void DepositToAccount(string accountName, decimal amount)
        {
            BankAccount depositToAccount = GetAccount(accountName);
            Transaction transaction = new Transaction(DateTime.Now.ToString("dd/MM/yyyy"), TransactionType.Deposit, amount);

            depositToAccount.Deposit(transaction);
        }
        public void WithdrawFromAccount(string accountName, decimal amount)
        {
            BankAccount depositToAccount = GetAccount(accountName);
            Transaction transaction = new Transaction(DateTime.Now.ToString("dd/MM/yyyy"), TransactionType.Withdraw, amount);

            depositToAccount.Withdraw(transaction);
        }

        public void GenerateBankStatement(string accountName)
        {
            BankAccount bankAccount = GetAccount(accountName);

            bankAccount.PrintBankStatement();
        }

        public BankAccount GetAccount(string accountName)
        {
            return Bank.GetAccount(accountName, ID);
        }
    }
}
