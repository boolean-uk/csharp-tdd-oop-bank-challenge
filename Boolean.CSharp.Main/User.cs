using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class User
    {
        private int _ID;
        private string _name;
        private string _email;
        private string _password;
        private BankLocation _location;
        private CurrentAccount _account;
        private SavingsAccount _savingsAccount;

        public User(int ID, string name, string email, string password, BankLocation location)
        {
            _ID = ID;
            _name = name;
            _email = email;
            _password = password;
            _location = location;
            _account = new CurrentAccount(this);
            _savingsAccount = new SavingsAccount(this);
        }

        public int ID { get => _ID; }
        public string Name { get => _name; }
        public string Email { get => _email; }
        public BankLocation Location { get => _location; set => _location = value; }
        public CurrentAccount Account { get => _account; }
        public SavingsAccount SavingsAccount { get => _savingsAccount; }

        public void Deposit(double balance, IAccount account)
        {
            account.Deposit(balance);
        }

        public bool Withdraw(double balance, IAccount account)
        {
            return account.Withdraw(balance);
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