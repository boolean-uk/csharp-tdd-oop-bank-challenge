using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime transactionDate {  get; set; }
        public float transactionAmount { get; set; }

        public Transaction(float Amount, DateTime Datetime) 
        {
            this.transactionDate = Datetime;
            this.transactionAmount = Amount;
        }
    }
}
