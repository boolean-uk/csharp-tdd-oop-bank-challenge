using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        string Name { get; set; }
        decimal Balance { get; set; }

        public bool Withdraw(decimal amount);
        public bool Deposit(decimal amount);
    }
}
