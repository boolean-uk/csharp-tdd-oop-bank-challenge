using Boolean.CSharp.Main.Classes;
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
        private ICustomer _customer;

        public AccountSavings(ICustomer customer)
        {
            this._customer = customer;
        }
    }
}
