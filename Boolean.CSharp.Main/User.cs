using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class User
    {
        private string _ID;
        private List<IAccount> _accounts = new List<IAccount>();

        public User()
        {
            _ID = Guid.NewGuid().ToString();

        }

        public IAccount createAccount(IAccount account)
        {
            _accounts.Add(account);
            return account;
        }

        public List<IAccount> ListAccounts()
        {
            return _accounts;
        }

    }
}
