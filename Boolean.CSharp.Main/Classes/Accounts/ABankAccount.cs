using Boolean.CSharp.Main.Interfaces;
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
        eBranch _branch;
        List<OverdraftRequest> _overdrafts;
        public eBranch Branch{ get { return _branch; } }

        public ABankAccount(eBranch e = eBranch.Central)
        {
            _transactions = new List<BankStatement>();
            _overdrafts = new List<OverdraftRequest>();
            _branch = e;
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

        public StringBuilder WriteTransactions()
        {
            string test = string.Format("{0,-11} || {1,-10} || {2,-10} || {3,-10} \n", "Date", "Credit", "Debit", "Balance");
            StringBuilder sb = new StringBuilder();
            sb.Append(test);
            double money = 0d;

            foreach (BankStatement transaction in _transactions.OrderBy(t => t.Date).Where(t => t.Status == true))
            {
                money = money + transaction.Transaction;
                test = string.Format("{0,11} || {1,10} || {2,10} || {3,10} \n",
                    transaction.Date.ToShortDateString(),
                    transaction.Type == eType.Credit ? transaction.Transaction : 0,
                    transaction.Type == eType.Debit ? transaction.Transaction : 0,
                    money);
                sb.Append(test);
            }
            return sb;
        }

        public void Overdraft(OverdraftRequest a)
        {
            _overdrafts.Add(a);
        }

        public double OverdraftAmount()
        {
            double amount = 0;
            foreach (var ov in _overdrafts.Where(t => t.RequestStatus == eStatus.Approved))
            {
                amount += ov.Amount;
            }
            return amount;
        }

        public void SendTextMessage(ITextMessageSender sender)
        {
            sender.SendMessage(WriteTransactions().ToString());
        }
    }
}
