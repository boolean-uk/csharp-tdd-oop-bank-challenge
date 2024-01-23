using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.extra;
using Boolean.CSharp.Main.src.sms;
using Boolean.CSharp.Main.src.transaction;

namespace Boolean.CSharp.Main.src.account
{
    public abstract class Account : IAccount
    {
        private List<BankTransaction> _transactions = new List<BankTransaction>();
        private List<Overdraft> _overdrafts = new List<Overdraft>();
        private Branch _branch;

        public List<BankTransaction> Transactions { get { return _transactions; } }
        public Branch Branch { get { return _branch; } }

        public Account(Branch branch)
        {
            _branch = branch;
        }

        public double GetBalance()
        {
            return _transactions.Where(t => t.Status.Equals(Status.Approved))
                .Sum(t => t.Type.Equals(TransactionType.Deposit) ? t.Amount : -t.Amount);
        }

        public double PossibleOverdraft()
        {
            return _overdrafts.Where(t => t.Status.Equals(Status.Approved)).Sum(t => t.Amount);
        }

        public void Deposit(double amount)
        {
            if (_transactions.Count == 0)
            {
                _transactions.Add(new BankTransaction(TransactionType.Deposit, amount));
            }
            else
            {
                _transactions.Add(new BankTransaction(_transactions[_transactions.Count - 1], TransactionType.Deposit, amount));
            }
        }

        public bool Withdraw(double amount)
        {
            if (_transactions.Count == 0)
            {
                _transactions.Add(new BankTransaction(TransactionType.Withdrawal, amount, PossibleOverdraft()));
            }
            else
            {
                _transactions.Add(new BankTransaction(_transactions[_transactions.Count - 1], TransactionType.Withdrawal, amount, PossibleOverdraft()));
            }
            return _transactions[_transactions.Count - 1].Status.Equals(Status.Approved);
        }

        public string BankStatement()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0,-12} || {1, -6} || {2, -6} || {3, -6}", "Date", "Credit", "Debit", "Balance"));

            foreach (BankTransaction transaction in _transactions)
            {
                sb.AppendLine(transaction.ToString());
            }


            return sb.ToString();
        }

        public void RequestOverdraft(Overdraft overdraft)
        {
            _overdrafts.Add(overdraft);
        }

        public void SmsStatement(string toNumber)
        {
            SmsProvider provider = new SmsProvider();
            provider.SendMessage(BankStatement(), toNumber);
        }
    }
}
