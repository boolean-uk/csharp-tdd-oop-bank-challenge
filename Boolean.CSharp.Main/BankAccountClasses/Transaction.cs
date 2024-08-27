using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccountClasses
{
    public class Transaction
    {
        #region Properties
        private DateTime _date;
        private TransactionType _typeOfTransaction;
        private decimal _amount;

        public DateTime Date { get => _date; set => _date = value; }
        public TransactionType TypeOfTransaction { get => _typeOfTransaction; set => _typeOfTransaction = value; }
        public decimal Amount { get => _amount; set => _amount = value; }
        #endregion

        public Transaction(DateTime date, TransactionType typeOfTransaction, decimal amount)
        {
            _date = date;
            _typeOfTransaction = typeOfTransaction;
            _amount = amount;
        }
    }
}
