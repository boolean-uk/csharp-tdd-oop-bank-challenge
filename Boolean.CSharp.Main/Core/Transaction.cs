using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Core
{
    public class Transaction
    {
        public bool isCredit { get; private set; } = true;
        private DateTime time;
        private double amount;
        public double balance { get; private set; }

        public Transaction(DateTime time, double amount, double balance)
        {
            this.time = time;
            if (amount < 0) isCredit = false;
            this.amount = Math.Abs(amount);
            this.balance = balance;
        }

        public string Amount { get => amount.ToString("0.00"); }
        public string Balance { get => balance.ToString("0.00"); }

        public string Time { get => time.ToString("dd/MM/yyyy"); }
    }
}
