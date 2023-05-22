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
                        if (transaction.Type == TransactionType.Deposit)
                        {
                            balance += transaction.Amount;
                        }
                        else if (transaction.Type == TransactionType.Withdraw)
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
        }
        public Transaction Deposit(DateTime date, decimal amount)
        {
            var newBalance = Balance + amount;
            var transaction = new Transaction(date, amount, newBalance, TransactionType.Deposit);
            Transactions.Add(transaction);
            return transaction;
        }
        public Transaction Withdraw(DateTime date, decimal amount)
        {
            if (Balance >= amount)
            {
                var newBalance = Balance - amount;
                var transaction = new Transaction(date, amount, newBalance, TransactionType.Withdraw);
                Transactions.Add(transaction);
                return transaction;
            }
            else
            {
                throw new Exception("Insufficient balance");
            }

        }

        public List<Transaction> GenerateStatement()
        {
            return Transactions;
        }
    }
}
