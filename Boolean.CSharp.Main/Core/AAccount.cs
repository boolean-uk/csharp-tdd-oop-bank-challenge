using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Core
{
    public abstract class AAccount
    {
        public List<Transaction> transactions { get; private set; } = new List<Transaction>();
        public double _savings { get; private set; }
        
        public AAccount()
        {
            _savings = 0;
        }


        public bool Deposit(double amount)
        {
            _savings += amount;
            Transaction transaction = new Transaction(DateTime.Now, amount, _savings);
            transactions.Add(transaction);
            return true;
        }

        public bool Deposit(double amount, DateTime date)
        {
            _savings += amount;
            Transaction transaction = new Transaction(date, amount, _savings);
            transactions.Add(transaction);
            return true;
        }

        public bool Withdraw(double amount)
        {
            if (amount > _savings) return false;
            _savings -= amount;
            return true;
        }
    }
}
