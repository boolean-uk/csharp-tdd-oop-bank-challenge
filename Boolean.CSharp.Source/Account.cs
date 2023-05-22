using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace Boolean.CSharp.Source
{
    public abstract class Account
    {
        public List<Transaction> transactions = new List<Transaction> ();
        public Customer customer { get; set; }
        //public decimal balance;

        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (Transaction t in transactions)
            {
                balance -= t.credit;
                balance += t.debit;
            }
            return balance;
        }
        public void DepositMoney(decimal deposit)
        {
            Transaction transaction = new Transaction ();
            transaction.date = DateTime.Now;
            transaction.debit = deposit;
            //balance= balance + deposit;
            //transaction.newBalance = balance;
            transactions.Add (transaction);
            //return balance;
        }

        public void WithdrawMoney(decimal withdraw)
        {
            Transaction transaction = new Transaction();
            transaction.date = DateTime.Now;
            transaction.credit = withdraw;
            //balance = balance - withdraw;
            //transaction.newBalance = balance;
            transactions.Add(transaction);
            //return balance;
        }
        public void BankStatement()
        {
           
             Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            foreach (Transaction transaction in transactions.OrderByDescending(t => t.date)) 
            {
                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                            transaction.date.ToShortDateString(),
                            transaction.credit,
                            transaction.debit,
                            transaction.newBalance);
              
            }
            ;
        }
        
    }
}
