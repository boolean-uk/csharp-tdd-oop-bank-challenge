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
        public int AccountNumber { get; }
        public double Balance { get; protected set; }
        private readonly List<Transaction> transactions;
        public Enums.Branches Branch { get; set; }

        protected Account(int accountNumber, Enums.Branches defaultBranch = Enums.Branches.Oslo)
        {
            this.AccountNumber = accountNumber;
            Balance = 0;
            transactions = new List<Transaction>();
            Branch = defaultBranch;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            AddTransaction(amount);
        }

        public bool Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
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
            transactions.Add(new Transaction(amount, Balance));
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
    }
}
