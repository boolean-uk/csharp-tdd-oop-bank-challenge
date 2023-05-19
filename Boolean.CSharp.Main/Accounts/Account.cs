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
        public decimal Balance { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
        }
        public  Transaction Deposit(DateTime date, decimal amount)
        {
            Balance += amount;
            var transaction = new Transaction(date, amount, Balance, TransactionType.Deposit);
            Transactions.Add( transaction );
            return transaction;
        }
        public  Transaction Withdraw(DateTime date, decimal amount)
        {
            if(Balance >= amount)
            {
                Balance -= amount;
                var transaction = new Transaction(date, amount, Balance, TransactionType.Withdraw);
                Transactions.Add( transaction );
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
