using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main.Accounts
{
    public class SavingAccount : Account, IAccount
    {
        public SavingAccount() : base() { }

        public bool isSavingAccount => true;
    }
}
