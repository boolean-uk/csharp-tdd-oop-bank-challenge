using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class User
    {
        private int _Id;
        private string _name;
        private double _overdraftAmount;
        private BankLocation _location;
        private IAccount _account;
        private IAccount _savingsAccount;

        public User(int Id, string name, BankLocation location)
        {
            _Id = Id;
            _name = name;
            _location = location;
            _overdraftAmount = 0;
            _account = new CurrentAccount(this);
            _savingsAccount = new SavingsAccount(this);
        }

        public int Id { get => _Id; }
        public string Name { get => _name; }
        public BankLocation Location { get => _location; set => _location = value; }
        public double OverdraftAmount { get => _overdraftAmount; set => _overdraftAmount = value; }
        public IAccount Account { get => _account; }
        public IAccount SavingsAccount { get => _savingsAccount; }

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