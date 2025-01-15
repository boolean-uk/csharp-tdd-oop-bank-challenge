using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.AccountTypes
{
    public class SavingAccount : Account
    {
        public SavingAccount(string name, Branch branch) : base(name, branch)
        {
        }
    }
}
