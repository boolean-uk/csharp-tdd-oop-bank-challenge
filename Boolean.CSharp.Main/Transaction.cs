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
        public float balance;

        public Transaction(string date, float credit, float debit, float balance)
        {
            this.date = date;
            this.credit = credit;
            this.debit = debit;
            this.balance = balance;
        }
    }
}