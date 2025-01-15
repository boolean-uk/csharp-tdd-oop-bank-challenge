using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    
    public class Bank
    {
        public List<Account> bankAccounts = new List<Account>();
        public Bank() { }

        public void AddCurrentAccount(string name, Branch branch)
        { bankAccounts.Add(new CurrentAccount(name, branch)); }

        public void AddSavingsAccount(string name, Branch branch)
        {
            bankAccounts.Add(new SavingsAccount(name, branch));
        }
    }
}
