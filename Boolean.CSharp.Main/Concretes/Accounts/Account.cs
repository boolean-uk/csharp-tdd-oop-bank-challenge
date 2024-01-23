using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        private List<ITransaction> _transactions = new List<ITransaction>();

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public double GetBalance()
        {
            double balance = 0;
            balance += (_transactions.Sum(t => t.GetDetails().Item2));

            return balance;
        }
    }
}
