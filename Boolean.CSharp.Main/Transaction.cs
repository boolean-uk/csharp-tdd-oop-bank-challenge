using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public enum TransactionType { Withrawal, Deposit }

    public class Transaction
    {
        private string _id;
        private TransactionType _type;
        private DateTime _date;
        private decimal _amount;
        private decimal _previousValue;
        private decimal _newValue;

        public Transaction(TransactionType type, decimal amount, decimal previousValue) 
        {
            throw new NotImplementedException();

        }
    }
}
