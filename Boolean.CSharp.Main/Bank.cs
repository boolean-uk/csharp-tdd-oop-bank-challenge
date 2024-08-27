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

        private List<Account> _accounts = new List<Account>();

        public Bank(string name)
        {
            this._name = name;
            //this._accounts = accounts;
        }

        public void CreateCurrentAccount(Customer customer, Branch branch, string accountnr, string type)
        {
            Account current = new Current(customer, branch, accountnr, type, 0.0);
            _accounts.Add(current);
        }

        public string Name { get => _name; set => _name = value; }
        public List<Account> Accounts { get => _accounts; set => _accounts = value; }

        public Account GetAccount(string accountnr)
        {
            var matches = _accounts.Where(x => x.AccountNr == accountnr).ToList(); ;
            return matches[0];
        } 
    }
}
