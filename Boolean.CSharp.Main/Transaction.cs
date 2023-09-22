using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private static int id = 0;

        private int _id;
        private DateTime _date;
        TransactionType _type;
        private decimal _amount;
        private decimal _newBalance;

        public Transaction(DateTime date, TransactionType type, decimal amount, decimal prevBalance)
        {
            _id = ++id;
            _date = date;
            _type = type;
            _amount = amount;
            if (type == TransactionType.Credit)
            {
                _newBalance = prevBalance + amount;
            }
            else
            {
                _newBalance = prevBalance - amount;
            }
        }

        public string ToString()
        {
            return $"{_date.ToString("dd/MM/yyyy")} || {(_type == TransactionType.Credit ? _amount : ""), 7} || {(_type == TransactionType.Debit ? _amount : ""), 6} || {_newBalance}";
        }

        public decimal NewBalance { get => _newBalance; }
    }
}
