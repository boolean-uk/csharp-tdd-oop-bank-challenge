using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        public bool OverdraftRequestIsActive { get; set; }
        public decimal BalanceLimit { get; set; } //Use for overdrafts, default to 0
        public AccountType Type { get; }

        public Branch Branch { get; }
        public List<Transaction> Transactions { get; set; }
        public bool Deposit(decimal amount);

        public bool Withdraw(decimal amount);

        public void GenerateStatement();

        public decimal GetBalance();

        

    }
}
