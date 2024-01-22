using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountname, decimal balance, Branch associatedBranch) : base(accountname, balance, associatedBranch)
        {
        }

        public override AccountType GetAccountType() {
            return AccountType.SAVINGS;
        }
    }
}