using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        public ICustomer owner;
        public IBranch branch;
        public bool type; //True = Current | False = Saving
        protected List<string> transactionHistory;

        protected Account(ICustomer owner, IBranch branch, bool type)
        {
            this.owner = owner;
            this.branch = branch;
            this.type = type;
            this.transactionHistory = new List<string>();
        }

        public string Transactions()
        {
            string history = "date\t\t\t||credit\t||debit\t||balance";

            transactionHistory.Reverse();

            foreach(var transaction in transactionHistory)
            {
                history += transaction.ToString();
            }

            transactionHistory.Reverse();
            
            return history;
        }

        public decimal Balance()
        {
            decimal balance = 0;

            //Pick up the latest balance from the transactionHistory
            if (transactionHistory.Count > 0)
            {
                string balanceString = transactionHistory.Last().Substring(transactionHistory.Last().LastIndexOf('|') + 1);
                balanceString.Trim();
                balance = Convert.ToDecimal(balanceString);
            }

            return balance;
        }

        public abstract void Deposit(decimal amount);
        
        public abstract bool Withdraw(decimal amount);
    }
}
