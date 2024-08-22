using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingAccount : IAccount
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
