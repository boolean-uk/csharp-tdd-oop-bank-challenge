using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private decimal _balance = 0;
        private List<ITransaction> _transactions = new();
        private bool _manager = false;
        private bool _engineer = false;
        private Branch _branch;



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
                statement.Append($"{date}".PadRight(8) + "|");
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
        public decimal CalculateBalance()
        {
            if (_engineer == true)
            {
                decimal calculated = _transactions[0].beforeAmount;
                foreach (ITransaction transaction in _transactions)
                {
                    if (transaction.operation == Operation.Add)
                    {
                        calculated += transaction.operationAmount;
                    }
                    else
                    {
                        calculated -= transaction.operationAmount;
                    }
                }
                return calculated;
            }
            return -88888888888m;
        }

        public void EngineerAccess(string password)
        {
            if (password == "password")
            {
                _engineer = true;
            }
        }

        public void ManagerAccess(string password)
        {
            if (password == "password")
            {
                _manager = true;
            }
        }

        public void SetBranch(Branch branch)
        {
            if (_manager == true)
                _branch = branch;
        }

        public Branch GetBranch()
        {
            return _branch;
        }
    }
}
