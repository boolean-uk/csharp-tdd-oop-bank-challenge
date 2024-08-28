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
            string date = System.DateTime.Today.ToString("ddmmyy");
            foreach (ITransaction transaction in _transactions)
            {
                statement.AppendLine($"date      ||debit    ||credit   ||balance   ");
                statement.AppendLine();
                statement.Append($"{date}|".PadRight(9));
                if (transaction.operation == Operation.Add)
                {
                    statement.AppendLine("|" + $"{Math.Round(transaction.operationAmount,1)}".PadRight(8) + "|");
                    statement.AppendLine("|" + $"".PadRight(8) + "|");
                }
                else
                {
                    statement.AppendLine("|" + $"".PadRight(8) + "|");
                    statement.AppendLine("|" + $"{Math.Round(transaction.operationAmount, 1)}".PadRight(8) + "|");
                }
                
            }
            return statement.ToString();
        }
    }
}
