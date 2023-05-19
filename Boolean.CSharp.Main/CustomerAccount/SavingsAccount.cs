using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.CustomerAccounts
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(decimal balance)
        {
            this.Balance = balance;
            SavingsTransactions = new List<Transaction.Transaction>();
        }

        public override bool deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transaction.Transaction transaction = new Transaction.Transaction(DateTime.Now, amount, 0, Balance);
                SavingsTransactions.Add(transaction);
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
                SavingsTransactions.Add(transaction);
                return true;
            }
            return false;
        }

        public override List<Transaction.Transaction> printBankStatement()
        {
            return SavingsTransactions;
        }
    }
}
