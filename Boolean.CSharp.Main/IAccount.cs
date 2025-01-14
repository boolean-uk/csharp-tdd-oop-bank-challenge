using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{

    //Should have used abstract class and not interface
    public interface IAccount
    {
        int AccountNumber { get; set; }
        decimal Balance { get; set; }

        public Dictionary<int, decimal> AccountBalance { get; set; }

        public decimal Withdraw(decimal amount);
        public decimal Deposit(decimal amount);
    }
}
