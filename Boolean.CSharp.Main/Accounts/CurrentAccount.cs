using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : Account
    {
        private Enums.AccountBranch _branch { get; }
        public string Name { get; set; }
        public CurrentAccount(string AccountName, Enums.AccountBranch branch)
        {
            Name = AccountName;
            _branch = branch;
        }
    }
}
