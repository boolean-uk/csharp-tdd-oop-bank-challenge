using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class BankAccount : ITransactionable
    {
        protected List<Transaction> transactions;

        public BankAccount()
        {
            transactions = new List<Transaction>();
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                transactions.Add(new Transaction(amount, TransactionType.Deposit, GetBalance() + amount));
                return true;
            }

            return false;
        }
        public bool Withdraw(double amount)
        {
            if (amount > 0 && GetBalance() >= amount)
            {
                transactions.Add(new Transaction(amount, TransactionType.Withdraw, GetBalance() - amount));
                return true;
            }
            return false;
        }

        public double GetBalance()
        {
            // Implement getting balance logic
            if (transactions.Count > 0)
            {
                // Return the balance from the latest transaction
                return transactions.Last().Balance;
            }

            return 0; // Return 0 if no transactions yet
        }

        public void GenerateStatement()
        {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            transactions = transactions.OrderByDescending(t => t.Date).ToList();
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                    transaction.Date.ToShortDateString(),
                    transaction.Type == TransactionType.Deposit ? transaction.Amount.ToString() : 0,
                    transaction.Type == TransactionType.Withdraw ? transaction.Amount.ToString() : 0,
                    transaction.Balance.ToString());
            }
        }

        string ITransactionable.GenerateStatement()
        {
            throw new NotImplementedException();
        }
    }

}

