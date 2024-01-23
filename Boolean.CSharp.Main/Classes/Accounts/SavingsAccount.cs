using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes.Accounts
{
    public class SavingsAccount : ABankAccount
    {
        public SavingsAccount(eBranch e = eBranch.Central) : base(e) { }
    }
}
