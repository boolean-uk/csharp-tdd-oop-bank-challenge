using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class User
    {
        public List<IAccount> Accounts;
        public bool Admin { get; set; }

        public string Name;

        public User(string name) 
        { 
            Accounts = new List<IAccount>();
            Admin = false;
            this.Name = name;

        }

        public void CreateAccount(string user, string branch, string name)
        {
            Account account = new Account(user, branch, name);
            Accounts.Add(account);
        }
        public void CreateSavingAccount(string user, string branch, string name)
        {
            SavingAccount account = new SavingAccount(user, branch, name);
            Accounts.Add(account);
        }
    }
}
