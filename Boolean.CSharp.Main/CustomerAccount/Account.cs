using Boolean.CSharp.Main.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.CustomerAccounts
{
    public abstract class Account : iTransaction
    {
        private decimal _balance;

        public decimal Balance { get { return _balance; } set { _balance = value; } }

        public List<Transaction.Transaction> CurrentTransactions { get; set; }
        public List<Transaction.Transaction> SavingsTransactions { get; set; }
        public abstract bool deposit(decimal amount);

        public abstract bool withdraw(decimal amount);

        public abstract List<Transaction.Transaction> printBankStatement();
    }
}
