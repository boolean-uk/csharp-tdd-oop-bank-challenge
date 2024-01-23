using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;

namespace Boolean.CSharp.Main
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BankLocation Location { get; set; }
        public double OverdraftAmount { get; set; }
        public IAccount Account { get; set; }
        public IAccount SavingsAccount { get; set; }

        public User(int id, string name, BankLocation location)
        {
            Id = id;
            Name = name;
            Location = location;
            OverdraftAmount = 0;
            Account = new CurrentAccount(this);
            SavingsAccount = new SavingsAccount(this);
        }

        public void Deposit(double balance, IAccount account)
        {
            account.Deposit(balance);
        }

        public bool Withdraw(double balance, IAccount account)
        {
            return account.Withdraw(balance, OverdraftAmount);
        }

        public double GetBalance(IAccount account)
        {
            return account.GetBalance();
        }

        public void GenerateBankStatement(IAccount account)
        {
            Console.WriteLine("{0,10} || {1, 11} || {2,11} || {3,11} ", "Date", "Deposit", "Withdraw", "Balance");
            foreach (Transaction transaction in account.Transactions.OrderByDescending(t => t.Time))
            {
                Console.WriteLine("{0,10} || £{1,10} || £{2,10} || £{3, 10}", 
                    transaction.Time.Date.ToShortDateString(), 
                    transaction.Type == TransactionType.Deposit ? Math.Round(transaction.Amount, 2) : 0,
                    transaction.Type == TransactionType.Withdrawal ? Math.Round(transaction.Amount, 2) : 0,
                    Math.Round(transaction.NewBalance, 2));
            }
        }
    }
}