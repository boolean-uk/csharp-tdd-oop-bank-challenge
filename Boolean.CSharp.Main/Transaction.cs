using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public string date;
        public float credit;
        public float debit;
        private float balance;

        public Transaction(string date, float credit, float debit)
        {
            this.date = date;
            this.credit = credit;
            this.debit = debit;
            
            this.balance = 0.0f;
            this.balance += credit;
            this.balance -= debit;
        }

        public float GetBalance()
        {
            return balance;
        }
    }
}