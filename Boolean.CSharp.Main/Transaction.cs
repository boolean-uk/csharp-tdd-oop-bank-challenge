using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public string date {  get; set; }
        
        public double credit { get; set; }
        
        public double debit { get; set; }
        
        public double balance { get; set; }

        public Transaction(string date, double balance, double credit, double debit) 
        { 
            this.date = date;
            this.balance = balance;
            this.credit = credit;
            this.debit = debit;
        }
    }
}
