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
        public List<Account> accounts = new List<Account>();

        public Branch(string name) 
        {   
            this.Name = name;
        }

        public void AddAccount(Account account) 
        {
            Console.WriteLine($"Account added to branch: {this.Name}");
            accounts.Add(account);
        }

        public List<Account> getAllAccountsFromBranch()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Branch: {account.branch.Name} | Balance: {account.getBalance()}");
            }

            return accounts;
        }
    }
}
