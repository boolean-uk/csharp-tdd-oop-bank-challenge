using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        public string Name     { get; set; }
        public decimal Balance { get; set; }

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
