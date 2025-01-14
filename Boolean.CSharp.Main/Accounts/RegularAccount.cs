using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Accounts
{
    public class RegularAccount : Account
    {
        public RegularAccount(string name, Branch branch = Branch.Trondheim) : base(name, branch) { }

        public override AccountTransaction Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override AccountTransaction Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
