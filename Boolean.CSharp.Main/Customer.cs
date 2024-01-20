using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private string _ID;
        private List<IAccount> _accounts = new List<IAccount>();

        public Customer()
        {
            _ID = Guid.NewGuid().ToString();

        }

        public IAccount addAccount(AccountType type, string branch)
        {
            IAccount account = Account.createAccount(type, branch);
            _accounts.Add(account);
            return account;
        }

        public List<IAccount> ListAccounts()
        {
            return _accounts;
        }

    }
}
