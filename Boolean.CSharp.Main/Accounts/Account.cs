using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        private double _balance;

        public double Balance { get => _balance; set => _balance = value; }

        private List<ITransaction> _transactions = new List<ITransaction>();
        public List<ITransaction> Transactions { get => _transactions; set => _transactions = value; }

        public double Deposit(double v)
        {
            throw new NotImplementedException();
        }

        public double Withdraw(double v)
        {
            throw new NotImplementedException();
        }

        public string GenerateBankStatement()
        {
            throw new NotImplementedException();
        }
    }
}
