using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private Branch branch;
        private List<Transaction> transactionHistory;

        public Account(string accountType, double initialAmount, Branch branch)
        {
            this.transactionHistory = new List<Transaction>();
            this.branch = branch;
            addTransaction(new Transaction(DateTime.Now, initialAmount, initialAmount, "Credit"));
        }

        public void addTransaction(Transaction transaction)
        {
            transactionHistory.Add(transaction);
        }

        public double calculateBalance()
        {
            double balance = 0;
            foreach (Transaction transaction in transactionHistory)
            {
                if ("Credit".Equals(transaction.getDebitOrCredit()))
                {
                    balance += transaction.getAmount();
                }
                else if ("Debit".Equals(transaction.getDebitOrCredit()))
                {
                    balance -= transaction.getAmount();
                }
            }
            return balance;
        }

        public List<Transaction> getTransactionHistory()
        {
            return new List<Transaction>(transactionHistory);
        }

        public Branch getBranch()
        {
            return branch;
        }

        public void setBranch(Branch branch)
        {
            this.branch = branch;
        }
    }
}
