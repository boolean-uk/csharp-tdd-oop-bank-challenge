using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _date;
        private decimal _amount;
        private TransactionType _type;
        
        public DateTime Date { get { return _date; } }
        public decimal Amount { get { return _amount; } }
        public TransactionType TransactionType { get { return _type; } }

        public Transaction(decimal  amount, TransactionType type)
        {
            _date = DateTime.Now;
            _amount = amount; 
            _type = type;
        }

        public string ToString(decimal balance)
        {
            StringBuilder result = new StringBuilder();
            switch (TransactionType)
            {
                case TransactionType.Credit:
                    result.Append($"{Date,-10:dd/MM/yyyy} || {Amount,-10:F2} || {"",10} || {balance:F2}");
                    break;
                case TransactionType.Debit:
                    result.Append($"{Date,-10:dd/MM/yyyy} || {"",10} || {Amount,-10:F2} || {balance:F2}");
                    break;
                default:
                    break;
            }
            return result.ToString();
        }

        public decimal GetAmount() 
        {
            if (TransactionType == TransactionType.Credit) return Amount;
            else return -Amount;
        }
    }
}