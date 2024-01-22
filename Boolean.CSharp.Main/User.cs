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
        private List<Account> _accounts;

        public User(int ID, string name, string email, string password)
        {
            _ID = ID;
            _name = name;
            _email = email;
            _password = password;
            _account = new CurrentAccount(this);
            _savingsAccount = new SavingsAccount(this);
            _accounts = new List<Account>()
            {
                _account, _savingsAccount
            };
        }

        public int ID { get => _ID; }
        public string Name { get => _name; }
        public string Email { get => _email; }
        public CurrentAccount Account { get => _account; }
        public SavingsAccount SavingsAccount { get => _savingsAccount; }
        public List<Account> Accounts { get => _accounts; }

        public void Deposit(double balance, AccountType account)
        {
            if (account == AccountType.CurrentAccount)
            {
                _account.Deposit(balance);
            }
            else if (account == AccountType.SavingsAccount)
            {
                _savingsAccount.Deposit(balance);
            }
        }

        public bool Withdraw(double balance, AccountType account)
        {
            if(account == AccountType.CurrentAccount)
            {
                return _account.Withdraw(balance);
            }
            else if (account == AccountType.SavingsAccount)
            {
                return _savingsAccount.Withdraw(balance);
            }

            return false;
        }

    }
}