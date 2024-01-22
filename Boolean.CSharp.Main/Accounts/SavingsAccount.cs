using Boolean.CSharp.Main.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(IBranch branch, string name) : base(branch, name)
        {
        }
    }
}
