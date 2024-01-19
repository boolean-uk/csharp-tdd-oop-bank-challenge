using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private List<IAccount> _accounts;
        public List<IAccount> Accounts => _accounts;
        public Customer()
        {
            _accounts = new List<IAccount>();
        }

        public void AddAccount(IAccount account)
        {
            _accounts.Add(account);
        }
    }
}
