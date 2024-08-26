using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private decimal _balance;

        public virtual AccountType AccountType { get; }
        public TransactionType TransactionType { get; }
        public Transaction Transaction { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public decimal Balance { get { return _balance; } set { _balance = value; } } 


        public bool Deposit(decimal amount, TransactionType transactionType)
        { 
            if (amount > 0)
            {
                Balance += amount;
                Transaction transaction = new Transaction(amount, Balance, transactionType);
                Transactions.Add(transaction);
                return true;
            }

            return false;
        }


        public bool Withdraw(decimal amount, TransactionType transactionType)
        {
            if (amount > 0)
            {
                Balance -= amount;
                Transaction transaction = new Transaction(amount, Balance, transactionType);
                Transactions.Add(transaction);
                return true;
            }
            return false;
        }


        public void GenerateBankStatement()
        {
            Console.WriteLine("{0,-10} || {1,-6} || {2,-6} || {3,-6}",
                    "date",
                   "credit",
                   "debit",
                   "balance"
             );

            foreach (Transaction transaction in Transactions)
            {
                decimal credit = 0;
                decimal debit = 0;

                if (transaction.TransactionType == TransactionType.Deposit)
                {
                    credit = transaction.Amount;
                }
                else if (transaction.TransactionType == TransactionType.Withdraw)
                {
                    debit = transaction.Amount;
                }

                Console.WriteLine("{0,-10} || {1,-6} || {2,-6} || {3,-6}",
                    transaction.Date,
                    credit,
                    debit,
                    transaction.Balance
                );

            }
        }
    }
}