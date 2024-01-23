using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankTransaction
    {
        private decimal _amount;
        private TransactionType _type;
        private DateTime _transactionDate;
        private decimal _balance;

        public BankTransaction(decimal amount, TransactionType type, decimal balance = 0) 
        {
            _amount = amount;
            _type = type;
            _transactionDate = DateTime.Now;
            _balance = balance;
        }

        public TransactionType Type {  get { return _type; } }
        public decimal Amount { get { return _amount; } }

        public DateTime TransactionDate { get { return _transactionDate; } }

        public decimal Balance { get { return _balance; }  set { _balance = value; } }
    }

}
