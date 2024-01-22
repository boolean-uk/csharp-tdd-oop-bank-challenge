using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountName) : base(accountName)
        {
            base.AccountType = "SavingsAccount";
        }
    }
}
