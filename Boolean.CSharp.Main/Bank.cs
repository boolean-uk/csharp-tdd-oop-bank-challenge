using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Bank
    {
        private string _name;

        private List<Account> _accounts;

        public Bank(string name)
        {
            this._name = name;
            //this._accounts = accounts;
        }

        public void CreateCurrentAccount(Customer customer, Branch branch, string accountnr, string type)
        {
            
        }

        public string Name { get => _name; set => _name = value; }
        public List<Account> Accounts { get => _accounts; set => _accounts = value; }
    }
}
