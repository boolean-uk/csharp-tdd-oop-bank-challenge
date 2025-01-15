using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public double amount { get; set; }

        public Transaction(DateTime date, double amount)
        {
            Date = date;
            this.amount = amount;
        }

        public override string ToString()
        {
            return $"{Date}: £{amount}";
        }
    }
}
