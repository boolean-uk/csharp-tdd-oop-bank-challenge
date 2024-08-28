using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(Branch branch) : base(branch) { }

        public override AccountType AccountType { get; } = AccountType.Savings;

    }
}
