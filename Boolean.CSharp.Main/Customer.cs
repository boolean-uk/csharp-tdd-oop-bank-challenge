using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        List<Account> Accounts { get; }

        public void CreateSavingsAccount() { }

        public void CreateCurrentAccount() { }

        public string DepositToAccount() { return "";  }

        public string WithdrawFromAccount() { return ""; }
    }
}
