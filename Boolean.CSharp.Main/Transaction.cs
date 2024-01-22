using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private float currentBalance;
        private string date;
        private float change;
        private string type;

        public Transaction(float currentBalance, string date, float change, string type) 
        { 
            this.currentBalance = currentBalance;
            this.date = date;
            this.change = change;
            this.type = type;
        }

        public string getDate()
        {
            return date;
        }
        public float getChange()
        {
            return change;
        }
        public string getType()
        {
            return type;
        }
        public float getCurrentBalance()
        {
            return currentBalance;
        }

    }
}
