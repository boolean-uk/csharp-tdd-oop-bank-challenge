using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAcc : IAccount
    {
        public AccountType accountType { get; set; }

        public CurrentAcc(AccountType accountType)
        {
            this.accountType = accountType;
        }
    }
}
