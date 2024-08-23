using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();
        public decimal Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string GenerateStatement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public List<ITransaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public void Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        string IAccount.GenerateStatement()
        {
            throw new NotImplementedException();
        }

        public List<ITransaction> Transactions { get => _transactions; }

    }
}
