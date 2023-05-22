using BankingApp.Boolean.CSharp.Main.Overdraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        public List<Transaction> Transactions { get; set; }
        public decimal Balance
        {
            get
            {
                {
                    decimal balance = 0;
                    foreach (var transaction in Transactions.OrderBy(x=> x.Date))
                    {
                        if (transaction.TransactionType == Enums.Deposit)
                        {
                            balance += transaction.Amount;
                        }
                        else if (transaction.TransactionType == Enums.Withdraw)
                        {
                            balance -= transaction.Amount;
                        }
                            
                    }
                    return balance;

                }
            }
        }

        public Account()
        {
            Transactions = new List<Transaction>();
            OverdraftHistory = new OverdraftHistory();
        }
        public Transaction Deposit(DateTime date, decimal amount)
        {
            var newBalance = Balance + amount;
            var transaction = new Transaction(date, amount, newBalance, Enums.Deposit);
            Transactions.Add(transaction);
            return transaction;
        }
        public Transaction Withdraw(DateTime date, decimal amount)
        {
            if (Balance >= amount)
            {
                var newBalance = Balance - amount;
                var transaction = new Transaction(date, amount, newBalance, Enums.Withdraw);
                Transactions.Add(transaction);
                return transaction;
            }
            else
            {
                throw new Exception("Insufficient balance");
            }

        }
        public Branch Branch { get; set; }
        public List<Transaction> GenerateStatement()
        {
            return Transactions;
        }

        public decimal OverdraftLimit { get; set; } = 0;
        public OverdraftHistory OverdraftHistory { get;}
    }
}
