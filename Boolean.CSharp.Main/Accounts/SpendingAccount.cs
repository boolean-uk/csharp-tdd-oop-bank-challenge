using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SpendingAccount : Account
    {
        public SpendingAccount(Branch branch, string name) : base(branch, name)
        {
        }
    }
}
