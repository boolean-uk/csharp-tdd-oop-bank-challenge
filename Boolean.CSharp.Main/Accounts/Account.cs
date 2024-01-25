using Boolean.CSharp.Main.Users;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Common;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        private Guid _accountId = Guid.NewGuid();
        private List<BankTransaction> _transactions = new List<BankTransaction>();
        public Branches Branches { get; set; }

        
        public Guid AccountId { get { return _accountId; } set { _accountId = value; } }
        



        public void deposit(double amount)
        {
            makeTransaction(TransactionType.Credit, amount);
        }

        public void withdraw(double amount)
        {
            makeTransaction(TransactionType.Debit, amount);

        }

        public void printTransactions()
        {
            Console.WriteLine("{0,23} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            Console.WriteLine(("").PadRight(65, '-'));
            foreach (BankTransaction bt in _transactions.OrderByDescending(t => t.Date))
            {

                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                    bt.Date.ToString(),
                    bt.TransactionType == TransactionType.Credit? bt.Amount : 0,
                    bt.TransactionType == TransactionType.Debit ? bt.Amount : 0,
                    bt.NewBalance);
            }
        }

        public void makeTransaction(TransactionType type, double amount)
        {
            double oldBalance = getBalance();
            double newBalance = 0;
            double delta = 0;

            if (_transactions.Any())
            {
                BankTransaction latestTransaction = _transactions.OrderByDescending(t => t.Date).First();
            }

            if (type == TransactionType.Credit)
            {
                delta = amount;

            }
            else if (type == TransactionType.Debit)
            {
                delta = -amount;
            }
            newBalance = oldBalance + delta;
            BankTransaction transaction = new BankTransaction(type, amount, newBalance, oldBalance);
            _transactions.Add(transaction);
            
        }

        public double getBalance()
        {
            double balance = 0;

            foreach (BankTransaction transaction in _transactions.OrderBy(t => t.Date))
            {
                switch (transaction.TransactionType)
                {
                    case TransactionType.Credit:
                        balance += transaction.Amount;
                        break;

                    case TransactionType.Debit:
                        balance -= transaction.Amount;
                        break;
                }
            }

            return balance;
        }

    }
}
