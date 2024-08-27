using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        string date;
        decimal amount;
        decimal balance;

        public Transaction(decimal amount, decimal balance)
        {
            this.amount = amount;
            this.balance = balance;
            date = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public override string ToString()
        {
            StringBuilder transactionString = new StringBuilder();
            transactionString.Append($"{date, -10} ||");

            if (amount > 0)
            {
                transactionString.Append($" {amount, -10} || {"", -10 } ||");
            }
            else
            {
                transactionString.Append($" {"",-11}|| {-amount, -10} ||");
            }

            transactionString.Append($" {balance}");

            return transactionString.ToString();

        }
    }
}
