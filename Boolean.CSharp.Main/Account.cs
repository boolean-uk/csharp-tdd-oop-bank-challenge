using System;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        protected decimal balance;
        protected List<Transaction> transactions;

        public Account()
        {
            balance = 0;
            transactions = new List<Transaction>();
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            balance += amount;
            transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Amount = amount,
                Balance = balance,
                IsDeposit = true
            });
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            balance -= amount;
            transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Amount = amount,
                Balance = balance,
                IsDeposit = false
            });
        }

        public BankStatement GenerateStatement()
        {
            return new BankStatement { Transactions = transactions };
        }

        public decimal CalculateBalance()
        {
            decimal balance = 0;

            foreach (var transaction in transactions)
            {
                if (transaction.IsDeposit)
                {
                    balance += transaction.Amount;
                }
                else
                {
                    balance -= transaction.Amount;
                }
            }

            return balance;
        }

        public string Branch { get; set; }

        public void SendStatementToPhone()
        {
            // implement logic to send a statement as a message to a phone number
        }
    }
}