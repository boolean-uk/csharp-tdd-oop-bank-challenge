using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
//using Boolean.CSharp.Main;


namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public List<Transaction> Transactions { get; } = new List<Transaction>();
        public virtual bool Deposit(decimal amount)
        {
            return true;
        }

        public virtual bool Withdraw(decimal amount)
        {
 
            return true;
        }
        
        protected abstract void RecordTransaction(Transaction transaction);

        public abstract string GenerateStatement();


        public virtual decimal GetBalance()
        {
            return 0m;
        }
    }



}
