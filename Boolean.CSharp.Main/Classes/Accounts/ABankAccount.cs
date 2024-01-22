using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes.Accounts
{
    abstract public class ABankAccount
    {
        List<BankStatement> _transactions;

        public ABankAccount()
        {
            _transactions = new List<BankStatement>();
        }

        public double Transaction(BankStatement statement)
        {
            _transactions.Add(statement);
            return Money();
        }

        public double Money() 
        {
            double money = 0;
            foreach (var transaction in _transactions)
            {
                money += transaction.Transaction;
            }
            return Math.Round(money, 2);
        }

        public string WriteTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
