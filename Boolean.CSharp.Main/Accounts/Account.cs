using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        public List<BankTransactions> transactions;
        private double _balance;
        private Enums.OverdraftStatus overDraft;

        public Account()
        {
            _balance = 0;
            transactions = new List<BankTransactions>();
            overDraft = Enums.OverdraftStatus.Idle;
        }

        public Enums.OverdraftStatus GetOverdraftStatus()
        {
            return overDraft;
        }

        public void SetOverdraftStatus(Enums.OverdraftStatus status)
        {
            overDraft = status;
        }

        public double Deposit(double amount)
        {
            _balance += amount;
            transactions.Add(new BankTransactions(amount, Enums.TransactionType.Deposit, _balance));
            return _balance;
        }

        public double Withdraw(double amount)
        {

            if (_balance >= amount)
            {
                _balance -= amount;
                transactions.Add(new BankTransactions(amount, Enums.TransactionType.Withdrawal, _balance));
            }
            return _balance;
        }

        public Enums.OverdraftStatus RequestOverdraft()
        {
            overDraft = Enums.OverdraftStatus.Pending;
            return overDraft;
        }


        public double Balance()
        {
            double balance = 0.00;
            if (transactions.Count < 1)
            {
                return balance;
            }
            else
            {
                foreach (var transaction in transactions)
                {
                    if (transaction.transactionType == Enums.TransactionType.Deposit)
                    {
                        balance = balance + transaction._amount;
                    }
                    else
                    {
                        balance = balance - transaction._amount;
                    }
                }
            }
            return balance;
        }


        public void ShowTransactions()
        {
            Console.WriteLine("Date                        ||       credit       ||     debit      ||      balance");
            foreach (var t in transactions)
            {
                Console.Write($"{t._date.ToString("f")}");
                if (t.transactionType == Enums.TransactionType.Deposit)
                {
                    Console.Write($"          {t._amount}                             ");
                }
                else if (t.transactionType == Enums.TransactionType.Withdrawal)
                {
                    Console.Write($"                              {t._amount}          ");
                }
                Console.Write($"       {t._balance}\n");
            }
        }

    }
}
