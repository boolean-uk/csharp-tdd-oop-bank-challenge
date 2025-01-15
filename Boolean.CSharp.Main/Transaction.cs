using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime date { get; set; }
        public double amount { get; set; }

        public Transaction(double amount)
        {
            this.date = DateTime.Now;
            this.amount = amount;
        }

        public override string ToString()
        {
            return $"{date}: £{amount}";
        }
    }
}
