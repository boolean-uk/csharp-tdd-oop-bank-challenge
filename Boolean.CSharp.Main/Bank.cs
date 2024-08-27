using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        List<Account> accounts = new List<Account>();
        List<string> branches = new List<string>();

        public Bank(List<Account> accounts)
        {
            this.accounts = accounts;
        }

        public void CreateAccount(Customer customer, string accountnr, string type, string branch)
        {

        }
    }
}
