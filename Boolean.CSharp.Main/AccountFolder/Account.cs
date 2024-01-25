using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boolean.CSharp.Main.AccountFolder.Enums;

namespace Boolean.CSharp.Main.AccountFolder
{
    public abstract class Account
    {
        
        private List<Transactions> _transactions = new List<Transactions>();

        public void Deposit(Transactions transaction)
        {
            if (transaction.Type == TransactionTypes.Credit)
            {
                if(_transactions.Count > 0)
                {
                    transaction.Balance = _transactions.Last().Balance + transaction.Amount;
                    _transactions.Add(transaction);
                }
                else
                {
                    transaction.Balance = transaction.Amount;
                    _transactions.Add(transaction);
                }
            }
        }

        public void Withdraw(Transactions transaction)
        { 
            if(transaction.Type == TransactionTypes.Debit) 
            {
                if (transaction.Amount <= GetBalance())
                {
                    if (_transactions.Count > 0)
                    {
                        transaction.Balance = _transactions.Last().Balance - transaction.Amount;
                        _transactions.Add(transaction);
                    }
                   
                }
            }
        }

        public void printStatement()
        {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            foreach (Transactions transaction in _transactions.OrderByDescending(t => t.TransactionDate))
            {

                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                        transaction.TransactionDate.ToShortDateString(),
                        transaction.Type == TransactionTypes.Credit ? transaction.Amount : 0,
                        transaction.Type == TransactionTypes.Debit ? transaction.Amount : 0,
                        transaction.Balance);
            };
        }

        public decimal GetBalance()
        {
            if(_transactions.Count == 0)
            {
                return 0;
            }
            return _transactions.Last().Balance;
        }
    }
}
