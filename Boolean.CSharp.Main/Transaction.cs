using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private int currentBalance;
        private string date;
        private int change;
        private string type;

        public Transaction(int currentBalance, string date, int change, string type) 
        { 
            this.currentBalance = currentBalance;
            this.date = date;
            this.change = change;
            this.type = type;
        }
    }
}
