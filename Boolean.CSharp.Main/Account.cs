using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public abstract class Account
    {

        public virtual AccountType AccountType { get; }
        public TransactionType TransactionType { get; }
        public Transaction Transaction { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public Branch Branch { get; set; }

        public Account(Branch branch) { 
            this.Branch = branch; 
        }


        public decimal GetBalance() { 
            decimal deposit = Transactions.Where(t => t.TransactionType == TransactionType.Deposit).Sum(t => t.Amount);
            decimal withdraw = Transactions.Where(t => t.TransactionType == TransactionType.Withdraw).Sum(t => t.Amount);

            decimal balance = deposit - withdraw;
            return balance;
        }

        public bool Deposit(decimal amount, TransactionType transactionType)
        { 
            if (amount > 0)
            {
                Transaction transaction = new Transaction(amount, TransactionType.Deposit, GetBalance() + amount);
                Transactions.Add(transaction);
                return true;
            }

            return false;
        }


        public bool Withdraw(decimal amount, TransactionType transactionType)
        {
            if (amount > 0)
            {
                Transaction transaction = new Transaction(amount, TransactionType.Withdraw, GetBalance() - amount);
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