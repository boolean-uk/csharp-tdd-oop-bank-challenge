using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
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
            double money = 0;
            foreach (var transaction in _transactions)
            {
                money += transaction.Transaction;
            }
            return Math.Round(money,2);
        }

        public string WriteTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
