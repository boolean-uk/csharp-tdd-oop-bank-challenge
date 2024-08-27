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
        }

        public Account CreateCurrentAccount(Customer customer, Branch branch, string accountnr, string type)
        {
            Account current = new Current(customer, branch, accountnr, type, 0.0);
            _accounts.Add(current);
            return current;
        }

        public Account CreateSavingsAccount(Customer customer, Branch branch, string accountnr, string type)
        {
            Account savings = new Savings(customer, branch, accountnr, type, 0.0);
            _accounts.Add(savings);
            return savings;
        }

        public string Name { get => _name; set => _name = value; }
        public List<Account> Accounts { get => _accounts; set => _accounts = value; }

        public Account GetAccount(string accountnr)
        {
            var matches = _accounts.FirstOrDefault(x => x.AccountNr == accountnr);
            return matches;
        } 
    }
}
