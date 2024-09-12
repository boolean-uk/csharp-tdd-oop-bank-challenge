using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.CustomerAccounts
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(decimal balance)
        {
            this.Balance = balance;
            CurrentTransactions = new List<Transaction.Transaction>();
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
    }
}
