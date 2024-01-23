using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class AccountSavings : Account
    {
        public AccountSavings(ICustomer customer, Branch branch) : base(customer, branch)
        {
        }
    }
}
