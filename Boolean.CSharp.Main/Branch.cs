using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Branch
    {
        public string Name { get; set; }
        List<Account> accounts = new List<Account>();

        public Branch(string name) 
        {   
            this.Name = name;
        }

        public List<Account> getAllAccountsFromBranch()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Branch: {account.branch} | {}");
            }

            return accounts;
        }
    }
}
