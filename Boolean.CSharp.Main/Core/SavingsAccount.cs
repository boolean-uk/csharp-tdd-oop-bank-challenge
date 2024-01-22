using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Core
{
    public class SavingsAccount : AAccount
    {
        
        public SavingsAccount() : base() { }
        public SavingsAccount(Branch branch) : base(branch) { }

    }
}
