using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.ManagerAccount
{
    public class ManagerCurrentAccount : ManagerAccount
    {
        public ManagerCurrentAccount(decimal balance,List<string> branches)
        {
            this.Balance = balance;
            CurrentTransactions = new List<Transaction.Transaction>();
            branchesAcc1 = new List<string>();
            this.branchesAcc1 = branches;
        }

        public override bool deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transaction.Transaction transaction = new Transaction.Transaction(DateTime.Now, amount, 0, Balance);
                CurrentTransactions.Add(transaction);
                return true;
            }
            return false;
        }

        public override bool withdraw(decimal amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                Transaction.Transaction transaction = new Transaction.Transaction(DateTime.Now, 0, amount, Balance);
                CurrentTransactions.Add(transaction);
                return true;
            }
            return false;
        }

        public override List<Transaction.Transaction> printBankStatement()
        {
            return CurrentTransactions;
        }

        public void addBranch(string branch)
        {
            branchesAcc1.Add(branch);
        }

    }
}
