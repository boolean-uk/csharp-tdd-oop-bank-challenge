using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes.Accounts
{
    public class CurrentAccount : ABankAccount
    {
        public CurrentAccount(eBranch e = eBranch.Central) : base(e) { }
    }
}
