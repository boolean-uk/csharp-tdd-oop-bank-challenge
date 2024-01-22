using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; protected set; }
        public List<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
        }

        public virtual void Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public virtual void Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
