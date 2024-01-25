using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boolean.CSharp.Main.AccountFolder.Enums;

namespace Boolean.CSharp.Main
{

    
    public class Transactions
    {
        private decimal _amount;
        private TransactionTypes _type;
        private DateTime _datetime;
        private decimal _balance;
        

        public Transactions(decimal amount, TransactionTypes type, decimal balance = 0)
        {
            _amount = amount;
            _type = type;
            _datetime = DateTime.Now;
            _balance = balance;
        }

        public TransactionTypes Type { get { return _type; } }
        public decimal Amount { get { return _amount; } }

        public DateTime TransactionDate { get { return _datetime; } }

        public decimal Balance { get { return _balance; } set { _balance = value; } }
    }
}
