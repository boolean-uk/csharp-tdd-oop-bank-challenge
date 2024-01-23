using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Objects
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountName, Branch accountBranch) : base(accountName, accountBranch)
        {
            AccountType = "SavingsAccount";
        }
    }
}
