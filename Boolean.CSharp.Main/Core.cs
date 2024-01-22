using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{

    public enum AccountType
    {
        Current,
        Savings
    }
    public abstract class BankAccount
    {
        public string AccountNumber { get; }
        public AccountType Type { get; }
        public decimal Balance { get; protected set; }
        private List<Transaction> transactionHistory;



        public BankAccount(string accountNumber, AccountType type)
        {
            AccountNumber = accountNumber;
            Type = type;
            Balance = 0;
            transactionHistory = new List<Transaction>();
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount.");
                return;
            }

            Balance += amount;
            RecordTransaction(amount);
            Console.WriteLine($"Deposit of {amount:C} successful. Current balance: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                Console.WriteLine("Invalid withdrawal amount.");
                return;
            }

            Balance -= amount;
            RecordTransaction(-amount);
            Console.WriteLine($"Withdrawal of {amount:C} successful. Current balance: {Balance:C}");
        }

        public void PrintStatement()
        {
            Console.WriteLine($"{"Date",-12}||{"Credit",-12}||{"Debit",-12}||{"Balance",-12}");

            foreach (var transaction in transactionHistory)
            {
                string credit = transaction.Amount > 0 ? $"{transaction.Amount:C}" : "";
                string debit = transaction.Amount < 0 ? $"{-transaction.Amount:C}" : "";

                Console.WriteLine($"{transaction.Date:dd/MM/yyyy} || {credit,-12} || {debit,-12} || {transaction.Balance:C}");
            }
        }

        private void RecordTransaction(decimal amount)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Amount = amount,
                Balance = Balance
            };

            transactionHistory.Add(transaction);
        }


    }
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(string accountNumber) : base(accountNumber, AccountType.Current) { }
    }

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountNumber) : base(accountNumber, AccountType.Savings) { }
    }
}