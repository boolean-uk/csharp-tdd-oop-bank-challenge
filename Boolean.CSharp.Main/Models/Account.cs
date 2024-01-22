using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public class AccountNumberGenerator
    {
        private static int currentID = 0;

        public static int GetID()
        {
            return ++currentID;
        }
    }

    public class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; protected set; }
        public List<Transaction> Transactions { get; set; }

        public Account()
        {
            AccountNumber = AccountNumberGenerator.GetID();
            Balance = 0;
            Transactions = new List<Transaction>();
        }

        public virtual void Deposit(double amount)
        {
            Transaction transaction = new Transaction(amount, TransactionType.Credit);
            Transactions.Add(transaction);

            if (transaction != null)
                Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds for withdrawal.");

            Transaction transaction = new Transaction(amount, TransactionType.Debit);
            Transactions.Add(transaction);

            if (transaction != null)
                Balance -= amount;
        }

        public double GetBalanceAfterTransaction(Transaction transaction)
        {
            double result = 0;

            foreach (Transaction tx in Transactions.Where(t => t.Date <= transaction.Date))
            {
                result += tx.Type == TransactionType.Credit ? tx.Amount : -tx.Amount;
            }

            return result;
        }
    }
}
