using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _date { get; }
        private decimal _depositAmount { get; }
        private decimal _withdrawAmount { get; }
        public Transaction(decimal amount, TransactionType transactionType)
        {
            if(transactionType == TransactionType.Deposit) 
                _depositAmount = amount;
            else 
                _withdrawAmount = amount;
            _date = DateTime.UtcNow;
        }

        public DateTime Date {  get { return _date; } }
        public decimal WithdrawAmount { get { return _withdrawAmount; } }
        public decimal DepositAmount { get { return _depositAmount;    } }
    }
}
