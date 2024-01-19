using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Core
{
    public class Transaction
    {
        private DateTime time;
        private double amount, balance;

        public Transaction(DateTime time, double amount, double balance)
        {
            this.time = time;
            this.amount = amount;
            this.balance = balance;
        }

        public string Amount { get => amount.ToString("C2"); }
        public string Balance { get => balance.ToString("C2"); }

        public string Time { get => time.ToString("dd/mm/yyyy"); }
    }
}
