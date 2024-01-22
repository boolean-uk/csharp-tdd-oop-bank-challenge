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
        private List<Account> _accounts = [];
        public Customer()
        {
            _id = Guid.NewGuid();
        }
        
        public void CreateSpendingAccount(string name, Branch branch)
        {
           if ( name == "" ) { return; }
          _accounts.Add(new SpendingAccount(branch, name));
            
        }
        public void CreateSavingsAccount(string name, Branch branch)
        {
            if (name == "") { return; }
            _accounts.Add(new SavingsAccount(branch, name));

        }
        public List<Account> GetAccounts()
        {
            return _accounts;
        }
    }
}
