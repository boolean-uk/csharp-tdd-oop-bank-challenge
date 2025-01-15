using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class Transactions
    {
        public DateTime date;

        public double amount;

        public double balance;


        public Transactions(DateTime date, double amount, double balance) 
        {
            this.date = date;
            this.amount = amount;
            this.balance = balance;
        }

    }
}
