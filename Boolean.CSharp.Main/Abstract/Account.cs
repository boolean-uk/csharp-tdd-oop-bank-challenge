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
        private List<string> _transactionHistory;

        protected Account(ICustomer owner, IBranch branch, bool type)
        {
            this.owner = owner;
            this.branch = branch;
            this.type = type;
            this._transactionHistory = new List<string>();
        }

        public string Transactions()
        {
            string history = "date\t\t||\tcredit\t||\tdebit\t||\tbalance\t";

            foreach (string transaction in _transactionHistory)
            {
                history += transaction;
            }
            
            return history;
        }
    }
}
