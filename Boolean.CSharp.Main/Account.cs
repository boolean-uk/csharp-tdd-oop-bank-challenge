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
        private bool _overDraftRequest = false;
        private bool _overDraft = false;
        private decimal _overdraftLimit = 0;



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
        public bool Withdraw(decimal amount)
        {
            if ((_balance - amount) >= 0)
            {
                _transactions.Add(new CreditTransaction(amount, this._balance));
                _balance -= amount;
                return true;
            }
            else if (_overDraft == true && (_balance - amount) >= _overdraftLimit)
            {
                _transactions.Add(new CreditTransaction(amount, this._balance));
                _balance -= amount;
                return true;
            }
            return false;
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

        public void RequestOverdraft()
        {
            _overDraftRequest = true;
        }

        public bool AproveOverdraft()
            //sets the overdraft limit with: limit = currentbalance * 0.05 + Sum(previous debit transactions) * 0.1
        {
            if (_manager)
            {
                _overdraftLimit = 0 - ((_balance * 0.05m) + _transactions.Where(t => t.operation == Operation.Add).ToList().Sum(s => s.operationAmount) * 0.1m);
                _overDraft = true;
                return true;
            }
            return false;
        }

        public bool OverDraftRequest { get => _overDraftRequest; set => _overDraftRequest = value; }
    }

}
