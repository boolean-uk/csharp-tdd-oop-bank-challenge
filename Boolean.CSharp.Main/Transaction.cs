using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private decimal _amount;
        private string _type;
        private DateTime _transactionDate;

        public Transaction(decimal amount, string type) 
        {
            _amount = amount;
            _type = type;
            _transactionDate = DateTime.Now;
        }

        public string Type {  get { return _type; } }
        public decimal Amount { get { return _amount; } }

        public DateTime TransactionDate { get { return _transactionDate; } }
    }

}
