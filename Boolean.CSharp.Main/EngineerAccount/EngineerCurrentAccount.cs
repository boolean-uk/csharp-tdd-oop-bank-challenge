using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.EngineerAccount
{
    public class EngineerCurrentAccount : EngineerAccount
    {
        public EngineerCurrentAccount()
        {
            CurrentTransactions = new List<Transaction.Transaction>();
        }
        public override decimal deposit(decimal amount)
        {
            decimal total = 0;
            foreach (var transaction in CurrentTransactions)
            {
                total += transaction.credit;
                total -= transaction.debit;
            }
            if (amount > 0)
            {
                total += amount;
                Transaction.Transaction transaction = new Transaction.Transaction(DateTime.Now, amount, 0, total);
                CurrentTransactions.Add(transaction);
            }
            return total;
        }
        public override decimal withdraw(decimal amount)
        {
            decimal total = 0;
            foreach (var transaction in CurrentTransactions)
            {
                total += transaction.credit;
                total -= transaction.debit;
            }
            if (total - amount > 0)
            {
                total -= amount;
                Transaction.Transaction transaction = new Transaction.Transaction(DateTime.Now, amount, 0, total);
                CurrentTransactions.Add(transaction);
            }
            return total;
        }

        public override List<Transaction.Transaction> printBankStatement()
        {
            return CurrentTransactions;
        }
    }
}
