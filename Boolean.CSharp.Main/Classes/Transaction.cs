using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class Transaction
    {
        public string date;

        public double credit;
        public double debit;

        public double balance;


        public Transaction(string date, double credit, double debit, double balance) 
        {
            this.date = date;
            this.credit = credit;
            this.debit = debit;
            this.balance = balance;
        }
    }
}
