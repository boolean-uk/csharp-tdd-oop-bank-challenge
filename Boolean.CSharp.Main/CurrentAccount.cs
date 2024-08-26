using Boolean.CSharp.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(Branch branch) : base(branch) { }
        public override AccountType AccountType { get; } = AccountType.Current;
        public override bool OverdraftActive { get; set; } = false;
        public override decimal BalanceCapacity { get; set; } = 0m;

    }
}

