using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private string _date;
        private decimal _amount;

        public string Date { get => _date; }
        public decimal Amount { get => _amount; }

        public Transaction(decimal amount)
        {
            this._amount = amount;
            _date = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public override string ToString()
        {
            StringBuilder transactionString = new StringBuilder();
            transactionString.Append($"{_date, -10} ||");

            if (_amount > 0)
            {
                transactionString.Append($" {_amount, -7} || {"", -7 } ||");
            }
            else
            {
                transactionString.Append($" {"",-7} || {-_amount, -7} ||");
            }

            return transactionString.ToString();

        }
    }
}
