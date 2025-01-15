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
        public string branchName { get; set; }
        public List<Account> accounts = new List<Account>();

        public Branch(string name) 
        {   
            this.branchName = name;
        }

        public void AddAccount(Account account) 
        {
            Console.WriteLine($"Account added to branch: {this.branchName}");
            accounts.Add(account);
        }

        public List<Account> getAllAccountsFromBranch()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Branch: {account.branch.branchName} | Balance: {account.getBalance()}");
            }

            return accounts;
        }
    }
}
