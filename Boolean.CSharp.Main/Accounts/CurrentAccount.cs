using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : Account
    {
        private Customer _customer;

        public CurrentAccount(Customer customer)
        {
            this._customer = customer;
        }

        public Customer Customer => _customer;
    }
}
