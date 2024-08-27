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

        List<Account> accounts = new List<Account>();

        public Bank(List<Account> accounts, string name)
        {
            this._name = name;
            this.accounts = accounts;
        }

        public void CreateCurrentAccount(Customer customer, string accountnr, string type, string branch)
        {

        }

        public string Name { get => _name; set => _name = value; }
    }
}
