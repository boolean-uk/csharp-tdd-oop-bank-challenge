using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main
{
    public abstract class Account 
    {
        private double _balance = 0;
        private Branch _branch;
        List<ITransaction> _transactions;
        List<IOverdraft> _overdraftRequests;

        public Account()
        {
            _transactions = new List<ITransaction>();
            _overdraftRequests = new List<IOverdraft>();
        }

        public double GetBalance()
        {
            ITransaction transaction = _transactions.OrderByDescending(t => t.DateTime).FirstOrDefault();
            _balance = transaction?.Balance ?? 0;
            return _balance;
        }

        public void Deposit(double amount)
        {
            double oldBalance = _balance;
            _balance = _balance + amount;
            ITransaction transaction = new Transaction(_balance, amount, oldBalance, TransactionType.Credit);
            _transactions.Add(transaction);
        }


        public void WithDraw(double amount)
        {
            if (amount > _balance) {
                IOverdraft overdraft = new Overdraft(amount);
                _overdraftRequests.Add(overdraft);
            
            } else {
                double oldBalance = _balance;
                _balance = _balance - amount;
                ITransaction transaction = new Transaction(_balance, amount, oldBalance, TransactionType.Debit);
                _transactions.Add(transaction);
            }
        }

        public void WithDraw(IOverdraft overdraft)
        {
            if (overdraft.overdraftStatus == OverdraftStatus.Approved)
            {
                double oldBalance = _balance;
                ITransaction transaction = new Transaction(_balance, overdraft.amount, oldBalance, TransactionType.Debit);
                _transactions.Add(transaction);
            }
        }

        public double Balance => GetBalance();
        public List<ITransaction> Transactions { get { return _transactions; } }
        public Branch Branch { get { return _branch; } set { _branch = value; } }
        public List<IOverdraft> OverdraftRequests { get { return _overdraftRequests; } }

    }
}
