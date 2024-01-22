using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
            string test = string.Format("{0,-11} || {1,-10} || {2,-10} || {3,-10} \n", "Date", "Credit", "Debit", "Balance");
            StringBuilder sb = new StringBuilder();
            sb.Append(test);
            double money = 0d;

            foreach (BankStatement transaction in _transactions.OrderByDescending(t => t.Date).Where(t => t.Status == true))
            {
                money = money + transaction.Transaction;
                test = string.Format("{0,10} || {1,10} || {2,10} || {3,10} ",
                    transaction.Date.ToShortDateString(),
                    transaction.Type == eType.Credit ? transaction.Transaction : 0,
                    transaction.Type == eType.Debit ? transaction.Transaction : 0,
                    money);
                sb.Append(test);
            }

        }
    }
}
