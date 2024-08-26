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

        public CurrentAccount(Branch branch) : base(branch) {
        }

        public override AccountType AccountType { get; } = AccountType.Current;

    }
}

