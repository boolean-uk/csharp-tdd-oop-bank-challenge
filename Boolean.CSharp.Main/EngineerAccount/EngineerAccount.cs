using Boolean.CSharp.Main.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.EngineerAccount
{
    public abstract class EngineerAccount : iTransaction
    {
        public abstract decimal deposit(decimal amount);
        public abstract decimal withdraw(decimal amount);
        public abstract List<Transaction.Transaction> printBankStatement();
        public List<Transaction.Transaction> CurrentTransactions { get; set; }
        public List<Transaction.Transaction> SavingsTransactions { get; set; }
    }
}
