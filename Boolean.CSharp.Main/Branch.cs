using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Branch
    {
        private string name;
        private string address;
        private List<Account> accounts;
        public Branch(string name, string address)
        {
            this.name = name;
            this.address = address;
            this.accounts = new List<Account>();
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getAddress()
        {
            return address;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }

        public List<Account> getAccounts()
        {
            return accounts;
        }

        public void setAccounts(List<Account> accounts)
        {
            this.accounts = accounts;
        }

        public void addAccount(Account account)
        {
            accounts.Add(account);
        }

    }
}
