using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public abstract class BankAccount
    {
        private decimal _balance = 0;

        public bool Deposit(decimal amount)
        {
            _balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > _balance) return false;
            _balance -= amount;
            return true;
        }

        public decimal Balance { get { return _balance; } }

        public List<BankStatement> BankStatements { get; set; }
    }
}
