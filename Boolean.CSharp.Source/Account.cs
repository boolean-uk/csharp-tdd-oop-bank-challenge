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
        public string brancheName { get; set; }
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
            transaction.newBalance = GetBalance() + deposit;
            transactions.Add (transaction);
        }

        public void WithdrawMoney(decimal withdraw)
        {
            Transaction transaction = new Transaction();
            transaction.date = DateTime.Now;
            transaction.credit = withdraw;
            transaction.newBalance = GetBalance() - withdraw;
            transactions.Add(transaction);
        }
        public void BankStatement()
        {
           
             Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            foreach (Transaction transaction in transactions.OrderByDescending(t => t.date)) 
            {
                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                            transaction.date.ToShortDateString(),
                            transaction.credit == 0 ? "":transaction.credit,
                            transaction.debit == 0 ? "" : transaction.debit,
                            transaction.newBalance);
              
            }
            ;
        }
        
    }
}
