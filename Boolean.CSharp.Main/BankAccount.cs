using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public abstract class BankAccount
    {
        private decimal _balance = 0;
        Stack<BankStatement> _bankStatements = new Stack<BankStatement>();

        public bool Deposit(decimal amount)
        {
            _balance += amount;
            _bankStatements.Push(new BankStatement(DateTime.Now, amount, "Deposit", _balance));
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > _balance) return false;
            _balance -= amount;
            _bankStatements.Push(new BankStatement(DateTime.Now, amount, "Withdraw", _balance));
            return true;
        }

        public string PrintBankStatements()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("date".PadRight(20));
            sb.Append("||  credit".PadRight(12));
            sb.Append("||  debit".PadRight(12));
            sb.AppendLine("|| balance".PadRight(12));

            

            foreach (var bs in _bankStatements)
            {
                sb.Append($"{bs.DateTime}".PadRight(20));
                if (bs.Type == "Deposit") sb.Append("|| " + $"{bs.Amount} ".PadLeft(9) + "|| ".PadRight(12));
                if (bs.Type == "Withdraw") sb.Append("|| ".PadRight(12) + "|| " + $"{bs.Amount} ".PadLeft(9));
                sb.AppendLine($"|| {bs.Balance}".PadRight(12));
            }

            return sb.ToString();
        }

        public decimal Balance { get { return _balance; } }

        public Stack<BankStatement> BankStatements { get { return _bankStatements; } }
    }
}
