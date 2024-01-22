using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(string accountname, decimal balance) : base(accountname, balance)
        {
        }

        public override AccountType GetAccountType()
        {
            throw new NotImplementedException();
        }
    }
}