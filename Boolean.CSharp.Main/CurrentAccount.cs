using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {

        public CurrentAccount(int customerId, BranchLocation branch) : base(customerId, branch)
        {
            
        }

    }
}
