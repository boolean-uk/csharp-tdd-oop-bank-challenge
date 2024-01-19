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

        public List<BankStatement> BankStatements { get { return _bankStatements; } }

        private double _balance = 100d;
        private readonly List<BankStatement> _bankStatements = [];

        public void Deposit(double amount)
        {
            _balance += amount;
            GenerateBankStatements(amount);
        }

        public double Withdraw(double amount)
        {
            if (amount > _balance)
            {
                throw new Exception("Can't withdraw more than the current balance!");
            }
            _balance -= amount;
            GenerateBankStatements(amount);
            return amount;
        }

        public void GenerateBankStatements(double amount)
        {
            BankStatement bankStatement = new(_balance, amount);
            _bankStatements.Add(bankStatement);
        }

    }
}
