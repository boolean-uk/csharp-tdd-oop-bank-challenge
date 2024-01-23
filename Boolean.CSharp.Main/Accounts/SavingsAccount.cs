using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : Account
    {
        public string Name { get; set; }
        private Enums.AccountBranch _branch { get; }
        public SavingsAccount(string AccountName, Enums.AccountBranch branch)
        {
            Name = AccountName;
            _branch = branch;
        }
    }
}

