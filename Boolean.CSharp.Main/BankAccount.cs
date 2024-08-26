using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public abstract class BankAccount
    {
        //private decimal _balance = 0;
        private Stack<BankStatement> _bankStatements = new Stack<BankStatement>();
        private BankBranch _bankBranch;

        public bool Deposit(decimal amount)
        {
            //_balance += amount;
            decimal totalBalance = amount;
            if (_bankStatements.Count > 0) totalBalance += _bankStatements.Peek().Balance;
            _bankStatements.Push(new BankStatement(DateTime.Now, amount, "Deposit", totalBalance));
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            decimal totalBalance = 0;
            if (_bankStatements.Count > 0) totalBalance = _bankStatements.Peek().Balance;
            if (amount > totalBalance) return false;
            //_balance -= amount;
            totalBalance -= amount;
            _bankStatements.Push(new BankStatement(DateTime.Now, amount, "Withdraw", totalBalance));
            return true;
        }

        public bool RequestOverdraft(decimal amount, Manager manager)
        {
            decimal totalBalance = 0;
            if (_bankStatements.Count > 0) totalBalance = _bankStatements.Peek().Balance;

            if (manager != null)
            {
                if (manager.ApproveOverdraft(amount, totalBalance))
                {
                    totalBalance -= amount;
                    _bankStatements.Push(new BankStatement(DateTime.Now, amount, "Withdraw", totalBalance));
                    return true;
                }
            }

            return false;
        }

        public string PrintBankStatements()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("date".PadRight(20) + "||");
            sb.Append("credit ||".PadLeft(12));
            sb.Append("debit ||".PadLeft(12));
            sb.AppendLine("balance ||".PadLeft(12));

            foreach (var bs in _bankStatements)
            {
                sb.Append($"{bs.DateTime}".PadRight(20) + "||");
                if (bs.Type == "Deposit") sb.Append($"{bs.Amount} ||".PadLeft(12) + " ||".PadLeft(12));
                if (bs.Type == "Withdraw") sb.Append(" ||".PadLeft(12) + $"{bs.Amount} ||".PadLeft(12));
                sb.AppendLine($"{bs.Balance} ||".PadLeft(12));
            }

            return sb.ToString();
        }

        public decimal Balance { get { return _bankStatements.Peek().Balance; } }

        public Stack<BankStatement> BankStatements { get { return _bankStatements; } }

        public BankBranch Branch { get { return _bankBranch; } set { _bankBranch = value; } }
    }
}
