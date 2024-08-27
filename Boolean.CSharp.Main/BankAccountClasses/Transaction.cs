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
        private string _date;
        private TransactionType _typeOfTransaction;
        private decimal _amount;
        private bool _checked = false;

        public string Date { get => _date; set => _date = value; }
        public TransactionType TypeOfTransaction { get => _typeOfTransaction; set => _typeOfTransaction = value; }
        public decimal Amount { get => _amount; set => _amount = value; }
        public bool Checked { get => _checked; set => _checked = value; }
        #endregion

        public Transaction(string date, TransactionType typeOfTransaction, decimal amount)
        {
            _date = date;
            _typeOfTransaction = typeOfTransaction;
            _amount = amount;
        }

        public override string ToString()
        {
            return _typeOfTransaction == TransactionType.Withdraw ?
                // Withdraw
                $"{_date}".PadRight(11) + "||".PadRight(10) + "||".PadRight(4) + $"{_amount}".PadRight(5) :

                // Deposit
                $"{_date}".PadRight(11) + "||".PadRight(4) + $"{_amount}".PadRight(6) + "||".PadRight(9);
        }
    }
}
