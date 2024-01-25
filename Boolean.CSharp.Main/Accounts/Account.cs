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


        public Guid AccountId { get { return _accountId; } set { _accountId = value; } }
        public Branches Branches { get; set; }



        public void deposit(double amount)
        {
            makeTransaction("deposit", amount);
        }

        public void withdraw(double amount)
        {
            makeTransaction("withdraw", amount);

        }

        public void printTransactions()
        {
            Console.WriteLine("{0,20} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            foreach (BankTransaction bt in _transactions.OrderByDescending(t => t.Date))
            {

                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                    bt.Date.ToString(),
                    bt.TransactionType == "deposit" ? bt.Amount : 0,
                    bt.TransactionType == "withdraw" ? bt.Amount : 0,
                    bt.NewBalance);
            }
        }

        public void makeTransaction(string type, double amount)
        {
            double oldBalance = 0;
            double newBalance = 0;

            if (_transactions.Any())
            {
                BankTransaction latestTransaction = _transactions.OrderByDescending(t => t.Date).First();
                oldBalance = latestTransaction.OldBalance;
                newBalance = latestTransaction.OldBalance;
            }

            if (type.ToLower() == "deposit")
            {
                newBalance = oldBalance + amount;
                oldBalance = oldBalance;

            }
            else if (type.ToLower() == "withdraw")
            {
                newBalance = oldBalance - amount;
                oldBalance = oldBalance;


            }

            BankTransaction transaction = new BankTransaction(type.ToLower(), amount, newBalance, oldBalance);
            _transactions.Add(transaction);
            
        }

        public double getBalance()
        {
            double balance = 0;

            foreach (BankTransaction transaction in _transactions.OrderBy(t => t.Date))
            {
                switch (transaction.TransactionType.ToLower())
                {
                    case "deposit":
                        balance += transaction.Amount;
                        break;

                    case "withdraw":
                        balance -= transaction.Amount;
                        break;
                }
            }

            return balance;
        }
    }
}
