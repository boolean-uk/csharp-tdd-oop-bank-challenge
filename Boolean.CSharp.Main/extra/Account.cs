using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.extra
{
    public  abstract class Account : IAccount
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public List<Transaction> Transactions { get { return _transactions; } }

        public double GetBalance()
        {
            return _transactions.Count > 0 ? _transactions[_transactions.Count-1].NewBalance : 0;
        }

        public void Deposit(double amount)
        {
            if (_transactions.Count == 0)
            {
                _transactions.Add(new Transaction(TransactionType.Deposit, amount));
            } else
            {
                _transactions.Add(new Transaction(_transactions[_transactions.Count-1], TransactionType.Deposit, amount));
            }
        }

        public bool Withdraw(double amount)
        {
            if (_transactions.Count == 0)
            {
                _transactions.Add(new Transaction(TransactionType.Withdrawal, amount));
                return false;
            }
            else
            { 
                _transactions.Add(new Transaction(_transactions[_transactions.Count - 1], TransactionType.Withdrawal, amount));
            }
            return _transactions[_transactions.Count - 1].Succeeded();
        }

        public string BankStatement()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("{0,-12} || {1, -6} || {2, -6} || {3, -6}", "Date", "Credit", "Debit", "Balance"));

            foreach (Transaction transaction in _transactions)
            {
                sb.AppendLine(transaction.ToString());
            }


            return sb.ToString();
        }
    }
}
