using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boolean.CSharp.Main.Customer
{
    public class Customer
    {
        private Guid _id;
        private List<Account> _accounts = [];
        private string _name;
        private Branch _branch;
        public Branch Branch { get { return _branch; } }
        public Customer(string name, Branch branch)
        {
            _id = Guid.NewGuid();
            _name = name;
            _branch = branch;
        }
        
        public void CreateSpendingAccount(string name, Branch branch)
        {
           if ( name == "" ) { return; }
          _accounts.Add(new SpendingAccount(branch,name));
            
        }
        public void CreateSavingsAccount(string name, Branch branch)
        {
            if (name == "") { return; }
            _accounts.Add(new SavingsAccount(branch,name));

        }
        public List<Account> GetAccounts()
        {
            return _accounts;
        }
        
    }
}
