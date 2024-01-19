using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Balance { get { return _balance; } }
        private double _balance = 100d;

        public bool Deposit(double amount)
        {
            _balance += amount;
            return true;
        }

        public void GenerateBankStatements()
        {
            throw new NotImplementedException();
        }

        public double Withdraw(double amount)
        {
            if (amount > _balance)
            {
                throw new Exception("Can't withdraw more than the current balance!");
            }
            _balance -= amount;
            return amount;
        }
    }
}
