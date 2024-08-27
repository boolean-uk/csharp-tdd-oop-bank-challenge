using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank.AccountTypes
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountType) 
        {
            AccountType = accountType;
        }
    }
}
