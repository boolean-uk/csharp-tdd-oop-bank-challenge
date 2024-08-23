using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public abstract class BankAccount
    {
        private decimal _balance = 0;
        List<BankStatement> _bankStatements = new List<BankStatement>();

        public bool Deposit(decimal amount)
        {
            _balance += amount;
            _bankStatements.Add(new BankStatement(DateTime.Now, amount, "Deposit", _balance));
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > _balance) return false;
            _balance -= amount;
            _bankStatements.Add(new BankStatement(DateTime.Now, amount, "Withdraw", _balance));
            return true;
        }

        public decimal Balance { get { return _balance; } }

        public List<BankStatement> BankStatements { get { return _bankStatements; } }
    }
}
