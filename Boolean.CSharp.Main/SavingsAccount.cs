using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountname, decimal balance) : base(accountname, balance)
        {
        }

        public override AccountType GetAccountType() {
            return AccountType.SAVINGS;
        }
    }
}