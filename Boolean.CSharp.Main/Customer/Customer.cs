using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Customer
{
    public class Customer
    {
        private Guid _id;
        private List<IAccount> _accounts = [];
        public Customer()
        {
            _id = Guid.NewGuid();
        }
        
        public void CreateAccount(string name, AccountType accountType, Branch branch)
        {
           if ( name == "" ) { return; }
          _accounts.Add(new Account(accountType, branch, name));
            
        }
        public List<IAccount> GetAccounts()
        {
            return _accounts;
        }
    }
}
