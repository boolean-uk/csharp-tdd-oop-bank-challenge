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
        private CurrentAccount _account;
        private SavingsAccount _savingsAccount;

        public User(int ID, string name, string email, string password)
        {
            _ID = ID;
            _name = name;
            _email = email;
            _password = password;
            _account = new CurrentAccount(this);
            _savingsAccount = new SavingsAccount(this);
        }

        public int ID { get => _ID; }
        public string Name { get => _name; }
        public string Email { get => _email; }
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

        public void GenerateBankStatement(IAccount account)
        {
            throw new NotImplementedException();
        }
    }
}