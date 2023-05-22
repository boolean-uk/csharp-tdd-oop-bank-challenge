using Boolean.CSharp.Main.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.ManagerAccount
{
    public abstract class ManagerAccount : iTransaction
    {
        private decimal _balance;
        private List<string> _branchesAcc1;
        private List<string> _branchesAcc2;

        public decimal Balance { get { return _balance; } set { _balance = value; } }

        public List<Transaction.Transaction> CurrentTransactions { get; set; }
        public List<Transaction.Transaction> SavingsTransactions { get; set; }
        public abstract bool deposit(decimal amount);

        public abstract bool withdraw(decimal amount);

        public abstract List<Transaction.Transaction> printBankStatement();

        public decimal balance { get { return _balance; } set { _balance = value; } }
        public List<string> branchesAcc1 { get { return _branchesAcc1; } set { _branchesAcc1 = value; } }
        public List<string> branchesAcc2 { get { return _branchesAcc2; } set { _branchesAcc2 = value; } }
    }
}
