using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        List<Transaction> TransactionHistory;

        public string Depocit(decimal amount) { return ""; }

        public string Withdraw(decimal amount) { return ""; }

        public string BankStatement() { return ""; }
    }
}
