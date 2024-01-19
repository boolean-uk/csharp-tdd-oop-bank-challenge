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
        public double Balance => throw new NotImplementedException();
        private double _balance;

        public Account(double startBalance)
        {
            _balance = startBalance;
        }

        public bool Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public void GenerateBankStatements()
        {
            throw new NotImplementedException();
        }

        public double Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
