using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main.BankAndAccounts
{
    public class Current : Account
    {
        public Current(ICustomer owner, IBranch branch) : base(owner, branch, true) { }
    }
}
