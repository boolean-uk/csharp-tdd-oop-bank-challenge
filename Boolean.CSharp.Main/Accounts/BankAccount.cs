using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class BankAccount
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

        public abstract string GenerateStatemenr();
    }

}
