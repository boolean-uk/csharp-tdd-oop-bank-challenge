using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.User;
using Boolean.CSharp.Main.Interfaces;
using System.Transactions;


namespace Boolean.CSharp.Main
{
    public class Bank
    {

        List<Transaction> transactions = new List<Transaction>();
        
        public Bank() { }

        public Transaction Deposit(int sum, IAccount account)
        {
            DateTime transactionTime = DateTime.Now;
            int oldBalance = account.Balance;
            int newBalance = oldBalance + sum;

            account.Balance = newBalance;
            Transaction newDeposit = new Transaction(transactionTime, "Credit", sum, "Approved", newBalance);
            return newDeposit;
        }

        public Transaction Withdraw(int sum, IAccount account)
        {
            DateTime transactionTime = DateTime.Now;
            int oldBalance = account.Balance;
            int newBalance = oldBalance - sum;

            account.Balance = newBalance;
            Transaction newDeposit = new Transaction(transactionTime, "Debit", sum, "Approved", newBalance);
            return newDeposit;
        }

        public void WriteStatement(List<Transaction> transactions)
        {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            foreach (Transaction transaction in transactions.OrderByDescending(t => t.Date).Where(t => t.Status == "Approved"))
            {

                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                        transaction.Date.ToShortDateString(),
                        transaction.Type == "Credit" ? transaction.Amount : 0,
                        transaction.Type == "Debit" ? transaction.Amount : 0,
                        transaction.NewBalance);
            };
        }
    }
}
