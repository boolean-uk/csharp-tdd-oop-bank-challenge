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

        public User(int iD, string name, string email, string password)
        {
            throw new NotImplementedException();
        }

        public int ID { get => _ID; }
        public string Name { get => _name; }
        public string Email { get => _email; }
        public CurrentAccount Account { get => _account; }
        public SavingsAccount SavingsAccount { get => _savingsAccount; }
        public List<Account> Accounts { get => _accounts; }

    }
}