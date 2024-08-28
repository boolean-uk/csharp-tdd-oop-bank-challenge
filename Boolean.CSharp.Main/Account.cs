using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private decimal _balance = 0;
        private List<ITransaction> _transactions = new();




        public Account(decimal number)
        {
            this._balance = number;
        }

        public decimal GetBalance()
        {
            decimal temp = _balance;
            return temp;
        }

        public void Deposit(decimal amount)
        {
            _transactions.Add(new DebitTransaction(amount, this._balance));
            _balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            _transactions.Add(new CreditTransaction(amount, this._balance));
            _balance -= amount;
        }
        public string GetStatement()
        {
            StringBuilder statement = new();

            string date = System.DateTime.Today.ToString("dd.MM.yy");
            statement.AppendLine($"Account initiated with {_transactions[0].beforeAmount} at {date}");
            statement.AppendLine($"date    ||debit   ||credit  ||balance |");
        
            foreach (ITransaction transaction in _transactions)
            {
                statement.Append( $"{date}".PadRight(8) + "|");
                if (transaction.operation == Operation.Add)
                {
                    statement.Append("|" + $"{Math.Round(transaction.operationAmount, 2)}".PadRight(8) + "|");
                    statement.Append("|" + $"".PadRight(8) + "|");
                    statement.Append("|" + $"{Math.Round(transaction.GetBalance(), 2)}".PadRight(8) + "|");
                }
                else
                {
                    statement.Append("|" + $"".PadRight(8) + "|");
                    statement.Append("|" + $"{Math.Round(transaction.operationAmount, 2)}".PadRight(8) + "|");
                    statement.Append("|" + $"{Math.Round(transaction.GetBalance(), 2)}".PadRight(8) + "|");
                }
                statement.AppendLine();

            }
            return statement.ToString();
        }
    }
}
