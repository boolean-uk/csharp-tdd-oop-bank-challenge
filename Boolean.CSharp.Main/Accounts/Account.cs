using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        public int accountNumber { get; }
        public double balance { get; protected set; }
        private readonly List<Transaction> transactions;

        protected Account(int accountNumber)
        {
            this.accountNumber = accountNumber;
            balance = 0;
            transactions = new List<Transaction>();
        }

        public void Deposit(double amount)
        {
            balance += amount;
            AddTransaction(amount);
        }

        public bool Withdraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                AddTransaction(-amount);
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }
        }

        public void AddTransaction(double amount)
        {
            transactions.Add(new Transaction(amount, balance));
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
    }
}
